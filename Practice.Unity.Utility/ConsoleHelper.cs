using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Utility
{
    public static class ConsoleHelper
    {
        public static void  WriteGreenLine(string s)
        {
            WriteLine(s, ConsoleColor.Green);
        }

        public static void WriteCyanLine(string s)
        {
            WriteLine(s, ConsoleColor.Cyan);
        }

        public static void WriteBlueLine(string s)
        {
            WriteLine(s, ConsoleColor.Blue);
        }

        public static void WriteYellowLine(string s)
        {
            WriteLine(s, ConsoleColor.DarkYellow);
        }

        public static void WriteGrayLine(string s)
        {
            WriteLine(s, ConsoleColor.DarkGray);
        }

        private static void WriteLine(string s, ConsoleColor color)
        {
            ConsoleColor colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ForegroundColor = colorBefore;
        }
    }
}
