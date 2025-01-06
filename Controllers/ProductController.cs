using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TequioDemoTrack.Data;
using TequioDemoTrack.Models;
using TequioDemoTrack.Models.DTOs;

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

    [HttpPost]
    // [Authorize]
    public IActionResult CreateProduct(IMapper mapper, CreateProductDTO product)
    {
        var newProduct = mapper.Map<Product>(product);
        _dbContext.Products.Add(newProduct);
        _dbContext.SaveChanges();

        return Created($"/api/Product/{newProduct.Id}", newProduct);
    }

    [HttpDelete("{id}/delete")]
    // [Authorize]
    public IActionResult DeleteProduct(int id)
    {
        var foundProduct = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        _dbContext.Products.Remove(foundProduct);
        _dbContext.SaveChanges();

        return NoContent();
    }
}