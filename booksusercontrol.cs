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
    public partial class Books_Usercontrol : UserControl
    {

        SqlConnection con = new SqlConnection("Data Source=Laptop\\SQLEXPRESS;Initial Catalog=libdb;Integrated Security=True");

        private static Books_Usercontrol _instance;
        public static Books_Usercontrol Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Books_Usercontrol();
                }
                return _instance;
            }
        }
        public Books_Usercontrol()
        {
            InitializeComponent();
        }
        private void Books_Usercontrol_Load(object sender, EventArgs e)
        {
            refresh_DatagridView();
        }
        public void refresh_DatagridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllbooks_SP", con);
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
                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch(Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Booksdelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id", bookIDtextBox2.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" << INVALID QUERY \n" + ex);
                }
                con.Close();
                refresh_DatagridView();


            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            
        }

        private void Addnew_Click(object sender, EventArgs e){
            SqlCommand cmd = new SqlCommand("BooksAdd_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@book_id", bookIDtextBox2.Text);
            cmd.Parameters.AddWithValue("@title",nametextbox.Text);
            cmd.Parameters.AddWithValue("@author",author_textbox.Text);
            cmd.Parameters.AddWithValue("@publisher",publisher_textbox.Text);
            cmd.Parameters.AddWithValue("@d_id",d_idtextBox.Text);
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
            refresh_DatagridView();
            }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try{
                 SqlCommand cmd = new SqlCommand("SearchBooks_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id",bookidtextBox1.Text);
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

                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            catch (Exception ex){
                MessageBox.Show(" " + ex);
                }
             }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            bookidtextBox1.Text = "";
            bookIDtextBox2.Text = " ";
            nametextbox.Text = " ";
            publisher_textbox.Text = " ";
            author_textbox.Text = " ";
            d_idtextBox.Text = " ";
            refresh_DatagridView();

        }
    }
}
