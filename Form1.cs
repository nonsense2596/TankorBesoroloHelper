using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanKorSeged_v01_teszt;

namespace TanKorSeged_v01
{
    
    public partial class Form1 : Form
    {
        //string GTB_LOCATION, FELVETTEK_LOCATION, KOLI_LOCATION;
        FileDataReader fdh;
        List<DataGridViewSystemContainer> l = new List<DataGridViewSystemContainer>();
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // teszt
            fdh = new FileDataReader(button1);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread();
            /*for(int i = 0, j=0; i < 9; i++)
            {
                if (i % 2 == 0 && i != 0)
                    j += 2;
                DataGridViewKai dgvk1 = new DataGridViewKai();
                dgvk1.Size = new Size(600, 150);
                //dgvk1.Location = new Point(50, 100);
                dgvk1.Location = new Point(((i%2)*700)+100,(j*150)+50);
                dgvk1.Columns.Add("asd", "asd");
                dgvk1.Columns.Add("lol", "lol");
                dgvk1.Columns.Add("kek", "kek");
                dgvk1.Columns.Add("bur", "bur");
                dgvk1.Columns.Add("baz", "baz");
                dgvk1.Rows.Add("asd", "lol", "kek", "bur", "baz");
                dgvk1.AllowUserToAddRows = true;
                panel1.Controls.Add(dgvk1);

                Dgv_Exp_Horizontal dgv_e_h = new Dgv_Exp_Horizontal(dgvk1);
                dgv_e_h.Cursor = Cursors.SizeWE;
                dgv_e_h.Width = 10;
                dgv_e_h.Height = dgvk1.Height;
                //dgv_e_h.Location = new Point(250, 100);
                dgv_e_h.Location = new Point(dgvk1.Left+dgvk1.Width,dgvk1.Top);
                panel1.Controls.Add(dgv_e_h);

                Dgv_Exp_Vertical dgv_e_v = new Dgv_Exp_Vertical(dgvk1);
                dgv_e_v.Cursor = Cursors.SizeNS;
                dgv_e_v.Width = dgvk1.Width;
                dgv_e_v.Height = 10;
                //dgv_e_v.Location = new Point(50, 200);
                dgv_e_v.Location = new Point(dgvk1.Left,dgvk1.Top+dgvk1.Height);
                panel1.Controls.Add(dgv_e_v);

                Dgv_Mover dgv_m = new Dgv_Mover(dgvk1);
                dgv_m.Cursor = Cursors.SizeAll;
                //dgv_m.Location = new Point(40, 90);
                dgv_m.Location = new Point(dgvk1.Left-10,dgvk1.Top-10);
                panel1.Controls.Add(dgv_m);

                Dgv_Exp_Combined dgv_e_c = new Dgv_Exp_Combined(dgvk1);
                dgv_e_c.Cursor = Cursors.SizeAll;
                //dgv_e_c.Location = new Point(250, 200);
                dgv_e_c.Location = new Point(dgvk1.Left+dgvk1.Width,dgvk1.Top+dgvk1.Height);
                panel1.Controls.Add(dgv_e_c);

                dgv_e_h.Dgv = dgvk1;
                dgv_e_h.Dgv_e_v = dgv_e_v;
                dgv_e_h.Dgv_e_c = dgv_e_c;
                dgv_e_h.Dgv_m = dgv_m;

                dgv_e_v.Dgv = dgvk1;
                dgv_e_v.Dgv_e_h = dgv_e_h;
                dgv_e_v.Dgv_e_c = dgv_e_c;
                dgv_e_v.Dgv_m = dgv_m;

                dgv_e_c.Dgv = dgvk1;
                dgv_e_c.Dgv_e_h = dgv_e_h;
                dgv_e_c.Dgv_e_v = dgv_e_v;
                dgv_e_c.Dgv_m = dgv_m;

                dgv_m.Dgv = dgvk1;
                dgv_m.Dgv_e_h = dgv_e_h;
                dgv_m.Dgv_e_v = dgv_e_v;
                dgv_m.Dgv_e_c = dgv_e_c;

                l.Add(new DataGridViewSystemContainer(dgvk1, dgv_e_h, dgv_e_v, dgv_e_c, dgv_m));
            }*/

        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (var item in l)
            {
                for(int i = 0; i < item.Dgvk.Rows.Count; i++)
                {
                    Console.WriteLine(item.Dgvk.Rows[i].Cells[0].Value);
                }
            }
        }

        private void loadGTBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Add gtb.csv file";
            openFileDialog1.ShowHelp = true; // TEMP LOL MERT GYORSABB
            openFileDialog1.ShowDialog();
            //GTB_LOCATION = openFileDialog1.FileName;
            if (File.Exists(openFileDialog1.FileName))
            {
                fdh.GTB_LOCATION = openFileDialog1.FileName;
                Console.WriteLine("GTB_LOCATION successfully validated.");
            }

            toolStripTextBox1.Text = openFileDialog1.SafeFileName;
        }

        private void loadFelvettekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Add felvettek.csv file";
            openFileDialog1.ShowHelp = true; // TEMP LOL MERT GYORSABB
            openFileDialog1.ShowDialog();
           if (File.Exists(openFileDialog1.FileName))
            {
                fdh.FELVETTEK_LOCATION = openFileDialog1.FileName;
                Console.WriteLine("FELVETTEK_LOCATION successfully validated.");
            }
            toolStripTextBox2.Text = openFileDialog1.SafeFileName;
        }

        private void loadKoliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Add koli.csv file";
            openFileDialog1.ShowHelp = true; // TEMP LOL MERT GYORSABB
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                fdh.KOLI_LOCATION = openFileDialog1.FileName;
                Console.WriteLine("KOLI_LOCATION successfully validated.");
            }
            toolStripTextBox3.Text = openFileDialog1.SafeFileName;
        }
    }
}
