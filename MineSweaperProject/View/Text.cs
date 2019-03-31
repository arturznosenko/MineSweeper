using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class Text
    {
        public Text(int X, int Y, int lenght, int height, string text)
        {
            int newx = X + (lenght / 2) - (text.Length / 2);
            int newy = Y + height;
            Console.SetCursorPosition(newx, newy);
            Console.WriteLine(text);
        }

    }


}
