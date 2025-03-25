using OpenAITranslate.Abstract;
using OpenAITranslate.ServiceFactory;
using OpenAITranslate.Utiliy;

internal class Program
{
    /// <summary>
    /// OpenAI Translate uygulaması, kullanıcıdan bir dil seçmesini ve çevirmek istediği cümleyi girmesini bekler.
    /// </summary> 
    private static async Task Main(string[] args)
    {
        string apiKey = "API KEY HERE";
        bool continueTranslation;

        do
        {
            Console.Write("Lütfen bir dil seçin (İngilizce:1, Almanca:2, Fransızca:3, İspanyolca:4): ");
            string? langCodeStr = Console.ReadLine();
            var langCode = string.IsNullOrEmpty(langCodeStr) ? 0 : int.Parse(langCodeStr);

            Console.Write("Lütfen çevirmek istediğiniz cümleyi giriniz => ");
            string? inputText = Console.ReadLine();

            ILanguageService languageService = LanguageFactory.GetLanguageService(langCode);
            string translatedText = await languageService.TranslateText(inputText, apiKey);

            if (!string.IsNullOrEmpty(translatedText))
            {
                Console.WriteLine("*****************");
                Console.WriteLine($"Çeviri ({LanguagesDefine.Languages.FirstOrDefault(x => x.Key == langCode).Value}): {translatedText}");
                Console.WriteLine("****************");
            }
            else
            {
                Console.Write("Beklenmeyen bir hata oluştu");
            }

            Console.Write("Başka bir çeviri yapmak ister misiniz? (Evet: E, Hayır: H): ");

            var continueTranslationStr = Console.ReadLine();
            continueTranslation = continueTranslationStr == "E";
        } while (continueTranslation);
    }
}