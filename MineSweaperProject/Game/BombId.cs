using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Game
{
    class BombId
    {
        private List<int> _uniqueNumbers = new List<int>();
        private int _maxAmtOfBombs;
        private int _maxBombId;

        public BombId (int MaxAmtOfBombs, int MaxBombId)
        {
            _maxAmtOfBombs = MaxAmtOfBombs;
            _maxBombId = MaxBombId;
        }

        public List<int> BombList ()
        {
            Random newRandom = new Random();
           

            while (_uniqueNumbers.Count+1 <= _maxAmtOfBombs)
            {
                int a = newRandom.Next(1, _maxBombId);
                

                if (_uniqueNumbers.Contains(a))
                {

                }
                else
                {
                    _uniqueNumbers.Add(a);
                }
            }
            return _uniqueNumbers;
        }
    }
}
