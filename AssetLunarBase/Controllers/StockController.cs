using AssetLunarBase.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssetLunarBase.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly AssetDbContext _context;
    public StockController(AssetDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var stocks = _context.Stocks.ToList();
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var stock = _context.Stocks.Find(id);

        if (stock == null)
        {
            return NotFound();
        }
        return Ok(stock);
    }
}