using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01_teszt
{
    class Felvettek
    {
        public string Nev { set; get; }
        public int Irsz { get; set; }

        public string Nem { get; set; }
        public string Neptun { get; set; }

        public static Felvettek FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Felvettek fv = new Felvettek();
            fv.Nev = values[0];
            fv.Irsz = int.Parse(values[1]);
            fv.Nem = values[2];
            fv.Neptun = values[3];
            return fv;
        }
        public override string ToString()
        {
            return Nev + " " + Irsz + " " + Nem + " " + Neptun;
        }
    }
}
