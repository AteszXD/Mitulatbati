using Mitulatbati.HTML;
using Mitulatbati.SQL;
using Mitulatbati.CenterHelper;
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

            bool exit = false;
            while (!exit)
            {
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
                        int id = SelectVersenyzo(versenyzok);
                        new SQLManager().UpdateDatabase(id);
                        break;

                    case 3:
                        Console.Clear();
                        id = SelectVersenyzo(versenyzok);
                        new SQLManager().DeleteFromDatabase(id);
                        break;

                    case 4:
                        Console.Clear();
                        Console.Beep();
                        Helpers.WriteCentered("Biztosan kilép? (i/n): ");
                        if (Console.ReadKey().Key == ConsoleKey.I)
                        {
                            exit = true;
                        }
                        break;
                }

                if (!exit)
                {
                    versenyzok = new SQLManager().ReadUserDatabase();
                    versenyzok = new HTMLManager().OrderCompetitors(versenyzok);
                    new HTMLManager().GenerateHTML(versenyzok);
                }
            }
        }

        /// <summary>
        /// Műveletkiválasztó menü megjelenítése
        /// </summary>
        /// <param name="selectedOption">A jelenleg kijelölt menüpont</param>
        static void DisplayMenu(int selectedOption)
        {
            Console.Clear();
            Helpers.WriteCentered("Válasszon menüpontot:\n");
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
                Helpers.WriteCentered(menuItems[i]);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Versenyző kiválasztása a listából, menü navigációval
        /// </summary>
        /// <param name="versenyzok">A versenyzőket tároló lista</param>
        /// <returns>A kiválasztott versenyző sorszámát</returns>
        static int SelectVersenyzo(List<SQLManager> versenyzok)
        {
            int currentPoint = 1;
            bool selected = false;

            do
            {
                Console.Clear();
                Helpers.WriteCentered("Válasszon versenyzőt:\n");

                for (int i = 0; i < versenyzok.Count; i++)
                {
                    if (i + 1 == currentPoint)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Helpers.WriteCentered($"{versenyzok[i].Name} ({versenyzok[i].Legjobb_leng})");
                }
                Console.ResetColor();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        selected = true;
                        break;

                    case ConsoleKey.UpArrow:
                        if (currentPoint > 1)
                            currentPoint--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (currentPoint < versenyzok.Count)
                            currentPoint++;
                        break;
                }

            } while (!selected);

            Console.CursorVisible = true;

            return versenyzok[currentPoint - 1].Id;
        }
    }
}
