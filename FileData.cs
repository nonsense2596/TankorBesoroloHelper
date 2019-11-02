using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanKorSeged_v01;

namespace TanKorSeged_v01_teszt
{
    class FileData
    {
        private string _gtb_location;
        private string _felvettek_location;
        private string _koli_location;

        public string GTB_LOCATION
        {
            get
            {
                return _gtb_location;
            }
            set
            {
                _gtb_location = value;
                //if (IsAllLoaded())
                //    _button.Enabled = true;
            }
        }
        public string FELVETTEK_LOCATION 
        {
            get
            {
                return _felvettek_location;
            }
            set
            {
                _felvettek_location = value;
                //if (IsAllLoaded())
                //    _button.Enabled = true;
            }
        }
        public string KOLI_LOCATION 
        {
            get
            {
                return _koli_location;
            }
            set
            {
                _koli_location = value;
                //if (IsAllLoaded())
                //    _button.Enabled = true;
            }
        }
        private bool IsAllLoaded()
        {
            return (this.GetType().GetProperties()
                    .Where(val => val.PropertyType == typeof(string))
                    .Select(val => (string)val.GetValue(this))
                    .All(val2 => !string.IsNullOrEmpty(val2)));
        }

        private Form1 mainForm;
        public static void Initialize(Form1 form)
        {
            theFileData = new FileData();
            theFileData.mainForm = form;
        }

        private static FileData theFileData;
        public static FileData Instance
        {
            get { return theFileData; }
        }

        public void ExDee()
        {
            /*Button asd = new Button();
            asd.Location = new System.Drawing.Point(10, 10);
            asd.Size = new System.Drawing.Size(50, 50);
            asd.Name = "faszom";
            mainForm.Controls.Add(asd);
            string faszom = "faszom";
            mainForm.Controls[faszom].Top = 200;*/
        }

        private List<Felvettek> l_felv;
        private List<Koli> l_koli;
        private List<Gtb> l_gtb;
        private List<Besorolando> l;

        public void OpenFiles()
        {
            /*for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine("lol" + i);
            }*/
            //Task<List<Felvettek>> t1 = Task<List<Felvettek>>.Factory.StartNew(() => File.ReadAllLines(FELVETTEK_LOCATION).Skip(1).Select(v => Felvettek.FromCsv(v)).ToList());
            //l_felv = t1.Result;
            l_felv = File.ReadAllLines(FELVETTEK_LOCATION).Skip(1).Select(v => Felvettek.FromCsv(v)).ToList();
            l_koli = File.ReadAllLines(KOLI_LOCATION).Skip(1).Select(v => Koli.FromCsv(v)).ToList();
            l_gtb = File.ReadAllLines(GTB_LOCATION).Skip(1).Select(v => Gtb.FromCsv(v)).ToList();

            l = (from felv in l_felv
                        join koli in l_koli on felv.Neptun equals koli.Neptun into temp
                        from koli in temp.DefaultIfEmpty()
                        join gtb in l_gtb on felv.Neptun equals gtb.Neptun into temp2
                        from gtb in temp2.DefaultIfEmpty()
                        select new Besorolando(
                            felv.Nev,
                            felv.Irsz,
                            felv.Neptun,
                            felv.Nem,
                            gtb == null ? "-" : gtb.GSzoba,
                            gtb == null ? "-" : gtb.Kartya,
                            koli == null ? -1 : koli.Szoba,
                            gtb == null ? "-" : gtb.Garda,
                            Szin.Szürke
                        ))/*.OrderByDescending(x => x.Kartya).ThenBy(y=>y.GSzoba).*/.ToList();

            List<Emelet> e = new List<Emelet>();
            e.Add(new Emelet(600, 699, Szin.Sárga, "Dr.Wu"));
            e.Add(new Emelet(700, 799, Szin.Kék, "Nyuszi"));
            e.Add(new Emelet(800, 899, Szin.Fekete, "Fekete"));
            e.Add(new Emelet(900, 999, Szin.Piros, "TTNY"));
            e.Add(new Emelet(1000, 1099, Szin.Fehér, "SIR"));

            foreach (var golya in l)
            {
                foreach (var emelet in e)
                {
                    if (Enumerable.Range(emelet.Start, emelet.End).Contains(golya.Szoba) || golya.Garda.Equals(emelet.Gardanev))
                    {
                        golya.Szin = emelet.Color;
                    }
                }
            }
            l = l.OrderByDescending(x => x.Kartya).ThenBy(y => y.GSzoba).ThenBy(z => z.Szin).ToList();


            Console.WriteLine("Nev".PadRight(30) + "\tNeptun" + "\tIrsz".PadRight(5) + "\tNem".PadRight(5) +
                              "\tKartya".PadRight(30) + "\tGtb Szoba".PadRight(30) + "\tKoli".PadRight(4) + "\tGarda".PadRight(6) + "\tSzin");
            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }
    }
}
