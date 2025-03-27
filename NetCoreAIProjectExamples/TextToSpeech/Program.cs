using System.Speech.Synthesis;

class Program
{
    /// <summary>
    /// System.Speech.Synthesis kütüphanesi kullanılarak metni seslendiren uygulama
    /// Girilen text'i seslendiren uygulama, Erkek/Kadın sesi seçimi ve dil ses seçenekleri mevcuttur
    /// </summary> 
    static void Main(string[] args)
    {
        var continueTranslation = false;
        do
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

            speechSynthesizer.Volume = 100;
            speechSynthesizer.Rate = -1;


            // Erkek sesi seçimi
            foreach (var voice in speechSynthesizer.GetInstalledVoices())
            {
                if (voice.VoiceInfo.Gender == System.Speech.Synthesis.VoiceGender.Neutral)
                {
                    speechSynthesizer.SelectVoice(voice.VoiceInfo.Name);
                    break;
                }
            }

            // Türkçe bir ses var mı kontrol et
            foreach (var voice in speechSynthesizer.GetInstalledVoices())
            {
                if (voice.VoiceInfo.Culture.Name.StartsWith("tr"))  // Örn: "tr-TR"
                {
                    speechSynthesizer.SelectVoice(voice.VoiceInfo.Name);
                    Console.WriteLine($"Seçilen Ses: {voice.VoiceInfo.Name}");
                    break;
                }
            }


            Console.Write("Metni Girin: ");
            string input;
            input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                speechSynthesizer.Speak(input);
            }
              
            Console.Write("Devam etmek ister misiniz? (Evet: E, Hayır: H): ");

            var continueTranslationStr = Console.ReadLine();
            continueTranslation = continueTranslationStr == "E";
        } while (continueTranslation);


    }
}