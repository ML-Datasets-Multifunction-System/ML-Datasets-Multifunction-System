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
    public partial class web : Form
    {
        public web()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text.Trim();
            if (url == "")
            {
                url = "www.baidu.com";
                webBrowser1.Navigate(url);

            }
            else
                webBrowser1.Navigate(url);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)

        {

            

        }

        private void webBrowser1_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
            comboBox1.Text = webBrowser1.Url.ToString();
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            string url = this.webBrowser1.StatusText;
            this.webBrowser1.Url = new Uri(url);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
    }
}
