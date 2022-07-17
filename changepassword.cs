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
using System.Data.OleDb;

namespace Library_Management
{
    public partial class changepassword : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");
        int count = 0;

        public changepassword()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           


        }

        private void txtuserid_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from loginTable where userid='" + txtuserid.Text + "' AND pass='" + txtpass.Text + "'  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            if (count == 0)
            {
                MessageBox.Show("User Id & Password Not Match");
            }
            else
            {             
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update loginTable set  userid ='" + newtxtuserid.Text + "', pass = '" + newtxtpass.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Id & Password  Succesfully Updated");
               
            }


        }
        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtuserid.Text = "";
            txtpass.Text = "";
            newtxtuserid.Text = "";
            newtxtpass.Text = "";
        }

        private void changepassword_Load(object sender, EventArgs e)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
        }
    }
    }

