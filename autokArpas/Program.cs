using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace autokArpas
{
    class Program
    {
        static void Main(string[] args)
        {
            var autok = new List<Auto>();

            using var sr = new StreamReader(@"..\..\..\src\autok.txt", Encoding.UTF8);

            _ = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                autok.Add(new(sr.ReadLine()));
            }

            foreach (var a in autok)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("7. feladat");

            var felautomatikus = _7f(autok);

            if (felautomatikus.Count == 0)
            {
                Console.WriteLine("Nincs ilyen autó");
            }
            else
            {
                Console.WriteLine($"{felautomatikus.Count} ilyen autó van.");
            }

            Console.WriteLine("8. feladat");

            var legkevesbeOnvezetok = _8f(autok);

            Console.WriteLine("Legkevésbé önálló autók:");
            if (legkevesbeOnvezetok.Count == 0)
            {
                Console.WriteLine("Hiba! Nincs ilyen autó.");
            }
            else
            {
                foreach (var l in legkevesbeOnvezetok)
                {
                    Console.WriteLine(l);
                }
                Console.WriteLine($"..azaz {legkevesbeOnvezetok.Count} ilyen db van.");
                Console.WriteLine($"Max érték: {legkevesbeOnvezetok[0].VezetoiBeavatkozasok}");
            }

            Console.WriteLine("9. feladat");

            Console.WriteLine($"A legkisebb szélességi koordináta: {_9f(autok)}");

            Console.WriteLine("10. feladat");

            var gyartok = _10f(autok);

            if (gyartok.Count == 0)
            {
                Console.WriteLine("Nincs ilyen autó!");
            }
            else
            {
                Console.WriteLine("Gyártók:");
                foreach (var g in gyartok)
                {
                    Console.WriteLine(g);
                }
            }

            Console.WriteLine("11. feladat");

            for (int i = 0; i < autok.Count; i++)
            {
                if (_11f(autok[i]))
                {
                    Console.Write($"{i+2} ");
                }
            }

            Console.WriteLine("\n12. feladat");

            using var sw = new StreamWriter(@"..\..\..\src\nagybetusek.txt", false, Encoding.UTF8);

            foreach (var a in autok)
            {
                sw.WriteLine($"{Auto.Atalakito(a.GyartoEsModell)}, {a.SAESzint}");
            }

            Console.ReadKey();
        }

        public static List<Auto> _7f(List<Auto> autok) => autok.Where(a => a.SAESzint == "félautomatikus" && a.VezetesiMod == "manuális").ToList();
        public static List<Auto> _8f(List<Auto> autok) => autok.Where(a => a.VezetoiBeavatkozasok == autok.Max(a => a.VezetoiBeavatkozasok)).ToList();
        public static double _9f(List<Auto> autok) => autok.Where(a => a.KoordinataSzelesseg == autok.Min(a => a.KoordinataSzelesseg)).Select(a => a.KoordinataSzelesseg).ToList()[0];
        public static List<string> _10f(List<Auto> autok) => autok.Where(a => a.VezetesiMod == "automatikus").Select(a => a.GyartoEsModell.Split(" ")[0]).Distinct().OrderBy(a => a).ToList();
        public static bool _11f(Auto auto) => auto.AktualisSebesseg > 85 && auto.AktualisSebesseg < 95 && auto.Szenzorok.Split(",").Length >= 3;
    }
}