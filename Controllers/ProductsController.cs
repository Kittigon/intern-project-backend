using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly AppDbContext db;
    public ProductsController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetProduct()
    {
        var products = db.Products.ToList();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductDto dto)
    {
        var product = new ProductModel
        {
            Name = dto.Name,
            Price = dto.Price,
            IsAvailable = dto.IsAvailable,
            CreatedAt = DateTime.Now
        };

        db.Products.Add(product);
        db.SaveChanges();

        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDto dto)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound(new { message = "Product Not Found" });
        }

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.IsAvailable = dto.IsAvailable;

        db.SaveChanges();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        db.Products.Remove(product);
        db.SaveChanges();

        return Ok(new { message = "Deleted" });
    }
}