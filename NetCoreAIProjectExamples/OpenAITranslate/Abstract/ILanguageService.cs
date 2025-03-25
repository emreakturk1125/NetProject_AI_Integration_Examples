namespace OpenAITranslate.Abstract
{
    public interface ILanguageService
    {
         Task<string> TranslateText(string text, string apiKey);
    }
}