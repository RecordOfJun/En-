using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using LTT.View;
namespace LTT.Controller
{
    class WholeLecture
    {
        Excel.Sheets sheets;
        Excel.Worksheet worksheet;
        Excel.Range cellRange;
        LectureView lectureView = new LectureView();
        Array data;
        public WholeLecture(Excel.Sheets sheets)
        {
            this.sheets = sheets;
            worksheet = sheets["전체강의"] as Excel.Worksheet;
            cellRange = worksheet.get_Range("A1", "L185") as Excel.Range;
            data = (Array)cellRange.Cells.Value2;
        }
        public void ShowLectures()
        {
            Console.Clear();
            object value;
            for (int row = 1; row <= 185; row++)
            {
                for (int column = 1; column <= 12; column++)
                {
                    value = data.GetValue(row, column);
                    switch (column)
                    {
                        case 2:
                            Console.SetCursorPosition(4, Console.CursorTop);
                            break;
                        case 3:
                            Console.SetCursorPosition(24, Console.CursorTop);
                            break;
                        case 4:
                            Console.SetCursorPosition(33, Console.CursorTop);
                            break;
                        case 5:
                            Console.SetCursorPosition(38, Console.CursorTop);
                            break;
                        case 6:
                            Console.SetCursorPosition(71, Console.CursorTop);
                            break;
                        case 7:
                            Console.SetCursorPosition(84, Console.CursorTop);
                            break;
                        case 8:
                            Console.SetCursorPosition(89, Console.CursorTop);
                            break;
                        case 9:
                            Console.SetCursorPosition(94, Console.CursorTop);
                            break;
                        case 10:
                            Console.SetCursorPosition(125, Console.CursorTop);
                            break;
                        case 11:
                            Console.SetCursorPosition(139, Console.CursorTop);
                            break;
                        case 12:
                            Console.SetCursorPosition(166, Console.CursorTop);
                            break;
                    }
                    lectureView.ShowValue(value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
