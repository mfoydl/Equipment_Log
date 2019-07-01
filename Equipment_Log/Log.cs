using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Log{
    class Log : INotifyPropertyChanged {

        private int _ipads, _radios, _hex, _pliers, _batons, _ugm, _scc, _wcl, _subb, _subt, _ykey, _skey, _lot, _jeep, _yjackets, _ojackets, _raincoats, _bookbags, _duffelbags = 0;
        private string _flashlights, _cards, _slickers, _vests, _other, _snum1, _snum2, _signature1, _signature2 = "";
        private string _shift = "Shift...";
        private DateTime _date = DateTime.Today;
        private Boolean submitted = false;
        public int IPads { get { return _ipads; } set { _ipads = value; } }
        public int Radios { get { return _radios; } set { _radios = value; } }
        public string Flashlights { get { return _flashlights; } set { _flashlights = value; } }
        public int Hex { get { return _hex; } set { _hex = value; } }
        public int Pliers { get { return _pliers; } set { _pliers = value; } }
        public int Batons { get { return _batons; } set { _batons = value; } }
        public int UGM { get { return _ugm; } set { _ugm = value; } }
        public int SCC { get { return _scc; } set { _scc = value; } }
        public int WCL { get { return _wcl; } set { _wcl = value; } }
        public int SUBB { get { return _subb; } set { _subb = value; } }
        public int SUBT { get { return _subt; } set { _subt = value; } }
        public int YKEY { get { return _ykey; } set {_ykey = value; } }
        public int SKEY { get { return _skey; } set { _skey = value; } }
        public int LOT { get { return _lot; } set { _lot = value; } }
        public int JEEP { get { return _jeep; } set { _jeep = value; } }
        public string Cards { get { return _cards; } set { _cards = value; } }
        public string Slickers { get { return _slickers; } set { _slickers = value; } }
        public int YJackets { get { return _yjackets; } set { _yjackets = value; } }
        public int OJAckets { get { return _ojackets; } set { _ojackets = value; } }
        public int Raincoats { get { return _raincoats; } set { _raincoats = value; } }
        public string Vests { get { return _vests; } set { _vests = value; } }
        public int BookBags { get { return _bookbags; } set { _bookbags = value; } }
        public int DuffelBags { get { return _duffelbags; } set { _duffelbags = value; } }
        public string Other { get { return _other; } set { _other = value; } }
        public DateTime Date {
            get { return _date; }
            set {
                if (_date != value) {
                    _date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }
        public string Shift {
            get { return _shift; }
            set {
                if (_shift != value) {
                    _shift = value;
                    RaisePropertyChanged("Shift");
                }
            }
        }
        public string SNum1 { get { return _snum1; } set { _snum1 = value; } }
        public string SNum2 { get { return _snum2; } set { _snum2 = value; } }
        public string Signature1 { get { return _signature1; } set { _signature1 = value; } }
        public string Signature2 { get { return _signature2; } set { _signature2 = value; } }
        public Boolean Submitted { get { return submitted; } set { submitted = value; } }

        public Log() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

