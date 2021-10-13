using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedSnake
{
    //状态类
    public class GameState
    {
        //方向数组
        private string[] m_Direction = new string[] { "top", "bottom", "left", "right" };
        //蛇
        private Snake m_Snake;
        //糖果
        private Candy m_Candy;
        //墙体
        private Wall m_Wall;
        //模式
        private String m_StyleClass;
        //难度
        private String m_Difficulty;
        //模式
        private string[] m_StyleArray = new string[] { "单人模式", "双人模式" };

        public GameState(String styleClass, String difficulty)
        {
            this.m_StyleClass = styleClass;
            this.m_Difficulty = difficulty;
            this.m_Snake = new Snake(1);
            //初始化糖果
            this.m_Candy = new Candy(styleClass, difficulty);
            //初始化墙体
            this.m_Wall = new Wall(difficulty);
            this.RemoveDeduplication();
        }
        //防止重复
        public void RemoveDeduplication()
        {
            foreach (Coordinate coordinateCandy in this.m_Candy.CandyList)
            {
                foreach (Coordinate coordinateWall in this.m_Wall.WallQueue)
                {
                    if (coordinateCandy.X == coordinateWall.X && coordinateCandy.Y == coordinateWall.Y)
                    {
                        coordinateWall.X = coordinateWall.X > coordinateWall.Y ? coordinateWall.Y : coordinateWall.X - 1;
                    }
                }
            }
        }
        public void ProductCandy()
        {
            //刷新糖果
            this.m_Candy = new Candy(this.m_StyleClass, this.m_Difficulty);
        }
        //get snake
        public Snake Snake
        {
            get { return this.m_Snake; }
        }
        //get candy
        public Candy Candy
        {
            get { return this.m_Candy; }
        }
        //get wall
        public Wall Wall
        {
            get { return this.m_Wall; }
         }
        public Queue<Coordinate> SnakeQueue
        {
            get { return this.m_Snake.SnakeQueue; }
        }
        public List<Coordinate> CandyList
        {
            get { return this.m_Candy.CandyList; }
        }
        public Queue<Coordinate> WallQueue
        {
            get { return this.m_Wall.WallQueue; }
        }
    }
}
