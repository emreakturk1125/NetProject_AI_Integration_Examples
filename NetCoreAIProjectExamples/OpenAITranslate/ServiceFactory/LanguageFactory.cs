using OpenAITranslate.Abstract;
using OpenAITranslate.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAITranslate.ServiceFactory
{
    public static class LanguageFactory
    {
        public static ILanguageService GetLanguageService(int languageCode)
        {
            return languageCode switch
            {
                1 => new EnglishService(),
                2 => new GermanService(),
                3 => new FrenchService(),
                4 => new SpanishService(),
                _ => throw new ArgumentException("Geçersiz dil kodu!")
            };
        }
    }
}
