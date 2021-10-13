using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedSnake
{
    public class Coordinate
    {
        private int m_X;
        private int m_Y;

        public Coordinate(int x, int y)
        {
            this.m_X = x;
            this.m_Y = y;
        }
        public int X
        {
            get{ return this.m_X; }
            set { this.m_X = value; }
        }
        public int Y
        {
            get{ return this.m_Y; }
            set { this.m_Y = value; }
        }
    }
}
