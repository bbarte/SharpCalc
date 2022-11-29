using SharpCalc.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc.Windows
{
    public static class Helper
    {
        public static void DrawWindowWithDifferentScreens(List<string[]> screens, ConsoleColor background, ConsoleColor foreground)
        {
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(3, 3);
            Console.CursorVisible = false;
            Spreadsheet.Main.getInput = false;
            Spreadsheet.Main.DrawData();

            foreach (var item in screens)
            {
                Console.SetCursorPosition(3, 3);

                int windowWidth = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i].Length > windowWidth)
                        windowWidth = item[i].Length + 1;
                }

                int top = 3;
                // draw content
                for (int i = 0; i < item.Length; i++)
                {
                    Console.BackgroundColor = background;
                    Console.ForegroundColor = foreground;

                    Console.SetCursorPosition(3, top);
                    Console.Write(" ");
                    Console.Write(item[i]);
                    // draw white characters to match te window width
                    for (int j = item[i].Length; j < windowWidth; j++)
                        Console.Write(" ");
                    top++;
                    Console.ResetColor();
                    if (i > 0)
                        Console.Write("█"); // draw the shadow
                }

                // draw the shadow
                Console.SetCursorPosition(3 + 2, top);
                for (int i = 0; i < windowWidth; i++)
                    Console.Write("▀");

                Console.ReadKey();
                Spreadsheet.Main.DrawData();
            }

            Spreadsheet.Main.getInput = true;
            Console.CursorVisible = true;
        }
        public static ConsoleKey DrawWindowWithOptions(string[] screen, ConsoleColor background, ConsoleColor foreground)
        {
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(3, 3);
            Console.CursorVisible = false;
            Spreadsheet.Main.getInput = false;
            Spreadsheet.Main.DrawData();

            Console.SetCursorPosition(3, 3);

            int windowWidth = 0;
            for (int i = 0; i < screen.Length; i++)
            {
                if (screen[i].Length > windowWidth)
                    windowWidth = screen[i].Length + 1;
            }

            int top = 3;
            // draw content
            for (int i = 0; i < screen.Length; i++)
            {
                Console.BackgroundColor = background;
                Console.ForegroundColor = foreground;

                Console.SetCursorPosition(3, top);
                Console.Write(" ");
                Console.Write(screen[i]);
                // draw white characters to match te window width
                for (int j = screen[i].Length; j < windowWidth; j++)
                    Console.Write(" ");
                top++;
                Console.ResetColor();
                if (i > 0)
                    Console.Write("█"); // draw the shadow
            }

            // draw the shadow
            Console.SetCursorPosition(3 + 2, top);
            for (int i = 0; i < windowWidth; i++)
                Console.Write("▀");

            Spreadsheet.Main.getInput = true;
            Console.CursorVisible = true;

            return Console.ReadKey().Key;
        }
    }
}
