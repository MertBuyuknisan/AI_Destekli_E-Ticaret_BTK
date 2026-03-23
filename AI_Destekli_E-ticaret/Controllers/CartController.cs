
using AI_Destekli_E_ticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI_Destekli_E_ticaret.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public CartController(AppDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]

    public async Task<IActionResult> AddToCart(int productId)
    {
        //kullanıcıyı aldık.
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var userId = user.Id;

        var cartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.AppUserId == userId && c.ProductId == productId);

        if (cartItem != null)
        {
            cartItem.Quantity++;
        }
        else
        {
            cartItem = new CartItem
            {
                AppUserId = userId,
                ProductId = productId,
                Quantity = 1
            };

            _context.CartItems.Add(cartItem);

        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Cart", new { id = productId });
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //kullanıcıyı kontrol etme işlemii.
        var user = await _userManager.GetUserAsync(User);

        if (user is null)
        {
            return RedirectToAction("Login", "Account");
        }

        var cardItems = await _context.CartItems
        .Include(c => c.Product)
        .Where(c => c.AppUserId == user.Id).ToListAsync();
        return View(cardItems);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Increase(int cartItemId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null)
        {
            return RedirectToAction("Login", "Account");
        }
        var cartItem = await _context.CartItems
        .Include(c => c.Product)
        .FirstOrDefaultAsync(c => c.Id == cartItemId && c.AppUserId == user.Id);

        if (cartItem is null)
        {
            return NotFound();
        }

        if (cartItem.Quantity < cartItem.Product.Stok)
        {
            cartItem.Quantity++;
            await _context.SaveChangesAsync();
        }
        else
        {
            TempData["CartMessage"] = "Stok limiti aşılamaz.";
        }
        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    [Authorize]

    public async Task<IActionResult> Decrease(int cartItemId)
    {

        var user = await _userManager.GetUserAsync(User);
        if (user is null)
        {
            return RedirectToAction("Login", "Account");
        }
        var cartItem = await _context.CartItems
        .Include(c => c.Product)
        .FirstOrDefaultAsync(c => c.Id == cartItemId && c.AppUserId == user.Id);

        if (cartItem is null)
        {
            return NotFound();
        }

        if (cartItem.Quantity > 1)
        {
            cartItem.Quantity--;
        }
        else
        {
            _context.CartItems.Remove(cartItem);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Cart");
    }
}