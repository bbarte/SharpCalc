using System;

namespace SharpCalc.Spreadsheet
{
    public class SpreadsheetObject
    {
        public SpreadsheetObject(int column, int row, string value, ConsoleColor foreground, ConsoleColor background)
        {
            Column = column;
            Row = row;
            Value = value;
            Foreground = foreground;
            Background = background;
        }

        public SpreadsheetObject()
        {

        }

        public int Column { get; set; }
        public int Row { get; set; }
        public string Value { get; set; }
        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }
    }
}
