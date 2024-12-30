namespace Bilal_Habeş_Şimşek_1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string formatHata = "Lütfen sadece sayıyı uygun formatta giriniz.";
            string notDegeriHata = "Notu 0-100 aralığında girmelisiniz.";
            double vizeNotu, finalNotu, notOrtalama, sinifNotOrtalama = 0, enKucuk = 100, enBuyuk = 0;

            Console.Write("Kaç öğrenci kaydetmek istiyorsunuz: ");
            int ogrenciSayisi = Convert.ToInt32(Console.ReadLine());

            string[,] dizi = new string[ogrenciSayisi, 7];
            double[] ortalamalar = new double[ogrenciSayisi];

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.Write($"{i + 1}. Öğrencinin Numarasını Giriniz: ");
                dizi[i, 0] = Console.ReadLine();

                Console.Write($"{i + 1}. Öğrencinin Adını Giriniz: ");
                dizi[i, 1] = Console.ReadLine();

                Console.Write($"{i + 1}. Öğrencinin Soyadını Giriniz: ");
                dizi[i, 2] = Console.ReadLine();

                while (true)
                {
                    try
                    {
                        Console.Write($"{i + 1}. Öğrencinin Vize Notunu Giriniz: ");
                        vizeNotu = Convert.ToDouble(Console.ReadLine());
                        if (vizeNotu < 0 || vizeNotu > 100)
                        {
                            Console.WriteLine(notDegeriHata);
                        }
                        else
                        {
                            dizi[i, 3] = vizeNotu.ToString();
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine(formatHata);
                    }
                }

                while (true)
                {
                    try
                    {
                        Console.Write($"{i + 1}. Öğrencinin Final Notunu Giriniz: ");
                        finalNotu = Convert.ToDouble(Console.ReadLine());
                        if (finalNotu < 0 || finalNotu > 100)
                        {
                            Console.WriteLine(notDegeriHata);
                        }
                        else
                        {
                            dizi[i, 4] = finalNotu.ToString();
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine(formatHata);
                    }
                }

                notOrtalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
                dizi[i, 5] = notOrtalama.ToString("F2");
                ortalamalar[i] = notOrtalama;

                if (notOrtalama >= 85) { dizi[i, 6] = "AA"; }
                else if (notOrtalama >= 75) { dizi[i, 6] = "BA"; }
                else if (notOrtalama >= 60) { dizi[i, 6] = "BB"; }
                else if (notOrtalama >= 50) { dizi[i, 6] = "CB"; }
                else if (notOrtalama >= 40) { dizi[i, 6] = "CC"; }
                else if (notOrtalama >= 30) { dizi[i, 6] = "DC"; }
                else if (notOrtalama >= 20) { dizi[i, 6] = "DD"; }
                else if (notOrtalama >= 10) { dizi[i, 6] = "FD"; }
                else { dizi[i, 6] = "FF"; }

                if (notOrtalama < enKucuk) enKucuk = notOrtalama;
                if (notOrtalama > enBuyuk) enBuyuk = notOrtalama;
                sinifNotOrtalama += notOrtalama;
            }

            sinifNotOrtalama /= ogrenciSayisi;

            Console.WriteLine("\nNumara\tAd\tSoyad\tVize\tFinal\tOrtalama\tHarf Notu");
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(dizi[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nSınıf Ortalaması: {sinifNotOrtalama:F2}");
            Console.WriteLine($"En Düşük Not: {enKucuk:F2}");
            Console.WriteLine($"En Yüksek Not: {enBuyuk:F2}");

        }
    }
}
