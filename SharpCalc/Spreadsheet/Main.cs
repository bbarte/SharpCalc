using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc.Spreadsheet
{
    public static class Main
    {
        static bool run = true;

        static List<SpreadsheetObject> spreadsheetObjects = new List<SpreadsheetObject>();
        static int documentColumnsNumber = 10;
        //static int documentRowsNumber = 20;

        const ConsoleColor HeadersBackground = ConsoleColor.Gray;
        const ConsoleColor EvenHeadersBackground = ConsoleColor.White;
        const ConsoleColor HeadersForeground = ConsoleColor.Black;

        public static void Start()
        {
            while (run)
            {
                DrawData();
            }
        }

        private static void DrawData()
        {
            Console.Clear();
            Console.ResetColor();

            int columns = 0;
            int rows = GetRowsToDisplay();
            
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

                Console.ForegroundColor = HeadersForeground;

                if ((i + 1) % 2 != 0)
                    Console.BackgroundColor = HeadersBackground;
                else
                    Console.BackgroundColor = EvenHeadersBackground;

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
            for (int i = 0; i < rows; i++)
            {
                Console.ForegroundColor = HeadersForeground;
                if ((i + 1) % 2 != 0)
                    Console.BackgroundColor = HeadersBackground;
                else
                    Console.BackgroundColor = EvenHeadersBackground;

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

            GetUserInput();
        }

        private static void GetUserInput()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string input = Console.ReadLine();

            switch (input)
            {
                case "exit":
                    run = false;
                    return;
                case "clear":
                    spreadsheetObjects.Clear();
                    break;
            }

            /* BASIC SYNTAX:
             * ColumnNumber-RowNumber:Action
             * 
             * ACTIONS:
             * Number or text - insert/replace cell
             * '=' at the start - formula
             * 
             * FORMULA SYNTAX:
             * =NAME(value1;value2;...)
             */

            string[] mainParams = input.Split(':');
            string[] addressParams = mainParams[0].Split('-');
            // check if the user gave column number and row number
            if (mainParams.Length < 2)
                return;

            int columnNumber = 0;
            int rowNumber = 0;

            // check if the given numbers are correct
            if (int.TryParse(addressParams[0], out columnNumber) == false || int.TryParse(addressParams[1].Replace(":", ""), out rowNumber) == false)
                return;

            string value = mainParams[1];
            if (value[0] == '=')
            {
                string formula = value.Replace("=", "");
                string formulaParams = formula.Split('(', ')')[1];
                string[] insideFormulaParams = formulaParams.Split(';');
                if (formula.StartsWith("SETCOLOR"))
                {
                    string foreground = insideFormulaParams[0];
                    string background = insideFormulaParams[1];
                    spreadsheetObjects = DocumentManipulation.SetCellBackground(columnNumber, rowNumber, foreground, background, spreadsheetObjects);
                }
            }
            else
            {
                spreadsheetObjects = DocumentManipulation.SetCellValue(columnNumber, rowNumber, value, spreadsheetObjects);
            }
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
            return GetRowsToDisplay().ToString().Length + 2;
        }

        private static int GetRowsToDisplay()
        {
            return Console.WindowHeight - 2; // <-- available rows in the console minus one row for the user input
        }
    }
}
