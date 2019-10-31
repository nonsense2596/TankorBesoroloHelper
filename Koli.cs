using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01_teszt
{
    class Koli
    {
        public string Nev { get; set; }
        public string Neptun { get; set; }
        public int Szoba { get; set; }

        public static Koli FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Koli ko = new Koli();
            ko.Nev = values[0];
            ko.Neptun = values[1];
            try
            {
                ko.Szoba = int.Parse(values[2]);
            }
            catch
            {
                ko.Szoba = 0;
            }
            return ko;
        }
        public override string ToString()
        {
            return Nev + " " + Neptun + " " + Szoba;
        }
    }
}
