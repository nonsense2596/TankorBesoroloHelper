using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanKorSeged_v01_teszt
{
    class FileDataReader
    {
        private string _gtb_location;
        private string _felvettek_location;
        private string _koli_location;
        Button _button;

        public string GTB_LOCATION
        {
            get
            {
                return _gtb_location;
            }
            set
            {
                _gtb_location = value;
                if (IsAllLoaded())
                    _button.Enabled = true;
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
                if (IsAllLoaded())
                    _button.Enabled = true;
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
                if (IsAllLoaded())
                    _button.Enabled = true;
            }
        }
        private bool IsAllLoaded()
        {
            return (this.GetType().GetProperties()
                    .Where(val => val.PropertyType == typeof(string))
                    .Select(val => (string)val.GetValue(this))
                    .All(val2 => !string.IsNullOrEmpty(val2)));
        }


        public FileDataReader(Button b)
        {
            _button = b;
        } 

    }
}
