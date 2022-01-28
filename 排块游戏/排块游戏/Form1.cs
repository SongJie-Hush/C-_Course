using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 排块游戏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int N = 4; //按钮的行列数
        Button[,] buttons = new Button[N, N];//按钮的数组

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateAllButtons();
        }

        //生成所有按钮
        public void GenerateAllButtons()
        {
            int x0 = 100, y0 = 10, w = 45, d = 50;
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    int num = r * N + c;
                    Button btn = new Button();
                    btn.Text = (num + 1).ToString();
                    btn.Top = y0 + r * d;
                    btn.Left = x0 + c * d;
                    btn.Width = w;
                    btn.Height = w;
                    btn.Visible = true;
                    btn.Tag = r * N + c;
                    btn.Click += btn_Click;
                    buttons[r, c] = btn;//放到数组中
                    this.Controls.Add(btn);
                }
            buttons[N - 1, N - 1].Visible = false;
        }

        //打乱顺序
        public void shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int a = rnd.Next(N );
                int b = rnd.Next(N );
                int c = rnd.Next(N );
                int d = rnd.Next(N );
                swap(buttons[a, b], buttons[c, d]);
            }
        }
        //交换两个按钮
        public void swap(Button btna, Button btnb)
        {
            //交换文本
            string text = btna.Text;
            btna.Text = btnb.Text;
            btnb.Text = text;

            //交换按钮的可见性
            bool v = btna.Visible;
            btna.Visible = btnb.Visible;
            btnb.Visible = v;
        }

        //点击排块
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;//当前点中的按钮从object变成Button 
            Button blank = FindHiddenButton();

            //是否与白块相邻，是的话则交换
            if (IsNeighbour(btn, blank))
            {
                swap(btn, blank);
                blank.Focus();
            }

            //判断是否完成
            if (ResultIsOK())
                MessageBox.Show("OK");
        }

        //找隐藏的按钮
        public Button FindHiddenButton()
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (!buttons[i, j].Visible)
                        return buttons[i, j];
                }
            return null;
        }

        //判断是否与白块相邻
        public bool IsNeighbour(Button btna, Button btnb)
        {
            int a=(int )btna.Tag ;
            int b=(int )btnb .Tag ;
            int ra = a / N; int ca = a % N;
            int rb = b / N; int cb = b % N;
            if (ra == rb && (ca == cb + 1 || ca == cb - 1) || ca == cb && (ra == rb + 1 || ra == rb - 1))
                return true;
            return false;
        }

        bool ResultIsOK()
        {
            for(int r=0;r<N;r++)
                for (int c = 0; c < N; c++)
                {
                    if (buttons [r,c].Text !=(r *N +c +1).ToString ())
                    return false ;
                }
            return true ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shuffle();
        }
    }
}
