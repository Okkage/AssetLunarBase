using AssetLunarBase.Data;
using AssetLunarBase.DTOS.AssetType;
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

    #region Getters
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
    #endregion
    
    #region Posters
    [HttpPost]
    public IActionResult Create([FromBody] AssetTypeDefaultDTO assetTypeDto)
    {
        var assetType = AssetTypeMapper.AssetTypeMapFromDefaultDTOToAssetType(assetTypeDto);
        _context.AssetTypes.Add(assetType);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = assetType.Id }, assetType);
    }
    #endregion

    #region Putters
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] AssetTypeDefaultDTO assetTypeDto)
    {
        var matchedAssetType = _context.AssetTypes.FirstOrDefault(at => at.Id == id);

        if (matchedAssetType == null)
        {
            return NotFound();
        }
        
        matchedAssetType.Name = assetTypeDto.Name;
        matchedAssetType.Code = assetTypeDto.Code;
        matchedAssetType.CanHaveDividends = assetTypeDto.CanHaveDividends;
        matchedAssetType.DefaultCurrency = assetTypeDto.DefaultCurrency;

        _context.SaveChanges();

        return Ok(AssetTypeMapper.AssetTypeMapToDefaultDTO(matchedAssetType));
    }

    #endregion
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var assetTypeToRemove = _context.AssetTypes.FirstOrDefault(at => at.Id == id);

        if (assetTypeToRemove == null)
        {
            return NotFound();
        }
        _context.AssetTypes.Remove(assetTypeToRemove);
        
        _context.SaveChanges();

        return  NoContent();
    }
    
}