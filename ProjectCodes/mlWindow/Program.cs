using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mlWindow
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Form1 login = new Form1();
            
            //界面转换
         //   login.ShowDialog();
/*
            if (login.DialogResult == DialogResult.OK)
            {
                login.Dispose();
                Application.Run(new Form2());
            }
            else if (login.DialogResult == DialogResult.Cancel)
            {
                login.Dispose();
                return;
            }*/



         /*   if (login.DialogResult == DialogResult.Yes)
            {
                login.Dispose();
                Application.Run(new Formzhuce());
            }
            else if (login.DialogResult == DialogResult.Cancel)
            {
                login.Dispose();
                return;
            }*/


        }
    }
}
