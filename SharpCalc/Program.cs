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
            Console.WriteLine("│ c. Help                         │");
            Console.WriteLine("│ d. Exit                         │");
            Console.WriteLine("└─────────────────────────────────┘");
            
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    Spreadsheet.Main.Start();
                    break;
                case ConsoleKey.B:
                    break;
                case ConsoleKey.C:
                    PrintHelp();
                    break;
                case ConsoleKey.D:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void PrintHelp()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"┌───────────────────────────────────────────────┐");
            Console.WriteLine(@"│                                               │▒");
            Console.WriteLine(@"│      SharpCalc - C# Terminal Spreadsheet      │▒");
            Console.WriteLine(@"│                     HELP                      │▒");
            Console.WriteLine(@"│                                               │▒");
            Console.WriteLine(@"└───────────────────────────────────────────────┘▒");
            Console.WriteLine(@"   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.ResetColor();
            Console.WriteLine("\nI. Inserting data into a cell:");
            Console.WriteLine("    FORMAT: column number-row number:your text");
            Console.WriteLine("    EXAMPLE: '3-2:HOME BUDGET'");
            Console.WriteLine("        This command will put the text 'HOME BUDGET' into the 3rd column and the 2nd 5row.");
            Console.WriteLine("\nII. Formulas and commands");
            Console.WriteLine("    FORMAT: column number-row number:=FORMULANAME(param1;param2;...)");
            Console.WriteLine("    EXAMPLE: '1-2:=SETCOLOR(Red;Black)'");
            Console.WriteLine("        This command will color the text red on the 1st column and the 2nd row.");
            Console.WriteLine("\nIII. Some other userful things");
            Console.WriteLine("    > 'exit' - closes the application");
            Console.WriteLine("    > 'clear' - clears the entire document. WARNING: this action cannot be undone!");
            Console.WriteLine("");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey();
            PrintTitle();
        }
    }
}
