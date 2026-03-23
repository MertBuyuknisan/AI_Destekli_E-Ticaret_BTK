

using AI_Destekli_E_ticaret.Services;
using Microsoft.AspNetCore.Mvc;

namespace AI_Destekli_E_ticaret.Controllers;

public class ChatController : Controller
{
    private readonly GeminiChatService _chatService;

    public ChatController(GeminiChatService chatService)
    {
        _chatService = chatService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage([FromBody] ChatRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest("Mesaj Boş Olamaz");
        }

        try
        {
            string aiResponse = await _chatService.SendMessageAsync(request.Message);

            return Json(new { response = aiResponse });
        }
        catch (Exception e)
        {
            // Hatayı kırmızı konsola yazdır ki asıl sebebi anında görelim!
            Console.WriteLine("API DEN GELEN HATA: " + e.Message);
            return StatusCode(500, "Hata:" + e.Message);
        }
    }
}