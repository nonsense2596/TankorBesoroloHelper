using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanKorSeged_v01
{
    public partial class Dgv_Mover : System.Windows.Forms.Panel
    {
        public DataGridView Dgv { get; set; }
        public Dgv_Exp_Horizontal Dgv_e_h { get; set; }
        public Dgv_Exp_Vertical Dgv_e_v { get; set; }
        public Dgv_Exp_Combined Dgv_e_c { get; set; }

        private Point MouseDownLocation;

        public Dgv_Mover(DataGridView dgv)
        {
            Dgv = dgv;
            this.Size = new Size(10, 10);
            this.BackColor = Color.Red;
            InitializeComponent();
        }

        private void PanelKai_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownLocation = e.Location;
        }
        private void PanelKai_MouseMove(object sender, MouseEventArgs e)
        {
            timer1.Interval = 1;
            if (timer1.Enabled)
                timer1.Stop();
            
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssFFF"));
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left){
                this.Left = e.X + this.Left - MouseDownLocation.X;
                Dgv.Left = e.X + Dgv.Left - MouseDownLocation.X;
                Dgv_e_h.Left = e.X + Dgv_e_h.Left - MouseDownLocation.X;
                Dgv_e_v.Left = e.X + Dgv_e_v.Left - MouseDownLocation.X;
                Dgv_e_c.Left = e.X + Dgv_e_c.Left - MouseDownLocation.X;

                this.Top = e.Y + this.Top - MouseDownLocation.Y;               
                Dgv.Top = e.Y + Dgv.Top - MouseDownLocation.Y;
                Dgv_e_h.Top = e.Y + Dgv_e_h.Top - MouseDownLocation.Y;
                Dgv_e_v.Top = e.Y + Dgv_e_v.Top - MouseDownLocation.Y;
                Dgv_e_c.Top = e.Y + Dgv_e_c.Top - MouseDownLocation.Y;


            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("lol");
        }

        private void Dgv_Mover_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }
    }
}
