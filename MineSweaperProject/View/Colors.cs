using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    static class Colors
    {

        static public void SetColor (int a)
        {
            switch (a)
            {

                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
    }
}
