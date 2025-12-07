using AssetLunarBase.Data;
using Microsoft.AspNetCore.Mvc;

namespace AssetLunarBase.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AssetController : ControllerBase
{
    private readonly AssetDbContext _context;
    public AssetController(AssetDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var assets = _context.Assets.ToList();
        return Ok(assets);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var asset = _context.Assets.Find(id);

        if (asset == null)
        {
            return NotFound();
        }
        return Ok(asset);
    }
}