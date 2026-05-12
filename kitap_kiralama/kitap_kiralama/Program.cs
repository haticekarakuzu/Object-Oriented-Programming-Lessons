using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static Dictionary<string, string> kitaplar = new Dictionary<string, string>();
    static string dosyaAdi = "kitaplar.json";

    static void Main()
    {
        KitaplariYukle();
        while (true)
        {
            Console.WriteLine("\n=== Kitap Kiralama Sistemi ===");
            Console.WriteLine("1.Kitap Kirala");
            Console.WriteLine("2.Kitap Iade Et");
            Console.WriteLine("3.Odunc Verilen Kitapları Listele");
            Console.WriteLine("4.Cikis");
            Console.Write("Seciminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    KitapKirala();
                    break;
                case "2":
                    KitapIadeEt();
                    break;
                case "3":
                    OduncVerilenleriListele();
                    break;
                case "4":
                    Console.WriteLine("Sistemden cikiliyor...");
                    return;
                default:
                    Console.WriteLine("Gecersiz secim ,tekrar deneyin.");
                    break;
            }
        }
    }

    static void KitapKirala()
    {
        Console.Write("Kiralanacak Kitabin Adi: ");
        string kitapAdi = Console.ReadLine();

        if (kitaplar.ContainsKey(kitapAdi))
        {
            Console.WriteLine("Hata: '{kitapAdi}' kitabi zaten {kitaplar[kitapAdi]} tarafindan alinmis!");
        }
        else
        {
            Console.Write("Odunc Alan Kisinin Adi: ");
            string kisi = Console.ReadLine();

            kitaplar.Add(kitapAdi, kisi);
            VerileriKaydet();
            Console.WriteLine("Kitap basariyla kiralandi.");
        }
    }

    static void KitapIadeEt()
    {
        Console.Write("İade Edilen Kitabin Adi: ");
        string kitapAdi = Console.ReadLine();

        if (kitaplar.ContainsKey(kitapAdi))
        {
            kitaplar.Remove(kitapAdi);
            VerileriKaydet();
            Console.WriteLine("'{kitapAdi}' iade alindi. Kitap su an musait.");
        }
        else
        {
            Console.WriteLine("Hata: Bu kitap zaten kutuphanede veya kayitli degil.");
        }
    }

    static void OduncVerilenleriListele()
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("Su anda odunc verilmis hic kitap yok.");
        }
        else
        {
            Console.WriteLine("\n--- Odunc Verilen Kitaplar Listesi ---");
            foreach (var kitap in kitaplar)
            {
                Console.WriteLine($"- Kitap: {kitap.Key} | Odunc Alan: {kitap.Value}");
            }
        }
    }

    static void VerileriKaydet()
    {
        // Dictionary yapısını JSON formatına çevirip dosyaya yazar
        string json = JsonSerializer.Serialize(kitaplar);
        File.WriteAllText(dosyaAdi, json);
    }

    static void KitaplariYukle()
    {
        // Dosya varsa verileri oku, yoksa boş dictionary ile devam et
        if (File.Exists(dosyaAdi))
        {
            string json = File.ReadAllText(dosyaAdi);
            kitaplar = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                       ?? new Dictionary<string, string>();
        }
    }
}