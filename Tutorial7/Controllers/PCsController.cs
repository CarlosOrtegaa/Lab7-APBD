using Microsoft.AspNetCore.Mvc;
using Tutorial7.DTOs;
using Tutorial7.Services;

namespace Tutorial7.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController : ControllerBase
{
    private readonly IPCService _pcService;

    public PCsController(IPCService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PcDto>>> GetAllPcs()
    {
        var pcs = await _pcService.GetAllPcsAsync();

        return Ok(pcs);
    }

    [HttpGet("{id:int}/components")]
    public async Task<ActionResult<IEnumerable<PcComponentDto>>> GetPcComponents(int id)
    {
        var components = await _pcService.GetPcComponentsAsync(id);

        if (components == null)
        {
            return NotFound();
        }

        return Ok(components);
    }

    [HttpPost]
    public async Task<ActionResult<PcDto>> CreatePc(CreatePcDto dto)
    {
        var createdPc = await _pcService.CreatePcAsync(dto);

        return CreatedAtAction(
            nameof(GetPcComponents),
            new { id = createdPc.Id },
            createdPc
        );
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<PcDto>> UpdatePc(int id, UpdatePcDto dto)
    {
        var updatedPc = await _pcService.UpdatePcAsync(id, dto);

        if (updatedPc == null)
        {
            return NotFound();
        }

        return Ok(updatedPc);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePc(int id)
    {
        var deleted = await _pcService.DeletePcAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}