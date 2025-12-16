using Mitulatbati.HTML;
using Mitulatbati.SQL;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mitulatbati
{
    internal class Program
    {
        static void Main(string[] _)
        {
            Directory.SetCurrentDirectory(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"))); // Ez azért van, hogy a html fájlt a .css és .js mellé mentse
            Console.Title = "Szélesbálási Fedettpályás Kalaplengető Verseny";

            int currentPoint = 1;
            bool selected = false;
            do
            {
                DisplayMenu(currentPoint);
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                    case ConsoleKey.UpArrow:
                        if (currentPoint > 1)
                        {
                            currentPoint -= 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            if (currentPoint < 4)
                                currentPoint += 1;
                        }
                        break;
                }
            } while (!selected);

            List<SQLManager> versenyzok = new SQLManager().ReadUserDatabase();

            switch (currentPoint)
            {
                case 1:
                    new SQLManager().InsertIntoDatabase();
                    break;

                case 2:
                    Console.Clear();
                    foreach (SQLManager versenyzo in versenyzok)
                    {
                        Console.WriteLine($"{versenyzo.Id}, {versenyzo.Name}");
                    }
                    Console.Write("Kérem adja meg a módosítandó versenyző sorszámát: ");
                    int updateId = int.Parse(Console.ReadLine());
                    new SQLManager().UpdateDatabase(updateId);
                    break;

                case 3:
                    Console.Clear();
                    foreach (SQLManager versenyzo in versenyzok)
                    {
                        Console.WriteLine($"{versenyzo.Id}, {versenyzo.Name}");
                    }
                    Console.Write("Kérem adja meg a törlendő versenyző sorszámát: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    new SQLManager().DeleteFromDatabase(deleteId);
                    break;

                case 4:
                    Console.Clear();
                    Console.Beep();
                    Console.Write("Biztosan kilép? (i/n): ");
                    if (Console.ReadKey().Key != ConsoleKey.I)
                    {
                        currentPoint = 1;
                    }
                    break;
            }

            versenyzok = new SQLManager().ReadUserDatabase();
            versenyzok = new HTMLManager().OrderCompetitors(versenyzok);
            new HTMLManager().GenerateHTML(versenyzok);
        }

        static void DisplayMenu(int selectedOption)
        {
            Console.Clear();
            string[] menuItems = { "1. Eredményfelvétel", "2. Rekordmódosítás", "3. Eredménytörlés", "4. Kilépés" };

            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i + 1 == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine(menuItems[i]);
            }
            Console.ResetColor();
        }
    }
}
