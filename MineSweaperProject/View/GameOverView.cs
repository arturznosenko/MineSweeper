using MineSweaperProject.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.View
{
    class GameOverView
    {
        public GameOverView (GameBoard GameBoard, int Lenght, int Height)
        {

            List<Unit> GameOverStatus = GameBoard.GetAllItemList();
            
                foreach (Unit unit in GameOverStatus)
                {

                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(unit.X, unit.Y);
                   if (unit.Bomb == true && unit.Open == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("*");
                    }
                    else if (unit.Bomb == true && unit.Open == true)
                {
                    Console.BackgroundColor = ConsoleColor.Red;  // cia kas paspausdinti bombas raudonai
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("*");
                   }

                else if (unit.Bomb == false && unit.Open == false)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(".");
                    }
                    else if (unit.Open == true)
                    {
                        if (unit.BombsAround ==0)
                            {
                                Console.WriteLine(" ");
                            }
                        else
                            { 
                                Colors.SetColor(unit.BombsAround);
                                Console.WriteLine(unit.BombsAround);
                            }
                    }

                
            }

        }
    }
}
