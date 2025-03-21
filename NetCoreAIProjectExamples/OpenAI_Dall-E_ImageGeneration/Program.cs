using System.Text;
using System.Text.Json;

internal class Program
{
    /// <summary>
    /// Text'i resim formatına dönüştürür. Resmin linkini verir
    /// </summary> 
    private static async Task Main(string[] args)
    {
        var apiKey = string.Empty; // OPEN AI API KEY ini giriniz

        Console.WriteLine("Örnek Prompt:");
        var prompt = Console.ReadLine();

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestBody = new
            {
                prompt = prompt,
                n = 1,
                size = "1024x1024"
            };

            var jsonRequestBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            try
            {
                Console.WriteLine("Resim hazırlanıyor...");
                var response = await httpClient.PostAsync("https://api.openai.com/v1/images/generations", content);
                var responseString = await response.Content.ReadAsStringAsync(); // Servis resim URL'sini döndürecek

                if (response.IsSuccessStatusCode)
                { 
                    Console.WriteLine("Response from OpenAI:");
                    Console.WriteLine(responseString);   
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
    }
}