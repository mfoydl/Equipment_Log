using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Log {
    class DBConnector {
        private string connStr = "server=localhost;user=root;database=new_schema;port=3306;password=Opcenter5!";
        public DBConnector() {
        
            
        }
        public Log LoadLog(DateTime date, string shift) {
            Log log= new Log();
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sdate = date.ToString("yyyy-MM-dd HH:mm:ss");
                string sql = $"SELECT * FROM shift_begin WHERE date='{sdate}' AND shift='{shift}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) {
                    rdr.Read();

                    log.Date = (DateTime)rdr[0];
                    log.Shift = (string)rdr[1];
                    log.Radios = (int)rdr[2];
                    log.IPads = (int)rdr[3];
                    log.Flashlights = (string)rdr[4];
                    log.Hex = (int)rdr[5];
                    log.Pliers = (int)rdr[6];
                    log.Batons = (int)rdr[7];
                    log.UGM = (int)rdr[8];
                    log.SCC = (int)rdr[9];
                    log.WCL = (int)rdr[10];
                    log.SUBB = (int)rdr[11];
                    log.SUBT = (int)rdr[12];
                    log.YKEY = (int)rdr[13];
                    log.SKEY = (int)rdr[14];
                    log.LOT = (int)rdr[15];
                    log.JEEP = (int)rdr[16];
                    log.Cards = (string)rdr[17];
                    log.Slickers = (string)rdr[18];
                    log.YJackets = (int)rdr[19];
                    log.OJAckets = (int)rdr[20];
                    log.Raincoats = (int)rdr[21];
                    log.Vests = (string)rdr[22];
                    log.BookBags = (int)rdr[23];
                    log.DuffelBags = (int)rdr[24];
                    log.Other = (string)rdr[25];
                    log.SNum1 = (string)rdr[26];
                    log.Signature1 = (string)rdr[27];
                    log.Submitted = true;
                }
                else {
                    return new Log {
                        Date = date,
                        Shift = shift,
                        Submitted = true
                    };
                }
               
                rdr.Close();

                sql = $"SELECT * FROM shift_end WHERE date='{sdate}' AND shift='{shift}'";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows) {
                    rdr.Read();

                    log.Radios2 = (int)rdr[2];
                    log.IPads2 = (int)rdr[3];
                    log.Flashlights2 = (string)rdr[4];
                    log.Hex2 = (int)rdr[5];
                    log.Pliers2 = (int)rdr[6];
                    log.Batons2 = (int)rdr[7];
                    log.UGM2 = (int)rdr[8];
                    log.SCC2 = (int)rdr[9];
                    log.WCL2 = (int)rdr[10];
                    log.SUBB2 = (int)rdr[11];
                    log.SUBT2 = (int)rdr[12];
                    log.YKEY2 = (int)rdr[13];
                    log.SKEY2 = (int)rdr[14];
                    log.LOT2 = (int)rdr[15];
                    log.JEEP2 = (int)rdr[16];
                    log.Cards2 = (string)rdr[17];
                    log.Slickers2 = (string)rdr[18];
                    log.YJackets2 = (int)rdr[19];
                    log.OJAckets2 = (int)rdr[20];
                    log.Raincoats2 = (int)rdr[21];
                    log.Vests2 = (string)rdr[22];
                    log.BookBags2 = (int)rdr[23];
                    log.DuffelBags2 = (int)rdr[24];
                    log.Other2 = (string)rdr[25];
                    log.SNum2 = (string)rdr[26];
                    log.Signature2 = (string)rdr[27];
                    log.Submitted = true;
                }
                else {
                    return new Log {
                        Date = date,
                        Shift = shift,
                        Submitted = true
                    };
                }

                rdr.Close();


            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            return log;
        }
            
        public void UploadLog(Log log) {
            string sql = $"INSERT INTO shift_begin (date, shift, ipads, radios, flashlights, hex, pliers, batons, " +
                $"ugm, scc, wcl, subb, subt, ykey, skey, lot, jeep, cards, slickers, yjackets, ojackets, raincoats" +
                $", vests, bookbags, duffelbags, other, snum, signature) VALUES " +
                $"('{log.Date.ToString("yyyy-MM-dd HH:mm:ss")}','{log.Shift}','{log.Radios}','{log.IPads}','{log.Flashlights}'," +
                $"'{log.Hex}','{log.Pliers}','{log.Batons}','{log.UGM}','{log.SCC}','{log.WCL}','{log.SUBB}','{log.SUBT}','{log.YKEY}'," +
                $"'{log.SKEY}','{log.LOT}','{log.JEEP}','{log.Cards}','{log.Slickers}','{log.YJackets}','{log.OJAckets}','{log.Raincoats}'," +
                $"'{log.Vests}','{log.BookBags}','{log.DuffelBags}','{log.Other}','{log.SNum1}','{log.Signature1}')";

            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            sql = $"INSERT INTO shift_end (date, shift, ipads, radios, flashlights, hex, pliers, batons, " +
                $"ugm, scc, wcl, subb, subt, ykey, skey, lot, jeep, cards, slickers, yjackets, ojackets, raincoats" +
                $", vests, bookbags, duffelbags, other, snum, signature) VALUES " +
                $"('{log.Date.ToString("yyyy-MM-dd HH:mm:ss")}','{log.Shift}','{log.Radios2}','{log.IPads2}','{log.Flashlights2}'," +
                $"'{log.Hex2}','{log.Pliers2}','{log.Batons2}','{log.UGM2}','{log.SCC2}','{log.WCL2}','{log.SUBB2}','{log.SUBT2}','{log.YKEY2}'," +
                $"'{log.SKEY2}','{log.LOT2}','{log.JEEP2}','{log.Cards2}','{log.Slickers2}','{log.YJackets2}','{log.OJAckets2}','{log.Raincoats2}'," +
                $"'{log.Vests2}','{log.BookBags2}','{log.DuffelBags2}','{log.Other2}','{log.SNum2}','{log.Signature2}')";

            try {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }
        
    }
}
