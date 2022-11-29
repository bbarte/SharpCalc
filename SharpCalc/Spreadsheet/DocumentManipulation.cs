using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc.Spreadsheet
{
    public static class DocumentManipulation
    {
        public static List<SpreadsheetObject> SetCellValue(int column, int row, string value, List<SpreadsheetObject> list)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                list.RemoveAll(x => x.Column == column && x.Row == row);
                return list;
            }
            if (list.Where(x => x.Column == column && x.Row == row).Count() == 1)
            {
                foreach (var item in list.Where(x => x.Column == column && x.Row == row))
                {
                    item.Value = value;
                }
            }
            else
            {
                list.Add(new SpreadsheetObject(column, row, value));
            }

            return list;
        }
        public static List<SpreadsheetObject> SetCellBackground(int column, int row, string foregronud, string background, List<SpreadsheetObject> list)
        {
            ConsoleColor foregr = ConsoleColor.White;
            ConsoleColor back = ConsoleColor.Black;

            try
            {
                foregr = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), foregronud);
                back = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), background);
            } catch { return list; }

            foreach (var item in list.Where(x => x.Column == column && x.Row == row))
            {
                item.Foreground = foregr;
                item.Background = back;
            }

            return list;
        }
    }
}
