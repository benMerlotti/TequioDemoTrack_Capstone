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

    [HttpGet("{id}")]
    public IActionResult GetPurchasesById(int id)
    {
        var purchase = _dbContext.Purchases
            .Include(p => p.Customer)
            .Include(p => p.Employee)
            .Include(p => p.PurchaseProducts)
            .ThenInclude(pp => pp.Product).FirstOrDefault(p => p.Id == id);

        return Ok(purchase);
    }


    [HttpPost]
    public IActionResult CreatePurchase([FromBody] CreatePurchaseDTO model)
    {
        // Validate input
        if (model == null || model.PurchaseProducts == null || model.PurchaseProducts.Count == 0)
        {
            return BadRequest("Invalid data.");
        }

        // Check if Customer exists
        var customerExists = _dbContext.Customers.Any(c => c.Id == model.CustomerId);
        if (!customerExists)
        {
            return NotFound($"Customer with ID {model.CustomerId} not found.");
        }

        // Check if Employee exists
        var employeeExists = _dbContext.Employees.Any(e => e.Id == model.EmployeeId);
        if (!employeeExists)
        {
            return NotFound($"Employee with ID {model.EmployeeId} not found.");
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

    [HttpPut("{id}/edit")]
    public IActionResult EditPurchase(IMapper _mapper, int id, [FromBody] List<UpdatePurchaseProductDTO> purchaseProducts)
    {
        Purchase foundPurchase = _dbContext.Purchases
       .Include(p => p.PurchaseProducts)
       .FirstOrDefault(p => p.Id == id);

        if (foundPurchase == null)
        {
            return NotFound($"Purchase with ID {id} not found.");
        }

        // Remove existing products
        _dbContext.PurchaseProducts.RemoveRange(foundPurchase.PurchaseProducts);

        // Map DTOs to PurchaseProduct entities and set PurchaseId
        var newProducts = _mapper.Map<List<PurchaseProduct>>(purchaseProducts);
        newProducts.ForEach(product => product.PurchaseId = id);

        // Add new products to the purchase
        foundPurchase.PurchaseProducts = newProducts;

        // Save changes to the database
        _dbContext.SaveChanges();

        return Ok("Purchase updated successfully.");
    }

}
