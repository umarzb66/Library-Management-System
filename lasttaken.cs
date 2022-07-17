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
    public partial class lasttaken : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public lasttaken()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void std()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter The Acces No ");
            }
            else
            {
                Con.Open();
                string query = "select Top 1 * from stdissuecopyTable where accessno='" + accessno.Text + "' order by [issuedate] desc";
               
                 SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    access.Text = dr["accessno"].ToString();
                    bookname.Text = dr["bookname"].ToString();
                    issueeto.Text = dr["stdrollno"].ToString();
                    IssueDate.Value = Convert.ToDateTime(dr["issuedate"].ToString());
                    who.Text = dr["stdname"].ToString();
                }
                Con.Close();
            }
        }
        private void staff()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter The Acces No ");
            }
            else
            {
                Con.Open();
                string query = "select Top 1 * from staffissuecopyTable where accessno='" + accessno.Text + "'order by [issuedate] desc";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    access.Text = dr["accessno"].ToString();
                    bookname.Text = dr["bookname"].ToString();
                    issueeto.Text = dr["staffid"].ToString();
                    IssueDate.Value = Convert.ToDateTime(dr["issuedate"].ToString());
                    who.Text = dr["staffname"].ToString();
                }
                Con.Close();
            }
        }
        private void guest()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter The Acces No ");
            }
            else
            {
                Con.Open();
                string query = "select Top 1 * from guestissuecopyTable where accessno='" + accessno.Text + "'order by [issuedate] desc";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    access.Text = dr["accessno"].ToString();
                    bookname.Text = dr["bookname"].ToString();
                    issueeto.Text = dr["guestid"].ToString();
                    IssueDate.Value = Convert.ToDateTime(dr["issuedate"].ToString());
                    who.Text = dr["guestname"].ToString();
                }
                Con.Close();
            }
        }
        private void btnsubsearch_Click(object sender, EventArgs e)
        {
            std();
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            staff();
        }

        private void btnguest_Click(object sender, EventArgs e)
        {
            guest();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            access.Text = "";
            accessno.Text = "";
            bookname.Text = "";
            issueeto.Text = "";
            IssueDate.Text = "";
            who.Text = "";
        }
    }
}
