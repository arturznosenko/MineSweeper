using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class StartBoard
    {
        public StartBoard(int x, int y, int Lenght, int Height)
            
        {
            Console.ForegroundColor = ConsoleColor.White;
            GUI Square = new GUI(0, 0, 40, 25);
            Square.Render('*');

            int newx =  20 - (Lenght / 2);
            int newy =  12 - (Height / 2);

            for (int i = newy; i < Height+ newy; i++)
            {
                for (int j = newx; j < Lenght+ newx; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(".");

                }

            }
        }
    }
}
