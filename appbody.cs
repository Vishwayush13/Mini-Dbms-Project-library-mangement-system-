using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Library_Management_System
{
    public partial class AppBody : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public AppBody()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void logoff_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!contentPanel.Controls.Contains(Books_Usercontrol.Instance))
            {
                contentPanel.Controls.Add(Books_Usercontrol.Instance);
                Books_Usercontrol.Instance.Dock = DockStyle.Fill;
                Books_Usercontrol.Instance.BringToFront();

            }
            else
            {
                Books_Usercontrol.Instance.BringToFront();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!contentPanel.Controls.Contains(borrow_usercontrol.Instance))
            {
                contentPanel.Controls.Add(borrow_usercontrol.Instance);
                borrow_usercontrol.Instance.Dock = DockStyle.Fill;
                borrow_usercontrol.Instance.BringToFront();
            }
            else
            {
                borrow_usercontrol.Instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!contentPanel.Controls.Contains(transaction_usercontrol.Instance))
            {
                contentPanel.Controls.Add (transaction_usercontrol.Instance);
                transaction_usercontrol.Instance.Dock= DockStyle.Fill;
                transaction_usercontrol.Instance.BringToFront();

            }
            else
            {   transaction_usercontrol.Instance.BringToFront();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!contentPanel.Controls.Contains(settings_usercontrol.Instance))
            {
                contentPanel.Controls.Add(settings_usercontrol.Instance);
                settings_usercontrol.Instance.Dock = DockStyle.Fill;
                settings_usercontrol.Instance.BringToFront();

            }
            else
            {
               settings_usercontrol.Instance.BringToFront();


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!contentPanel.Controls.Contains(about_usercontrol.Instance))
            {
                contentPanel.Controls.Add(about_usercontrol.Instance);
                about_usercontrol.Instance.Dock = DockStyle.Fill;
                about_usercontrol.Instance.BringToFront();

            }
            else
            {
                about_usercontrol.Instance.BringToFront();


            }
        }
    }
}
