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
    public partial class borrow_usercontrol : UserControl
    {
        private static borrow_usercontrol _instance;
        public static borrow_usercontrol Instance
        {
            get { 
                
                if( _instance == null )
                {
                    _instance = new borrow_usercontrol();
                }               
                return _instance; 
            }

        }


        SqlConnection con = new SqlConnection("Data Source=Laptop\\SQLEXPRESS;Initial Catalog=libdb;Integrated Security=True");

        public borrow_usercontrol()
        {
            InitializeComponent();
        }
        public void Refresh_DatagridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllborrower_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" <<< INAVLID SQL OPERATION " + ex);
                }
                con.Close();
                dataGridViewborrow.DataSource = DS.Tables[0];
                this.dataGridViewborrow.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridViewborrow.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridViewborrow.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridViewborrow.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
        private void borrow_usercontrol_Load(object sender, EventArgs e)
        {
            Refresh_DatagridView();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewborrow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addborrower_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("BorrowerAdd_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@br_id",bridtextbox.Text);
            cmd.Parameters.AddWithValue("@name",brnametextbox.Text);
            cmd.Parameters.AddWithValue("@address",addresstextbox.Text);
            cmd.Parameters.AddWithValue("@phone",phonetextbox.Text);
            
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" <<< INVALID SQL OPERATION \n" + ex);

            }
            con.Close();
            Refresh_DatagridView();
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            bridtextbox.Text = "";
            brnametextbox.Text = "";
            addresstextbox.Text = "";
            phonetextbox.Text = "";
            Refresh_DatagridView();
        }
    }
}
