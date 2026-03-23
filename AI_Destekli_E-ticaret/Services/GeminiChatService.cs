using System.Text;
using System.Text.Json;
using AI_Destekli_E_ticaret.Models;

namespace AI_Destekli_E_ticaret.Services;

public class GeminiChatService
{
    private readonly GeminiSettings _settings;

    private readonly HttpClient _httpClient;


    public GeminiChatService(GeminiSettings settings, HttpClient httpClient, AppDbContext db)
    {
        _settings = settings;
        _httpClient = httpClient;
    }

    public async Task<string> SendMessageAsync(string userMessage)
    {

        string apiKey = _settings.ApiKey.Trim();
        string model = _settings.Model.Trim();
        string apiUrl = $"{_settings.BaseUrl}{model}:generateContent?key={apiKey}";


        var payload = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[] { new { text = userMessage } }
                }
            }
        };
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string jsonPayload = JsonSerializer.Serialize(payload, options);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // İsteği gönderiyoruz
        var response = await _httpClient.PostAsync(apiUrl, content);


        if (!response.IsSuccessStatusCode)
        {
            string errorBody = await response.Content.ReadAsStringAsync();
            throw new Exception($"Gemini API Hatası ({response.StatusCode}): {errorBody}");
        }

        string responseJson = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseJson);

        string answer = doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString() ?? "Cevap yok.";

        return answer;
    }
}