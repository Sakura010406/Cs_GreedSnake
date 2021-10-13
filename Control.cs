using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace GreedSnake
{
    //控制类
    public class Control
    {
        //蛇
        private Snake m_Snake;
        //糖果
        private Candy m_Candy;
        //墙体
        private Wall m_Wall;
        //方向数组
        private string[] m_Direction = new string[] { "top", "bottom", "left", "right" };
        //状态
        private GameState m_Gs;
        public Control(GameState gs)
        {
            this.m_Gs = gs;
            this.m_Snake = gs.Snake;
            this.m_Candy = gs.Candy;
            this.m_Wall = gs.Wall;
        }
        //移动
        public void GreedSnakeMove(int x, int y)
        {
            this.m_Snake.SnakeQueue.Dequeue();
            this.m_Snake.SnakeQueue.Enqueue(new Coordinate(x, y));
            this.m_Snake.HeadCoordinate = new Coordinate(x, y);
        }
        //返回蛇、糖果、墙体
        public Snake Snake
        {
            get { return this.m_Snake; }
        }
        public Candy Candy
        {
            get { return this.m_Candy; }
        }
        public Wall Wall
        {
            get { return this.m_Wall; }
        }
        //记录蛇尾
        public void Record()
        {
            this.m_Snake.TailCoordinate = this.m_Snake.SnakeQueue.Peek();
        }
        //碰撞检测
        public bool ExamCollision(Queue<Coordinate> wall)
        {
            foreach (Coordinate coordinate in wall)
            {
                if (this.m_Snake.HeadCoordinate.X == coordinate.X && this.m_Snake.HeadCoordinate.Y == coordinate.Y)
                {
                    return true;
                }
            }
            return false;
        }
        //吃糖果
        public bool EatCandy(List<Coordinate> candy)
        {
            foreach (Coordinate coordinate in candy)
            {
                if (this.m_Snake.HeadCoordinate.X == coordinate.X && this.m_Snake.HeadCoordinate.Y == coordinate.Y)
                {
                    candy.Remove(coordinate);
                    if(candy.Count == 0)
                    {
                        this.m_Gs.ProductCandy();
                    }
                    return true;
                }
            }
            return false;
        }
        //增长
        public void AddLength()
        {
            Queue<Coordinate> initQue = new Queue<Coordinate>();
            initQue.Enqueue(this.m_Snake.TailCoordinate);
            foreach(Coordinate coordinate in this.m_Snake.SnakeQueue)
            {
                initQue.Enqueue(coordinate);
            }
            this.m_Snake.SnakeQueue = initQue;
        }
        //移动
        public void Move()
        {
            int[] ret = new int[] { -1, 1 };
            for (int i = 0; i < this.m_Direction.Length; i++)
            {
                if (this.m_Gs.Snake.InitialDirection == this.m_Direction[i])
                {
                    this.m_Snake.SnakeQueue.Dequeue();
                    this.m_Snake.SnakeQueue.Enqueue(new Coordinate(this.m_Gs.Snake.HeadCoordinate.X + (i <= 1 ? 0 : ret[i % 2]), this.m_Gs.Snake.HeadCoordinate.Y + (i >= 2 ? 0 : ret[i % 2])));
                    this.m_Snake.HeadCoordinate = new Coordinate(this.m_Gs.Snake.HeadCoordinate.X + (i <= 1 ? 0 : ret[i % 2]), this.m_Gs.Snake.HeadCoordinate.Y + (i >= 2 ? 0 : ret[i % 2]));
                }
            }
        }
    }
}
