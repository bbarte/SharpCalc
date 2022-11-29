using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc
{
    class Program
    {
        /* ================================================
        /* SharpCalc - C# (C Sharp), Calc - spreadsheet ;)
        /* author: bbarte on github, 2022
        /* ================================================
        */
        static void Main(string[] args)
        {
            PrintTitle();
        }

        static void PrintTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"┌───────────────────────────────────────────────┐");
            Console.WriteLine(@"│                                               │▒");
            Console.WriteLine(@"│      SharpCalc - C# Terminal Spreadsheet      │▒");
            Console.WriteLine(@"│         author: bbarte on github, 2022        │▒");
            Console.WriteLine(@"│                                               │▒");
            Console.WriteLine(@"└───────────────────────────────────────────────┘▒");
            Console.WriteLine(@"   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("\n");
            Console.ResetColor();
            Console.WriteLine("┌─ MENU ──────────────────────────┐");
            Console.WriteLine("│ a. New File                     │");
            Console.WriteLine("│ b. Load from an existing file   │");
            Console.WriteLine("│ c. Exit                         │");
            Console.WriteLine("└─────────────────────────────────┘");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    Spreadsheet.Main.Start();
                    break;
                case ConsoleKey.B:
                    break;
                case ConsoleKey.C:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
