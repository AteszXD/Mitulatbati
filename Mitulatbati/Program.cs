using Mitulatbati.HTML;
using Mitulatbati.SQL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitulatbati
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Directory.SetCurrentDirectory(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\")));
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
