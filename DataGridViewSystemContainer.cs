using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanKorSeged_v01
{
    class DataGridViewSystemContainer
    {
        public DataGridViewSystemContainer(DataGridViewKai dgvk, Dgv_Exp_Horizontal dgv_e_h, Dgv_Exp_Vertical dgv_e_v, Dgv_Exp_Combined dgv_e_c, Dgv_Mover dgv_m)
        {
            Dgvk = dgvk;
            Dgv_e_h = dgv_e_h;
            Dgv_e_v = dgv_e_v;
            Dgv_e_c = dgv_e_c;
            Dgv_m = dgv_m;
        }

        public DataGridViewKai Dgvk { get; set; }
        public Dgv_Exp_Horizontal Dgv_e_h { get; set; }
        public Dgv_Exp_Vertical Dgv_e_v { get; set; }
        public Dgv_Exp_Combined Dgv_e_c { get; set; }
        public Dgv_Mover Dgv_m { get; set; }
    }
}
