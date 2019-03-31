using MineSweaperProject.Game;
using MineSweaperProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MineSweaperProject.Logic
{
    class Navigation
    {
       private ConsoleKeyInfo _PressedKey;
       private int _lenght;
       private int _height;
       private int _nrOfMines;
       private int x = 0;
       private int y = 0;
       private bool quit = false;
       private int seconds = 0;
       private GameBoard _newGame;

        public Navigation(int Lenght, int Height, int NrOfMines)
            {

            x = 20 - (Lenght / 2);
            y = 12 - (Height / 2);
            _lenght = Lenght;
            _height = Height;
            _nrOfMines = NrOfMines;

            GameBoard newGame = new GameBoard(_lenght, _height, _nrOfMines);

            _newGame = newGame;
            Flagged();
            LeftToOpen();

           // newGame.RenderGameBoard(); ///Sitas atidaro apacioje visus atsakymus:)
            Timer newTimer = new Timer(1000);
            newTimer.Enabled = true;
            newTimer.Elapsed += Seconds;

            Console.SetCursorPosition(x, y);
            do
            {
                

                while (Console.KeyAvailable)

                {
                    _PressedKey = Console.ReadKey(true);

                    if (_PressedKey.Key == ConsoleKey.RightArrow && x < _lenght-1+ 20 - (Lenght / 2))
                    {
                        x += 1;
                        Console.SetCursorPosition(x, y);
                    }

                    if (_PressedKey.Key == ConsoleKey.LeftArrow && x > 20 - (Lenght / 2))
                    {
                        x -= 1;
                        Console.SetCursorPosition(x, y);
                    }

                    if (_PressedKey.Key == ConsoleKey.DownArrow && y < _height- 1 + 12 - (Height / 2))
                    {
                        y += 1;
                        Console.SetCursorPosition(x, y);
                    }

                    if (_PressedKey.Key == ConsoleKey.UpArrow && y > 12 - (Height / 2))
                    {
                        y -= 1;
                        Console.SetCursorPosition(x, y);
                    }

                    if (_PressedKey.Key == ConsoleKey.Enter || _PressedKey.Key == ConsoleKey.Spacebar)
                    {
                        if (newGame.GetOneUnit(x, y).Bomb == true && newGame.GetOneUnit(x, y).Flaged == false)
                        {
                            newTimer.Stop();
                            newTimer.Dispose();
                            newGame.GetOneUnit(x, y).Open = true;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            LastPageNavigation Winnerpage = new LastPageNavigation(_lenght, _height, _nrOfMines, false, newGame, 0);
                            quit = true;

                        }

                        else if (newGame.GetOneUnit(x, y).Flaged == false)
                        { 
                        OpenUnits newOpenUnits = new OpenUnits(x, y, newGame);
                        LeftToOpen();
                        Console.SetCursorPosition(x, y);
                        }

                        if (newGame.HowMuchLeftToOpen() == 0)
                        {
                            newTimer.Stop();
                            newTimer.Dispose();
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.SetCursorPosition(0, 25);
                            LastPageNavigation Winnerpage = new LastPageNavigation(_lenght, _height, _nrOfMines, true, newGame, seconds);
                            quit = true;

                        }

                    }

                    if (_PressedKey.Key == ConsoleKey.Q)
                    {
                        if (newGame.GetOneUnit(x, y).QuestionMark == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("?");
                            Console.SetCursorPosition(x, y);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(".");
                            Console.SetCursorPosition(x, y);
                        }

                    }

                    if (_PressedKey.Key == ConsoleKey.F)
                    {
                        if (newGame.GetOneUnit(x, y).Flaged == false)
                        { 
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("F");
                        newGame.GetOneUnit(x, y).Flaged = true;
                        Console.WriteLine();
                        Flagged();
                        Console.SetCursorPosition(x, y);
                        }
                        else
                        {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(".");
                        newGame.GetOneUnit(x, y).Flaged = false;
                        Flagged();
                        Console.SetCursorPosition(x, y);
                        }

                    }


                    if (_PressedKey.Key == ConsoleKey.Escape)
                    {
                        newTimer.Stop();
                        newTimer.Dispose();
                        quit = true;

                    }

                }

            } while (quit == false);
    }
        public  void Seconds(Object source, ElapsedEventArgs e)
        {
                 
            seconds += 1;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(12, 1);
            Console.WriteLine($"Time passed: {seconds}");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);


        }
        public void Flagged ()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(12, 3);
            Console.WriteLine($"Mines left: {_nrOfMines - _newGame.NumberofFlaged()}   ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }

        public void LeftToOpen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(12, 2);
            Console.WriteLine("Left to open: " + _newGame.HowMuchLeftToOpen() + "   ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
        }
    }
}
