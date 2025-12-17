using System;

namespace Mitulatbati.CenterHelper
{
    public static class Helpers
    {
        public static void WriteCentered(string text)
        {
            int width = Console.WindowWidth;
            int leftPadding = (width - text.Length) / 2;
            if (leftPadding < 0) leftPadding = 0;

            Console.WriteLine(new string(' ', leftPadding) + text);
        }

        public static string ReadCentered(string prompt)
        {
            int width = Console.WindowWidth;
            int leftPadding = ((width - prompt.Length) / 2) - 15; // A 15 egy általános érték (új sor miatt)
            if (leftPadding < 0) leftPadding = 0;

            Console.Write(new string(' ', leftPadding) + prompt);
            return Console.ReadLine();
        }
    }
}
