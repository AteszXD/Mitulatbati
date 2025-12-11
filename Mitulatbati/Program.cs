using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mitulatbati.SQL;

namespace Mitulatbati
{
    internal class Program
    {
        static void Main(string[] _)
        {
            List<SQLManager> versenyzok = new SQLManager().ReadUserDatabase();
            foreach (SQLManager versenyzo in versenyzok)
            {
                Console.WriteLine($"{versenyzo.Name}, {versenyzo.Elso_leng}, {versenyzo.Masodik_leng}, {versenyzo.Harmadik_leng}, {versenyzo.Legjobb_leng}");
            }

            //Console.WriteLine("Kérem az adatokat: (Név, Első lengetés, Második lengetés, Harmadik lengetés)");
            //string[] versenyzoUj = Console.ReadLine().Split(' ');
        }
    }
}
