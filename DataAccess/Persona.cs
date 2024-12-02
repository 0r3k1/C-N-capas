using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using Common;


namespace DataAccess {
    public class Persona:Conn {

        public DataTable listarPersonas() {
            DataTable dt = new DataTable();
            using (var connection = GetConnection()) {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Personas;", connection)) {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 60;

                    using (MySqlDataReader reader = command.ExecuteReader()) {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }

        public bool agregarPersona(DPersona persona) {
            bool exito = false;

            using(var connection = GetConnection()) {
                connection.Open();
                using(var command = new MySqlCommand("INSERT INTO Personas(Nombre, Apellido, Sexo) VALUES(@Nombre, @Apellido, @Sexo);", connection)) {
                    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    command.Parameters.AddWithValue("@Sexo", persona.Sexo);

                    int filasAfectadas = command.ExecuteNonQuery();
                    exito = filasAfectadas > 0;
                }
            }


            return exito;
        }

        public bool eliminarPersona(int id) {
            bool exito = false;

            using(var connection = GetConnection()) {
                connection.Open();
                using(var command = new MySqlCommand("DELETE FROM Personas WHERE ID = @ID;", connection)) {
                    command.Parameters.AddWithValue("@ID", id);

                    int filsAfectadas = command.ExecuteNonQuery();
                    exito = filsAfectadas > 0;
                }
            }

            return exito;
        }

        public bool editarPersona(DPersona persona) {
            bool exito = false;
            using(var connection = GetConnection()) {
                connection.Open();
                using(var command = new MySqlCommand("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, Sexo = @Sexo WHERE ID = @ID;", connection)) {
                    command.Parameters.AddWithValue("@ID", persona.ID);
                    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    command.Parameters.AddWithValue("@Sexo", persona.Sexo);

                    int filasAfectadas = command.ExecuteNonQuery();
                    exito = filasAfectadas > 0;
                }
            }

            return exito;
        }
    }
}
