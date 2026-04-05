using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.DTOs;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext db;

    public OrdersController(AppDbContext context)
    {
        db = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = db.Orders.ToList();
        return Ok(orders);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDto dto)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == dto.ProductId);

        if (product == null)
            return BadRequest(new { message = "Product not found" });

        var order = new OrderModel
        {
            UserId = dto.UserId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            CreatedAt = DateTime.Now
        };

        db.Orders.Add(order);
        db.SaveChanges();

        return Ok(order);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = db.Orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        db.Orders.Remove(order);
        db.SaveChanges();

        return Ok(new { message = "Order deleted" });
    }
}