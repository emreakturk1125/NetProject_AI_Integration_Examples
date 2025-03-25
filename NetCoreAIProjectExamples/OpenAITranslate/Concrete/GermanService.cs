using OpenAITranslate.Abstract;
using OpenAITranslate.Utility;
using OpenAITranslate.Utiliy;

namespace OpenAITranslate.Concrete
{
    internal class GermanService : ILanguageService
    {
        public async Task<string> TranslateText(string text, string apiKey)
        {
            return await BaseLanguageMethod.TranslateText(text, apiKey, LanguagesDefine.Languages.FirstOrDefault(x => x.Key == (int)LanguagesEnum.German).Value);
        }
    }
}