using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01_teszt
{
    class Besorolando_temp
    {
        public Besorolando Besorolando { get; set; }
        public int Index { get; set; }
        public Besorolando_temp(Besorolando besorolando, int index)
        {
            this.Besorolando = besorolando;
            this.Index = index;
        }
    }
}
