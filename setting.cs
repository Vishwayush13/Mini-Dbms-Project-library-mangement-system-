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
    public partial class settings_usercontrol : UserControl
    {
        private static settings_usercontrol _instance;
        public static settings_usercontrol Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new settings_usercontrol();
                return _instance;

            }
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-636UV7BI\\SQLEXPRESS;Initial Catalog=libdb;Integrated Security=True");
        public settings_usercontrol()
        {
            InitializeComponent();
        }

        private void logdetailsbutton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("showall_logdetails", con);
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
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }
    }
}
