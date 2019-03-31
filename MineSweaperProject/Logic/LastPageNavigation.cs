using MineSweaperProject.Game;
using MineSweaperProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Logic
{
    class LastPageNavigation
    {
        private bool quit = false;
        private ConsoleKeyInfo _PressedKey;


        public LastPageNavigation (int Lenght, int Height, int NrOfMines, bool Winner, GameBoard GameBoard, int WinnerTime)
        {
            if (Winner == true)
            {
                WinnerPage newWinnerPage = new WinnerPage(WinnerTime, NrOfMines);
            }
            else
            {
                GameOverPage newGameOver = new GameOverPage(GameBoard, Lenght, Height);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            
            do
            {

                while (Console.KeyAvailable)
                {
                    _PressedKey = Console.ReadKey(true);
                    if (_PressedKey.Key == ConsoleKey.M)
                    {
                        Console.CursorVisible = true;
                        Console.Clear();
                        FirstPageNavigation newGame = new FirstPageNavigation();
                        quit = true;
                    }
                    if (_PressedKey.Key == ConsoleKey.R)
                    {
                        Console.CursorVisible = true;
                        Console.Clear();
                        StartBoard newStartBoard = new StartBoard(0, 0, Lenght, Height);
                        Navigation newNavigation = new Navigation(Lenght, Height, NrOfMines);
                        quit = true;
                    }
                    if (_PressedKey.Key == ConsoleKey.Escape)
                    {
                        quit = true;
                    }

                }
            } while (quit == false);
        }
    }
}
