using System;
using System.Collections.Generic;
using System.Drawing;
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
        private int _num_of_person = 0;
        private int _num_of_tankor = 0;

        public string GTB_LOCATION
        {
            get
            {
                return _gtb_location;
            }
            set
            {
                _gtb_location = value;
                IsAllLoaded();
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
                IsAllLoaded();
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
                IsAllLoaded();
            }
        }
        public int NUM_OF_PERSON
        {
            get
            {
                return _num_of_person;
            }
            set
            {
                _num_of_person = value;
                IsAllLoaded();
            }
        }
        public int NUM_OF_TANKOR
        {
            get
            {
                return _num_of_tankor;
            }
            set
            {
                _num_of_tankor = value;
                IsAllLoaded();
            }
        }

        private void IsAllLoaded()
        {

            if (_gtb_location!=null && _felvettek_location!=null && _koli_location!=null && _num_of_person!=0 && _num_of_tankor != 0)
            {
                mainForm.Controls["startButton"].Enabled = true;
            }
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

        }

        private List<Felvettek> l_felv;
        private List<Koli> l_koli;
        private List<Gtb> l_gtb;
        private List<Besorolando> l;
        public List<Besorolando_temp> toadd_temp = new List<Besorolando_temp>();

        public void OpenFiles()
        {
            // temp TODO
            GTB_LOCATION = "D:\\Documents\\hk\\tesztadatok\\gtb.csv";
            FELVETTEK_LOCATION = "D:\\Documents\\hk\\tesztadatok\\info.csv";
            KOLI_LOCATION = "D:\\Documents\\hk\\tesztadatok\\koli.csv";


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
                        ))/*.OrderByDescending(y => y.Kartya).ThenBy(z=>z.GSzoba)*/.ToList();

            List<Emelet> e = new List<Emelet>() {
                                                    new Emelet(600, 699, Szin.Sárga, "Dr.Wu"),
                                                    new Emelet(700, 799, Szin.Kék, "Nyuszi"),
                                                    new Emelet(800, 899, Szin.Fekete, "Fekete"),
                                                    new Emelet(900, 999, Szin.Piros, "TTNY"),
                                                    new Emelet(1000, 1099, Szin.Fehér, "SIR")};

            // itt vannak elrendezve csoportok alapjan
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

            // kellene group by szin alapjan

            var teszt = l.GroupBy(x => x.Garda).Select(grp => grp.ToList()).ToList();//.OrderByDescending(x => x.Kartya).ThenBy(y => y.GSzoba).ThenBy(z => z.Szin).ToList();

            List<Besorolando> l2 = new List<Besorolando>();
            foreach (var item in teszt)
            {
                foreach (var item2 in item)
                {
                    l2.Add(item2);
                    //Console.WriteLine(item2);
                }
            }
            foreach (var item in l2)
            {
                Console.WriteLine(item);
            }


            // TODO itt kellene valahogyan a megadott szamu tankorbe szetrobbantani a tombot

            // 1st section: megcsinalunk minden szinbol legalabb egy fix tankort
            //List<Besorolando> kek_fix = new List<Besorolando>();
            //List<Besorolando> feher_fix = new List<Besorolando>();
            //List<Besorolando> piros_fix = new List<Besorolando>();
            //List<Besorolando> sarga_fix = new List<Besorolando>();
            //List<Besorolando> fekete_fix = new List<Besorolando>();
            //List<Besorolando> maradek = new List<Besorolando>();

            toadd_temp = new List<Besorolando_temp>();
            List<Besorolando> toadd_temp_rest = new List<Besorolando>();
            foreach (var item in l2)
            {
                switch (item.Garda)
                {
                    case "Nyuszi":  // kek
                        toadd_temp.Add(new Besorolando_temp(item,0));
                        break;
                    case "SIR":     // feher
                        toadd_temp.Add(new Besorolando_temp(item, 1));
                        break;
                    case "TTNY":    // piros
                        toadd_temp.Add(new Besorolando_temp(item, 2));
                        break;
                    case "Dr.Wu":   // sarga
                        toadd_temp.Add(new Besorolando_temp(item, 3));
                        break;
                    case "Fekete":  // fekete
                        toadd_temp.Add(new Besorolando_temp(item, 4));
                        break;
                    default:        // the rest
                        toadd_temp_rest.Add(item);
                        break;
                }
            }
            // process the rest, and add them to toadd_temp







        }
    }
}
