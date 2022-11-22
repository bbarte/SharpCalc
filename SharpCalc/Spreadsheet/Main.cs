using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc.Spreadsheet
{
    public static class Main
    {
        static List<SpreadsheetObject> spreadsheetObjects = new List<SpreadsheetObject>()
        {
            new SpreadsheetObject(1, 1, "HOME BUDGET", ConsoleColor.Green, ConsoleColor.Black),
            new SpreadsheetObject(1, 2, "Source", ConsoleColor.Cyan, ConsoleColor.Black),
            new SpreadsheetObject(2, 2, "Value [$]", ConsoleColor.Cyan, ConsoleColor.Black),
            new SpreadsheetObject(1, 3, "TV", ConsoleColor.White, ConsoleColor.Black),
            new SpreadsheetObject(2, 3, "50", ConsoleColor.White, ConsoleColor.Black),
            new SpreadsheetObject(1, 4, "Education", ConsoleColor.White, ConsoleColor.Black),
            new SpreadsheetObject(2, 4, "20", ConsoleColor.White, ConsoleColor.Black),
            new SpreadsheetObject(1, 5, "Food", ConsoleColor.White, ConsoleColor.Black),
            new SpreadsheetObject(2, 5, "500", ConsoleColor.White, ConsoleColor.Black),
        };
        static int documentColumnsNumber = 10;
        static int documentRowsNumber = 20;

        const ConsoleColor HeadersBackground = ConsoleColor.Gray;
        const ConsoleColor HeadersForeground = ConsoleColor.Black;

        public static void Start()
        {
            Console.Clear();
            Console.ResetColor();
            DrawData();
        }

        private static void DrawData()
        {
            int columns = 0;
            int rows = Console.WindowHeight - 1; // <-- available rows in the console minus one row for the user input
            
            int startColumn = 0;
            int startRow = 0;

            // draw whitespace
            for (int i = 0; i < GetRowHeaderWidth(); i++)
            {
                Console.Write(" ");
            }

            // draw columns
            int actualColNo = 0;
            int colWidthSum = 0;
            for (int i = 0; i < documentColumnsNumber; i++)
            {
                Console.SetCursorPosition(GetRowHeaderWidth() + colWidthSum, 0);

                int colWidth = GetColumnWidthBasedOnRows(i + 1);

                Console.BackgroundColor = HeadersBackground;
                Console.ForegroundColor = HeadersForeground;

                Console.Write(i + 1);
                for (int j = (i + 1).ToString().Length; j < colWidth; j++)
                {
                    Console.Write(" ");
                }

                // draw cells
                foreach (var item in spreadsheetObjects.Where(x => x.Column.Equals(i + 1)))
                {
                    Console.SetCursorPosition(GetRowHeaderWidth() + colWidthSum, item.Row);
                    Console.BackgroundColor = item.Background;
                    Console.ForegroundColor = item.Foreground;
                    Console.Write(item.Value);
                }

                Console.ResetColor();

                actualColNo++;
                colWidthSum += colWidth;
            }

            // draw row headers
            int top = 1;
            Console.SetCursorPosition(0, top);
            for (int i = 0; i < documentRowsNumber; i++)
            {
                Console.BackgroundColor = HeadersBackground;
                Console.ForegroundColor = HeadersForeground;

                Console.Write(i + 1);
                for (int j = (i + 1).ToString().Length; j < GetRowHeaderWidth(); j++)
                {
                    Console.Write(" ");
                    //if (j != GetRowHeaderWidth() - 1)
                    //    Console.Write(".");
                    //else
                    //    Console.Write("|");
                }

                top++;
                Console.SetCursorPosition(0, top);
            }

            Console.ReadLine();
        }

        private static int GetColumnWidthBasedOnRows(int columnNo)
        {
            int maxWidth = 0;
            int columnNumberWidth = columnNo.ToString().Length;
            foreach (var item in spreadsheetObjects.Where(i => i.Column.Equals(columnNo)))
            {
                if (item.Value.Length > maxWidth)
                    maxWidth = item.Value.Length;
            }
            if (maxWidth < columnNumberWidth)
                maxWidth += columnNumberWidth;
            return maxWidth + 2;
        }

        private static int GetRowHeaderWidth()
        {
            return documentRowsNumber.ToString().Length + 2;
        }
    }
}
