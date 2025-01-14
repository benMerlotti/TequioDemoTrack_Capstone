using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequioDemoTrack.Data;
using TequioDemoTrack.Models;
using TequioDemoTrack.Models.DTOs;

[ApiController]
[Route("api/[controller]")]

public class EmployeeController : ControllerBase
{
    private TequioDemoTrackDbContext _dbContext;

    public EmployeeController(TequioDemoTrackDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Employees
        .ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetCustomerById(int id)
    {
        Employee foundEmployee = _dbContext
        .Employees
        .Include(e => e.Purchases)
        .ThenInclude(p => p.PurchaseProducts)
        .FirstOrDefault(e => e.Id == id);
        return Ok(foundEmployee);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateEmployee(IMapper mapper, CreateEmployeeDTO employee)
    {
        var newEmployee = mapper.Map<Employee>(employee);
        _dbContext.Employees.Add(newEmployee);
        _dbContext.SaveChanges();

        return Created($"/api/Employee/{newEmployee.Id}", newEmployee);
    }

    [HttpDelete("{id}/delete")]
    [Authorize]
    public IActionResult DeleteEmployee(int id)
    {
        var foundEmployee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
        _dbContext.Employees.Remove(foundEmployee);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}/edit")]
    [Authorize]
    public IActionResult EditCustomer(int id, CreateEmployeeDTO employee)
    {
        var foundEmployee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);

        foundEmployee.Name = employee.Name;
        foundEmployee.Email = employee.Email;
        foundEmployee.Address = employee.Address;

        _dbContext.SaveChanges();

        return NoContent();
    }
}