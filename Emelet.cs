using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01_teszt
{
    class Emelet
    {
        public Emelet(int start, int end, Szin color, string gardanev)
        {
            Start = start;
            End = end;
            Color = color;
            Gardanev = gardanev;
        }

        public int Start { get; set; }
        public int End { get; set; }
        public Szin Color { get; set; }
        public string Gardanev { get; set; }

    }
