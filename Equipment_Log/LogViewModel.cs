using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Equipment_Log {
    class LogViewModel : INotifyPropertyChanged{
        public CurrentLog Log { get; set; }
        public int IPads { get { return Log.IPads; } set { Log.IPads = value; } }
        public int Radios { get { return Log.Radios; } set { Log.Radios = value; } }
        public string Flashlights { get { return Log.Flashlights; } set { Log.Flashlights = value; } }
        public int Hex { get { return Log.Hex; } set { Log.Hex = value; } }
        public int Pliers { get { return Log.Pliers; } set { Log.Pliers = value; } }
        public int Batons { get { return Log.Batons; } set { Log.Batons = value; } }
        public int UGM { get { return Log.UGM; } set { Log.UGM = value; } }
        public int SCC { get { return Log.SCC; } set { Log.SCC = value; } }
        public int WCL { get { return Log.WCL; } set { Log.WCL = value; } }
        public int SUBB { get { return Log.SUBB; } set { Log.SUBB = value; } }
        public int SUBT { get { return Log.SUBT; } set { Log.SUBT = value; } }
        public int YKEY { get { return Log.YKEY; } set { Log.YKEY = value; } }
        public int SKEY { get { return Log.SKEY; } set { Log.SKEY = value; } }
        public int LOT { get { return Log.LOT; } set { Log.LOT = value; } }
        public int JEEP { get { return Log.JEEP; } set { Log.JEEP = value; } }
        public string Cards { get { return Log.Cards; } set { Log.Cards = value; } }
        public string Slickers { get { return Log.Slickers; } set { Log.Slickers = value; } }
        public int YJackets { get { return Log.YJackets; } set { Log.YJackets = value; } }
        public int OJAckets { get { return Log.OJAckets; } set { Log.OJAckets = value; } }
        public int Raincoats { get { return Log.Raincoats; } set { Log.Raincoats = value; } }
        public string Vests { get { return Log.Vests; } set { Log.Vests = value; } }
        public int BookBags { get {return Log.BookBags; } set { Log.BookBags = value; } }
        public int DuffelBags { get { return Log.DuffelBags; } set { Log.DuffelBags = value; } }
        public string Other { get { return Log.Other; } set { Log.Other = value; } }
        public DateTime Date { get { return Log.Date; } set { Log.Date = value; } }
        public string Shift { get { return Log.Shift; } set { Log.Shift = value; } }
        public string SNum1 { get { return Log.SNum1; } set { Log.SNum1 = value; } }
        public string SNum2 { get { return Log.SNum2; } set { Log.SNum2 = value; } }
        public string Signature1 { get { return Log.Signature1; } set { Log.Signature1 = value; } }
        public string Signature2 { get { return Log.Signature2; } set{Log.Signature2=value;} }

        public LogViewModel() {
            Log = new CurrentLog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Load() {

        }
        public void Submit() {

        }
    }
}
