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
    public partial class bookentry : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public bookentry()
        {
            InitializeComponent();
        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }
        public void populate()
        {
            Con.Open();
            string query = "select * from bookTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            bookDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void btnaddbook_Click(object sender, EventArgs e)
        {
            if (accessno.Text == "" || bookname.Text == "" || bookauthor.Text == "" || bookpublication.Text == "" || bookcategory.Text == "" || bookplace.Text == "" || bookcondition.Text == "" || bookcopies.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string purchasedate = PurchaseDate.Value.Day.ToString() + "/" + PurchaseDate.Value.Month.ToString() + "/" + PurchaseDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(purchasedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into bookTable values ('" + accessno.Text + "','" + bookname.Text + "','" + bookauthor.Text + "','" + bookpublication.Text + "','" + bookcategory.SelectedItem.ToString() + "','" + bookplace.Text + "','" + bookcondition.Text + "'," + bookcopies.Text + ",'" + date.ToString("MM-dd-yyyy") + "'," + price.Text + "," + edition.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book  Added Succesfully");
                Con.Close();
                populate();

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (accessno.Text == "" || bookname.Text == "" || bookauthor.Text == "" || bookpublication.Text == "" || bookcategory.Text == "" || bookplace.Text == "" || bookcondition.Text == "" || bookcopies.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string purchasedate = PurchaseDate.Value.Day.ToString() + "/" + PurchaseDate.Value.Month.ToString() + "/" + PurchaseDate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(purchasedate);
                Con.Open();
                string query = "update bookTable set  booksname ='" + bookname.Text + "', author = '" + bookauthor.Text + "', publication ='" + bookpublication.Text + "',bookcategory ='" + bookcategory.SelectedItem.ToString() + "',place ='" + bookplace.Text + "',condition ='" + bookcondition.Text + "',copies=" + bookcopies.Text + ",purchasedate ='" + date.ToString("MM-dd-yyyy") + "',price=" + price.Text +", edition = " + edition.Text + " where accessno='" + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Data  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter The  Access No");
            }
            else
            {
                Con.Open();
                String query = "delete from bookTable where accessno =' " + accessno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Book Deleted Succesfully");
                Con.Close();
                populate();

            }
        }
        private void fetchbook()
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter Access No");
            }
            else
            {
                Con.Open();
                string query = "select * from bookTable where accessno='" + accessno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    bookname.Text = dr["booksname"].ToString();
                    bookauthor.Text = dr["author"].ToString();
                    bookpublication.Text = dr["publication"].ToString();
                    bookcategory.Text = dr["bookcategory"].ToString();
                    bookplace.Text = dr["place"].ToString();
                    bookcondition.Text = dr["condition"].ToString();
                    bookcopies.Text = dr["copies"].ToString();
                    PurchaseDate.Value = Convert.ToDateTime(dr["purchasedate"].ToString());
                    price.Text = dr["price"].ToString();
                    edition.Text = dr["edition"].ToString();
                }
                Con.Close();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            fetchbook();
            string searchValue = accessno.Text;
 
            bookDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in bookDGV.Rows)
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
            accessno.Text = "";
            bookname.Text = "";
            bookauthor.Text = "";
            bookpublication.Text = "";
            bookcategory.Text= "";
            bookplace.Text = "";
            bookcondition.Text = "";
            bookcopies.Text = "";
            price.Text = "";
            edition.Text = "";

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void bookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            accessno.Text = bookDGV.SelectedRows[0].Cells[0].Value.ToString();
            bookname.Text = bookDGV.SelectedRows[0].Cells[1].Value.ToString();
            bookauthor.Text = bookDGV.SelectedRows[0].Cells[2].Value.ToString();
            bookpublication.Text = bookDGV.SelectedRows[0].Cells[3].Value.ToString();
            bookcategory.SelectedValue =bookDGV.SelectedRows[0].Cells[4].Selected.ToString();
            bookplace.Text = bookDGV.SelectedRows[0].Cells[5].Value.ToString();
            bookcondition.Text = bookDGV.SelectedRows[0].Cells[6].Value.ToString();
            bookcopies.Text = bookDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bookentry_Load(object sender, EventArgs e)
        {
            populate();
            PurchaseDate.Value = System.DateTime.Now;
        }

        private void gunaLabel10_Click(object sender, EventArgs e)
        {

        }
    }
}
