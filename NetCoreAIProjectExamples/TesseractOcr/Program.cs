using Tesseract;

internal class Program
{
    /// <summary>
    /// Tesseract OCR ile karakter okuması yapar
    /// Link : https://github.com/tesseract-ocr/tessdata/blob/main/tur.traineddata?utm_source=chatgpt.com
    /// bu linkten ilgili traineddata dosyasını indirip C:\tessdata klasörüne atınız
    /// </summary>
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Karakter Okuması Yapılacak Resim Yolu:");
        string imagePath = Console.ReadLine();

        string tessDataPath = @"C:\tessdata";

        Console.WriteLine("Tesseract OCR Çalıştırılıyor...");

        try
        {
            using (var engine = new TesseractEngine(tessDataPath, "tur", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        Console.WriteLine("OCR Çıktısı:");
                        Console.WriteLine(text);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hata: " + ex.Message);
        }

        Console.ReadLine();
    }
}