using System;
using System.IO;
using System.Net.Mime;


namespace ConsoleApp5
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
           random(out Random rastgele);
            girdi(out var basamak, out var sifreYeri);
            
            sifreOlustur(out var sifre, basamak);
            string son=sifreKaristir(sifre);
            dosyaYaz(sifreYeri,son);
            Console.ReadLine();
        }

        static void random(out Random rastgele)
        {
            rastgele = new Random();
        }
        private static void girdi(out string basamak,out string sifreYeri)
        {
            bool kontrol =false;
            do
            {
               
                random(out Random rastgele);
                Console.Write("kaç karakterli olsun yada random ise r yazınız:");
                basamak = Console.ReadLine();

                if (basamak == "r")
                {
                    basamak = Convert.ToString(rastgele.Next(6, 14));
                    Console.WriteLine("seçilen karakter sayısı:" + basamak);
                }

                if (!char.IsNumber(basamak[0]))
                {
                    Console.WriteLine("hatalı giriş");

                    kontrol = true;
                }else
                    kontrol = false;
            } while (kontrol);

            Console.WriteLine("ne için şifre");
            sifreYeri = Console.ReadLine();
            
        }

        private static void sifreOlustur(out string sifre,string basamak)
        {
            random(out Random rastgele);
            sifre="";
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(33,47)));
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(48,57)));
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(60,64)));
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(65,90)));
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(91,96)));
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(97,122)));
            sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(122,127)));
            for (int i = 0; i <Convert.ToInt32(basamak)-7; i++)
            {
                sifre=string.Concat(sifre,Convert.ToChar(rastgele.Next(32, 127)));
            }
        }

        private static string sifreKaristir(string sifre)
        {
            random(out Random rastgele);
            string karistir="";
            int randomIndex = 0;         
            int uzunluk=sifre.Length;
            for (int i = uzunluk; i > 0; i--)
            {
                randomIndex = rastgele.Next(0, uzunluk);
                karistir += sifre[randomIndex];
                sifre = sifre.Remove(randomIndex, 1);             
                uzunluk=sifre.Length;
            }
            Console.WriteLine(karistir);
            return karistir;
        }

        static void dosyaYaz(string sifreYeri,string karistir)
        {
            string file = @"C:\Users\salih\OneDrive\Masaüstü\şifreler.txt";
            File.AppendAllText(file, sifreYeri+":\t"+karistir + Environment.NewLine);
        }
    }
}