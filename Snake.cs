using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedSnake
{
    public class Snake
    {
        //蛇头
        private Coordinate m_HeadCoordinate;
        //蛇队列
        private Queue<Coordinate> m_SnakeQueue = new Queue<Coordinate>();
        //方向
        private string m_InitialDirection;
        //方向数组
        private string[] m_Direction = new string[] { "top", "bottom", "left", "right" };
        //上一个队首 即蛇尾
        private Coordinate m_tailCoordinate;

        public Snake(int y)
        {
            //初始化头
            this.m_HeadCoordinate = new Coordinate(2, 1);
            //初始化贪吃蛇
            for (int i = 0; i < 3; i++)
            {
                this.m_SnakeQueue.Enqueue(new Coordinate(i, y));
            }
            //初始化尾
            this.m_tailCoordinate = this.m_SnakeQueue.Peek();
            //方向
            this.m_InitialDirection = this.m_Direction[3];
        }
        public Queue<Coordinate> SnakeQueue
        {
            get { return this.m_SnakeQueue; }
            set { this.m_SnakeQueue = value; }
        }
        public Coordinate HeadCoordinate
        {
            get { return this.m_HeadCoordinate; }
            set { this.m_HeadCoordinate = value; }
        }
        public Coordinate TailCoordinate
        {
            get { return this.m_tailCoordinate; }
            set { this.m_tailCoordinate = value; }
        }
        public string InitialDirection
        {
            get { return this.m_InitialDirection; }
            set { this.m_InitialDirection = value; }
        }
    }
}
