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

        public SpreadsheetObject(int column, int row, string value)
        {
            Column = column;
            Row = row;
            Value = value;
        }

        public SpreadsheetObject()
        {

        }

        public int Column { get; set; }
        public int Row { get; set; }
        public string Value { get; set; }
        
        private ConsoleColor _foregrund = ConsoleColor.White;

        public ConsoleColor Foreground
        {
            get { return _foregrund; }
            set { _foregrund = value; }
        }

        private ConsoleColor _background = ConsoleColor.Black;

        public ConsoleColor Background
        {
            get { return _background; }
            set { _background = value; }
        }

    }
}
