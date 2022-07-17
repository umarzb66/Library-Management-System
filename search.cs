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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Library_Management
{
    public partial class search : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public search()
        {
            InitializeComponent();
        }

        private void search_Load(object sender, EventArgs e)
        {
            bookreader();
            access();
           
            bookauthor();
            bookpublication();
            autoplace();
          
        
        }
        private void access()
        {
            Con.Open();
            string sqlquery = "select accessno From bookTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.ToString());
            }
            accessno.AutoCompleteMode = AutoCompleteMode.Suggest;
            accessno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            accessno.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
      
        private void bookreader()
        {
            Con.Open();
            string sqlquery = "select booksname From bookTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.ToString());
            }
            name.AutoCompleteMode = AutoCompleteMode.Suggest;
            name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            name.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        private void bookauthor()
        {
            Con.Open();
            string sqlquery = "select author From bookTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            author.AutoCompleteMode = AutoCompleteMode.Suggest;
            author.AutoCompleteSource = AutoCompleteSource.CustomSource;
            author.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        private void bookpublication()
        {
            Con.Open();
            string sqlquery = "select publication From bookTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            publication.AutoCompleteMode = AutoCompleteMode.Suggest;
            publication.AutoCompleteSource = AutoCompleteSource.CustomSource;
            publication.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        private void autoplace()
        {
            Con.Open();
            string sqlquery = "select place From bookTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            place.AutoCompleteMode = AutoCompleteMode.Suggest;
            place.AutoCompleteSource = AutoCompleteSource.CustomSource;
            place.AutoCompleteCustomSource = autotext;
            Con.Close();
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void author_TextChanged(object sender, EventArgs e)
        {

        }
    
        private void btnaccess_Click(object sender, EventArgs e)
        {
            if (accessno.Text == "")
            {
                MessageBox.Show("Enter Access No");
            }
            
            else
            {
                Con.Open();
                string query = "select * from bookTable where accessno='" + accessno.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                bookDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnname_Click(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("Enter Book Name");
            }
            else
            {
                Con.Open();
                string query = "select * from bookTable where booksname='" + name.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                bookDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnauthor_Click(object sender, EventArgs e)
        {
            if (author.Text == "")
            {
                MessageBox.Show("Enter Author Name");
            }
            else
            {
                Con.Open();
                string query = "select * from bookTable where author='" + author.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                bookDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnpublication_Click(object sender, EventArgs e)
        {
            if (publication.Text == "")
            {
                MessageBox.Show("Enter Publication Name");
            }
            else
            {
                Con.Open();
                string query = "select * from bookTable where publication='" + publication.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                bookDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (place.Text == "")
            {
                MessageBox.Show("Enter Place");
            }
            else
            {
                Con.Open();
                string query = "select * from bookTable where place='" + place.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                bookDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            accessno.Text = "";
            name.Text = "";
            author.Text = "";
            publication.Text = "";
            category.Text = "";
            place.Text = "";
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(bookDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in bookDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in bookDGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documento PDF (*.pdf)|*.pdf";
            sfd.FileName = DateTime.Now.ToString("dd-MM-yyyy");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                string filename = sfd.FileName;
                FileStream file = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, file);
                doc.Open();
                doc.Add(pdfTable);
                doc.Close();
                System.Diagnostics.Process.Start(sfd.FileName);


            }
        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (condition.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Select Book Condition");
            }
            else
            {
                Con.Open();
                string query = "select * from bookTable where condition='" + condition.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                bookDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }
    }
}
