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
    public partial class staff : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public staff()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from staffTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            studentDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void btnstdadd_Click(object sender, EventArgs e)
        {
            if (staffid.Text == "" || staffname.Text == "" || staffintial.Text == "" || staffdepartment.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into staffTable values (" + staffid.Text + ",'" + staffname.Text + "','" + staffintial.Text + "','" + staffdepartment.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Data Added Succesfully");
                Con.Close();
                populate();

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (staffid.Text == "" || staffname.Text == "" || staffintial.Text == "" || staffdepartment.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update staffTable set  staffname ='" + staffname.Text + "', staffintial = '" + staffintial.Text + "', staffdepartment ='" + staffdepartment.Text + "' where staffid=" + staffid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Data  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (staffid.Text == "")
            {
                MessageBox.Show("Enter The  Staff Id");
            }
            else
            {
                Con.Open();
                String query = "delete from staffTable where staffid = " + staffid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Data Deleted Succesfully");
                Con.Close();
                populate();

            }
        }
        private void fetchstaff()
        {
            if (staffid.Text == "")
            {
                MessageBox.Show("Enter Staff Id ");
            }
            else
            {
                Con.Open();
                string query = "select * from staffTable where staffid=" + staffid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    staffname.Text = dr["staffname"].ToString();
                    staffintial.Text = dr["staffintial"].ToString();
                    staffdepartment.Text = dr["staffdepartment"].ToString();
                }
                Con.Close();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fetchstaff();
            string searchValue = staffid.Text;

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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            staffid.Text = "";
            staffname.Text = "";
            staffintial.Text = "";
            staffdepartment.Text = "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void studentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            staffid.Text = studentDGV.SelectedRows[0].Cells[0].Value.ToString();
            staffname.Text = studentDGV.SelectedRows[0].Cells[1].Value.ToString();
            staffintial.Text = studentDGV.SelectedRows[0].Cells[2].Value.ToString();
            staffdepartment.Text = studentDGV.SelectedRows[0].Cells[3].Value.ToString();        }

        private void staff_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
