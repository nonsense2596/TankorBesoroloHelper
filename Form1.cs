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
        //FileDataReader fdr;
        List<DataGridViewSystemContainer> l = new List<DataGridViewSystemContainer>(); // EZ SEM KELL MAJD


        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }


        private void button1_Click(object sender, EventArgs e) // TODO ÁTVINNI FILEDATA-BA
        {
            //fdr.Fut();
            //Thread t = new Thread();
            for(int i = 0, j=0; i < 9; i++)
            {
                if (i % 2 == 0 && i != 0)
                    j += 2;
                DataGridViewKai dgvk1 = new DataGridViewKai();
                dgvk1.Size = new Size(950, 150);
                //dgvk1.Location = new Point(50, 100);
                dgvk1.Location = new Point(((i%2)*1000)+50,(j*150)+50);
                //dgvk1.Columns.Add("asd", "asd");
                //dgvk1.Columns.Add("lol", "lol");
                //dgvk1.Columns.Add("kek", "kek");
                //dgvk1.Columns.Add("bur", "bur");
                //dgvk1.Columns.Add("baz", "baz");
                dgvk1.Columns.Add("nev", "név");
                dgvk1.Columns.Add("neptun", "Neptun");
                dgvk1.Columns.Add("irsz", "Irsz.");
                dgvk1.Columns.Add("nem", "Nem");
                dgvk1.Columns.Add("kartya", "Kártya");
                dgvk1.Columns.Add("szoba", "Szoba");
                dgvk1.Columns.Add("emelet", "Emelet");
                dgvk1.Columns.Add("garda", "Gárda");
                dgvk1.Columns.Add("szin", "Szín");  // 9 rows total
                dgvk1.Rows.Add("asd", "lol", "kek", "bur", "baz", "baz2", "baz3","baz4", "baz5");
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

                //l.Add(new DataGridViewSystemContainer(dgvk1, dgv_e_h, dgv_e_v, dgv_e_c, dgv_m));
            }

        }

        private async void button6_Click(object sender, EventArgs e)  // TESZT CUCC
        {


            Task t = new Task(FileData.Instance.OpenFiles);
            t.Start();
            await t;

        }

        private void loadGTBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Add gtb.csv file";
            openFileDialog1.ShowHelp = true; // TEMP LOL MERT GYORSABB
            openFileDialog1.ShowDialog();
            //GTB_LOCATION = openFileDialog1.FileName;
            if (File.Exists(openFileDialog1.FileName))
            {
                FileData.Instance.GTB_LOCATION = openFileDialog1.FileName;
                
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
                FileData.Instance.FELVETTEK_LOCATION = openFileDialog1.FileName;
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
                FileData.Instance.KOLI_LOCATION = openFileDialog1.FileName;
                Console.WriteLine("KOLI_LOCATION successfully validated.");
            }
            toolStripTextBox3.Text = openFileDialog1.SafeFileName;
        }

        private void noPerson_TextChanged(object sender, EventArgs e)
        {
            int num;
            if(Int32.TryParse(noPerson.Text, out num))
            {
                FileData.Instance.NUM_OF_PERSON = num;
            }
        }

        private void noTankor_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (Int32.TryParse(noTankor.Text, out num))
            {
                FileData.Instance.NUM_OF_TANKOR = num;
            }
        }
    }
}
