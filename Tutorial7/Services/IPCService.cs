using Tutorial7.DTOs;

namespace Tutorial7.Services;

public interface IPCService
{
    Task<IEnumerable<PcDto>> GetAllPcsAsync();

    Task<IEnumerable<PcComponentDto>?> GetPcComponentsAsync(int id);

    Task<PcDto> CreatePcAsync(CreatePcDto dto);

    Task<PcDto?> UpdatePcAsync(int id, UpdatePcDto dto);

    Task<bool> DeletePcAsync(int id);
}