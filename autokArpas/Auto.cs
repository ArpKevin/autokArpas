using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autokArpas
{
    class Auto
    {
        public string GyartoEsModell { get; set; }
        public string SAESzint { get; set; }
        public double AktualisSebesseg { get; set; }
        public string Szenzorok { get; set; }
        public double KoordinataSzelesseg { get; set; }
        public double KoordinataHosszusag { get; set; }
        public int VezetoiBeavatkozasok { get; set; }
        public string VezetesiMod { get; set; }

        public static string Atalakito(string GyartoEsModell)
        {
            return GyartoEsModell.ToUpper();
        }

        public Auto(string sor)
        {
            var a = sor.Split("; ");
            GyartoEsModell = a[0];
            SAESzint = a[1];
            AktualisSebesseg = double.Parse(a[2]);
            Szenzorok = a[3];
            var koordinatak = a[4].Split("|");
            KoordinataSzelesseg = double.Parse(koordinatak[0]);
            KoordinataHosszusag = double.Parse(koordinatak[1]);

            VezetoiBeavatkozasok = int.Parse(a[5]);
            VezetesiMod = a[6];
        }

        public override string ToString() => $"Gyártó és modell: {GyartoEsModell} {GyartoEsModell}; SAE-szint: {SAESzint}; Aktuális sebesség: {AktualisSebesseg} km/h; Szenzorok: {Szenzorok}; X-koordináta: {KoordinataSzelesseg}; Y-koordináta: {KoordinataHosszusag}; Vezetői beavatkozások száma: {VezetoiBeavatkozasok}, Vezetési mód: {VezetesiMod}";
    }
}
