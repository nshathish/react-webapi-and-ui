using System.ComponentModel.DataAnnotations;

namespace ReactLearnLabs.Api.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    [MaxLength(300)] public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}