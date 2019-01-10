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
    public partial class Formzhuce : Form
    {
        public Formzhuce()
        {
            InitializeComponent();
        }
        static string conStr = "server=39.98.38.64;port=3306;database=userdata;user=root;password=13196054326";
        MySqlConnection con = new MySqlConnection(conStr);


        private void Formzhuce_Load(object sender, EventArgs e)
        {

            textBox2.PasswordChar = '@';
            textBox2.UseSystemPasswordChar = true;
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        bool sameflag=false;
        private void button2_Click(object sender, EventArgs e)
        {
            string userName = this.textBox1.Text;
            string userPassword = this.textBox2.Text;

            con.Open();
            string sql = "select * from userdata";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            string name = "";
            string password = "";
            reader.Read();

            int sfyjyzgyh = 0;
            int usernumber = 0;

         //   MessageBox.Show("恭喜您！注册成功！");
            if (userName.Equals("") || userPassword.Equals(""))
            {
                MessageBox.Show("用户名或密码不能为空！");
                sfyjyzgyh++;
            }
            // 若不为空，验证用户名和密码是否与数据库匹配
            // 这里只做字符串对比验证
            else
            {
                while (reader.Read())
                {
                    usernumber++;
                    name = reader.GetString("id");
                    password = reader.GetString("password");
              
                    //string name1 = name.ToString();
                    //用户名和密码验证正确，提示成功，并执行跳转界面。
                    if (userName == name )
                    {
                        MessageBox.Show("对不起！该用户名已存在");
                        sfyjyzgyh ++;

                        /**
                         * 待添加代码区域
                         * 实现界面跳转功能
                         * 
                         */
                        //this.DialogResult = DialogResult.OK;
                      //  this.Dispose();
                        //this.Close();
                    }
                    //用户名和密码验证错误，提示错误。
                }

            }
            reader.Close();
            string newusername = "";
            string newpassword = "";

            if (sfyjyzgyh == 0)
            {
                usernumber++;
                usernumber++;
                newusername = userName;
                newpassword = userPassword;
                string user = "user";
                string sqlwrite = "insert into userdata(number,id,password,role) value('"+usernumber+"','"+newusername+"','"+ newpassword + "','" + user + "')";
                MySqlCommand cmd2 = new MySqlCommand(sqlwrite, con);
                cmd2.ExecuteNonQuery();





                //MySqlCommand cmd2 = new MySqlCommand("insert into userdata set number ='" + usernumber + "'" + ",id='" + newusername + "'"+", password = '" + newpassword + "'"+",role='"+user+"'", con);
                MessageBox.Show("恭喜您！注册成功！");
                //cmd2.ExecuteNonQuery();
              
                Form1 signform = new Form1();
               
                //signform.ShowDialog(this);
                signform.Show();
               
                this.Hide();

            }



            con.Close();





        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '@';
            textBox3.UseSystemPasswordChar = true;
            if (textBox3.Text != textBox2.Text)
            {
                label5.Text = "两次输入密码不一致";

            }
            else
            {
                label5.Text = "两次输入密码一致";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
