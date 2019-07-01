using System;
using System.Reflection;

namespace Equipment_Log {
    class LogViewModel {
        private static Log saved;
        private static DBConnector db;
        public static Log CurrentLog { get { return Log; } set { Log = value; } }
        

        internal static Log Log { get; set; }

        public LogViewModel() {
            Log = new Log();
            db = new DBConnector();
        }

        public static void Load(DateTime date, string shift) {
            if (Log.Submitted == false) {
                SaveLog();
            }

            if (saved!= null && date==saved.Date && shift == saved.Shift) {
                LoadLog(saved);
            }
            else {
                Log newLog= db.LoadLog(date,shift);
                LoadLog(newLog);
            }
            


        }
        public static void InitialLoad(DateTime date, string shift) {
            Log newLog = db.LoadLog(date, shift);
            LoadLog(newLog);
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
        public static void Submit() {
            Log.Submitted = true;
            db.UploadLog(Log);
        }

        public static string FindShift() {
            return Log.FindShift();
        }
    }
}
