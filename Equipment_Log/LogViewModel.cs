using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Equipment_Log {
    class LogViewModel {

        public Log log;
        public Log CurrentLog { get { return log; } }
        

        public LogViewModel() {
            log = new Log();
        }

        public void Load() {

        }
        public void Submit() {

        }
    }
}
