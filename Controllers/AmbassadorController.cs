using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            Address = up.Address,
            IsActive = up.IsActive,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetAmbassadorById(int id)
    {
        UserProfile foundAmbassador = _dbContext
        .UserProfiles
        .Include(up => up.Purchases)
        .ThenInclude(p => p.PurchaseProducts)
        .ThenInclude(pp => pp.Product)
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
    [HttpPut("{id}/updateStatus")]
    [Authorize]
    public IActionResult ToggleActivationAmbassador(int id)
    {
        UserProfile foundUser = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == id);


        if (foundUser.IsActive)
        {
            foundUser.IsActive = false;
        }
        else
        {
            foundUser.IsActive = true;
        }
        _dbContext.SaveChanges();
        return Ok(foundUser);
    }


    [HttpPut("{id}/edit")]
    [Authorize]
    public IActionResult EditAmbassador(int id, UserProfile userProfile)
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

    [HttpDelete("{id}/delete")]
    [Authorize]
    public IActionResult DeleteAmbassador(int id)
    {
        var foundAmbassador = _dbContext.UserProfiles.FirstOrDefault(up => up.Id == id);
        _dbContext.UserProfiles.Remove(foundAmbassador);
        _dbContext.SaveChanges();

        return NoContent();
    }
}