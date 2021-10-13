using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedSnake
{
    public class Candy
    {
        //糖果队列
        List<Coordinate> m_CandyList = new List<Coordinate>();
        //糖果icon（类型）
        //模式
        string[] m_StyleClass = new string[] { "单人模式", "双人模式" };
        //难度
        string[] m_DiffiClass = new string[] { "简单", "一般", "困难" };
        //糖果队列长度
        private int m_CandyLength;
        public Candy(String styleClass, String difficulty)
        {
            //随机初始化糖果队列长度
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));

            int styleIndex = 1;
            //单双
            if (styleClass == this.m_StyleClass[0]) 
            {
                styleIndex = 1; 
            }
            else
            {
                styleIndex = 2;
            }
            //简单
            if (difficulty == this.m_DiffiClass[0])
            {
                this.m_CandyLength = ra.Next(3, 4);
                this.m_CandyList = this.RandCandy(this.m_CandyLength * styleIndex);
            }
            //一般
            else if (difficulty == this.m_DiffiClass[1])
            {
                this.m_CandyLength = ra.Next(2, 3);
                this.m_CandyList = this.RandCandy(this.m_CandyLength * styleIndex);
            }
            //困难
            else
            {
                this.m_CandyLength = ra.Next(1, 2);
                this.m_CandyList = this.RandCandy(this.m_CandyLength * styleIndex);
            }
        }
        public List<Coordinate> RandCandy(int length)
        {
            List<Coordinate> candy = new List<Coordinate>();
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < length; i++)
            {
                Coordinate co = new Coordinate(ra.Next(0, 20), ra.Next(0, 20));
                candy.Add(co);
            }
            return candy;
        }
        public List<Coordinate> CandyList
        {
            get { return this.m_CandyList; }
        }
    }
}
