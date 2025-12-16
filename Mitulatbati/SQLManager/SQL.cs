using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization; // Szóval hu-HU miatt vesszőt vár a decimal.Parse? Az baráti...

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

        /// <summary>
        /// Beolvassa a versenyzőket az SQL-ből és visszaadja őket egy listában
        /// </summary>
        /// <returns>A versenyzőket tartalmazó listát</returns>
        public List<SQLManager> ReadUserDatabase()
        {
            MySqlConnection connection = EstablishConnection();

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

        /// <summary>
        /// Versenyző adatainak bekérése és beszúrása az adatbázisba
        /// </summary>
        public void InsertIntoDatabase()
        {
            Console.Clear();
            Console.WriteLine("Kérem az adatokat: (Név, Első lengetés, Második lengetés, Harmadik lengetés)");
            string[] versenyzoUj = Console.ReadLine().Split(',');
            for (int i = 0; i < versenyzoUj.Length; i++)
            {
                versenyzoUj[i] = versenyzoUj[i].TrimStart(' ');
            }

            MySqlConnection connection = EstablishConnection();

            string insertSQL = "INSERT INTO `versenyzok` (`Sorszam`, `Nev`, `Elso_leng`, `Masodik_leng`, `Harmadik_leng`) VALUES (null,@nev,@elso_leng,@masodik_leng,@harmadik_leng)";
            MySqlCommand command = new MySqlCommand(insertSQL, connection);
            command.Parameters.AddWithValue("@nev", versenyzoUj[0]);
            command.Parameters.AddWithValue("@elso_leng", decimal.Parse(versenyzoUj[1], CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("@masodik_leng", decimal.Parse(versenyzoUj[2], CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("@harmadik_leng", decimal.Parse(versenyzoUj[3], CultureInfo.InvariantCulture));
            int sorok = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorok > 0 ? "A versenyzőt sikeresen rögzítette" : "Hiba történt";
            Console.WriteLine(valasz);
        }

        /// <summary>
        /// A megadott sorszámú versenyző adatainak módosítása az adatbázisban
        /// </summary>
        /// <param name="id">A sorszám</param>
        public void UpdateDatabase(int id)
        {
            Console.Clear();
            Console.WriteLine("Kérem az adatokat: (Név, Első lengetés, Második lengetés, Harmadik lengetés)");
            string[] versenyzoUj = Console.ReadLine().Split(',');
            for (int i = 0; i < versenyzoUj.Length; i++)
            {
                versenyzoUj[i] = versenyzoUj[i].TrimStart(' ');
            }

            MySqlConnection connection = EstablishConnection();

            string updateSQL = "UPDATE `versenyzok` SET Sorszam=@id,Nev=@nev,Elso_leng=@elso_leng,Masodik_leng=@masodik_leng,Harmadik_leng=@harmadik_leng WHERE Sorszam=@id";
            MySqlCommand command = new MySqlCommand(updateSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nev", versenyzoUj[0]);
            command.Parameters.AddWithValue("@elso_leng", decimal.Parse(versenyzoUj[1], CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("@masodik_leng", decimal.Parse(versenyzoUj[2], CultureInfo.InvariantCulture));
            command.Parameters.AddWithValue("@harmadik_leng", decimal.Parse(versenyzoUj[3], CultureInfo.InvariantCulture));
            int sorok = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorok > 0 ? "Sikeres módosítás" : "Hiba történt";
            Console.WriteLine(valasz);
        }

        /// <summary>
        /// A megadott sorszámú versenyző törlése az adatbázisból
        /// </summary>
        /// <param name="id">A sorszám</param>
        public void DeleteFromDatabase(int id)
        {
            MySqlConnection connection = EstablishConnection();

            string deleteSQL = "DELETE FROM `versenyzok` WHERE Sorszam=@id";
            MySqlCommand command = new MySqlCommand(deleteSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            int sorok = command.ExecuteNonQuery();
            connection.Close();

            string valasz = sorok > 0 ? "Sikeres törlés" : "Hiba történt";
            Console.WriteLine(valasz);
        }

        /// <summary>
        /// Létrehozza a MySQL kapcsolatot és visszaadja azt
        /// </summary>
        /// <returns>A MySQL kapcsolatot</returns>
        MySqlConnection EstablishConnection()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=szelesbalas;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }
    }
}
