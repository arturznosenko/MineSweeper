using MineSweaperProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Logic
{
    class FirstPageNavigation
    {   private bool quit = false;
        private ConsoleKeyInfo _PressedKey;
        private FirstPage _newpage;
        private int count = 0;

        public FirstPageNavigation ()
        {

            Console.ForegroundColor = ConsoleColor.White;
            FirstPage Newpage = new FirstPage();
            
            _newpage = Newpage;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Newpage.RenderBeginner();

            do
            {

                while (Console.KeyAvailable)
                {
                    _PressedKey = Console.ReadKey(true);
                    if (_PressedKey.Key == ConsoleKey.DownArrow && count < 2)
                    {
                        count = count + 1;
                        RenderMenu(count);
                    }
                    if (_PressedKey.Key == ConsoleKey.UpArrow && count > 0)
                    {
                        count = count - 1;
                        RenderMenu(count);
                    }
                    if (_PressedKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        if (count == 0)
                        {
                            StartBoard newStartBoard = new StartBoard(0,0,12, 7);
                            Navigation newNavigation = new Navigation(12, 7, 10);
                        }

                        else if (count == 1)
                        {
                            StartBoard newStartBoard = new StartBoard(0, 0, 20, 13);
                            Navigation newNavigation = new Navigation(20, 13, 40);
                        }
                        else if (count == 2)
                        {
                            StartBoard newStartBoard = new StartBoard(0, 0, 30, 16);
                            Navigation newNavigation = new Navigation(30, 16, 99);
                        }

                        quit = true;
                    }
                    if (_PressedKey.Key == ConsoleKey.Escape)
                    {
                        quit = true;
                    }

                }
            } while (quit == false);
        }

        public void RenderMenu (int a)
        {
            if (a == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                _newpage.RenderBeginner();
                Console.ForegroundColor = ConsoleColor.White;
                _newpage.RenderMedium();
                _newpage.RenderDifficult();
            }

            if (a == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                _newpage.RenderMedium();
                Console.ForegroundColor = ConsoleColor.White;
                _newpage.RenderBeginner();
                _newpage.RenderDifficult();
            }
            if (a == 2)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                _newpage.RenderDifficult();
                Console.ForegroundColor = ConsoleColor.White;
                _newpage.RenderBeginner();
                _newpage.RenderMedium();
            }
        }
    }
}
