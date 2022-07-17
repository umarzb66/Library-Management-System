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
    public partial class stafftransaction : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public stafftransaction()
        {
            InitializeComponent();
        }

        private void stafftransaction_Load(object sender, EventArgs e)
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
                int copies, newcopies,num;
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
                    newcopies = copies - num;
                    string query1 = "update bookTable set copies=" + newcopies + " where accessno='" + accessno.Text + "'";
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
                int copies, newcopies,num;
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
        private void fetchstaff()
        {
            if (staffid.Text == ""|| accessno.Text == "")
            {
                MessageBox.Show("Enter Staff ID & Access No ");
            }
            else
            {
                Con.Open();
                string query = "select * from staffTable where staffid='" + staffid.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    staffintial.Text = dr["staffintial"].ToString();
                    staffname.Text = dr["staffname"].ToString();
                    department.Text = dr["staffdepartment"].ToString();
                }
                Con.Close();
            }
        }


        private void fetchbook()
        {
            if (copies.Text =="0")
            {
                MessageBox.Show("No More Copies Available ");
            }
            else
            {

                Con.Open();
                string query = "select * from bookTable where accessno ='" + accessno.Text + "'";
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

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            getcopies();
            fetchstaff();
            fetchbook();
        }

        public void populate1()
        {
            Con.Open();
            string query = "select * from staffissueTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVissue.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void staffissuecopy()
        {
            if (staffid.Text == "" || accessno.Text == "" || staffname.Text == "" || staffintial.Text == "" || department.Text == "" || bookname.Text == "")
            {

            }
            else
            {
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into staffissuecopyTable values (" + staffid.Text + ",'" + accessno.Text + "','" + staffintial.Text + "','" + staffname.Text + "','" + department.Text + "','" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                Con.Close();


            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (staffid.Text == "" || accessno.Text == "" || staffname.Text == "" || staffintial.Text == "" || department.Text == "" || bookname.Text == "" || bookcopies.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                updatebook();
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into staffissueTable values (" + staffid.Text + ",'" + accessno.Text + "','" + staffintial.Text + "','" + staffname.Text + "','" + department.Text + "','" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("sussesfully issued");
                Con.Close();      
                staffissuecopy();
                populate1();
                populate2();
            }
        
       
        }

        private void btnissueedit_Click(object sender, EventArgs e)
        {

        }

        private void staffissuecopydelete()
        {
            if (accessno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from staffissuecopyTable where accessno = '" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
        }

        private void btnissuedelete_Click(object sender, EventArgs e)
        {
            if (accessno.Text == "" || staffid.Text == "" || bookcopies.Text == "")
            {
                MessageBox.Show("Enter The  Access No &  Satff Id & Copies");
            }
            else
            {
                deletebook();
                Con.Open();
                string query = "delete from staffissueTable where accessno =' " + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" issued Deleted Succesfully");
                Con.Close();        
                staffissuecopydelete();
                populate1();
                populate2();


            }
        }

        private void DGVissue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            staffid.Text = DGVissue.SelectedRows[0].Cells[0].Value.ToString();
            accessno.Text = DGVissue.SelectedRows[0].Cells[1].Value.ToString();
            staffname.Text = DGVissue.SelectedRows[0].Cells[2].Value.ToString();
            staffintial.Text = DGVissue.SelectedRows[0].Cells[3].Value.ToString();
            department.Text = DGVissue.SelectedRows[0].Cells[4].Value.ToString();
            bookname.Text = DGVissue.SelectedRows[0].Cells[5].Value.ToString();
            IssueDate.Value = Convert.ToDateTime(DGVissue.SelectedRows[0].Cells[6].Value.ToString());
        }


        public void populate2()
        {
            Con.Open();
            string query = "select * from staffreturnTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            DGVreturn.DataSource = ds.Tables[0];
            Con.Close();
        }

   
        private void returnissuedbook()
        {
            if (staffid.Text == "" || accessno.Text == "" || staffname.Text == "" || staffintial.Text == "" || department.Text == "" || bookname.Text == "" || bookcopies.Text == "")
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
                SqlCommand cmd = new SqlCommand("insert into staffreturnTable values (" + staffid.Text + ",'" + accessno.Text + "','" + staffname.Text + "','" + staffintial.Text + "','" + department.Text + "','" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "','" + date1.ToString("MM-dd-yyyy") + "')", Con);
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
                String query = "delete from staffissueTable where accessno =' " + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                
                Con.Close();

            }
        }
        private void btnreturn_Click(object sender, EventArgs e)
        {
            deletebook();
            returnissuedbook();
            issuedelete();
            populate1();
            populate2();
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
                string query = "delete from staffreturnTable where accessno ='" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();

            }

        }
        private void returnadddeleted()
        {
            if (staffid.Text == "" || accessno.Text == "" || staffname.Text == "" || staffintial.Text == "" || department.Text == "" || bookname.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string issuedate = IssueDate.Value.Day.ToString() + "/" + IssueDate.Value.Month.ToString() + "/" + IssueDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(issuedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into staffissueTable values (" + staffid.Text + ",'" + accessno.Text + "','" + staffname.Text + "','" + staffintial.Text + "','" + department.Text + "','" + bookname.Text + "'," + bookcopies.SelectedItem.ToString() + ",'" + date.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("sussesfully Returned Deleted");
                Con.Close();
                deletebook();
                staffissuecopy();

            }
        }
        private void btnreturndelete_Click(object sender, EventArgs e)
        {
            updatebook();
            returnadddeleted();
            returndelete();
            populate1();
            populate2();
        }
    
        private void searchissued_Click(object sender, EventArgs e)
        {
            if (accessno.Text == "" || staffid.Text == "")
            {
                MessageBox.Show("Enter The Acces No & Staff Id");
            }

            else
            {
                Con.Open();
                string query = "select * from staffissueTable where accessno='" + accessno.Text + " 'AND staffid=" + staffid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    bookname.Text = dr["bookname"].ToString();
                }
                    if (string.IsNullOrWhiteSpace(bookname.Text))
                {
                    MessageBox.Show("Entered Acces No & Roll No Not Exits");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        staffid.Text = dr["staffid"].ToString();
                        staffintial.Text = dr["staffintial"].ToString();
                        staffname.Text = dr["staffname"].ToString();
                        department.Text = dr["department"].ToString();
                        bookname.Text = dr["bookname"].ToString();
                        bookcopies.Text = dr["copies"].ToString();
                        IssueDate.Value = Convert.ToDateTime(dr["issuedate"].ToString());
                    }
                }
                Con.Close();
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            staffid.Text = "";
            accessno.Text = "";
            staffintial.Text = "";
            staffname.Text = "";
            department.Text = "";
            bookname.Text = "";
            bookcopies.Text = "";
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            populate1();
            populate2();
        }

        private void DGVreturn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            staffid.Text = DGVissue.SelectedRows[0].Cells[0].Value.ToString();
            accessno.Text = DGVissue.SelectedRows[0].Cells[1].Value.ToString();
            staffname.Text = DGVissue.SelectedRows[0].Cells[2].Value.ToString();
            staffintial.Text = DGVissue.SelectedRows[0].Cells[3].Value.ToString();
            department.Text = DGVissue.SelectedRows[0].Cells[4].Value.ToString();
            bookname.Text = DGVissue.SelectedRows[0].Cells[5].Value.ToString();
            IssueDate.Value = Convert.ToDateTime(DGVissue.SelectedRows[0].Cells[6].Value.ToString());
            Returndate.Value = Convert.ToDateTime(DGVissue.SelectedRows[0].Cells[7].Value.ToString());

        }
     

        private void Returndate_onValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}