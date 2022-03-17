using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KeyFinder
{
    class Program
    {
        static void Szukaj(string plik, string plikWyjscie, string klucz)
        {

            string[] linie = File.ReadAllLines(plik);
            int ile = 0;
            using (StreamWriter sw = new StreamWriter(plikWyjscie))
            {
                for (int i = 0; i < linie.Length; i++)
                {
                    int wystapnienie = 0;
                    string linia = linie[i].ToLower();
                    if (linia.Contains(klucz))
                    {
                        ile++;
                        string[] podzielWiersz = linia.Split(' ');
                        foreach (string c in podzielWiersz)
                            if (c.Contains(klucz))
                                wystapnienie++;
                        sw.WriteLine("{0}) {1} [{2}]", ile, linie[i], wystapnienie);
                    }
                }
            }
            Console.WriteLine("Do pliku wpisano: {0} wierszy", ile);
        }
        static void Main(string[] args)
        {
            string plik = @".\PanTadeusz.txt";
            string plikWyjscie = @".\PanTadeusz2.txt";
            Console.Write("Podaj klucz: ");
            string klucz = Console.ReadLine();

            klucz = klucz.ToLower();
            try
            {
                Szukaj(plik, plikWyjscie, klucz);
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd, nie wpisano do pliku.");
            }
            Console.ReadLine();
        }
    }
}
