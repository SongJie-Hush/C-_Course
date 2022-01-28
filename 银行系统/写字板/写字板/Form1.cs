using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写字板
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 撤销UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Undo();
        }

        private void 重复RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Redo();
        }

        private void 剪切TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Cut();
        }

        private void 复制CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Copy();
        }

        private void 粘贴PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Paste();
        }

        private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.SelectAll();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Clear();
            string s_Filename = "";
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.InitialDirectory = "C:\\";
            OpenFileDialog1.Filter = "文本文件|*.txt|C#文件|*.cs|所有文件|*.*";
            OpenFileDialog1.RestoreDirectory = true;
            OpenFileDialog1.FilterIndex = 1;
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                s_Filename = OpenFileDialog1.FileName;
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                rtbContent.SelectionFont = fontDialog1.Font;

        }

    }
}
