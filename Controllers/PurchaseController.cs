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
    // [Authorize]
    public IActionResult GetPurchases()
    {
        return Ok(_dbContext
        .CustomerProductEmployees
        .Include(p => p.Customer)
        .Include(p => p.Employee)
        .Include(p => p.Product)
        .ToList());
    }

    [HttpPost]
    // [Authorize]
    public IActionResult CreatePurchase(IMapper mapper, PurchaseDTO purchase)
    {
        var newPurchase = mapper.Map<CustomerProductEmployee>(purchase);
        _dbContext.CustomerProductEmployees.Add(newPurchase);
        _dbContext.SaveChanges();

        return Created($"/api/Purchase/{newPurchase.Id}", newPurchase);
    }
}