using Microsoft.EntityFrameworkCore;
using Tutorial7.Data;
using Tutorial7.DTOs;
using Tutorial7.Models;

namespace Tutorial7.Services;

public class PCService : IPCService
{
    private readonly AppDbContext _context;

    public PCService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PcDto>> GetAllPcsAsync()
    {
        return await _context.PCs
            .Select(pc => new PcDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PcComponentDto>?> GetPcComponentsAsync(int id)
    {
        var pcExists = await _context.PCs.AnyAsync(pc => pc.Id == id);

        if (!pcExists)
        {
            return null;
        }

        return await _context.PCComponents
            .Where(pcComponent => pcComponent.PCId == id)
            .Select(pcComponent => new PcComponentDto
            {
                Code = pcComponent.Component.Code,
                Name = pcComponent.Component.Name,
                Description = pcComponent.Component.Description,
                Manufacturer = pcComponent.Component.ComponentManufacturer.FullName,
                ComponentType = pcComponent.Component.ComponentType.Name,
                Amount = pcComponent.Amount
            })
            .ToListAsync();
    }

    public async Task<PcDto> CreatePcAsync(CreatePcDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return new PcDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<PcDto?> UpdatePcAsync(int id, UpdatePcDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);

        if (pc == null)
        {
            return null;
        }

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return new PcDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> DeletePcAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);

        if (pc == null)
        {
            return false;
        }

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();

        return true;
    }
}