using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;


namespace DataAccess {
    public abstract class Conn {
        private readonly string connectionString;
        public Conn() {
            string server = "localhost";
            string db = "CRUD_N_CAPAS";
            string user = "root";
            string pwd = "123456";
            connectionString = $"server={server};Port={3306};database={db};Uid={user};pwd={pwd};";
        }

        protected MySqlConnection GetConnection() {
            return new MySqlConnection(connectionString);
        }
    }
}
