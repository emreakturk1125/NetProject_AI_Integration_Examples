using Newtonsoft.Json;
using System.Text;

namespace OpenAITranslate.Concrete
{
    public static class BaseLanguageMethod
    {
        public static async Task<string> TranslateText(string text, string apiKey, string languageDesc)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var requestBody = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new {role="system",content="You are a helpful translator."},
                        new {role="user",content= $"Please translate this text to {languageDesc}: {text}"}
                    }
                };

                string jsonBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    dynamic responseObject = JsonConvert.DeserializeObject(responseString);
                    string translation = responseObject.choices[0].message.content;

                    return translation;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bir hata oluştu: {ex.Message}");
                    return null;
                }
            }
        }
    }
}