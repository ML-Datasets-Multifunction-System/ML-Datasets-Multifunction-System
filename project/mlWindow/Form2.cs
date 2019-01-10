using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace mlWindow
{
    
    public partial class Form2 : Form
    {
        public int[,] jxarray = new int[100, 4];
        public bool SetLabel = false;
        public Form2()
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.Paint += pictureBox1_Paint2;
            


        }
        string file = "";


        bool bDrawStart = false;

        Point pointStart = Point.Empty;

        Point pointContinue = Point.Empty;

        public bool clearflag=false;
        private void pictureBox1_Paint2(object sender, PaintEventArgs e)
        {
            if (clearflag)
            {
                Graphics clear = e.Graphics;
                clear.Clear(BackColor);
                dicPoints.Clear();
                dx = 0;
                clearflag = false;
            }
        }



        
        public int dx = 0;
        public int jxcounter = 0;
        Dictionary<Point, Point> dicPoints = new Dictionary<Point, Point>();

        private void pictureBox1_Paint(object sender, PaintEventArgs e)

        {

            System.Drawing.Pen pen = new System.Drawing.Pen(Color.LimeGreen);



            pen.Width = 2;

            if (bDrawStart)

            {

                //实时的画矩形

                Graphics g = e.Graphics;

                g.DrawRectangle(pen, pointStart.X, pointStart.Y, pointContinue.X - pointStart.X, pointContinue.Y - pointStart.Y);
            }



            //实时的画之前已经画好的矩形

            foreach (var item in dicPoints)

            {

                Point p1 = item.Key;

                Point p2 = item.Value;

                e.Graphics.DrawRectangle(pen, p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
            }
            /*
            foreach (KeyValuePair<Point, Point> item in dicPoints)

            {
                if (dx<dicPoints.Count)
                {
                    Point p3 = item.Key;

                    Point p4 = item.Value;




                    jxarray[jxcounter, 0] = p3.X;
                    jxarray[jxcounter, 1] = p3.Y;
                    jxarray[jxcounter, 2] = p4.X;
                    jxarray[jxcounter, 3] = p4.Y;

                  // MessageBox.Show(dicPoints.Count.ToString());
                    dx++;
                    jxcounter++;
                    textBox1.Text = jxarray[0, 0].ToString();
                    textBox2.Text = jxarray[0, 1].ToString();
                    textBox3.Text = jxarray[0, 2].ToString();
                    textBox4.Text = jxarray[0, 3].ToString();
                    textBox8.Text = jxarray[5, 0].ToString();
                    textBox7.Text = jxarray[5, 1].ToString();
                    textBox6.Text = jxarray[5, 2].ToString();
                    textBox5.Text = jxarray[5, 3].ToString();


                }

            }
            */

            pen.Dispose();

        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

           // int x = pointStart.X;
          //  int y = pointStart.Y;
          //  string x1 = jxarray[0,0].ToString();
          //  string y1 = jxarray[0,1].ToString();
          //  string x2 = jxarray[0,2].ToString();
           // string y2 = jxarray[0,3].ToString();

//
          //  textBox1.Text = x1;
           // textBox2.Text = y1;
           // textBox3.Text = x2;
          //  textBox4.Text = y2;
          //  textBox8.Text = jxarray[1,0].ToString();
          //  textBox7.Text = jxarray[1,1].ToString();
           // textBox6.Text = jxarray[1,2].ToString();
           // textBox5.Text = jxarray[1,3].ToString();

            //MessageBox.Show(xx);
            // MessageBox.Show(yy);
        }




        
 


        public string  picturename="";
        public string pictureloc = "";
        public string plabel1 = "";
        public string plabel2 = "";
        public string plabel3 = "";
        public string plabel4 = "";

        public bool SelectPic = false;
        private void button1_Click(object sender, EventArgs e)
        {
            SelectPic = true;
            if (SetLabel)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = true;
                fileDialog.Title = "请选择文件";
                fileDialog.Filter = "所有文件(*jpg*)|*.jpg*"; //设置要选择的文件的类型
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    file = fileDialog.FileName;//返回文件的完整路径   
                    pictureloc = file;
                    picturename = fileDialog.SafeFileName;
                }
                pictureBox1.ImageLocation = file;
                plabel1 = textBox8.Text;
                plabel2 = textBox7.Text;
                plabel3 = textBox6.Text;
                plabel4 = textBox5.Text;

                toolStripMenuItem1.Text = plabel1;
                toolStripMenuItem2.Text = plabel2;
                toolStripMenuItem3.Text = plabel3;
                toolStripMenuItem4.Text = plabel4;

                toolStripMenuItem6.Text = plabel1;
                toolStripMenuItem7.Text = plabel2;
                toolStripMenuItem8.Text = plabel3;
                toolStripMenuItem9.Text = plabel4;

                toolStripMenuItem11.Text = plabel1;
                toolStripMenuItem12.Text = plabel2;
                toolStripMenuItem13.Text = plabel3;
                toolStripMenuItem14.Text = plabel4;

                toolStripMenuItem16.Text = plabel1;
                toolStripMenuItem17.Text = plabel2;
                toolStripMenuItem18.Text = plabel3;
                toolStripMenuItem19.Text = plabel4;

            }
            else {
                MessageBox.Show("请先设置类标！");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            SetLabel = true;
            // toolStripTextBox1.Text = textBox8.Text;
            //toolStripComboBox1.Text = textBox8.Text;
            toolStripMenuItem1.Text = textBox8.Text;
            toolStripMenuItem6.Text = textBox8.Text;
            toolStripMenuItem11.Text = textBox8.Text;
            toolStripMenuItem16.Text = textBox8.Text;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            toolStripMenuItem2.Text = textBox7.Text;
            toolStripMenuItem7.Text = textBox7.Text;
            toolStripMenuItem12.Text = textBox7.Text;
            toolStripMenuItem17.Text = textBox7.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            toolStripMenuItem3.Text = textBox6.Text;
            toolStripMenuItem8.Text = textBox6.Text;
            toolStripMenuItem13.Text = textBox6.Text;
            toolStripMenuItem18.Text = textBox6.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            toolStripMenuItem4.Text = textBox5.Text;
            toolStripMenuItem9.Text = textBox5.Text;
            toolStripMenuItem14.Text = textBox5.Text;
            toolStripMenuItem19.Text = textBox5.Text;
        }
        public int picturenum = 1;
        
      
        private void button2_Click(object sender, EventArgs e)
        {
            string str = savepath; // 获取当前执行文件的路径 
            string filenameIM = str + "\\ImageSets" + "\\Main";
            string filenameJ = str + "\\JPEGImages"; // 在该路径下打算创建一个叫做picture的文件夹
            string filenameI = str + "\\ImageSets"; // 在该路径下打算创建一个叫做picture的文件夹
            string dest = filenameJ + "\\" + picturenum.ToString("000000") + ".jpg";// 文件的完全路径
            string filenameA = str + "\\Annotations"; // 在该路径下打算创建一个叫做picture的文件夹
 

            if ((textBox17.Text != "")&&(SelectPic))
            {
                SelectPic = false;
                if (!Directory.Exists(filenameJ)) //如果该文件夹不存在就建立这个新文件夹
                {
                    Directory.CreateDirectory(filenameJ);
                }


                if (!Directory.Exists(filenameA)) //如果该文件夹不存在就建立这个新文件夹
                {
                    Directory.CreateDirectory(filenameA);
                }


                if (!Directory.Exists(filenameI)) //如果该文件夹不存在就建立这个新文件夹
                {
                    Directory.CreateDirectory(filenameI);
                }


                if (!Directory.Exists(filenameIM)) //如果该文件夹不存在就建立这个新文件夹
                {
                    Directory.CreateDirectory(filenameIM);
                }






                if (File.Exists(dest))
                {
                    File.Delete(dest);
                }



               // File.Copy(pictureloc, dest);
                Image img = Image.FromFile(pictureloc);
                Image newImg = new Bitmap(512,512);
                Graphics gg = Graphics.FromImage(newImg);
                gg.DrawImage(img, 0, 0, 512, 512);
                newImg.Save(dest);
                img.Dispose();
                newImg.Dispose();




                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);
                //创建一个根节点（一级）
                XmlElement root = doc.CreateElement("annotation");
                doc.AppendChild(root);

                XmlElement folder = doc.CreateElement("folder");
                folder.InnerText = "VOC2007";
                root.AppendChild(folder);

                XmlElement filename = doc.CreateElement("filename");
                filename.InnerText = picturenum.ToString("000000") + ".jpg";
                root.AppendChild(filename);



                //创建节点（二级）
                XmlNode size = doc.CreateElement("size");

                XmlElement width = doc.CreateElement("width");
                width.InnerText = "512";
                size.AppendChild(width);

                XmlElement height = doc.CreateElement("height");
                height.InnerText = "512";
                size.AppendChild(height);

                XmlElement depth = doc.CreateElement("depth");
                depth.InnerText = "3";
                size.AppendChild(depth);

                root.AppendChild(size);




                //创建节点（三级）
                //XmlElement element1 = doc.CreateElement("Third1");

                //element1.SetAttribute("Name", "Sam");
                // element1.SetAttribute("ID", "665");
                //element1.InnerText = "Sam Comment";
                // size.AppendChild(element1);

                //XmlElement element2 = doc.CreateElement("Third2");
                //element2.SetAttribute("Name", "Round");
                //element2.SetAttribute("ID", "678");
                //element2.InnerText = "Round Comment";
                //size.AppendChild(element2);




                XmlNode objectnode = doc.CreateElement("object");


                XmlElement name = doc.CreateElement("name");
                name.InnerText = textBox9.Text;
                objectnode.AppendChild(name);

                XmlElement pose = doc.CreateElement("pose");
                pose.InnerText = "Unspecified";
                objectnode.AppendChild(pose);

                XmlElement truncated = doc.CreateElement("truncated");
                truncated.InnerText = "0";
                objectnode.AppendChild(truncated);

                XmlElement difficult = doc.CreateElement("difficult");
                difficult.InnerText = "0";
                objectnode.AppendChild(difficult);

                XmlElement bndbox = doc.CreateElement("bndbox");

                XmlElement xminx = doc.CreateElement("xmin");
                xminx.InnerText = jxarray[0, 0].ToString();
                bndbox.AppendChild(xminx);

                XmlElement yminy = doc.CreateElement("ymin");
                yminy.InnerText = jxarray[0, 1].ToString();
                bndbox.AppendChild(yminy);

                XmlElement xmaxx = doc.CreateElement("xmax");
                xmaxx.InnerText = jxarray[0, 2].ToString();
                bndbox.AppendChild(xmaxx);

                XmlElement ymaxy = doc.CreateElement("ymax");
                ymaxy.InnerText = jxarray[0, 3].ToString();
                bndbox.AppendChild(ymaxy);

                objectnode.AppendChild(bndbox);
                root.AppendChild(objectnode);
                ///////////////////////////////////////////////////////
                XmlNode objectnode2 = doc.CreateElement("object");


                XmlElement name2 = doc.CreateElement("name");
                name2.InnerText = textBox10.Text;
                objectnode2.AppendChild(name2);

                XmlElement pose2 = doc.CreateElement("pose");
                pose2.InnerText = "Unspecified";
                objectnode2.AppendChild(pose2);

                XmlElement truncated2 = doc.CreateElement("truncated");
                truncated2.InnerText = "0";
                objectnode2.AppendChild(truncated2);

                XmlElement difficult2 = doc.CreateElement("difficult");
                difficult2.InnerText = "0";
                objectnode2.AppendChild(difficult2);

                XmlElement bndbox2 = doc.CreateElement("bndbox");

                XmlElement xminx2 = doc.CreateElement("xmin");
                xminx2.InnerText = jxarray[1, 0].ToString();
                bndbox2.AppendChild(xminx2);

                XmlElement yminy2 = doc.CreateElement("ymin");
                yminy2.InnerText = jxarray[1, 1].ToString();
                bndbox2.AppendChild(yminy2);

                XmlElement xmaxx2 = doc.CreateElement("xmax");
                xmaxx2.InnerText = jxarray[1, 2].ToString();
                bndbox2.AppendChild(xmaxx2);

                XmlElement ymaxy2 = doc.CreateElement("ymax");
                ymaxy2.InnerText = jxarray[1, 3].ToString();
                bndbox2.AppendChild(ymaxy2);

                objectnode2.AppendChild(bndbox2);

                if ((jxarray[1, 3] != 0) && (textBox10.Text != ""))
                {

                    root.AppendChild(objectnode2);

                }

                /////////////////////////////////////////////////////

                XmlNode objectnode3 = doc.CreateElement("object");


                XmlElement name3 = doc.CreateElement("name");
                name3.InnerText = textBox11.Text;
                objectnode3.AppendChild(name3);

                XmlElement pose3 = doc.CreateElement("pose");
                pose3.InnerText = "Unspecified";
                objectnode3.AppendChild(pose3);

                XmlElement truncated3 = doc.CreateElement("truncated");
                truncated3.InnerText = "0";
                objectnode3.AppendChild(truncated3);

                XmlElement difficult3 = doc.CreateElement("difficult");
                difficult3.InnerText = "0";
                objectnode3.AppendChild(difficult3);

                XmlElement bndbox3 = doc.CreateElement("bndbox");

                XmlElement xminx3 = doc.CreateElement("xmin");
                xminx3.InnerText = jxarray[2, 0].ToString();
                bndbox3.AppendChild(xminx3);

                XmlElement yminy3 = doc.CreateElement("ymin");
                yminy3.InnerText = jxarray[2, 1].ToString();
                bndbox3.AppendChild(yminy3);

                XmlElement xmaxx3 = doc.CreateElement("xmax");
                xmaxx3.InnerText = jxarray[2, 2].ToString();
                bndbox3.AppendChild(xmaxx3);

                XmlElement ymaxy3 = doc.CreateElement("ymax");
                ymaxy3.InnerText = jxarray[2, 3].ToString();
                bndbox3.AppendChild(ymaxy3);

                objectnode3.AppendChild(bndbox3);

                if ((jxarray[2, 3] != 0) && (textBox11.Text != ""))
                {

                    root.AppendChild(objectnode3);

                }
                //////////////////////////////////////////////////
                XmlNode objectnode4 = doc.CreateElement("object");


                XmlElement name4 = doc.CreateElement("name");
                name4.InnerText = textBox12.Text;
                objectnode4.AppendChild(name4);

                XmlElement pose4 = doc.CreateElement("pose");
                pose4.InnerText = "Unspecified";
                objectnode4.AppendChild(pose4);

                XmlElement truncated4 = doc.CreateElement("truncated");
                truncated4.InnerText = "0";
                objectnode4.AppendChild(truncated4);

                XmlElement difficult4 = doc.CreateElement("difficult");
                difficult4.InnerText = "0";
                objectnode4.AppendChild(difficult4);

                XmlElement bndbox4 = doc.CreateElement("bndbox");

                XmlElement xminx4 = doc.CreateElement("xmin");
                xminx4.InnerText = jxarray[3, 0].ToString();
                bndbox4.AppendChild(xminx4);

                XmlElement yminy4 = doc.CreateElement("ymin");
                yminy4.InnerText = jxarray[3, 1].ToString();
                bndbox4.AppendChild(yminy4);

                XmlElement xmaxx4 = doc.CreateElement("xmax");
                xmaxx4.InnerText = jxarray[3, 2].ToString();
                bndbox4.AppendChild(xmaxx4);

                XmlElement ymaxy4 = doc.CreateElement("ymax");
                ymaxy4.InnerText = jxarray[3, 3].ToString();
                bndbox4.AppendChild(ymaxy4);

                objectnode4.AppendChild(bndbox4);

                if ((jxarray[3, 3] != 0) && (textBox12.Text != ""))
                {

                    root.AppendChild(objectnode4);

                }












                doc.Save(filenameA + "\\" + picturenum.ToString("000000") + ".xml");








                label5.Text = picturenum.ToString();
                picturenum++;
            }
            else {

                if (textBox17.Text == "")
                {
                    MessageBox.Show("请先选择数据集的保存路径！");
                }

                if (SelectPic ==false)
                {
                    MessageBox.Show("该图片已标记完毕，请选择下一张图片！");
                }

            }

        }
        public bool threadstop;



        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";





            // Form2 mainform2 = new Form2();
            //mainform2.Show();
            //this.Hide();
            // signform.ShowDialog(this);
            //pictureBox1.Refresh();
            //pictureBox1.Image.Dispose();
            //Graphics g = Graphics.FromImage(pictureBox1.Image);
            // g.Clear(Color.White);
            //g.Dispose();
            // pictureBox1.Refresh();
            // pictureBox1.Image = null;
            // pictureBox1.Invalidate();
            //  pictureBox1.Refresh();

            clearflag = true;
            pictureBox1.ImageLocation = "";
            for (int yibai=0;yibai<100;yibai ++)
            {
                
                for (int si=0; si < 4; si++)
                {
                    jxarray[yibai,si] = 0;
                }
            }
            

        }






        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //  e.Cancel = true;
            //   if (DialogResult.Yes == MessageBox.Show("关闭程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
            //  {
            //      e.Cancel = false;
            //  }

            XZGG mainform = new XZGG();

            //signform.ShowDialog(this);
            mainform.Show();

            this.Hide();
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (bDrawStart)

            {

                bDrawStart = false;

            }

            else

            {

                bDrawStart = true;

                pointStart = e.Location;

            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (bDrawStart)

            {

                dicPoints.Add(pointStart, pointContinue);
                if (dx < 10)
                {
                    jxarray[dx, 0] = pointStart.X;
                    jxarray[dx, 1] = pointStart.Y;
                    jxarray[dx, 2] = pointContinue.X;
                    jxarray[dx, 3] = pointContinue.Y;
                    if (jxarray[0, 0] != 0)
                    {
                        textBox1.Text = "x左上=" + jxarray[0, 0].ToString() + " y左上=" + jxarray[0, 1].ToString() + " x右下=" + jxarray[0, 2].ToString() + " y右下=" + jxarray[0, 3].ToString();
                    }
                    else {
                        textBox1.Text = "";
                    }

                    if (jxarray[1, 0] != 0)
                    {
                        textBox2.Text = "x左上=" + jxarray[1, 0].ToString() + " y左上=" + jxarray[1, 1].ToString() + " x右下=" + jxarray[1, 2].ToString() + " y右下=" + jxarray[1, 3].ToString();
                    }
                    else {
                        textBox2.Text = "";
                    }
                    if (jxarray[2, 0] != 0)
                    {
                        textBox3.Text = "x左上=" + jxarray[2, 0].ToString() + " y左上=" + jxarray[2, 1].ToString() + " x右下=" + jxarray[2, 2].ToString() + " y右下=" + jxarray[2, 3].ToString();
                    }
                    else {
                        textBox3.Text = "";
                    }
                    if (jxarray[3, 0] != 0)
                    {
                        textBox4.Text = "x左上=" + jxarray[3, 0].ToString() + " y左上=" + jxarray[3, 1].ToString() + " x右下=" + jxarray[3, 2].ToString() + " y右下=" + jxarray[3, 3].ToString();
                    }
                    else {
                        textBox4.Text = "";
                    }


                    dx++;
                }




            }



            bDrawStart = false;

        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (bDrawStart)

            {

                pointContinue = e.Location;

                Refresh();

            }
        }
        public string savepath = "";
        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.textBox17.Text = path.SelectedPath;
            savepath = path.SelectedPath;
            
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            savepath = textBox17.Text;
        }




        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox9.Text = toolStripMenuItem2.Text;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            textBox9.Text = toolStripMenuItem3.Text;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            textBox9.Text = toolStripMenuItem4.Text;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            textBox10.Text = toolStripMenuItem6.Text;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            textBox10.Text = toolStripMenuItem7.Text;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            textBox10.Text = toolStripMenuItem8.Text;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            textBox10.Text = toolStripMenuItem9.Text;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            textBox11.Text = toolStripMenuItem11.Text;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            textBox11.Text = toolStripMenuItem12.Text;

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            textBox11.Text = toolStripMenuItem13.Text;
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            textBox11.Text = toolStripMenuItem14.Text;
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            textBox12.Text = toolStripMenuItem16.Text;
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            textBox12.Text = toolStripMenuItem17.Text;
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            textBox12.Text = toolStripMenuItem18.Text;
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            textBox12.Text = toolStripMenuItem19.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            textBox9.Text = toolStripMenuItem1.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
          // int[] testarray = { };
            List<int> testarray = new List<int>();
            int[] trainarray = { };
            int[] valarray = { };
            int[] trainval = { };
            //int[] allarray = { };
            List<int> allarray = new List<int>();

            if (Convert.ToInt32(label5.Text) < Convert.ToInt32(textBox13.Text))
            {
                MessageBox.Show("请输入小于已标记样本数量的训练样本数！");
            }
            else {

                  for (int i = 0; i < Convert.ToInt32(label5.Text); i++)
                  {
                     allarray.Add(i + 1);
                }

               


                testarray=GetRandomArray(Convert.ToInt32(label5.Text) / 2, 1, Convert.ToInt32(label5.Text)).ToList();



                string filenameIM = savepath + "\\ImageSets" + "\\Main";

                string newTxtPath = filenameIM + "\\" + "test.txt";
                StreamWriter sw = new StreamWriter(newTxtPath, false, Encoding.Default);
                for (int j = 0; j < Convert.ToInt32(label5.Text) / 2; j++)
                {

 
                    sw.WriteLine(testarray[j].ToString("000000")+"\n");


                }
                sw.Flush();
                sw.Close();




                clearflag = true;
                pictureBox1.ImageLocation = "";
                for (int yibai = 0; yibai < 100; yibai++)
                {

                    for (int si = 0; si < 4; si++)
                    {
                        jxarray[yibai, si] = 0;
                    }
                }


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";

                textBox8.Text = "";
                textBox7.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
                textBox13.Text = "";
                label5.Text = "";
                picturenum = 1;
            }
        }
          public int[] GetRandomArray(int Number, int minNum, int maxNum)
        {
   int j;
   int[] b = new int[Number];
   Random r = new Random();
  for(j=0;j<Number;j++)
            {
  int i = r.Next(minNum, maxNum + 1);
 int num = 0;
   for(int k=0;k<j;k++)
   {
   if(b[k]==i)
    {
    num=num+1;
   }
   }
  if(num==0 )
  {
    b[j]=i;
  }
   else
   {
    j=j-1;
   }
   }
   return b;
  }


    }
}
