using System;

namespace KutuphaneSistemi
{
    class Uye
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public Uye(string kullaniciAdi, string sifre)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
        }

        public bool GirisYap(string kadi, string sifre)
        {
            return (this.KullaniciAdi == kadi && this.Sifre == sifre);
        }
    }

    class Program
    {
        static void Main(string[] args)
        { 
            Uye sabitUye = new Uye("kitapci", "1234");

            int denemeHakki = 3;
            bool girisBasarili = false;

            Console.WriteLine("--- Kütüphane Üye Giriş Sistemi ---");

            while (denemeHakki > 0)
            {
                Console.Write("\nKullanıcı Adı: ");
                string girilenKadi = Console.ReadLine();

                Console.Write("Şifre: ");
                string girilenSifre = Console.ReadLine();

                if (sabitUye.GirisYap(girilenKadi, girilenSifre))
                {
                    Console.WriteLine("\n[+] Giriş başarılı! Çevrimiçi kaynaklara yönlendiriliyorsunuz.");
                    girisBasarili = true;
                }
                else
                {
                    denemeHakki--;
                    if (denemeHakki > 0)
                    {
                        Console.WriteLine($"[-] Hatalı giriş! Kalan deneme hakkınız: {denemeHakki}");
                    }
                }
            }

            if (!girisBasarili)
            {
                Console.WriteLine("\n[!!!] 3 kez hatalı giriş yapıldı. Hesap kilitlendi!");
            }

            Console.WriteLine("\nSistem kapatılıyor. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}