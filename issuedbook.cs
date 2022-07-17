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
    public partial class issuedbook : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Documents\Mylib.mdf;Integrated Security=True;Connect Timeout=30");

        public issuedbook()
        {
            InitializeComponent();
        }

        private void issuedbook_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox4_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }
        public void populate()
        {
            Con.Open();
            string query = "select * from stdissuecopyTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            issueDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            populate();
            fineamt.Text = "";
        }
        public void populate1()
        {
            Con.Open();
            string query = "select * from staffissuecopyTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            issueDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            populate1();
            fineamt.Text = "";
        }
        public void populate2()
        {
            Con.Open();
            string query = "select * from guestissuecopyTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            issueDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        public void populate3()
        {
            Con.Open();
            string query = "select * from stdreturnTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            issueDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            populate2();
            fineamt.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(issueDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in issueDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in issueDGV.Rows)
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

        private void gunaLabel1_Click_1(object sender, EventArgs e)
        {

        }
        private void stdfine()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(fine) from stdreturnTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            fineamt.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(fineamt.Text))
            {
                fineamt.Text = "0";
            }
            else
            {
               fineamt.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void guna2RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            populate3();
            stdfine();

        }
    }
}