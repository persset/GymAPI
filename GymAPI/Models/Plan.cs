using System.ComponentModel.DataAnnotations.Schema;

namespace GymAPI.Models;

public class Plan {
    public int Id { get; set;}
    public string Name { get; set;} = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal Value { get; set; } = 0.0m;
}