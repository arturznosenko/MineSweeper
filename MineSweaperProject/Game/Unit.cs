using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweaperProject.Game
{
    class Unit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public bool Bomb { get; set; }
        public int BombsAround { get; set; }
        public bool Open { get; set; }
        public bool Flaged { get; set; }
        public bool QuestionMark { get; set; }

        public Unit (int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
    }
}
