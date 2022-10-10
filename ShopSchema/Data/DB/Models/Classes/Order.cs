using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DB.Models;

[Table("Orders",Schema = "Work")]
public sealed class Order : Entity
{
    [Column("date")]
    public DateTime OrderDate { get; set; }

    [Required]
    [Column("address")]
    public string Address { get; set; } = null!;

    [Required]
    [Column("phone")]
    public string Phone { get; set; } = null!;

    [Column( "items")]
    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
}