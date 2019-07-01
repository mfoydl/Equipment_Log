using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

namespace Equipment_Log{
    class Log : INotifyPropertyChanged {

        private int _ipads, _radios, _hex, _pliers, _batons, _ugm, _scc, _wcl, _subb, _subt, _ykey, _skey, _lot, _jeep, _yjackets, _ojackets, _raincoats, _bookbags, _duffelbags = 0;
        private string _flashlights, _cards, _slickers, _vests, _other, _snum1, _snum2, _signature1, _signature2 = "";
        private string _shift;
        private DateTime _date = DateTime.Today;
        private Boolean submitted = false;
        public int IPads {
            get { return _ipads; }
            set {
                if (_ipads != value) {
                    _ipads = value;
                    RaisePropertyChanged("IPads");
                }

            }
        }
        public int Radios {
            get { return _radios; }
            set {
                if (_radios != value) {
                    _radios = value;
                    RaisePropertyChanged("Radios");
                }

            }
        }
        public string Flashlights {
            get { return _flashlights; }
            set {
                if (_flashlights != value) {
                    _flashlights = value;
                    RaisePropertyChanged("Flashlights");
                }

            }
        }
        public int Hex {
            get { return _hex; }
            set {
                if (_hex != value) {
                    _hex = value;
                    RaisePropertyChanged("Hex");
                }

            }
        }
        public int Pliers {
            get { return _pliers; }
            set {
                if (_pliers != value) {
                    _pliers = value;
                    RaisePropertyChanged("Pliers");
                }

            }
        }
        public int Batons {
            get { return _batons; }
            set {
                if (_batons != value) {
                    _batons = value;
                    RaisePropertyChanged("Batons");
                }

            }
        }
        public int UGM {
            get { return _ugm; }
            set {
                if (_ugm != value) {
                    _ugm = value;
                    RaisePropertyChanged("UGM");
                }

            }
        }
        public int SCC {
            get { return _scc; }
            set {
                if (_scc != value) {
                    _scc = value;
                    RaisePropertyChanged("SCC");
                }

            }
        }
        public int WCL {
            get { return _wcl; }
            set {
                if (_wcl != value) {
                    _wcl = value;
                    RaisePropertyChanged("WCL");
                }

            }
        }
        public int SUBB {
            get { return _subb; }
            set {
                if (_subb != value) {
                    _subb = value;
                    RaisePropertyChanged("SUBB");
                }

            }
        }
        public int SUBT {
            get { return _subt; }
            set {
                if (_subt != value) {
                    _subt = value;
                    RaisePropertyChanged("SUBT");
                }

            }
        }
        public int YKEY {
            get { return _ykey; }
            set {
                if (_ykey != value) {
                    _ykey = value;
                    RaisePropertyChanged("YKEY");
                }

            }
        }
        public int SKEY {
            get { return _skey; }
            set {
                if (_skey != value) {
                    _skey = value;
                    RaisePropertyChanged("SKEY");
                }

            }
        }
        public int LOT {
            get { return _lot; }
            set {
                if (_lot != value) {
                    _lot = value;
                    RaisePropertyChanged("LOT");
                }

            }
        }
        public int JEEP {
            get { return _jeep; }
            set {
                if (_jeep != value) {
                    _jeep = value;
                    RaisePropertyChanged("JEEP");
                }

            }
        }
        public string Cards {
            get { return _cards; }
            set {
                if (_cards != value) {
                    _cards = value;
                    RaisePropertyChanged("Cards");
                }

            }
        }
        public string Slickers {
            get { return _slickers; }
            set {
                if (_slickers != value) {
                    _slickers = value;
                    RaisePropertyChanged("Slickers");
                }

            }
        }
        public int YJackets {
            get { return _yjackets; }
            set {
                if (_yjackets != value) {
                    _yjackets = value;
                    RaisePropertyChanged("YJackets");
                }

            }
        }
        public int OJAckets {
            get { return _ojackets; }
            set {
                if (_ojackets != value) {
                    _ojackets = value;
                    RaisePropertyChanged("OJackets");
                }

            }
        }
        public int Raincoats {
            get { return _raincoats; }
            set {
                if (_raincoats != value) {
                    _raincoats = value;
                    RaisePropertyChanged("Raincoats");
                }

            }
        }
        public string Vests {
            get { return _vests; }
            set {
                if (_vests != value) {
                    _vests = value;
                    RaisePropertyChanged("Vests");
                }

            }
        }
        public int BookBags {
            get { return _bookbags; }
            set {
                if (_bookbags != value) {
                    _bookbags = value;
                    RaisePropertyChanged("BookBags");
                }

            }
        }
        public int DuffelBags {
            get { return _duffelbags; }
            set {
                if (_duffelbags != value) {
                    _duffelbags = value;
                    RaisePropertyChanged("DuffelBags");
                }

            }
        }
        public string Other {
            get { return _other; }
            set {
                if (_other != value) {
                    _other = value;
                    RaisePropertyChanged("Other");
                }

            }
        }
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
        public string SNum1 {
            get { return _snum1; }
            set { if (_snum1 != value) {
                    _snum1 = value;
                    RaisePropertyChanged("SNum1");
                }
            }
        }
        public string SNum2 {
            get { return _snum2; }
            set {
                if (_snum2 != value) {
                    _snum2 = value;
                    RaisePropertyChanged("SNum2");
                }

            }
        }
        public string Signature1 {
            get { return _signature1; }
            set {
                if (_signature1 != value) {
                    _signature1 = value;
                    RaisePropertyChanged("Signature1");
                }

            }
        }
        public string Signature2 {
            get { return _signature2; }
            set {
                if (_signature2 != value) {
                    _signature2 = value;
                    RaisePropertyChanged("Signature2");
                }

            }
        }
        public Boolean Submitted { get { return submitted; } set { submitted = value; } }

        public Log() {
            //FindShift();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void FindShift() {
            Console.WriteLine("Finding Shift");
            DateTime now = DateTime.Now;
            if (now.Hour >= 0 && now.Hour < 3) {
                Shift = "8pm - 4am";
            }
            else if (now.Hour < 7) {
                Shift = "4am - 8am";
            }
            else if (now.Hour < 11) {
                Shift = "4am - 12pm";
            }
            else if (now.Hour < 15) {
                Shift = "12pm - 4pm";
            }
            else if (now.Hour < 19) {
                Shift = "4pm - 8pm";
            }
            else {
                Shift = "8pm - 4am";
                Console.WriteLine("Foumd Shift");
            }
            Console.WriteLine("Shift=" + Shift);
        }
    }
}

