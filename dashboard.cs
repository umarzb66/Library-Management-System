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
    public partial class dashboard : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");
        
        public dashboard()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {
                    }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }
        private void std()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from stdissueTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            t1.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(t1.Text))
            {
                t1.Text = "0";
            }
            else
            {
                t1.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
          
        }
        private void staff()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from staffissueTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            t2.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(t2.Text))
            {
                t2.Text = "0";
            }
            else
            {
                t2.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void guest()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from guestissueTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            t3.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(t3.Text))
            {
                t3.Text = "0";
            }
            else
            {
                t3.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void issuetotal()
        {
           
            int num1, num2, num3, res;
            num1 = Convert.ToInt32(t1.Text);
            num2 = Convert.ToInt32(t2.Text);
            num3 = Convert.ToInt32(t3.Text);
            res = num1+ num2 + num3;
            issue.Text = Convert.ToString(res);
           
        }
        private void booktotal()
        {
            int num, num1,res;
            num = Convert.ToInt32(total.Text);
            num1 = Convert.ToInt32(issue.Text);
            res = num - num1;
            total.Text = Convert.ToString(res);

        }
        private void view()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from bookTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            total.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(total.Text))
            {
                total.Text = "0";
            }
            else
            {
                total.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
         
        }


        async void TimeUpdater()
        {
            while (true)
            {
                time.Text = DateTime.Now.ToString("hh : mm : ss tt");
                await Task.Delay(1000);
            }
        }
        private void stdreturnview()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from stdreturnTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            stdreturn.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(stdreturn.Text))
            {
                stdreturn.Text = "0";
            }
            else
            {
                stdreturn.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();

        }
        private void staffreturnview()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from staffreturnTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            staffreturn.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(staffreturn.Text))
            {
                staffreturn.Text = "0";
            }
            else
            {
                staffreturn.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();

        }
        private void guestreturnview()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from guestreturnTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            guestreturn.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(guestreturn.Text))
            {
                guestreturn.Text = "0";
            }
            else
            {
                guestreturn.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda4 = new SqlDataAdapter("select count(*) from stdTable ", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            stdissue.Text = dt4.Rows[0][0].ToString();
            SqlDataAdapter sda5 = new SqlDataAdapter("select count(*) from staffTable ", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            staffissue.Text = dt5.Rows[0][0].ToString();
            SqlDataAdapter sda6 = new SqlDataAdapter("select count(*) from guestTable ", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            guestissue.Text = dt6.Rows[0][0].ToString();
            Con.Close();
            std();
            staff();
            guest();
            issuetotal();
            view();
            TimeUpdater();
            stdreturnview();
            staffreturnview();
            guestreturnview();
            //booktotal();
        }
    }
}
