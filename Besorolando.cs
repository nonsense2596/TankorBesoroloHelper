using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01_teszt
{
    class Besorolando
    {
        public string Nev { get; set; }
        public int Irsz { get; set; }
        public string Neptun { get; set; }
        public string Nem { get; set; }
        public string GSzoba { get; set; }
        public string Kartya { get; set; }
        public int Szoba { get; set; }
        public string Garda { get; set; }
        public Szin Szin { get; set; }

        public Besorolando(string nev, int irsz, string neptun, string nem, string gszoba, string kartya, int szoba, string garda, Szin szin)
        {
            this.Nev = nev;
            this.Irsz = irsz;
            this.Neptun = neptun;
            this.Nem = nem;
            this.GSzoba = gszoba;
            this.Kartya = kartya;
            this.Szoba = szoba;
            this.Garda = garda;
            this.Szin = szin;
        }
        public override string ToString()
        {
            return Nev.PadRight(30) + "\t" + Neptun + "\t" + Irsz.ToString().PadRight(5) + "\t" + Nem.PadRight(5) + "\t" + Kartya.PadRight(30) + "\t" + GSzoba.PadRight(30) + "\t" + Szoba.ToString().PadRight(4) + "\t" + Garda.PadRight(6) + "\t" + Szin.ToString();
        }
    }
}
