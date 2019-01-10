using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using MySql.Data.MySqlClient;

using System.Web;

using System.Globalization;
using System.Net;




namespace mlWindow
{
    public partial class shareku : Form
    {
        public shareku()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //用户打开文件浏览

            using (OpenFileDialog dialog = new OpenFileDialog())

            {
                string mid = "";
                string mid2 = "";
                //只能单选一个文件

                dialog.Multiselect = false;

                //选择一个文件

                if (dialog.ShowDialog() == DialogResult.OK)

                {

                    try

                    {

                        //把选择的文件路径给txtPath

                        this.textBox1.Text = dialog.FileName;
                        textBox2.Text = dialog.SafeFileName;




                        textBox3.Text = dialog.FileName.Substring(0, dialog.FileName.Length - dialog.SafeFileName.Length);


                        mid = textBox3.Text.Substring(0, textBox3.Text.LastIndexOf("\\"));


                        textBox5.Text = mid.Substring(0, mid.LastIndexOf("\\") + 1);

                        mid = mid.Substring(mid.LastIndexOf("\\") + 1);

                        // mid2 = mid.Substring(0, mid.LastIndexOf("\\"));

                        textBox4.Text = mid;





                    }

                    catch (Exception ex)

                    {

                        //抛出异常

                        throw (ex);

                    }

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] a;
            //FTP地址
            string ftpPath = "ftp://39.98.38.64/";
            //本机要上传的目录的父目录
            string localPath = textBox5.Text;
            //要上传的目录名
            string fileName = textBox4.Text;

            FileInfo fi = new FileInfo(localPath);
            //判断上传文件是文件还是文件夹
            if ((fi.Attributes & FileAttributes.Directory) != 0)
            {
                //dir 如果是文件夹，则调用[上传文件夹]方法
                UploadDirectory(localPath, ftpPath, fileName);

                a = GetFileList();
                listView1.Items.Clear();
                this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

                if (a != null)
                {

                    for (int i = 0; i < a.Length; i++)   //添加10行数据
                    {
                        ListViewItem lvi = new ListViewItem();

                        //  lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

                        lvi.Text = a[i];

                        //    lvi.SubItems.Add("第2列,第" + i + "行");

                        //  lvi.SubItems.Add("第3列,第" + i + "行");

                        this.listView1.Items.Add(lvi);
                    }

                }


                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。


            }
            else
            {
                //file 如果是文件，则调用[上传文件]方法
                UpLoadFile(localPath, ftpPath);
                a = GetFileList();
                listView1.Items.Clear();
                this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

                if (a != null)
                {

                    for (int i = 0; i < a.Length; i++)   //添加10行数据
                    {
                        ListViewItem lvi = new ListViewItem();

                        //  lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

                        lvi.Text = a[i];

                        //    lvi.SubItems.Add("第2列,第" + i + "行");

                        //  lvi.SubItems.Add("第3列,第" + i + "行");

                        this.listView1.Items.Add(lvi);
                    }

                }


                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] a;
            a = GetFileList();

            /* for (int j=0; j<a.Length; j++)
                 {
               //  .Text = a[j]+"\n";




             }*/
            listView1.Items.Clear();
            this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

            if (a != null)
            {

                for (int i = 0; i < a.Length; i++)   //添加10行数据
                {
                    ListViewItem lvi = new ListViewItem();

                    //  lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

                    lvi.Text = a[i];

                    //    lvi.SubItems.Add("第2列,第" + i + "行");

                    //  lvi.SubItems.Add("第3列,第" + i + "行");

                    this.listView1.Items.Add(lvi);
                }

            }


            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            focused = listView1.Focused;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (focused != false)
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择文件路径";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foldPath = dialog.SelectedPath;
                    MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }





                ftpfile = sharestring + "/" + listView1.FocusedItem.Text;

                // ftpfile= ftpfile.Substring(0,ftpfile.LastIndexOf("."));
                foldPath = foldPath + "/";
                MessageBox.Show(foldPath);

                if (Download(ftpfile, foldPath, listView1.FocusedItem.Text))
                    MessageBox.Show("下载成功，请查看！");
                else
                    MessageBox.Show("下载失败！");
            }
            else
                MessageBox.Show("请在左侧选择要下载的内容");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] a;

            if (focused != false)
            {



                ftpfile = sharestring + "/" + listView1.FocusedItem.Text;

                // ftpfile= ftpfile.Substring(0,ftpfile.LastIndexOf("."));

                MessageBox.Show(ftpfile);

                if (DeleteFile(ftpfile))
                {
                    a = GetFileList();
                    listView1.Items.Clear();
                    this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度

                    if (a != null)
                    {

                        for (int i = 0; i < a.Length; i++)   //添加10行数据
                        {
                            ListViewItem lvi = new ListViewItem();

                            //  lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

                            lvi.Text = a[i];

                            //    lvi.SubItems.Add("第2列,第" + i + "行");

                            //  lvi.SubItems.Add("第3列,第" + i + "行");

                            this.listView1.Items.Add(lvi);
                        }

                    }


                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                    MessageBox.Show("删除成功，请查看！");
                }
                else
                    MessageBox.Show("删除失败！");
            }
            else
                MessageBox.Show("请在左侧选择要删除的内容");
        }


        /// <summary>
        /// 从ftp服务器下载文件的功能
        /// </summary>
        /// <param name="ftpfilepath">ftp下载的地址</param>
        /// <param name="filePath">存放到本地的路径</param>
        /// <param name="fileName">保存的文件名称</param>
        /// <returns></returns>
        public static bool Download(string ftpfilepath, string filePath, string fileName)
        {
            string ftpPath = "ftp://39.98.38.64/";
            string ftpUserID = "cwb";//用户名
            string ftpPassword = "WYR13196054326wyr";//密码



            try
            {
                //filePath = filePath.Replace("我的电脑\\", "");
                String onlyFileName = Path.GetFileName(fileName);
                string newFileName = filePath + onlyFileName;
                if (File.Exists(newFileName))
                {
                    //errorinfo = string.Format("本地文件{0}已存在,无法下载", newFileName);                   
                    File.Delete(newFileName);
                    //return false;
                }
                //ftpfilepath = ftpfilepath.Replace("\\", "/");
                string url = ftpPath + ftpfilepath;
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFtp.UseBinary = true;
                reqFtp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFtp.UsePassive = false;  //选择主动还是被动模式 ,  这句要加上的。


                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                FileStream outputStream = new FileStream(newFileName, FileMode.Create);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                //errorinfo = string.Format("因{0},无法下载", ex.Message);4
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        string file = "";
        string ftpfile = "";
        string filename = "";
        string foldPath = "";

        /// <summary>
        /// 从ftp服务器删除文件的功能
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DeleteFile(string fileName)
        {
            string ftpPath = "ftp://39.98.38.64/";
            string ftpUserID = "cwb";//用户名
            string ftpPassword = "WYR13196054326wyr";//密码
            try
            {
                string url = ftpPath + fileName;
                FtpWebRequest reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                reqFtp.UseBinary = true;
                reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFtp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                //errorinfo = string.Format("因{0},无法下载", ex.Message);
                return false;
            }
        }

        private void ku_Load(object sender, EventArgs e)
        {

            ColumnHeader ch = new ColumnHeader();

            ch.Text = "文件名：";   //设置列标题 
            Width = 500;    //设置列宽度 
            ch.TextAlign = HorizontalAlignment.Left;   //设置列的对齐方式 
            this.listView1.Columns.Add(ch);   //将列头添加到ListView控件
            listView1.View = View.Details;

        }

        bool focused = false;
        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://39.98.38.64/" + sharestring + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential("cwb", "WYR13196054326wyr");
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.UsePassive = false;  //选择主动还是被动模式 ,  这句要加上的。
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);


                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                string ftpPath = "ftp://39.98.38.64/";
                if (!CheckDirectoryExist(ftpPath, sharestring))
                {
                    MessageBox.Show("请先上传文件至数据库");


                }
                downloadFiles = null;
                return downloadFiles;
            }
        }


        private string ftpServerIP = "39.98.38.64";//服务器ip
        private string ftpUserID = "cwb";//用户名
        private string ftpPassword = "WYR13196054326wyr";//密码

        public void UpLoadFile(string localFile, string ftpPath)
        {
            if (!File.Exists(localFile))
            {
                MessageBox.Show("文件：“" + localFile + "” 不存在！");
                return;
            }
            FileInfo fileInf = new FileInfo(localFile);
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(ftpPath);// 根据uri创建FtpWebRequest对象 
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);// ftp用户名和密码
            reqFTP.KeepAlive = false;// 默认为true，连接不会被关闭 // 在一个命令之后被执行
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;// 指定执行什么命令
            reqFTP.UsePassive = false;  //选择主动还是被动模式 ,  这句要加上的。
            reqFTP.UseBinary = true;// 指定数据传输类型
            reqFTP.ContentLength = fileInf.Length;// 上传文件时通知服务器文件的大小
            int buffLength = 2048;// 缓冲大小设置为2kb
            byte[] buff = new byte[buffLength];
            int contentLen;

            // 打开一个文件流 (System.IO.FileStream) 去读上传的文件
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();// 把上传的文件写入流
                contentLen = fs.Read(buff, 0, buffLength);// 每次读文件流的2kb

                while (contentLen != 0)// 流内容没有结束
                {
                    // 把内容从file stream 写入 upload stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);

                    progressBar1.Value = (progressBar1.Value + 1) % (progressBar1.Maximum - progressBar1.Minimum);

                }
                // 关闭两个流
                strm.Close();
                fs.Close();
                MessageBox.Show("文件【" + ftpPath + "/" + fileInf.Name + "】上传成功！<br/>");
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传文件【" + ftpPath + "/" + fileInf.Name + "】时，发生错误：" + ex.Message + "<br/>");
            }


        }
        string sharestring = "share";
        public void UploadDirectory(string localDir, string ftpPath, string dirName)
        {
            string dir = localDir + dirName + @"\"; //获取当前目录（父目录在目录名）
            //检测本地目录是否存在
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("本地目录：“" + dir + "” 不存在！<br/>");
                return;
            }
            //检测FTP的目录路径是否存在
            dirName = sharestring;




            if (!CheckDirectoryExist(ftpPath, dirName))
            {

                MakeDir(ftpPath, dirName);//不存在，则创建此文件夹

            }
            List<List<string>> infos = GetDirDetails(dir); //获取当前目录下的所有文件和文件夹

            //先上传文件
            //Response.Write(dir + "下的文件数：" + infos[0].Count.ToString() + "<br/>");
            for (int i = 0; i < infos[0].Count; i++)
            {
                Console.WriteLine(infos[0][i]);
                UpLoadFile(dir + infos[0][i], ftpPath + dirName + @"/" + infos[0][i]);
            }
            //再处理文件夹
            //Response.Write(dir + "下的目录数：" + infos[1].Count.ToString() + "<br/>");
            for (int i = 0; i < infos[1].Count; i++)
            {
                UploadDirectory(dir, ftpPath + dirName + @"/", infos[1][i]);
                //Response.Write("文件夹【" + dirName + "】上传成功！<br/>");
            }
        }
        private bool CheckDirectoryExist(string ftpPath, string dirName)
        {
            bool flag = true;
            try
            {
                //实例化FTP连接
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpPath + dirName);
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
        public void MakeDir(string ftpPath, string dirName)
        {

            FtpWebRequest reqFTP;
            try
            {
                string ui = (ftpPath + dirName).Trim();
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(ui);
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                ftpStream.Close();
                response.Close();
                // MessageBox.Show("文件夹【" + dirName + "】创建成功！<br/>");
            }

            catch (Exception ex)
            {
                //  MessageBox.Show("新建文件夹【" + dirName + "】时，发生错误：" + ex.Message);
            }

        }
        private List<List<string>> GetDirDetails(string localDir)
        {
            List<List<string>> infos = new List<List<string>>();
            try
            {
                infos.Add(Directory.GetFiles(localDir).ToList()); //获取当前目录的文件

                infos.Add(Directory.GetDirectories(localDir).ToList()); //获取当前目录的目录

                for (int i = 0; i < infos[0].Count; i++)
                {
                    int index = infos[0][i].LastIndexOf(@"\");
                    infos[0][i] = infos[0][i].Substring(index + 1);
                }
                for (int i = 0; i < infos[1].Count; i++)
                {
                    int index = infos[1][i].LastIndexOf(@"\");
                    infos[1][i] = infos[1][i].Substring(index + 1);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return infos;
        }

        private void shareku_Load(object sender, EventArgs e)
        {
            ColumnHeader ch = new ColumnHeader();

            ch.Text = "文件名：";   //设置列标题 
            Width = 500;    //设置列宽度 
            ch.TextAlign = HorizontalAlignment.Left;   //设置列的对齐方式 
            this.listView1.Columns.Add(ch);   //将列头添加到ListView控件
            listView1.View = View.Details;
        }
    }
}
