using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            customizeDesing();


        }


        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<dashboard>();

        }
        
        public void MainForm_Load()
        {
            InitializeComponent();

            
        }

        private void customizeDesing()
        {

            panelbooktransubmenu.Visible = false;
            panelSearchSubmenu.Visible = false;
            panelDataentrySubmenu.Visible = false;
            panelReportSubmenu.Visible = false;
            panelControlpanelSubmenu.Visible = false;
        }
        
        private void hideSubMenu()
        {
            if (panelbooktransubmenu.Visible == true)
                panelbooktransubmenu.Visible = false;
            if (panelSearchSubmenu.Visible == true)
                panelSearchSubmenu.Visible = false;
            if (panelDataentrySubmenu.Visible == true)
                panelDataentrySubmenu.Visible = false;
            if (panelReportSubmenu.Visible == true)
                panelReportSubmenu.Visible = false;
            if (panelControlpanelSubmenu.Visible == true)
                panelControlpanelSubmenu.Visible = false;
        } 
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

       

        
        
        private void btnsubsearch_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<search>();

        }

        private void btnsubfind_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<findabook>();

        }

        private void btnsublasttaken_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<lasttaken>();
        }

        private void btnsubstudent_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<student>();
        }

        private void btnsubstaff_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<staff>();
        }

        private void btnsubguest_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<guest>();
        }

        private void btnsubbooks_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<bookentry>();
        }

        private void btnsubclass_Click(object sender, EventArgs e)
        {
            hideSubMenu();
           
        }

        private void btnsubissued_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<issuedbook>();
        }

        private void btnsubavailable_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<booksavailable>();
        }

        private void btnsubstudentstaff_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<studentstaffreport>();
        }

        private void btnsubclasswise_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<classwise>();
        }

        private void btnsubbydate_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<reportbydate>();
        }

        private void btnsubpassword_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<changepassword>();
        }

        private void btnsubbackup_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<backup>();
        }

        private void btnControlpanel_Click(object sender, EventArgs e)
        {
            showSubmenu(panelControlpanelSubmenu);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            showSubmenu(panelReportSubmenu);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDataentry_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panelDataentrySubmenu);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSearchSubmenu);
        }

        private void OpenForm<MyForm>() where MyForm : Form, new()
        {
            Form form;
            form = guna2Panel2.Controls.OfType<MyForm>().FirstOrDefault();//Search the form in the collection
                                                                          //if the form/instance does not exist
            if (form == null)
            {
                form = new MyForm();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                guna2Panel2.Controls.Add(form);
                guna2Panel2.Tag = form;
                form.Show();
                form.BringToFront();
            }
            //if the form/instance exists
            else
            {
                form.BringToFront();
            }
        }

        private void btnbooktran_Click(object sender, EventArgs e)
        {
            OpenForm<studenttransaction>();
            hideSubMenu();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<dashboard>();
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<about>();
        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<dashboard>();
        }

        private void btnbooktran_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panelbooktransubmenu);
        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panelSearchSubmenu);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            showSubmenu(panelDataentrySubmenu);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            showSubmenu(panelReportSubmenu);
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            showSubmenu(panelControlpanelSubmenu);
        }

        private void btnsubsearch_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<search>();
        }

        private void btnsubfind_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<findabook>();
        }

        private void btnlasttaken_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<lasttaken>();
        }

        private void btnsubstudent_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<student>();
        }

        private void btnsubstaff_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<staff>();
        }

        private void btnsubguest_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<guest>();
        }

        private void btnsubbooks_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<bookentry>();
        }

        private void btnsubissued_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<issuedbook>();
        }

        private void btnsubavailable_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<booksavailable>();
        }

        private void btnstudentstaff_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<studentstaffreport>();
        }

        private void btnsubclasswise_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<classwise>();
        }

        private void btnsubbydate_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<reportbydate>();
        }

        private void btnsubpassword_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<changepassword>();
        }

        private void btnsubbackup_Click_1(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<backup>();
        }

        private void subbtnissuestudent_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<studenttransaction>();
        }

        private void subbtnissuestaff_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<stafftransaction>();
        }

        private void subbtnissuesearch_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenForm<guesttransaction>();
        }
    }
}
