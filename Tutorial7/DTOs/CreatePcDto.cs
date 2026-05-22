using System.ComponentModel.DataAnnotations;

namespace Tutorial7.DTOs;

public class CreatePcDto
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [Range(0.01, double.MaxValue)]
    public decimal Weight { get; set; }

    [Range(1, int.MaxValue)]
    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}