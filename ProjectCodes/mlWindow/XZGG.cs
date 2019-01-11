using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mlWindow
{
    public partial class XZGG : Form
    {
        public XZGG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 mainform = new Form2();

            //signform.ShowDialog(this);
            mainform.Show();

            this.Hide();
        }

        private void 损失ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 qiehuan = new Form1();

            //signform.ShowDialog(this);
            qiehuan.Show();

            this.Hide();
        }

        private void 目标检测数据集生成工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Form2 mainform = new Form2();

            //signform.ShowDialog(this);
            // mainform.Show();

            // this.Hide();
            ClosePreForm();

            Form2 objecttool = new Form2();
            //嵌入窗体前判断当前容器中是否有窗口没关掉
            
            OpenForm(objecttool);


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ClosePreForm()
        {
            foreach (Control item in this.panel1.Controls)
            {
                if (item is Form)
                {
                    //Form objControl = (Form)item;
                    /*objControl.Hide();
                    objControl.Close();
                    objControl.Dispose();*/
                    item.Hide(); 
                }

            }
        }
        private void OpenForm(Form objFrm)
        {
            //嵌入子窗体到父窗体中，把添加学员信息嵌入到主窗体右侧
            objFrm.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
          //  objFrm.WindowState = FormWindowState.Maximized;//将当前窗口设置成最大化
            objFrm.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            objFrm.Parent = this.panel1;//指定子窗体显示的容器
            objFrm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // this.Close();
            System.Environment.Exit(0);
        }

        private void XZGG_FormClosing(object sender, FormClosingEventArgs e)
        {

            // this.Dispose();
            System.Environment.Exit(0);
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreForm();
            ku shareku = new ku();



          
        


            //嵌入窗体前判断当前容器中是否有窗口没关掉

            OpenForm(shareku);




        }

        private void 资料搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {

  




     
        }

        private void 共享ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 数据集仓库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void 浏览器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreForm();
            web browser = new web();


            //嵌入窗体前判断当前容器中是否有窗口没关掉
           
            OpenForm(browser);
        }

        private void 共享云数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosePreForm();
            shareku shareku1 = new shareku();







            //嵌入窗体前判断当前容器中是否有窗口没关掉

            OpenForm(shareku1);

        }
    }
}
