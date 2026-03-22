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
    public async Task<IActionResult> GetAll()
    {
        var assetTypes = await _context.AssetTypes.ToListAsync();
            
            var assetTypeDto = assetTypes
            .Select(l => AssetTypeMapper.AssetTypeMapToDefaultDTO(l)
            ).ToList();
        
        return Ok(assetTypeDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]Guid id)
    {
        var assetType = await _context.AssetTypes.Where(at => at.Id == id).FirstOrDefaultAsync();
        
        if (assetType == null)
        {
            return NotFound();
        }
        var assetTypeDto = AssetTypeMapper.AssetTypeMapToDefaultDTO(assetType);
        
        return Ok(assetTypeDto);
    }
    #endregion
    
    #region Posters
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AssetTypeDefaultDTO assetTypeDto)
    {
        var assetType = AssetTypeMapper.AssetTypeMapFromDefaultDTOToAssetType(assetTypeDto);
        await _context.AssetTypes.AddAsync(assetType);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = assetType.Id }, assetType);
    }
    #endregion

    #region Putters
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AssetTypeDefaultDTO assetTypeDto)
    {
        var matchedAssetType = await _context.AssetTypes.FirstOrDefaultAsync(at => at.Id == id);

        if (matchedAssetType == null)
        {
            return NotFound();
        }
        
        matchedAssetType.Name = assetTypeDto.Name;
        matchedAssetType.Code = assetTypeDto.Code;
        matchedAssetType.CanHaveDividends = assetTypeDto.CanHaveDividends;
        matchedAssetType.DefaultCurrency = assetTypeDto.DefaultCurrency;

        await _context.SaveChangesAsync();

        return Ok(AssetTypeMapper.AssetTypeMapToDefaultDTO(matchedAssetType));
    }

    #endregion
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var assetTypeToRemove = await _context.AssetTypes.FirstOrDefaultAsync(at => at.Id == id);

        if (assetTypeToRemove == null)
        {
            return NotFound();
        }
        _context.AssetTypes.Remove(assetTypeToRemove);
        
        await _context.SaveChangesAsync();

        return  NoContent();
    }
    
}