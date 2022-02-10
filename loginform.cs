using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=Laptop\\SQLEXPRESS;Initial Catalog=libdb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        private string getusername(){
            con.Open();
            String synatx = "SELECT value FROM sysTable where Property='Username'";
            cmd = new SqlCommand(synatx, con);
            dr  = cmd.ExecuteReader();
            dr.Read();
            string temp = dr[0].ToString();
            con.Close();
            return temp;
            }
        private string getPassword(){
            con.Open();
            String synatx = "SELECT value FROM sysTable where Property='Password'";
            cmd = new SqlCommand(synatx, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            string temp = dr[0].ToString();
            con.Close();
            return temp;}
            private void label3_Click(object sender, EventArgs e){
            String uname = getusername(), upass = getPassword(), name, pass;
            name = textBox1.Text;
            pass = textBox2.Text;
            if(name.Equals(uname) && pass.Equals(upass)){
                label5.Hide();
                AppBody obj = new AppBody();
                this.Hide();
                obj.Show();}
           else{
           label5.Show();
           }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
