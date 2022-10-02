using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DB.Models;

[Table("OrderItems",Schema = "Work")]
public sealed class OrderItem : Entity
{
    [Column(TypeName = "product")]
    public Product Product { get; set; } = null!;

    [Column(TypeName = "quantity")]
    public int? Quantity { get; set; }

    [Required]
    [Column(TypeName = "order")]
    public Order Order { get; set; } = null!;
}