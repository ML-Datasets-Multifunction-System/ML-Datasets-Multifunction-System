using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace mlWindow
{
    public partial class ChangePassword : Form
    {
        static string conStr = "server=39.98.38.64;port=3306;database=userdata;user=root;password=13196054326";
        MySqlConnection con = new MySqlConnection(conStr);

        public ChangePassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public string name = "";
        private void button3_Click(object sender, EventArgs e)
        {
            //1. 获取数据
            //从TextBox中获取用户输入信息


            string userName = this.textBox1.Text;
            string userPassword = this.textBox2.Text;

            string sql = "select * from userdata";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            /* while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
             {
                 //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                 //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                 MessageBox.Show(reader.GetInt32("id") + reader.GetString("password") + reader.GetString("role"));//"userid"是数据库对应的列名，推荐这种方式
             }
             */
            //string name="";
            string password = "";
            reader.Read();

            int denglu = 0;
            int dengluxianshi = 0;
            //2. 验证数据
            // 验证用户输入是否为空，若为空，提示用户信息
            if (userName.Equals("") || userPassword.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            // 若不为空，验证用户名和密码是否与数据库匹配
            // 这里只做字符串对比验证
            else
            {
                while (reader.Read())
                {
                    name = reader.GetString("id");
                    password = reader.GetString("password");
                    denglu++;
                    //string name1 = name.ToString();
                    //用户名和密码验证正确，提示成功，并执行跳转界面。
                    if (userName == name && userPassword == password)
                    {




                        MessageBox.Show("登录成功！");
                        namestring.namestr = name;
                        dengluxianshi++;
                        /**
                         * 待添加代码区域
                         * 实现界面跳转功能
                         * 
                         */
                        XZGG mainform = new XZGG();

                        //signform.ShowDialog(this);
                        mainform.Show();

                        this.Hide();


                        //this.DialogResult = DialogResult.OK;
                        // this.Dispose();
                        // this.Close();
                    }
                    //用户名和密码验证错误，提示错误。
                }
                if (denglu > 0 && dengluxianshi == 0)
                {
                    MessageBox.Show("用户名或密码错误！");
                }

            }
            con.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                //    MessageBox.Show("OK");
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
            }
            //  Check();
            con.Close();
            textBox2.PasswordChar = '@';
            textBox2.UseSystemPasswordChar = true;

        }

        void Check()
        {
            string sql = "select * from userdata";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
                //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                MessageBox.Show(reader.GetInt32("id") + reader.GetString("password") + reader.GetString("role"));//"userid"是数据库对应的列名，推荐这种方式
            }
        }
    }
}
