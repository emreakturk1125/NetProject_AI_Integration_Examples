using Newtonsoft.Json;
using OpenAITranslate.Abstract;
using OpenAITranslate.Utility;
using OpenAITranslate.Utiliy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OpenAITranslate.Concrete
{
    internal class FrenchService : ILanguageService
    {
        public async Task<string> TranslateText(string text, string apiKey)
        {
            return await BaseLanguageMethod.TranslateText(text, apiKey, LanguagesDefine.Languages.FirstOrDefault(x => x.Key == (int)LanguagesEnum.French).Value);
        }
    }
}
