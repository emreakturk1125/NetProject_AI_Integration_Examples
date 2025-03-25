using Google.Cloud.Vision.V1; 

internal class Program
{
    /// <summary>
    /// Google Cloud Vision, Google Cloud'un sunduğu bir makine öğrenimi hizmetidir ve görsellerden anlam çıkarmak için gelişmiş görüntü analiz yetenekleri sağlar.
    /// Bu API, resimlerdeki nesneleri, metinleri, yüzleri, logoları ve daha fazlasını tanımlamak için kullanılır.
    /// 300 $ lık ücretsiz kota ile başlayabilirsiniz.

    /// Öne Çıkan Özellikler:

    // Optik Karakter Tanıma(OCR) : Görsellerdeki metni tespit edip dijital formata dönüştürür.
    // Nesne Algılama: Görsellerdeki nesneleri ve sahneleri otomatik olarak tanır.
    // Yüz Algılama: Yüzleri tespit eder ve duyguları(mutlu, üzgün vb.) analiz edebilir.
    // Etiketleme: Görsel içeriğini sınıflandırarak konular hakkında bilgi verir.
    // Güvenlik Filtreleri: Uygunsuz içerikleri (örneğin yetişkin içeriği, şiddet) tespit edebilir.
    // Logo ve Ürün Tanıma: Görsellerdeki markaların logolarını ve ürünleri tanır.

    /// Kullanım Alanları:

    //Evrak tarama ve belge analizi (OCR ile otomatik veri çıkarımı)
    //E-ticaret(ürün tanıma, katalog oluşturma)
    //Güvenlik sistemleri(yüz tanıma ve sahtekarlık tespiti)
    //Sosyal medya moderasyonu(uygunsuz içerik filtreleme)

    /// </summary>

    private static void Main(string[] args)
    {
        Console.Write("Resim yolunu giriniz:");
        string imagePath = Console.ReadLine();
        Console.WriteLine();

        string credentialPath = @"";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);

        try
        {
            var client = ImageAnnotatorClient.Create();
            var image = Image.FromFile(imagePath);
            var response = client.DetectText(image);
            Console.WriteLine("Resimdeki Metin:");
            Console.WriteLine();
            foreach (var annotination in response)
            {
                if (!string.IsNullOrEmpty(annotination.Description))
                {
                    Console.WriteLine(annotination.Description);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu {ex.Message}");
        }
    }
}