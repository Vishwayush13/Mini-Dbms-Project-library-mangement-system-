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
    public partial class transaction_usercontrol : UserControl
    {
        private static transaction_usercontrol _instance;
        public static transaction_usercontrol Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new transaction_usercontrol();
                return _instance;

            }
        }
        public transaction_usercontrol()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=Laptop\\SQLEXPRESS;Initial Catalog=libdb;Integrated Security=True");
        SqlDataReader DR;
        SqlCommand cmd;
        public string book1, book2, borrower;

        private void transaction_usercontrol_Load(object sender, EventArgs e)
        {

        }

        

       

        private void transaction_usercontrol_Load_1(object sender, EventArgs e)
        {

        }

        private void transaction_usercontrol_Load_2(object sender, EventArgs e)
        {

        }

       

        private void searchbuttonborrow_Click(object sender, EventArgs e){
          // to get book1 value 
            con.Open();
            string syntax="SELECT book1 FROM Borrow_by where br_id ='"+borrowertextbox.Text+"'";
            cmd = new SqlCommand(syntax, con);  
            DR = cmd.ExecuteReader();
            DR.Read();
            Bklabel1.Text=book1=DR[0].ToString();
            con.Close();
            // to get book2 value 
            con.Open();
             syntax = "SELECT book2 FROM Borrow_by where br_id ='"+borrowertextbox.Text+"'";
            cmd = new SqlCommand(syntax, con);
            DR = cmd.ExecuteReader();
            DR.Read();
            BKlabel2.Text = book2 = DR[0].ToString();
            con.Close();
          }
        private void search_buttonbook_Click(object sender, EventArgs e)
        {
            // to get borrower 
            con.Open();
            string syntax = "SELECT borrower FROM Books where book_id ='" + bookIdtextbox.Text + "'";
            cmd = new SqlCommand(syntax, con);
            DR = cmd.ExecuteReader();
            DR.Read();
            BYlabel.Text = borrower = DR[0].ToString();

            con.Close();

        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            bookIdtextbox.Text = "";
            borrowertextbox.Text = "";
            Bklabel1.Text = "";
            BKlabel2.Text = "";
            BYlabel.Text = "";

        }

        private void Issuebook_Click(object sender, EventArgs e){
            // to see if book is borrowed by someone 
            searchbuttonborrow.PerformClick();
            //search_buttonbook.PerformClick();
            if (borrower != ""){
                // some has borrowed the book
                MessageBox.Show("Book is already borrowed by some other borrower with borrower's id: \n " + borrower);
                return;}
            // see if borrower has already taken 2 books 
            searchbuttonborrow.PerformClick();
            if((book1 !="") && (book2 != "")){
                // borrower has already borrowed maximum no of books
                MessageBox.Show("Borrower has already borrowed max no of books");
                return;}
            // now proceed with issue logic
            // set value of book1 and book2 as bookid of book being issued
            try{
                 if(book1 == ""){
                    // book1 must be updated in book1 slot
                    cmd=new SqlCommand("Trans_update_book1_SP", con);}
                else{
                    cmd = new SqlCommand("Trans_update_book2_SP", con);}
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id",bookIdtextbox.Text);
                cmd.Parameters.AddWithValue("@br_id",borrowertextbox.Text);
                con.Open();
                try{
                    cmd.ExecuteNonQuery();}
                catch (Exception ex){
                    MessageBox.Show(">>> INVALID QUERY \n" + ex);
                }}
                con.Close();
            catch(Exception ex){
            MessageBox.Show(" " + ex);
            }
            // now we will also update the brower's id in book table
            cmd = new SqlCommand("Trans_update_borrower_SP", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@book_id", bookIdtextbox.Text);
            cmd.Parameters.AddWithValue("@br_id", borrowertextbox.Text);
            con.Open();
            try{
            cmd.ExecuteNonQuery();}
            catch( Exception ex){
              MessageBox.Show(">>>> INVALID QUERY \n" + ex);}
            con.Close();
            search_buttonbook.PerformClick();
            searchbuttonborrow.PerformClick();
            MessageBox.Show("ISSUED SUCCESSFULLY !!!");
            }


       

        private void returnButton_Click(object sender, EventArgs e)
        {
            search_buttonbook.PerformClick();
            searchbuttonborrow.PerformClick();

          
            // see if borrower has already taken  that book 
            searchbuttonborrow.PerformClick();
            if (bookIdtextbox.Text!=book1 && bookIdtextbox.Text!=book2)
            {
                
                MessageBox.Show("The inputed borrower has not borrowed the book inputed");
                return;
            }
            // now proceed with retunr logic
            
            try
            {
                if (book1 == bookIdtextbox.Text)
                {
                    // book1 must be updated in book1 slot
                    cmd = new SqlCommand("Trans_update_book1_SP", con);

                }
                else
                {
                    cmd = new SqlCommand("Trans_update_book2_SP", con);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id",(object)DBNull.Value);
                cmd.Parameters.AddWithValue("@br_id", borrowertextbox.Text);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(">>> INVALID QUERY \n" + ex);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
            // now we will also update the brower's id in book table
            cmd = new SqlCommand("Trans_update_borrower_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@book_id", bookIdtextbox.Text);
            cmd.Parameters.AddWithValue("@br_id", (object)DBNull.Value);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" >> INVALID QUERY " + ex);
            }
            con.Close();

            search_buttonbook.PerformClick();
            searchbuttonborrow.PerformClick();
            MessageBox.Show("RETURNED  SUCCESSFULLY !!!");



        }
    }
}
