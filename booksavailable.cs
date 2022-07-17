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
    public partial class booksavailable : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public booksavailable()
        {
            InitializeComponent();
        }

        private void booksavailable_Load(object sender, EventArgs e)
        {
            populate();
            view();
            std();
            staff();
            guest();
           issuetotal();
           issuetotal1();
            finaltotal();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from bookTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            booksDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void view()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(copies) from bookTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            total.Text = dt.Rows[0][0].ToString();
            Con.Close();
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
            Con.Open();
            int num1, num2, num3, res;
            num1 = Convert.ToInt32(t1.Text);
            num2 = Convert.ToInt32(t2.Text);
            num3 = Convert.ToInt32(t3.Text);
            res = num1 + num2 + num3;
            issue.Text = Convert.ToString(res);
            Con.Close();
        }
        private void finaltotal()
        {
            Con.Open();
            int num1, num2, num3, res, res1;
            num1 = Convert.ToInt32(total.Text);
            num2 = Convert.ToInt32(issue.Text);
            num3 = Convert.ToInt32(remain.Text);
            res = num1 + num2;
            total.Text = Convert.ToString(res);
            res1 = res - num2;
            remain.Text = Convert.ToString(res1);
            Con.Close();
        }
        private void issuetotal1()
        {
            Con.Open();
            int num1, num2, res;
            num1 = Convert.ToInt32(total.Text);
            num2 = Convert.ToInt32(issue.Text);
            res = num1 - num2;
            remain.Text = Convert.ToString(res);
            Con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            populate();
            view();
            std();
            staff();
            guest();
            issuetotal();
            issuetotal1();
            finaltotal();
        }




        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(booksDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in booksDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in booksDGV.Rows)
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
    }
}