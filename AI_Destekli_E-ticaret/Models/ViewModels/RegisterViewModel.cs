

using System.ComponentModel.DataAnnotations;

namespace AI_Destekli_E_ticaret.Models.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Şifre tekrar alanı zorunludur.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Şifreler birbiriyle uyuşmuyor.")]
    public string ConfirmPassword { get; set; }
}