using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class GUI
    {
        private int _x;
        private int _y;
        private int _lenght;
        private int _height;

        public GUI (int X, int Y, int lenght, int height)
        {
            _x = X;
            _y = Y;
            _lenght = lenght;
            _height = height;
        }

        public void Render(char _renderchar)

        {
            for (int j = 0; j < _height; j++)
            {
                Console.SetCursorPosition(_x, _y + j);
                Console.Write(_renderchar);
                for (int i = 0; i < _lenght; i++)
                {
                    if (j == 0 || j == (_height - 1))
                    {
                        Console.Write(_renderchar);
                    }

                    else if (i == (_lenght - 1))
                    {
                        Console.Write(_renderchar);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
