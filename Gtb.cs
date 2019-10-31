using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01_teszt
{
    class Gtb
    {
        public string Neptun { get; set; }
        public string GSzoba { get; set; }
        public string Kartya { get; set; }
        public string Garda { get; set; }

        public static Gtb FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Gtb gtb = new Gtb();
            gtb.Neptun = values[0];
            gtb.GSzoba = values[1];
            gtb.Kartya = values[2];
            gtb.Garda = values[3];
            return gtb;
        }
        public override string ToString()
        {
            return Neptun + " " + GSzoba + " " + Kartya + " " + Garda;
        }
    }
}
