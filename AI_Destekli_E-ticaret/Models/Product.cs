using System.ComponentModel.DataAnnotations;
namespace AI_Destekli_E_ticaret.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad alanı zorunludur.")]
    public string Ad { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Maksimum 500 karakter")]
    public string? Aciklama { get; set; }

    [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
    public double Fiyat { get; set; }

    [Required(ErrorMessage = "Stok alanı zorunludur.")]
    public int Stok { get; set; }

    public string? ResimUrl { get; set; }

    [Required(ErrorMessage = "Kategori alanı zorunludur.")]
    public string Kategori { get; set; } = string.Empty;

    public bool aktifMi { get; set; }





}