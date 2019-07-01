using System;
using System.ComponentModel;

namespace Equipment_Log{
    class Log : INotifyPropertyChanged {

        private int[] _ipads = new int[2];
        private int[] _radios = new int[2];
        private int[] _hex = new int[2];
        private int[] _pliers = new int[2];
        private int[] _batons = new int[2];
        private int[] _ugm = new int[2];
        private int[] _scc = new int[2];
        private int[] _wcl = new int[2];
        private int[] _subb = new int[2];
        private int[] _subt = new int[2];
        private int[] _ykey = new int[2];
        private int[] _skey = new int[2];
        private int[] _lot = new int[2];
        private int[] _jeep = new int[2];
        private int[] _yjackets = new int[2];
        private int[] _ojackets = new int[2];
        private int[] _raincoats = new int[2];
        private int[] _bookbags = new int[2];
        private int[] _duffelbags = new int[2];
        private string[] _flashlights= new string[2];
        private string[] _cards = new string[2];
        private string[] _slickers = new string[2];
        private string[] _vests = new string[2];
        private string[] _other = new string[2];
        private string _snum1, _snum2, _signature1, _signature2, _shift;
        private DateTime _date = DateTime.Today;

        public int IPads {
            get { return _ipads[0]; }
            set {
                if (_ipads[0] != value) {
                    _ipads[0] = value;
                    RaisePropertyChanged("IPads");
                }

            }
        }
        public int IPads2 {
            get { return _ipads[1]; }
            set {
                if (_ipads[1] != value) {
                    _ipads[1] = value;
                    RaisePropertyChanged("IPads2");
                }

            }
        }
        public int Radios {
            get { return _radios[0]; }
            set {
                if (_radios[0] != value) {
                    _radios[0] = value;
                    RaisePropertyChanged("Radios");
                }

            }
        }
        public int Radios2 {
            get { return _radios[1]; }
            set {
                if (_radios[1] != value) {
                    _radios[1] = value;
                    RaisePropertyChanged("Radios2");
                }

            }
        }
        public string Flashlights {
            get { return _flashlights[0]; }
            set {
                if (_flashlights[0] != value) {
                    _flashlights[0] = value;
                    RaisePropertyChanged("Flashlights");
                }

            }
        }
        public string Flashlights2 {
            get { return _flashlights[1]; }
            set {
                if (_flashlights[1] != value) {
                    _flashlights[1] = value;
                    RaisePropertyChanged("Flashlights2");
                }

            }
        }
        public int Hex {
            get { return _hex[0]; }
            set {
                if (_hex[0] != value) {
                    _hex[0] = value;
                    RaisePropertyChanged("Hex");
                }

            }
        }
        public int Hex2 {
            get { return _hex[1]; }
            set {
                if (_hex[1] != value) {
                    _hex[1] = value;
                    RaisePropertyChanged("Hex2");
                }

            }
        }
        public int Pliers {
            get { return _pliers[0]; }
            set {
                if (_pliers[0] != value) {
                    _pliers[0] = value;
                    RaisePropertyChanged("Pliers");
                }

            }
        }
        public int Pliers2 {
            get { return _pliers[0]; }
            set {
                if (_pliers[0] != value) {
                    _pliers[0] = value;
                    RaisePropertyChanged("Pliers2");
                }

            }
        }
        public int Batons {
            get { return _batons[0]; }
            set {
                if (_batons[0] != value) {
                    _batons[0] = value;
                    RaisePropertyChanged("Batons");
                }

            }
        }
        public int Batons2 {
            get { return _batons[1]; }
            set {
                if (_batons[1] != value) {
                    _batons[1] = value;
                    RaisePropertyChanged("Batons2");
                }

            }
        }
        public int UGM {
            get { return _ugm[0]; }
            set {
                if (_ugm[0] != value) {
                    _ugm[0] = value;
                    RaisePropertyChanged("UGM");
                }

            }
        }
        public int UGM2 {
            get { return _ugm[1]; }
            set {
                if (_ugm[1] != value) {
                    _ugm[1] = value;
                    RaisePropertyChanged("UGM2");
                }

            }
        }
        public int SCC {
            get { return _scc[0]; }
            set {
                if (_scc[0] != value) {
                    _scc[0] = value;
                    RaisePropertyChanged("SCC");
                }

            }
        }
        public int SCC2 {
            get { return _scc[1]; }
            set {
                if (_scc[1] != value) {
                    _scc[1] = value;
                    RaisePropertyChanged("SCC2");
                }

            }
        }
        public int WCL {
            get { return _wcl[0]; }
            set {
                if (_wcl[0] != value) {
                    _wcl[0] = value;
                    RaisePropertyChanged("WCL");
                }

            }
        }
        public int WCL2 {
            get { return _wcl[1]; }
            set {
                if (_wcl[1] != value) {
                    _wcl[1] = value;
                    RaisePropertyChanged("WCL2");
                }

            }
        }
        public int SUBB {
            get { return _subb[0]; }
            set {
                if (_subb[0] != value) {
                    _subb[0] = value;
                    RaisePropertyChanged("SUBB");
                }

            }
        }
        public int SUBB2 {
            get { return _subb[1]; }
            set {
                if (_subb[1] != value) {
                    _subb[1] = value;
                    RaisePropertyChanged("SUBB2");
                }

            }
        }
        public int SUBT {
            get { return _subt[0]; }
            set {
                if (_subt[0] != value) {
                    _subt[0] = value;
                    RaisePropertyChanged("SUBT");
                }

            }
        }
        public int SUBT2 {
            get { return _subt[1]; }
            set {
                if (_subt[1] != value) {
                    _subt[1] = value;
                    RaisePropertyChanged("SUBT2");
                }

            }
        }
        public int YKEY {
            get { return _ykey[0]; }
            set {
                if (_ykey[0] != value) {
                    _ykey[0] = value;
                    RaisePropertyChanged("YKEY");
                }

            }
        }
        public int YKEY2 {
            get { return _ykey[1]; }
            set {
                if (_ykey[1] != value) {
                    _ykey[1] = value;
                    RaisePropertyChanged("YKEY2");
                }

            }
        }
        public int SKEY {
            get { return _skey[0]; }
            set {
                if (_skey[0] != value) {
                    _skey[0] = value;
                    RaisePropertyChanged("SKEY");
                }

            }
        }
        public int SKEY2 {
            get { return _skey[1]; }
            set {
                if (_skey[1] != value) {
                    _skey[1] = value;
                    RaisePropertyChanged("SKEY2");
                }

            }
        }
        public int LOT {
            get { return _lot[0]; }
            set {
                if (_lot[0] != value) {
                    _lot[0] = value;
                    RaisePropertyChanged("LOT");
                }

            }
        }
        public int LOT2 {
            get { return _lot[1]; }
            set {
                if (_lot[1] != value) {
                    _lot[1] = value;
                    RaisePropertyChanged("LOT2");
                }

            }
        }
        public int JEEP {
            get { return _jeep[0]; }
            set {
                if (_jeep[0] != value) {
                    _jeep[0] = value;
                    RaisePropertyChanged("JEEP");
                }

            }
        }
        public int JEEP2 {
            get { return _jeep[1]; }
            set {
                if (_jeep[1] != value) {
                    _jeep[1] = value;
                    RaisePropertyChanged("JEEP");
                }

            }
        }
        public string Cards {
            get { return _cards[0]; }
            set {
                if (_cards[0] != value) {
                    _cards[0] = value;
                    RaisePropertyChanged("Cards");
                }

            }
        }
        public string Cards2 {
            get { return _cards[1]; }
            set {
                if (_cards[1] != value) {
                    _cards[1] = value;
                    RaisePropertyChanged("Cards2");
                }

            }
        }
        public string Slickers {
            get { return _slickers[0]; }
            set {
                if (_slickers[0] != value) {
                    _slickers[0] = value;
                    RaisePropertyChanged("Slickers");
                }

            }
        }
        public string Slickers2 {
            get { return _slickers[1]; }
            set {
                if (_slickers[1] != value) {
                    _slickers[1] = value;
                    RaisePropertyChanged("Slickers2");
                }

            }
        }
        public int YJackets {
            get { return _yjackets[0]; }
            set {
                if (_yjackets[0] != value) {
                    _yjackets[0] = value;
                    RaisePropertyChanged("YJackets");
                }

            }
        }
        public int YJackets2 {
            get { return _yjackets[1]; }
            set {
                if (_yjackets[1] != value) {
                    _yjackets[1] = value;
                    RaisePropertyChanged("YJackets2");
                }

            }
        }
        public int OJAckets {
            get { return _ojackets[0]; }
            set {
                if (_ojackets[0] != value) {
                    _ojackets[0] = value;
                    RaisePropertyChanged("OJackets");
                }

            }
        }
        public int OJAckets2 {
            get { return _ojackets[1]; }
            set {
                if (_ojackets[1] != value) {
                    _ojackets[1] = value;
                    RaisePropertyChanged("OJackets2");
                }

            }
        }
        public int Raincoats {
            get { return _raincoats[0]; }
            set {
                if (_raincoats[0] != value) {
                    _raincoats[0] = value;
                    RaisePropertyChanged("Raincoats");
                }

            }
        }
        public int Raincoats2 {
            get { return _raincoats[1]; }
            set {
                if (_raincoats[1] != value) {
                    _raincoats[1] = value;
                    RaisePropertyChanged("Raincoats2");
                }

            }
        }
        public string Vests {
            get { return _vests[0]; }
            set {
                if (_vests[0] != value) {
                    _vests[0] = value;
                    RaisePropertyChanged("Vests");
                }

            }
        }
        public string Vests2 {
            get { return _vests[1]; }
            set {
                if (_vests[1] != value) {
                    _vests[1] = value;
                    RaisePropertyChanged("Vests2");
                }

            }
        }
        public int BookBags {
            get { return _bookbags[0]; }
            set {
                if (_bookbags[0] != value) {
                    _bookbags[0] = value;
                    RaisePropertyChanged("BookBags");
                }

            }
        }
        public int BookBags2 {
            get { return _bookbags[1]; }
            set {
                if (_bookbags[1] != value) {
                    _bookbags[1] = value;
                    RaisePropertyChanged("BookBags2");
                }

            }
        }
        public int DuffelBags {
            get { return _duffelbags[0]; }
            set {
                if (_duffelbags[0] != value) {
                    _duffelbags[0] = value;
                    RaisePropertyChanged("DuffelBags");
                }

            }
        }
        public int DuffelBags2 {
            get { return _duffelbags[1]; }
            set {
                if (_duffelbags[1] != value) {
                    _duffelbags[1] = value;
                    RaisePropertyChanged("DuffelBags2");
                }

            }
        }
        public string Other {
            get { return _other[0]; }
            set {
                if (_other[0] != value) {
                    _other[0] = value;
                    RaisePropertyChanged("Other");
                }

            }
        }
        public string Other2 {
            get { return _other[1]; }
            set {
                if (_other[1] != value) {
                    _other[1] = value;
                    RaisePropertyChanged("Other2");
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
        public Boolean Submitted { get; set; } = false;

        public Log() {}
        
        public Log(Object[] b) {
            Object[] properties = { IPads, Radios, Flashlights,
                Hex, Pliers, Batons,
                UGM, SCC, WCL, SUBB, SUBT, YKEY, SKEY, LOT, JEEP,
                Cards, Slickers, YJackets, OJAckets, Raincoats, BookBags, Vests,
                Other, SNum1,Signature1 };

            for(int i = 0; i < properties.Length; i++) {
                properties[i] = b[i];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) {
            // take a copy to prevent thread issues
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string FindShift() {
            Console.WriteLine("Finding Shift");
            DateTime now = DateTime.Now;
            
            if (now.Hour >= 4 && now.Hour < 8) {
                Shift = "4am - 8am";
            }
            else if (now.Hour < 12) {
                Shift = "4am - 12pm";
            }
            else if (now.Hour < 16) {
                Shift = "12pm - 4pm";
            }
            else if (now.Hour < 20) {
                Shift = "4pm - 8pm";
            }
            else {
                Shift = "8pm - 4am";
                Console.WriteLine("Foumd Shift");
            }
            return Shift;
        }
    }
}

