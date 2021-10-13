using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedSnake
{
    public class Wall
    {
        //墙体队列
        private Queue<Coordinate> m_WallQueue = new Queue<Coordinate>();
        //难度
        private String[] m_DiffiClass = new string[] { "简单", "一般", "困难" };
        //墙队列长度
        private int m_WallLength;
        public Wall(String difficulty)
        {
            //随机初始化墙体
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            if(difficulty == this.m_DiffiClass[0])
            {
                this.m_WallLength = ra.Next(5, 10);
                this.m_WallQueue = this.RandWall(this.m_WallLength);
            }
            else if (difficulty == this.m_DiffiClass[1])
            {
                this.m_WallLength = ra.Next(10, 15);
                this.m_WallQueue = this.RandWall(this.m_WallLength);
            }
            else
            {
                this.m_WallLength = ra.Next(15, 20);
                this.m_WallQueue = this.RandWall(this.m_WallLength);
            }
        }
        public Queue<Coordinate> RandWall(int length)
        {
            Queue<Coordinate> wall = new Queue<Coordinate>();
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < length; i++)
            {
                Coordinate co = new Coordinate(ra.Next(0, 20), ra.Next(0, 20));
                wall.Enqueue(co);
            }
            return wall;
        }
        public Queue<Coordinate> WallQueue
        {
            get { return this.m_WallQueue; }
        }
    }
}
