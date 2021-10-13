using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GreedSnake
{
    public class Draw
    {
        public Draw()
        {
        }
        public Draw(Queue<Coordinate> snakeSender,Queue<Coordinate> snakeSenderNd ,List<Coordinate> candySender, Queue<Coordinate> wallSender, PaintEventArgs e, int width, int height)
        {
            //创建画板,这里的画板是由Form提供的
            Graphics g = e.Graphics;
            //定义了一个蓝色,宽度为2的画笔
            Pen p;
            //在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            //g.DrawLine(p, 10, 10, 100, 100);
            //遍历蛇队列
            foreach (Coordinate coordinate in snakeSender)
            {
                //定义画笔
                p = new Pen(Color.Red, 2);
                //画贪吃蛇
                g.DrawEllipse(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
            }
                //遍历第二条蛇队列
                foreach (Coordinate coordinate in snakeSenderNd)
                {
                    //定义画笔
                    p = new Pen(Color.Red, 2);
                    //画贪吃蛇
                    g.DrawEllipse(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
                }
         
            //遍历糖果队列
            foreach (Coordinate coordinate in candySender)
            {
                //定义画笔
                p = new Pen(Color.Purple, 3);
                //画糖果
                g.DrawRectangle(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
            }
            //遍历墙队列
            foreach (Coordinate coordinate in wallSender)
            {
                //定义画笔
                p = new Pen(Color.Black, 3);
                //画墙
                g.DrawEllipse(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
            }
        }
        public Draw(Queue<Coordinate> snakeSender, List<Coordinate> candySender, Queue<Coordinate> wallSender, PaintEventArgs e, int width, int height)
        {
            //创建画板,这里的画板是由Form提供的
            Graphics g = e.Graphics;
            //定义了一个蓝色,宽度为2的画笔
            Pen p;
            //在画板上画直线,起始坐标为(10,10),终点坐标为(100,100)
            //g.DrawLine(p, 10, 10, 100, 100);
            //遍历蛇队列
            foreach (Coordinate coordinate in snakeSender)
            {
                //定义画笔
                p = new Pen(Color.Red, 2);
                //画贪吃蛇
                g.DrawEllipse(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
            }
            //遍历糖果队列
            foreach (Coordinate coordinate in candySender)
            {
                //定义画笔
                p = new Pen(Color.Purple, 3);
                //画糖果
                g.DrawRectangle(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
            }
            //遍历墙队列
            foreach (Coordinate coordinate in wallSender)
            {
                //定义画笔
                p = new Pen(Color.Black, 3);
                //画墙
                g.DrawEllipse(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
            }
        }
        //  public void DrawSnake(Queue<Coordinate> snakeSender, PaintEventArgs e, int width, int height)
        //   { 
        //创建画板,这里的画板是由Form提供的
        //    Graphics g = e.Graphics;
        //定义了一个蓝色,宽度为2的画笔
        //    Pen p;
        //遍历蛇队列
        //    foreach (Coordinate coordinate in snakeSender)
        //    {
        //定义画笔
        //        p = new Pen(Color.Red, 2);
        //画贪吃蛇
        //        g.DrawEllipse(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
        //      }
        // }
        //  public void DrawCandy(List<Coordinate> candySender, PaintEventArgs e, int width, int height)
        //   {
        //创建画板,这里的画板是由Form提供的
        //    Graphics g = e.Graphics;
        //定义了一个蓝色,宽度为2的画笔
        //   Pen p;
        //遍历糖果队列
        //    foreach (Coordinate coordinate in candySender)
        //      {
        //定义画笔
        //       p = new Pen(Color.Purple, 3);
        //画糖果
        //        g.DrawRectangle(p, coordinate.X * (width / 20), coordinate.Y * (height / 20), (width / 20), (height / 20));
        //    }
        // }
        public System.Drawing.Image resizeBackgroundImage(System.Drawing.Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);
            int destWidth = (int)(sourceWidth * nPercentW);
            int destHeight = (int)(sourceHeight * nPercentH);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
    }
}
