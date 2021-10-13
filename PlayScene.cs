using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreedSnake
{
    public partial class PlayScene : Form
    {
        //绘图
        private Draw m_Dr;
        //背景
        private Draw m_BgDraw;
        //方向数组
        private string[] m_Direction = new string[] { "top", "bottom", "left", "right" };
        //资源
        private String m_SourcePath = @"D:\\Cs_pro\\GreedSnake\\resource";
        //背景图
        private String m_FileName;
        //状态
        private GameState m_Gs;
        //控制
        private Control m_Con;
        public PlayScene(GameState gs)
        {
            InitializeComponent();
            //设置本窗体
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            // 禁止擦除背景
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // 双缓冲
            SetStyle(ControlStyles.DoubleBuffer, true);
            //初始化filename
            this.m_FileName = "fangge2.jfif";
            //初始化背景绘图
            this.m_BgDraw = new Draw();
            //状态
            this.m_Gs = gs;  
            //控制
            this.m_Con = new Control(this.m_Gs);
            //绘制地图
            this.m_Dr = new Draw(this.m_Con.Snake.SnakeQueue, this.m_Con.Candy.CandyList, this.m_Con.Wall.WallQueue, new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle), this.Width, this.Height);
            //背景
            this.BackgroundImage = this.m_BgDraw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, ("\\" + this.m_FileName)))), new Size(1000, 700));
            this.SetBounds(250, 100, BackgroundImage.Width, BackgroundImage.Height);
            //响应键盘事件
            this.KeyPreview = true;
            //速度
            timer1.Interval = 400;
            //开始
            this.button1.Image = this.m_BgDraw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, "\\MenuSceneStartButton.png"))), new Size((int)(this.Width * 0.11), (int)(this.Height * 0.13)));
            this.button1.SetBounds((int)(this.Width * 0.44), (int)(this.Height * 0.5), (int)(this.Width * 0.11), (int)(this.Height * 0.13));
            //窗体在当前显示窗口中居中，尺寸在窗体大小中指定
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void PlayScene_Load(object sender, EventArgs e)
        {
        }
        private void PlayScene_Paint(object sender, PaintEventArgs e)
        {
            //防止重复
            this.m_Gs.RemoveDeduplication();
            //重绘
            this.m_Dr = new Draw(this.m_Con.Snake.SnakeQueue, this.m_Con.Candy.CandyList, this.m_Con.Wall.WallQueue, e, this.Width, this.Height);
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //移动
            this.m_Con.Move();
            //吃糖果
            if (this.m_Con.EatCandy(this.m_Gs.Candy.CandyList)) this.m_Con.AddLength();
            //上一个蛇尾 即队首
            this.m_Con.Record();
            //撞墙检测&&边界检测
            if (this.m_Con.ExamCollision(this.m_Gs.Wall.WallQueue) || this.m_Gs.Snake.HeadCoordinate.X == -1 || this.m_Gs.Snake.HeadCoordinate.X == 20
                || this.m_Gs.Snake.HeadCoordinate.Y == -1 || this.m_Gs.Snake.HeadCoordinate.Y == 19)
            {
                MainScene ms = new MainScene();
                MessageBox.Show("游戏失败!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                ms.Show();
                this.Close();
                return;
            }
            PaintEventArgs b = new PaintEventArgs(this.CreateGraphics(), this.ClientRectangle);
            this.Refresh();
        }
        private void PlayScene_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space: 
                    this.timer1.Stop();
                    break;

                case Keys.Up:
                    if (this.m_Gs.Snake.InitialDirection == this.m_Direction[0] || this.m_Gs.Snake.InitialDirection == this.m_Direction[1])
                    {
                        this.timer1.Interval = 200;
                        break;
                    }
                    this.timer1.Interval = 400;
                    this.m_Gs.Snake.InitialDirection = this.m_Direction[0];
                    break;

                case Keys.Down:
                    if (this.m_Gs.Snake.InitialDirection == this.m_Direction[0] || this.m_Gs.Snake.InitialDirection == this.m_Direction[1])
                    {
                        this.timer1.Interval = 200;
                        break;
                    }
                    this.timer1.Interval = 400;
                    this.m_Gs.Snake.InitialDirection = this.m_Direction[1];
                    break;

                case Keys.Left:
                    if (this.m_Gs.Snake.InitialDirection == this.m_Direction[2] || this.m_Gs.Snake.InitialDirection == this.m_Direction[3])
                    {
                        this.timer1.Interval = 200;
                        break;
                    }
                    this.timer1.Interval = 400;
                    this.m_Gs.Snake.InitialDirection = this.m_Direction[2];
                    break;

                case Keys.Right:
                    if (this.m_Gs.Snake.InitialDirection == this.m_Direction[2] || this.m_Gs.Snake.InitialDirection == this.m_Direction[3])
                    {
                        this.timer1.Interval = 200; 
                        break;
                    }
                    this.timer1.Interval = 400;
                    this.m_Gs.Snake.InitialDirection = this.m_Direction[3];
                    break;
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
                return false;
            else
                return base.ProcessDialogKey(keyData);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.button1.Visible = false;
        }
    }
}
