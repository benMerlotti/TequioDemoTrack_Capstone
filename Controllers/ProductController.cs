using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TequioDemoTrack.Data;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private TequioDemoTrackDbContext _dbContext;

    public ProductController(TequioDemoTrackDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
        .Products
        .ToList());
    }
}