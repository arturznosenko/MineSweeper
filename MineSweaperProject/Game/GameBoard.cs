using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Game
{
    class GameBoard 
    {
        private List<Unit> _all;
        private int _lenght;
        private int _height;
        private int _nrOfMines;

        public GameBoard (int Lenght, int Height, int NrOfMines)
        {
            _lenght = Lenght;
            _height = Height;
            _nrOfMines = NrOfMines;

            BombList newtest = new BombList(_lenght, _height, _nrOfMines);
            List<Unit> NoBomb = newtest.NoBombListFunc();
            List<Unit> Bomb = newtest.BombListFunc();
            CountBombsAround(NoBomb, Bomb);

            
            _all = newtest.AllList();
           


        }
        public void CountBombsAround (List<Unit> NoBomb, List<Unit> Bomb)
        {
            foreach (Unit a in NoBomb)
            {
                int result = (from i in Bomb
                              where i.X == a.X - 1 && i.Y == a.Y - 1 ||
                                    i.X == a.X - 1 && i.Y == a.Y ||
                                    i.X == a.X - 1 && i.Y == a.Y + 1 ||
                                    i.X == a.X && i.Y == a.Y - 1 ||
                                    i.X == a.X && i.Y == a.Y + 1 ||
                                    i.X == a.X + 1 && i.Y == a.Y - 1 ||
                                    i.X == a.X + 1 && i.Y == a.Y ||
                                    i.X == a.X + 1 && i.Y == a.Y + 1
                              select i).Count();

                a.BombsAround = result;
            }
        }


        public void RenderGameBoard()
        {
            foreach (Unit a in _all)
            {
                Console.SetCursorPosition(a.X, a.Y+19);  // cia faikine funkcija reiks 19 panaikinti ant game overo
                if (a.Bomb == true)
                {
                    Console.WriteLine("*");
                }
                else
                {
                    Console.WriteLine(a.BombsAround);
                }

            }
        }
        
        public Unit GetOneUnit ( int x, int y)
        {
            Unit Unit = (from a in _all
                        where a.X == x && a.Y == y
                        select a).First();

            return Unit;

        }

        public void SetOpen (int x, int y)
        {
            foreach (Unit a in _all)
            {
                if (a.X == x && a.Y == y)
                {
                    a.Open = true;
                }
            }
        }
        public int NumberofFlaged ()
        {
            int number = (from b in _all
                          where b.Flaged == true
                          select b).Count();
            return number;
        }

        public List<Unit> GetAllItemList ()
        {
            return _all;
        }

        public int HowMuchLeftToOpen()
        {
            int howMuch = (from x in _all
                           where x.Open == false && x.Bomb == false
                           select x).Count();
            return howMuch;
        }

        public List<Unit> GetUnitsAround (int x, int y)  
        {

            List<Unit> UnitsAround =  new List<Unit> ();

            if (x < _lenght-1 + 20 - (_lenght / 2))
            {
                UnitsAround.Add(GetOneUnit(x + 1, y));
            }
            if (y < _height-1+ 12 - (_height / 2))
            {
                UnitsAround.Add(GetOneUnit(x , y + 1));
            }

            if (x < _lenght-1 + 20 - (_lenght / 2) && y < _height-1+ 12 - (_height / 2))
            { 
            UnitsAround.Add(GetOneUnit(x + 1, y + 1));
            }

            if (x > 20 - (_lenght / 2))
            { 
                UnitsAround.Add(GetOneUnit(x - 1, y));
                
            }

            if (x > 20 - (_lenght / 2) && y < _height-1 + 12 - (_height / 2))
            {
                UnitsAround.Add(GetOneUnit(x - 1, y + 1));
            }

            if (x < _lenght-1 + 20 - (_lenght / 2) && y > 12 - (_height / 2))
            {
             UnitsAround.Add(GetOneUnit(x + 1, y - 1));
            }

            if (y > 12 - (_height / 2))
            { 
                UnitsAround.Add(GetOneUnit(x , y - 1));
            }
            
            if (y > 12 - (_height / 2) && x > 20 - (_lenght / 2))
            {
                UnitsAround.Add(GetOneUnit(x - 1, y - 1));
            }

            List<Unit> UnitsAround2 = (from a in UnitsAround
                                where a.Flaged == false
                                select a).ToList();

            return UnitsAround2;
        }
    }
}
