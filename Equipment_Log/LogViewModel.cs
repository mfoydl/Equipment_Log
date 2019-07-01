using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Equipment_Log {
    class LogViewModel {
        private static Log saved;
        public static Log CurrentLog { get { return Log; } set { Log = value; } }

        internal static Log Log { get; set; }

        public LogViewModel() {
            Log = new Log();
        }

        public static Boolean Load(DateTime date, string shift) {
            if (Log.Submitted == false) {
                SaveLog();
            }

            if (date==saved.Date && shift == saved.Shift) {
                LoadLog(saved);
                return false;
            }
            else {
                //Load new log from database
                return true;
            }
            


        }
        private static void SaveLog() {
            saved = new Log();

            Type typeSource = saved.GetType();

            object objTarget = saved;

            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);



            //Assign all source property to taget object 's properties

            foreach (PropertyInfo property in propertyInfo) {
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String))) {

                    property.SetValue(objTarget, property.GetValue(Log, null), null);

                }
            }
        }
        private static void LoadLog(Log newLog) {
            Type typeSource = newLog.GetType();

            object objTarget = Log;

            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);



            //Assign all source property to taget object 's properties

            foreach (PropertyInfo property in propertyInfo) {
                if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String))) {

                    property.SetValue(objTarget, property.GetValue(newLog, null), null);

                }
            }
        }
        public void Submit() {

        }

        public static void FindShift() {
            Log.FindShift();
        }
    }
}
