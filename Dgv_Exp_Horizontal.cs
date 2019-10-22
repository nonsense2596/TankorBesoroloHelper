using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanKorSeged_v01
{
    public partial class Dgv_Exp_Horizontal : System.Windows.Forms.Panel
    {

        public DataGridView Dgv { get; set; }
        public Dgv_Mover Dgv_m { get; set; }
        public Dgv_Exp_Vertical Dgv_e_v { get; set; }
        public Dgv_Exp_Combined Dgv_e_c { get; set; }

        private Point MouseDownLocation;

        public Dgv_Exp_Horizontal(DataGridView dgv)
        {
            Dgv = dgv;
            //this.Size = new Size(10, 100);
            this.BackColor = Color.Gray;
            InitializeComponent();
        }

        private void PanelKaiHorizontal_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseDownLocation = e.Location;
            
        }
        private void PanelKaiHorizontal_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Update();
            UpdateBounds();
            Invalidate();

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Dgv.Width = e.X + Dgv.Width - MouseDownLocation.X;

                this.Left = e.X + this.Left - MouseDownLocation.X;
                //Dgv_e_v.Left = e.X + Dgv_e_v.Left - MouseDownLocation.X;
                Dgv_e_v.Width = e.X + Dgv_e_v.Width - MouseDownLocation.X;
                //Dgv_m.Left = e.X + Dgv_m.Left - MouseDownLocation.X;
                Dgv_e_c.Left = e.X + Dgv_e_c.Left - MouseDownLocation.X;
            }
        }
    }
}
