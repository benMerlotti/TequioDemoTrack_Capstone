using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TequioDemoTrack.Data;
using TequioDemoTrack.Models;
using TequioDemoTrack.Models.DTOs;

[ApiController]
[Route("api/[controller]")]

public class AmbassadorController : ControllerBase
{
    private TequioDemoTrackDbContext _dbContext;

    public AmbassadorController(TequioDemoTrackDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .UserProfiles
        .Include(up => up.IdentityUser)
        .ToList());
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetAmbassadorById(int id)
    {
        UserProfile foundAmbassador = _dbContext
        .UserProfiles
        .Include(up => up.Purchases)
        .ThenInclude(p => p.PurchaseProducts)
        .FirstOrDefault(up => up.Id == id);
        return Ok(foundAmbassador);
    }

    // [HttpPost]
    // [Authorize]
    // public IActionResult CreateAmbassador(IMapper mapper, CreateUserProfileDTO employee)
    // {
    //     var newEmployee = mapper.Map<Employee>(employee);
    //     _dbContext.Employees.Add(newEmployee);
    //     _dbContext.SaveChanges();

    //     return Created($"/api/Employee/{newEmployee.Id}", newEmployee);
    // }

    [HttpDelete("{id}/delete")]
    [Authorize]
    public IActionResult DeleteAmbassador(int id)
    {
        var foundAmbassador = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == id);
        _dbContext.UserProfiles.Remove(foundAmbassador);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}/edit")]
    [Authorize]
    public IActionResult EditCustomer(int id, UserProfile userProfile)
    {
        var foundAmbassador = _dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .FirstOrDefault(up => up.Id == id);

        foundAmbassador.FirstName = userProfile.FirstName;
        foundAmbassador.LastName = userProfile.LastName;
        foundAmbassador.IdentityUser.Email = userProfile.IdentityUser.Email;
        foundAmbassador.Address = userProfile.Address;

        _dbContext.SaveChanges();

        return NoContent();
    }
}