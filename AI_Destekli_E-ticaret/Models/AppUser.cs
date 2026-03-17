using Microsoft.AspNetCore.Identity;
namespace AI_Destekli_E_ticaret.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}