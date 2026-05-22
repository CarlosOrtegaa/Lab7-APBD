namespace Tutorial7.DTOs;

public class PcComponentDto
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string ComponentType { get; set; } = null!;

    public int Amount { get; set; }
}