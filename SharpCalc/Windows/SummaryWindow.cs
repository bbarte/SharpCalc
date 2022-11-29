using SharpCalc.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCalc.Windows
{
    public static class SummaryWindow
    {
        public static void Start()
        {
            string[] sc1 = new string[]
            {
                "DOCUMENT SUMMARY",
                "----------------",
                $"Number of elements: {Main.spreadsheetObjects.Count}",
            };
            Helper.DrawWindowWithDifferentScreens(new List<string[]>() { sc1 }, ConsoleColor.DarkMagenta, ConsoleColor.White);
        }
    }
}
