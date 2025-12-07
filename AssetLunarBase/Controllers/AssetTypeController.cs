using AssetLunarBase.Data;
using AssetLunarBase.DTOS.Stock;
using AssetLunarBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetLunarBase.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AssetTypeController : ControllerBase
{
    private readonly AssetDbContext _context;
    public AssetTypeController(AssetDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var assetTypes =  _context.AssetTypes
            .Select(l => AssetTypeMapper.AssetTypeMapToDefaultDTO(l)
            ).ToList();
        
        return Ok(assetTypes);
    }
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var assetType = _context.AssetTypes.
            Where(at => at.Id == id).
            Select(l => AssetTypeMapper.AssetTypeMapToDefaultDTO(l));

        if (assetType == null)
        {
            return NotFound();
        }
        return Ok(assetType);
    }
}