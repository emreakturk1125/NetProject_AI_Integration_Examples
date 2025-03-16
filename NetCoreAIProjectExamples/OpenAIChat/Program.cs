using System.Text;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var apiKey = string.Empty; // OPEN AI API KEY   

        Console.WriteLine("Lütfen Sorunuzu Yazınız:");
        var prompt = Console.ReadLine();

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                },
                max_tokens = 100
            };

            var jsonRequestBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var resesponseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<JsonElement>(resesponseString);
                    var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                    Console.WriteLine("Response from OpenAI:");
                    Console.WriteLine(answer);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
    }
}