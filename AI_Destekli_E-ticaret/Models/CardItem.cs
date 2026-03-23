using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AI_Destekli_E_ticaret.Models;

public class CartItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    //o an giriş yapan kullanici id
    [Required]
    public string AppUserId { get; set; }

    [ForeignKey("AppUserId")]
    public virtual AppUser AppUser { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    [Required]
    public int Quantity { get; set; } = 1;
}