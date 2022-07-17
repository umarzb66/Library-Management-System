using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_Management
{
    public partial class LoginForm2 : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        int count = 0;
        public LoginForm2()
        {

            InitializeComponent();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLinePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }


        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from loginTable where userid='" + txtuser.Text + "' AND pass='" + txtpass.Text + "'  ";
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
                this.Hide();
                MainForm main = new MainForm();
                main.Show();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtuser_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtuser.Text == "Enter User Id")
            {
                txtuser.Clear();
            }
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpass.Text == "Enter Password")
            {
                txtpass.Clear();
                txtpass.PasswordChar = '*';
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();



        }

        private void LoginForm2_Load(object sender, EventArgs e)
        {
            
            if (Con.State==ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open(); 
        }

        private void gunaLinePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
