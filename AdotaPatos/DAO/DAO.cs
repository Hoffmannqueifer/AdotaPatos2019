using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdotaPatos.DAO {
    public class DAO {

        public static MySqlConnection GetMySqlConnection(bool open = true,
           bool convertZeroDatetime = false, bool allowZeroDatetime = false) {
            string cs = "Server=127.0.0.1;Database=projeto_ong_adota;Uid=root;Pwd=mysql23";
            var csb = new MySqlConnectionStringBuilder(cs) {
                AllowZeroDateTime = allowZeroDatetime,
                ConvertZeroDateTime = convertZeroDatetime
            };
            var conn = new MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}