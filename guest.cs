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
    public partial class guest : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public guest()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from guestTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            guestDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void btnstdadd_Click(object sender, EventArgs e)
        {
            if (guestid.Text == "" || guestname.Text == "" || guestintial.Text == "" || guestintroducedby.Text == "" || guestaddress.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into guestTable values (" + guestid.Text + ",'" + guestname.Text + "','" + guestintial.Text + "','" + guestintroducedby.Text + "','" + guestaddress.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("guest Data Added Succesfully");
                Con.Close();
                populate();

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guestid.Text == "" || guestname.Text == "" || guestintial.Text == "" || guestintroducedby.Text == "" || guestaddress.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update guestTable set  guestname ='" + guestname.Text + "', guestintial = '" + guestintial.Text + "', guestintroducedby ='" + guestintroducedby.Text + "', guestaddress ='" + guestaddress.Text + "' where guestid=" + guestid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("guest Data  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guestid.Text == "")
            {
                MessageBox.Show("Enter The  guest Id");
            }
            else
            {
                Con.Open();
                String query = "delete from guestTable where guestid = " + guestid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("guest Data Deleted Succesfully");
                Con.Close();
                populate();

            }
        }
        private void fetchguest()
        {
            if (guestid.Text == "")
            {
                MessageBox.Show("Enter Guest Id");
            }
            else
            {
                Con.Open();
                string query = "select * from GuestTable where Guestid=" + guestid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    guestname.Text = dr["guestname"].ToString();
                    guestintial.Text = dr["guestintial"].ToString();
                    guestintroducedby.Text = dr["guestintroducedby"].ToString();
                    guestaddress.Text = dr["guestaddress"].ToString();
                }
                Con.Close();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fetchguest();
            string searchValue = guestid.Text;

            guestDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in guestDGV.Rows)
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
            guestid.Text = "";
            guestname.Text = "";
            guestintial.Text = "";
            guestintroducedby.Text = "";
            guestaddress.Text = "";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guestDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            guestid.Text = guestDGV.SelectedRows[0].Cells[0].Value.ToString();
            guestname.Text = guestDGV.SelectedRows[0].Cells[1].Value.ToString();
            guestintial.Text = guestDGV.SelectedRows[0].Cells[2].Value.ToString();
            guestintroducedby.Text = guestDGV.SelectedRows[0].Cells[3].Value.ToString();
            guestaddress.Text = guestDGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guest_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
