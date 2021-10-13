using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace GreedSnake
{
    public partial class MainScene : Form
    {
        //资源
        private string m_SourcePath = @"D:\\Cs_pro\\GreedSnake\\resource";
        //背景图
        private String m_FileName;
        //背景音乐
        private String m_BackgroundMusic;
        //绘图
        private Draw m_Draw;
        //选择模式
        private static string[] m_StyleClass = new string[] { "单人模式", "双人模式"};
        //选择难度
        private static string[] m_DiffiClass = new string[] { "简单", "一般", "困难" };
        //图片数组
        private static String[] imgArray = new String[] { "\\pifu.jpg", "\\yinliang.jpg", "\\btn4.jpg", "\\more.jpg", "\\wenhao.jpg", "\\sheshe.jpg", "\\bofang.jfif" };
        public MainScene()
        {
            InitializeComponent();
            //设置本窗体
            this.DoubleBuffered = true;
            //使用自定义的绘制方式
            SetStyle(ControlStyles.UserPaint, true);
            // 禁止擦除背景
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            // 双缓冲
            SetStyle(ControlStyles.DoubleBuffer, true);
            //初始化绘图
            this.m_Draw = new Draw();
            //初始化filename
            this.m_FileName = "huabian3.jfif";
            //界面
            this.Interface();
            //大小响应
            this.SizeChanged += new EventHandler(FormSize_Change);
        }

        private void FormSize_Change(object sender, EventArgs e)
        {
            //界面
            this.Interface();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayScene ps;
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {   //游戏状态
                GameState gs = new GameState(m_StyleClass[comboBox1.SelectedIndex], m_DiffiClass[comboBox2.SelectedIndex]);
                ps = new PlayScene(gs);     
            }
            else
            {
                MessageBox.Show("请选择游戏模式和难度等级!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            ps.Show();
            this.Hide();
        }

        private void MainScene_Load(object sender, EventArgs e)
        {
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        //更换音乐
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择背景音乐";
            ofd.InitialDirectory = @"D:\\Cs_pro\\GreedSnake\\resource";
            ofd.Filter = "(*.mp3)|*.mp3";
            //表示可以多选
            ofd.Multiselect = false;
            //按下哪个按钮，对应的发生什么事件
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string bgPath = System.IO.Path.GetDirectoryName(ofd.FileName);
                this.m_BackgroundMusic = ofd.SafeFileName;
                //背景音乐变化
                this.axWindowsMediaPlayer1.URL = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择图片";
            ofd.InitialDirectory = @"D:\\Cs_pro\\GreedSnake\\resource";
            ofd.Filter = "(*.jpg;*.jfif)|*.jpg;*.jfif";
            //表示可以多选
            ofd.Multiselect = false;
            //按下哪个按钮，对应的发生什么事件
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string bgPath = System.IO.Path.GetDirectoryName(ofd.FileName);
                this.m_FileName = ofd.SafeFileName;
                //背景变化
                this.BackgroundImage = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(bgPath, ("\\" + this.m_FileName)))), new Size(this.Width, this.Height));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本游戏是一款贪吃蛇休闲类小游戏，玩家通过选择游戏难度来开启相应的地图进行游戏,同时玩家也可以和自己的好伙伴一起游戏，" +
                "当选择单人模式时，玩家可通过按下方向键控制蛇的方向，而在双人模式下，增加了wsad作为另一位玩家的方向键" , "攻略", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);   
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }
        public void Interface()
        {
            //背景
            this.BackgroundImage = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, ("\\" + this.m_FileName)))), new Size(1000, 700));
            this.SetBounds(250, 100, BackgroundImage.Width, BackgroundImage.Height);
            //皮肤
            this.button2.Image = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, imgArray[0]))), new Size((int)(this.Width * 0.08), (int)(this.Height * 0.11)));
            this.button2.SetBounds((int)(this.Width * 0.01), (int)(this.Height * 0.02), (int)(this.Width * 0.08), (int)(this.Height * 0.11));
            //开始
            this.button1.Image = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, imgArray[2]))), new Size((int)(this.Width * 0.2), (int)(this.Height * 0.13)));
            this.button1.SetBounds((int)(this.Width * 0.4), (int)(this.Height * 0.6), (int)(this.Width * 0.2), (int)(this.Height * 0.13));
            //加号
            this.button4.Image = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, imgArray[3]))), new Size((int)(this.Width * 0.1), (int)(this.Height * 0.11)));
            this.button4.SetBounds((int)(this.Width * 0.9), (int)(this.Height * 0.02), (int)(this.Width * 0.08), (int)(this.Height * 0.11));
            //问号
            this.button5.Image = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, imgArray[4]))), new Size((int)(this.Width * 0.08), (int)(this.Height * 0.11)));
            this.button5.SetBounds((int)(this.Width * 0.9), (int)(this.Height * 0.83), (int)(this.Width * 0.08), (int)(this.Height * 0.11));
            //蛇
            this.button6.Image = this.m_Draw.resizeBackgroundImage(new Bitmap(System.Drawing.Image.FromFile(string.Concat(m_SourcePath, imgArray[5]))), new Size((int)(this.Width * 0.2), (int)(this.Height * 0.3)));
            this.button6.SetBounds((int)(this.Width * 0.4), 0, (int)(this.Width * 0.2), (int)(this.Height * 0.3));
            //播放器
            this.axWindowsMediaPlayer1.SetBounds((int)(this.Width * 0.01), (int)(this.Height * 0.86), (int)(this.Width * 0.3), (int)(this.Height * 0.06));
            //游戏模式
            this.comboBox1.Items.Add($"{m_StyleClass[0]}");
            this.comboBox1.Items.Add($"{m_StyleClass[1]}");
            this.comboBox1.SetBounds((int)(this.Width * 0.4), (int)(this.Height * 0.4), (int)(this.Width * 0.2), (int)(this.Height * 0.13));
            //游戏难度
            this.comboBox2.Items.Add($"{m_DiffiClass[0]}");
            this.comboBox2.Items.Add($"{m_DiffiClass[1]}");
            this.comboBox2.Items.Add($"{m_DiffiClass[2]}");
            this.comboBox2.SetBounds((int)(this.Width * 0.4), (int)(this.Height * 0.5), (int)(this.Width * 0.2), (int)(this.Height * 0.13));
            //进度条
            //this.progressBar1.Value = 0;
            //this.progressBar1.SetBounds((int)(this.Width * 0.35), (int)(this.Height * 0.85), (int)(this.Width * 0.3), (int)(this.Height * 0.07));
            this.progressBar1.Visible = false;
        }
        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void button7_Click(object sender, EventArgs e)
        {
        }
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
        }
    }
}
