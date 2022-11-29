using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc.Windows
{
    public static class HelpWindow
    {
        public static void Start()
        {
            string[] sc0 = new string[]
            {
                "Welcome to the SharpCalc Help!",
                "Available options:",
                "a. Quick summary (basic concepts, basic commands)",
                "b. List of all commands",
                "c. Exit",
            };
            ConsoleKey key = Helper.DrawWindowWithOptions(sc0, ConsoleColor.DarkBlue, ConsoleColor.White);
            switch (key)
            {
                case ConsoleKey.A:
                    StartSummary();
                    break;
                case ConsoleKey.B:
                    StartListOfCommands();
                    break;
            }
        }

        private static void StartListOfCommands()
        {
            Helper.DrawWindowWithDifferentScreens(new List<string[]>()
            {
                new string[]
                {
                    "exit",
                    "  Closes the application",
                    "",
                    "[PRESS ANY KEY]",
                },
                new string[]
                {
                    "clear",
                    "  Removes the content from the entire document.",
                    "  WARNING: This action cannot be undone!",
                    "",
                    "[PRESS ANY KEY]",
                },
                new string[]
                {
                    "help",
                    "  Displays help.",
                    "",
                    "[PRESS ANY KEY]",
                },
                new string[]
                {
                    "summary",
                    "  Displays summary of the document, eg. number of elements.",
                    "",
                    "[PRESS ANY KEY]",
                },
            }, ConsoleColor.DarkCyan, ConsoleColor.White);
        }

        public static void StartSummary()
        {
            string[] sc1 = new string[]
            {
                "I. Inserting data into a cell",
                "  FORMAT: column number-row number:your text",
                "  EXAMPLE: '3-2':HOME BUDGET",
                "    This command will put the text 'HOME BUDGET' into the 3rd column and the 2nd row.",
                "[PRESS ANY KEY]",
            };
            string[] sc2 = new string[]
            {
                "II. Formulas and commands",
                "  FORMAT: column number-row number:=FORMULANAME(parameter 1; parameter 2;...)",
                "  EXAMPLE: '1-2:=SETCOLOR(Red;Black)'",
                "    This command will color the text red on the 1st column and the 2nd row.",
                "[PRESS ANY KEY]",
            };
            string[] sc3 = new string[]
            {
                "III. Some other useful things",
                "  * 'exit' - closes the application",
                "  * 'clear' - clears the entire document. WARNING: this command cannot be undone!",
                "[PRESS ANY KEY]",
            };

            Helper.DrawWindowWithDifferentScreens(new List<string[]>()
            {
                sc1,
                sc2,
                sc3
            }, ConsoleColor.DarkCyan, ConsoleColor.White);
        }
    }
}
