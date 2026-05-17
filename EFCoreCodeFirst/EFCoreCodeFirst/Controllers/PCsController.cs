using EFCoreCodeFirst.Exceptions;
using EFCoreCodeFirst.Service;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirst.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController(IPCsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add()
    {
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok();
    }
}