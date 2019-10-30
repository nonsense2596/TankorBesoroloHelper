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
    public partial class Dgv_Exp_Combined : System.Windows.Forms.Panel
    {
        public DataGridView Dgv { get; set; }
        public Dgv_Mover Dgv_m { get; set; }
        public Dgv_Exp_Horizontal Dgv_e_h { get; set; }
        public Dgv_Exp_Vertical Dgv_e_v { get; set; }

        //int dgv_e_h_x;
        //int dgv_e_h_y;
        //int dgv_e_v_x;
        //int dgv_e_v_y;

        private Point MouseDownLocation;
        public Dgv_Exp_Combined(DataGridView dgv)
        {
            Dgv = dgv;
            this.BackColor = Color.Blue;
            this.Size = new Size(10, 10);
            InitializeComponent();
        }

        private void Dgv_Exp_Combined_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownLocation = e.Location;
            //dgv_e_h_x = Dgv_e_h.Left;
            //dgv_e_h_y = Dgv_e_h.Top;
            //dgv_e_v_x = Dgv_e_v.Left;
            //dgv_e_v_y = Dgv_e_v.Top;
        }

        private void Dgv_Exp_Combined_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Dgv.Height = e.Y + Dgv.Height - MouseDownLocation.Y;
                Dgv.Width = e.X + Dgv.Width - MouseDownLocation.X;


                this.Top = e.Y + this.Top - MouseDownLocation.Y;
                this.Left = e.X + this.Left - MouseDownLocation.X;
                Dgv_e_h.Height = e.Y + Dgv_e_h.Height - MouseDownLocation.Y;
                Dgv_e_v.Width = e.X + Dgv_e_v.Width - MouseDownLocation.X;
                Dgv_e_h.Left = Dgv.Left + Dgv.Width;
                Dgv_e_v.Top = Dgv.Top + Dgv.Height;
            }
        }
    }
}
