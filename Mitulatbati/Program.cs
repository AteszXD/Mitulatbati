using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mitulatbati.SQL;
using Mitulatbati.HTML;

namespace Mitulatbati
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Console.Title = "Szélesbálási Fedettpályás Kalaplengető Verseny";

            new SQLManager().InsertIntoDatabase();
            List<SQLManager> versenyzok = new SQLManager().ReadUserDatabase();

            foreach (SQLManager versenyzo in versenyzok)
            {
                Console.WriteLine($"{versenyzo.Name}, {versenyzo.Elso_leng}, {versenyzo.Masodik_leng}, {versenyzo.Harmadik_leng}");
            }

            new HTMLManager().GenerateHTML(versenyzok);
        }
    }
}
