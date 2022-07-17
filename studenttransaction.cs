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

namespace Library_Management
{
    public partial class studenttransaction : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");
      
       
        public studenttransaction()
        {
            InitializeComponent();
        }

        private void Form1Dash_Load(object sender, EventArgs e)
        {
            IssueDate.Value = System.DateTime.Now;
            Returndate.Value = System.DateTime.Now;

            populate1();
            populate2();
            
        }

        
        private void updatebook()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter Accessno");
            }
            else
            {
                int copies,newcopies,num;
                Con.Open();
                string query = "select * from bookTable where accessno='" + accessno.Text+ "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    num = Convert.ToInt32(bookcopies.SelectedItem.ToString());
                    copies =Convert.ToInt32( dr["copies"].ToString());
                    newcopies = copies - num;
                    string query1 = "update bookTable set copies=" + newcopies + " where accessno='"+accessno.Text+"'";
                    SqlCommand cmd1 = new SqlCommand(query1, Con);
                    cmd1.ExecuteNonQuery();

                }
                Con.Close();
            }
        }
        private void deletebook()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter Accessno");
            }
            else
            {
                int copies, newcopies, num;
                Con.Open();
                string query = "select * from bookTable where accessno='" + accessno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    num = Convert.ToInt32(bookcopies.SelectedItem.ToString());
                    copies = Convert.ToInt32(dr["copies"].ToString());
                    newcopies = copies + num;
                    string query1 = "update bookTable set copies=" + newcopies + " where accessno='" + accessno.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, Con);
                    cmd1.ExecuteNonQuery();

                }
                Con.Close();
            }
        }


        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stdroll_TextChanged(object sender, EventArgs e)
        {

        }

        private void fetchstd()
        {
            if (stdroll.Text == ""|| accessno.Text == "")
            {
                MessageBox.Show("Enter Roll & Access No ");
            }
            else
            {
                Con.Open();
                string query = "select * from stdTable where stdrollno='" + stdroll.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    stdname.Text = dr["stdname"].ToString();
                    stdclass.Text = dr["stdclass"].ToString();
                    stdyear.Text = dr["stdyear"].ToString();
                }
                Con.Close();
            }
        }

    
        private void getcopies()
        {
            Con.Open();
            string query = "select * from bookTable where accessno ='" + accessno.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                copies.Text = dr["copies"].ToString();
            }
            Con.Close();
        }
        private void fetchbook()
        {


            if (copies.Text=="0")
            {
              
                MessageBox.Show("No More Copies Available ");
               
            }
            else 
            {
                Con.Open();
                string query = "select * from bookTable where accessno ='" + accessno.Text + "'" ;
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    bookname.Text = dr["booksname"].ToString();
                }
                Con.Close();
            }
        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            getcopies();
            fetchstd();
            fetchbook();
        }

        private void stdname_TextChanged(object sender, EventArgs e)
        {

        }

        private void stdclass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
           
        }
        public void populate1()
        {
            Con.Open();
            string query = "select * from stdissueTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVissue.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void studentissuecopy()
        {
            
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (stdroll.Text == "" || accessno.Text == "" || stdname.Text == "" || stdclass.Text == "" || stdyear.Text == "" || bookname.Text == "")
            {

            }
            else
            {
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stdissuecopyTable  values ('" + stdroll.Text + "','" + accessno.Text + "','" + stdname.Text + "','" + stdclass.Text + "'," + stdyear.Text + ",'" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                Con.Close();


            }
        }

     

        private void btnIssue_Click_1(object sender, EventArgs e)
        {
            
            if (stdroll.Text == "" || accessno.Text == "" || stdname.Text == "" || stdclass.Text == "" || stdyear.Text == "" || bookname.Text == "" || bookcopies.Text == "")
            {
                MessageBox.Show("Missing Information");
            }                
            else
            {
                updatebook();
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stdissueTable  values ('" + stdroll.Text + "','" + accessno.Text + "','" + stdname.Text + "','" + stdclass.Text + "'," + stdyear.Text + ",'" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("sussesfully issued");
                Con.Close();                              
                studentissuecopy();
                populate1();
                populate2();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            populate1();
            populate2();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            

        }

        private void DGVissue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            


        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        
        }
        private void studentissuecopydelete()
        {
            if (accessno.Text == "")
            {
               
            }
            else
            {
                Con.Open();
                String query = "delete from stdissuecopyTable where accessno = '" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                
                Con.Close();
           


            }
        }
        private void btnissuedelete_Click(object sender, EventArgs e)
        {
            if (accessno.Text == ""|| stdroll.Text == ""|| copies.Text == ""  )
            {
                MessageBox.Show("Enter The  Access No & Roll No & Copies");
            }
            else
            {
                deletebook();
                Con.Open();
                String query = "delete from stdissueTable where accessno ='" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" issued Deleted Succesfully");
                Con.Close();                          
                populate1();
                populate2();


            }
        }


        public void populate2()
        {
            Con.Open();
            string query = "select * from stdreturnTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVreturn.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void DGVissue_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            
        }

        private void DGVreturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }
        private void daycount()
        {
          
                int num1, num2;
                num.Text = (IssueDate.Value.Subtract(Returndate.Value)).TotalDays.ToString("#");
                num1 = Convert.ToInt32(num.Text);
                if (num1 < -14)
                {
                    num2 = Math.Abs(num1 + 14);

                    fine.Text = Convert.ToString(num2);
                }
                else
                {
                    fine.Text = "0";
                }
            
        }
        private void btnreturnedit_Click(object sender, EventArgs e)
                {
            if (accessno.Text == "" || stdroll.Text == "")
            {
                MessageBox.Show("Enter The Acces No & Roll No");
            }        
            else
            {
                Con.Open();
                string query = "select * from stdissueTable where accessno ='" + accessno.Text + "'AND stdrollno='" + stdroll.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    stdroll.Text = dr["stdrollno"].ToString();
                    stdname.Text = dr["stdname"].ToString();
                    stdclass.Text = dr["stdclass"].ToString();
                    stdyear.Text = dr["stdyear"].ToString();                   
                    bookname.Text = dr["bookname"].ToString();
                    bookcopies.Text = dr["copies"].ToString();
                    IssueDate.Value =Convert.ToDateTime( dr["issuedate"].ToString());
                }
                if (string.IsNullOrWhiteSpace(bookcopies.Text))
                {
                    MessageBox.Show("Entered Acces No & Roll No Not Exits");
                }
                else
                {
                    daycount();
                }
                Con.Close();
            }
        }

     

        private void returnissuedbook()
        {
            if (stdroll.Text == "" || accessno.Text == "" || stdname.Text == "" || stdclass.Text == "" || stdyear.Text == "" || bookname.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                string returndate = Returndate.Value.Day.ToString() + "/" + Returndate.Value.Month.ToString() + "/" + Returndate.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(returndate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stdreturnTable values ('" + accessno.Text + "','" + stdroll.Text + "','" + stdname.Text + "','" + stdclass.Text + "'," + stdyear.Text + ",'" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "','" + date1.ToString("MM-dd-yyyy") + "'," + fine.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("sussesfully Return");
                Con.Close();
                populate1();
                updatebook();

            }
        }
        private void issuedelete()
        {
            if (accessno.Text == "")
            {
                
            }
            else
            {
                Con.Open();
                String query = "delete from stdissueTable where accessno = '" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
             
                Con.Close();
                
            }
        }
        private void btnreturn_Click_1(object sender, EventArgs e)
        {
            deletebook();
            returnissuedbook();
            issuedelete();
            populate1();
            populate2();
        }
        private void btnreturn_Click(object sender, EventArgs e)
        {
           
        }
        private void returndelete()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter The  Access No");
            }
            else
            {
                Con.Open();
                String query = "delete from stdreturnTable where accessno = '" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();               
                Con.Close();

            }

            }
        private void returnadddeleted()
        {
            if (stdroll.Text == "" || accessno.Text == "" || stdname.Text == "" || stdclass.Text == "" || stdyear.Text == "" || bookname.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stdissueTable values ('" + stdroll.Text + "','" + accessno.Text + "','" + stdname.Text + "','" + stdclass.Text + "'," + stdyear.Text + ",'" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("sussesfully Returned Deleted");
                Con.Close();                
                deletebook();
                studentissuecopy();

            }
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            updatebook();
            returnadddeleted();            
            returndelete();            
            populate1();
            populate2();
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            stdroll.Text = "";
            accessno.Text = "";
            stdname.Text = "";
            stdclass.Text = "";
            stdyear.Text = "";
            bookname.Text = "";
        }

        private void btnrefresh_Click_1(object sender, EventArgs e)
        {
            populate1();
            populate2();

        }

        private void Returndate_onValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}