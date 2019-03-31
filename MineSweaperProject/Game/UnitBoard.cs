using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MineSweaperProject.Game
{

    class UnitBoard
    {
        private List<Unit> _GameBoard = new List<Unit>();
        private int _lenght;
        private int _height;
       
            public UnitBoard(int Lenght, int Height)
        {
            _lenght = Lenght;
            _height = Height;


        }

        public List<Unit> GameBoardUnits()
        {   int id = 1;

            int newx = 20 - (_lenght / 2);
            int newy = 12 - (_height / 2);

            for (int i = newx; i < _lenght+ newx; i++)  
            {
                for (int j = newy; j < _height+ newy; j++) 
                {
                    _GameBoard.Add(new Unit(i, j) { Id = id, Bomb = false , BombsAround = 0});
                    id += 1;
                }
            }
            return _GameBoard;
        }

        public int MaxId()
        {
            int Maxid = (from x in _GameBoard
                         select x.Id).Max();

            return Maxid;
        }
    }


}
