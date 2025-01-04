using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequioDemoTrack.Data;
using TequioDemoTrack.Models;
using TequioDemoTrack.Models.DTOs;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private TequioDemoTrackDbContext _dbContext;

    public CustomerController(TequioDemoTrackDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Customers
        .Include(c => c.Purchases)
        .ToList());
    }
    [HttpPost]
    // [Authorize]
    public IActionResult CreateCustomer(IMapper mapper, CreateCustomerDTO customer)
    {
        var newCustomer = mapper.Map<Customer>(customer);
        _dbContext.Customers.Add(newCustomer);
        _dbContext.SaveChanges();

        return Created($"/api/Purchase/{newCustomer.Id}", newCustomer);
    }

    [HttpDelete("{id}/delete")]
    // [Authorize]
    public IActionResult DeleteCustomer(int id)
    {
        var foundCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        _dbContext.Customers.Remove(foundCustomer);
        _dbContext.SaveChanges();

        return NoContent();
    }
}