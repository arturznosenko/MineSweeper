using MineSweaperProject.Game;
using MineSweaperProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Logic
{
    class OpenUnits
    {
        public OpenUnits(int x, int y, GameBoard newGame)
        {
            
            if (newGame.GetOneUnit(x, y).BombsAround == 0)
            {
                List<Unit> UnitToOpen = new List<Unit>();
                UnitToOpen.Add(newGame.GetOneUnit(x, y));

                do
                {
                    foreach (Unit a in UnitToOpen.ToList())
                    {
   
                            Console.SetCursorPosition(a.X, a.Y);
                            Console.WriteLine(" ");
                            a.Open = true;
                            UnitToOpen.Remove(a);

                            foreach (Unit b in newGame.GetUnitsAround(a.X, a.Y))
                            {

                                    if (b.BombsAround == 0 && b.Open == false)
                                    {
                                        UnitToOpen.Add(b);
                                        b.Open = true;
                                    }
                                    else if (b.Open == false)
                                    {
                                        Console.SetCursorPosition(b.X, b.Y);
                                        Colors.SetColor(b.BombsAround);
                                        Console.WriteLine(b.BombsAround);
                                        b.Open = true;
                                    }
                            }
                    }
                } while (UnitToOpen.Count > 0);

            }

            else 
            {
                Colors.SetColor(newGame.GetOneUnit(x, y).BombsAround);
                Console.WriteLine(newGame.GetOneUnit(x, y).BombsAround);
                newGame.GetOneUnit(x, y).Open = true;
            }

           
        }
 
    }
}

