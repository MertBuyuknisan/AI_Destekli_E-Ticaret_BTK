
using System.Collections;
using AI_Destekli_E_ticaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Formats.Tar;

namespace AI_Destekli_E_ticaret.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ProductController(AppDbContext context, IWebHostEnvironment hostEnvironment)
    {
        _context = context;
        _hostEnvironment = hostEnvironment;
    }

    public async Task<ActionResult> GetProduct()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
    }

    public async Task<ActionResult> Details(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        return View(product);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Product product, IFormFile? imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // wwwroot/images klasörünün yolu
                string wwwRootPath = _hostEnvironment.WebRootPath;

                // Güvenli ve benzersiz bir dosya adı oluşturmak için Guid
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string basePath = Path.Combine(wwwRootPath, "images");
                string finalPath = Path.Combine(basePath, fileName);

                // /images klasörü yoksa oluştur
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                // Dosyayı sunucuya kopyala
                using (var fileStream = new FileStream(finalPath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Veritabanına kaydedilecek yolu modele atadıö.
                product.ResimUrl = "/images/" + fileName;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetProduct", "Product");

        }
        return View(product);
    }


    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("GetProduct", "Product");
    }


    [Authorize(Roles = "Admin")]

    public IActionResult Update(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null)
        {
            return NotFound();
        }
        return View(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Update(int id, Product product, IFormFile? imageFile)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        var mevcutVeri = await _context.Products.FindAsync(id);

        if (mevcutVeri is null)
        {
            return NotFound();
        }

        mevcutVeri.Ad = product.Ad;
        mevcutVeri.Aciklama = product.Aciklama;
        mevcutVeri.Fiyat = product.Fiyat;
        mevcutVeri.Kategori = product.Kategori;
        mevcutVeri.Stok = product.Stok;


        if (imageFile != null && imageFile.Length > 0)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            // Güvenli ve benzersiz bir dosya adı oluşturmak için Guid
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            string basePath = Path.Combine(wwwRootPath, "images");
            string finalPath = Path.Combine(basePath, fileName);

            // /images klasörü yoksa oluştur
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            // Dosyayı sunucuya kopyala
            using (var fileStream = new FileStream(finalPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            // Veritabanına kaydedilecek yolu modele atadıö.
            mevcutVeri.ResimUrl = "/images/" + fileName;
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("GetProduct", "Product");





    }
}