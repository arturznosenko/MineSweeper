using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Game
{
    class BombList : UnitBoard
    {
        private List<Unit> _allListOfUnits;
        private BombId _newBombs;

        public BombList(int Lenght, int Height, int NumberOfBombs) : base (Lenght, Height)
        {
           _allListOfUnits = GameBoardUnits();

            BombId NewBombs = new BombId(NumberOfBombs, MaxId()); 
            _newBombs = NewBombs;

        }

        public List<Unit> BombListFunc()
        {
            foreach (Unit unit in _allListOfUnits)
            {
                if (_newBombs.BombList().Contains(unit.Id))
                {
                    unit.Bomb = true;
                }
            }

            var BombList = (from x in _allListOfUnits
                            where x.Bomb == true
                            select x).ToList();

            return BombList;
        }

        public List<Unit> NoBombListFunc()
        {
            var NoBombList = (from x in _allListOfUnits
                            where x.Bomb == false
                            select x).ToList();

            return NoBombList;
        }

        public List<Unit> AllList ()
        {
            return _allListOfUnits;
        }

    }
}
