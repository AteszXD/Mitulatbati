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
            Directory.SetCurrentDirectory(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))); // Ez azért van, hogy a html fájlt a .css és .js mellé mentse
            Console.Title = "Szélesbálási Fedettpályás Kalaplengető Verseny";

            Console.WriteLine("*** MENÜ ***");
            Console.WriteLine("1. Eredményfelvétel");
            Console.WriteLine("2. Rekordmódosítás");
            Console.WriteLine("3. Eredménytörlés");
            Console.WriteLine("4. Kilépés");

            Console.Write("Kérem válasszon menüpontot: ");
            int input = int.Parse(Console.ReadLine());

            while (input < 1 || input > 4)
            {
                Console.WriteLine("Érvénytelen menüpont!");
                Console.Write("Kérem válasszon menüpontot: ");
                input = int.Parse(Console.ReadLine());
            }

            List<SQLManager> versenyzok = new SQLManager().ReadUserDatabase();

            if (input == 1)
            {
                new SQLManager().InsertIntoDatabase();
            }
            else if (input == 2)
            {
                Console.Clear();
                foreach (SQLManager versenyzo in versenyzok)
                {
                    Console.WriteLine($"{versenyzo.Id}, {versenyzo.Name}");
                }
                Console.Write("Kérem adja meg a módosítandó versenyző sorszámát: ");
                int id = int.Parse(Console.ReadLine());
                new SQLManager().UpdateDatabase(id);
            }
            else if (input == 3)
            {
                Console.Clear();
                foreach (SQLManager versenyzo in versenyzok)
                {
                    Console.WriteLine($"{versenyzo.Id}, {versenyzo.Name}");
                }
                Console.Write("Kérem adja meg a törlendő versenyző sorszámát: ");
                int id = int.Parse(Console.ReadLine());
                new SQLManager().DeleteFromDatabase(id);
            }
            else if (input == 4)
            {
                Environment.Exit(0);
            }

            versenyzok = new SQLManager().ReadUserDatabase();
            new HTMLManager().GenerateHTML(versenyzok);
        }
    }
}
