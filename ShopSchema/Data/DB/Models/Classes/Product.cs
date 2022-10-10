using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DB.Models;

[Table("Products",Schema = "Work")]
public sealed class Product: NamedEntity
{
    [Key]
    [Column("id")]
    public int? Id { get; set; }
    
    [Column("price")]
    public decimal? Price { get; set; }

    [Column("category")]
    public string? Category { get; set; }
}