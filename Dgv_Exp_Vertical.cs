using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanKorSeged_v01
{
    public partial class Dgv_Exp_Vertical : System.Windows.Forms.Panel
    {
        public DataGridView Dgv { get; set; }
        public Dgv_Mover Dgv_m { get; set; }
        public Dgv_Exp_Horizontal Dgv_e_h { get; set; }
        public Dgv_Exp_Combined Dgv_e_c { get; set; }

        private Point MouseDownLocation;

        public Dgv_Exp_Vertical(DataGridView dgv)
        {
            Dgv = dgv;
            //this.Size = new Size(200, 10);
            this.BackColor = Color.Gray;
            InitializeComponent();
        }

        private void PanelKaiVertical_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownLocation = e.Location;
        }

        private void PanelKaiVertical_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Dgv.Height = e.Y + Dgv.Height - MouseDownLocation.Y;

                this.Top = e.Y + this.Top - MouseDownLocation.Y;
                //Dgv_e_h.Top = e.Y + Dgv_e_h.Top - MouseDownLocation.Y;
                Dgv_e_h.Height = e.Y + Dgv_e_h.Height - MouseDownLocation.Y;
                //Dgv_m.Top = e.Y + Dgv_m.Top - MouseDownLocation.Y;
                Dgv_e_c.Top = e.Y + Dgv_e_c.Top - MouseDownLocation.Y;
            }
        }
    }
}
