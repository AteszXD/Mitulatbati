using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Mitulatbati.SQL
{
    internal class SQLManager
    {
        public SQLManager(int id, string name, decimal elso_leng, decimal masodik_leng, decimal harmadik_leng, decimal legjobb_leng)
        {
            Id = id;
            Name = name;
            Elso_leng = elso_leng;
            Masodik_leng = masodik_leng;
            Harmadik_leng = harmadik_leng;
            Legjobb_leng = legjobb_leng;
        }

        public SQLManager()
        {

        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Elso_leng { get; set; }
        public decimal Masodik_leng { get; set; }
        public decimal Harmadik_leng { get; set; }
        public decimal Legjobb_leng { get; set; }

        public List<SQLManager> ReadUserDatabase()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=szelesbalas;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();

            string sql = "SELECT * FROM VERSENYZOK";
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            List<SQLManager> users = new List<SQLManager>();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                SQLManager user = new SQLManager(
                    id: reader.GetInt32("Sorszam"),
                    name: reader.GetString("Nev"),
                    elso_leng: reader.GetDecimal("Elso_leng"),
                    masodik_leng: reader.GetDecimal("Masodik_leng"),
                    harmadik_leng: reader.GetDecimal("Harmadik_leng"),
                    legjobb_leng: reader.GetDecimal("Legjobb_leng")
                    );
                users.Add(user);
            }

            connection.Close();

            return users;
        }
    }
}
