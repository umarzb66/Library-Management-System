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
    public partial class reportbydate : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public reportbydate()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM stdissueTable WHERE issuedate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnstaffissue_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM staffissueTable WHERE issuedate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnguestisssue_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM guestissueTable WHERE issuedate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnstudentreturn_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM stdreturnTable WHERE returndate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnstaffreturn_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM staffreturnTable WHERE returndate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void btnguestreturn_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM guestreturnTable WHERE returndate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(reportDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in reportDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in reportDGV.Rows)
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

        private void reportDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (from.Text == "" || to.Text == "")
            {
                MessageBox.Show("Select From to To");
            }
            else
            {
                string fromdate = from.Value.Day.ToString() + "/" + from.Value.Month.ToString() + "/" + from.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(fromdate);
                string todate = to.Value.Day.ToString() + "/" + to.Value.Month.ToString() + "/" + to.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(todate);
                Con.Open();
                string query = "SELECT * FROM stdreturnTable WHERE  returndate BETWEEN '" + date.ToString("MM-dd-yyyy") + "' AND + '" + date1.ToString("MM - dd - yyyy") + "' and fine>("+0+")";
                SqlDataAdapter da = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                reportDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
        }
    }
}