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
    public partial class student : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");
        public student()
        {
            InitializeComponent();
        }
        private void student_Load(object sender, EventArgs e)
        {
            populate();
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (stdroll.Text == "")
            {
                MessageBox.Show("Enter The Roll No");
            }
            else
            {
                Con.Open();
                String query = "delete from stdTable where stdrollno = " + stdroll.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Data Deleted Succesfully");
                Con.Close();
                populate();

            }
        }
        private void fetchstd()
        {
            if (stdroll.Text == "" )
            {
                MessageBox.Show("Enter Student Roll No");
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
                    stdsem.Text = dr["stdsem"].ToString();
                }
                Con.Close();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fetchstd();
            string searchValue = stdroll.Text;

            studentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in studentDGV.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue)) 
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (stdroll.Text == "" || stdname.Text == "" || stdclass.Text == "" || stdyear.Text == "" || stdsem.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update stdTable set  stdname ='" + stdname.Text + "', stdclass = '" + stdclass.SelectedItem.ToString() + "', stdyear =" + stdyear.Text + ",stdsem=" + stdsem.SelectedItem.ToString() + " where stdrollno='"+stdroll.Text+"';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Data  Succesfully Updated");
                Con.Close();
                populate();

            }
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from stdTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            studentDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void btnsubsearch_Click(object sender, EventArgs e)
        {
            if (stdroll.Text == "" || stdname.Text == "" || stdclass.Text == "" || stdyear.Text == "" || stdsem.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stdTable values ('" + stdroll.Text + "','" + stdname.Text + "','" + stdclass.SelectedItem.ToString() + "'," + stdyear.Text + "," + stdsem.SelectedItem.ToString() + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Data Added Succesfully");
                Con.Close();
                populate();

            }
        }

        private void studentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            stdroll.Text = studentDGV.SelectedRows[0].Cells[0].Value.ToString();
            stdname.Text = studentDGV.SelectedRows[0].Cells[1].Value.ToString();
            stdclass.Text = studentDGV.SelectedRows[0].Cells[2].Value.ToString();
            stdyear.Text = studentDGV.SelectedRows[0].Cells[3].Value.ToString();
            stdsem.Text = studentDGV.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            stdroll.Text = "";
            stdname.Text = "";
            stdclass.Items[stdclass.SelectedIndex] = "";
            stdyear.Text = "";
            stdsem.Items[stdsem.SelectedIndex] = "";
        }

        private void student_Load_1(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void student_Load_2(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            stdclass.Items.Add(addclass.Text);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            stdclass.Items.Remove(addclass.Text);
        }
    }
}
