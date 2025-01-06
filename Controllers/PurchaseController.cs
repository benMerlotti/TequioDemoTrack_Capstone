using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequioDemoTrack.Data;
using TequioDemoTrack.Models;
using TequioDemoTrack.Models.DTOs;

[ApiController]
[Route("api/[controller]")]

public class PurchaseController : ControllerBase
{
    private TequioDemoTrackDbContext _dbContext;

    public PurchaseController(TequioDemoTrackDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult GetPurchases()
    {
        var purchases = _dbContext.Purchases
            .Include(p => p.Customer)
            .Include(p => p.Employee)
            .Include(p => p.PurchaseProducts)
            .ThenInclude(pp => pp.Product)
            .ToList();

        return Ok(purchases);
    }


    [HttpPost]
    public IActionResult CreatePurchase([FromBody] CreatePurchaseDTO model)
    {
        // Validate input
        if (model == null || model.PurchaseProducts == null || model.PurchaseProducts.Count == 0)
        {
            return BadRequest("Invalid data.");
        }

        // Create a new Purchase object
        var purchase = new Purchase
        {
            CustomerId = model.CustomerId,
            EmployeeId = model.EmployeeId,
            PurchaseDate = DateTime.UtcNow
        };

        // Add PurchaseProducts to the Purchase
        foreach (var purchaseProductDto in model.PurchaseProducts)
        {
            var product = _dbContext.Products.Find(purchaseProductDto.ProductId);
            if (product == null)
            {
                return NotFound($"Product with ID {purchaseProductDto.ProductId} not found.");
            }

            var purchaseProduct = new PurchaseProduct
            {
                ProductId = purchaseProductDto.ProductId,
                Quantity = purchaseProductDto.Quantity
            };

            purchase.PurchaseProducts.Add(purchaseProduct);
        }

        // Save the Purchase and PurchaseProducts
        _dbContext.Purchases.Add(purchase);
        _dbContext.SaveChanges();

        // Return a response indicating the success of the operation
        return Created($"/api/Purchase/{purchase.Id}", purchase);
    }



}