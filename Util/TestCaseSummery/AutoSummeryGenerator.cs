using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DotNetEnv;

namespace SauseLabPomProject.Util.TestCaseSummery
{
    public class AutoSummeryGenerator
    {
        private const string GeminiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent";

        public async Task<string> GenerateSummeryAsync(string methodCode)
        {

            Env.Load(); 
            var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
                return "[Error: Gemini API key not found in environment variables]";

            var prompt = $"Summarize this C# Selenium test method in one sentence for XML documentation:\n{methodCode}";
            var promptJson = JsonSerializer.Serialize(prompt);

            var requestBody = $@"{{
            ""contents"": [{{""parts"": [{{""text"": {promptJson}}}]}}],
            ""generationConfig"": {{""maxOutputTokens"": 100}}
            }}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-goog-api-key", apiKey);

            try
            {
                var response = await client.PostAsync(
                    GeminiUrl,
                    new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                    return $"[API Error: {response.StatusCode}]";

                var responseBody = await response.Content.ReadAsStringAsync();
                return ExtractSummaryFromResponse(responseBody);
            }
            catch (HttpRequestException ex)
            {
                return $"[Network Error: {ex.Message}]";
            }
            catch (TaskCanceledException)
            {
                return "[Timeout Error: The request timed out]";
            }
            catch (Exception ex)
            {
                return $"[Unexpected Error: {ex.Message}]";
            }
        }

        private string ExtractSummaryFromResponse(string responseBody)
        {
            try
            {
                using var doc = JsonDocument.Parse(responseBody);
                var candidates = doc.RootElement.GetProperty("candidates");

                foreach (var candidate in candidates.EnumerateArray())
                {
                    var parts = candidate.GetProperty("content").GetProperty("parts");
                    foreach (var part in parts.EnumerateArray())
                    {
                        var text = part.GetProperty("text").GetString();
                        if (!string.IsNullOrWhiteSpace(text))
                            return text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                return $"[Response Parse Error: {ex.Message}]";
            }

            return "[No summary generated]";
        }
    }

}