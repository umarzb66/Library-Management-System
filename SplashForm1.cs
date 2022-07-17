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
    public partial class SplashForm1 : Form
    {
        public SplashForm1()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint +=1;
            myprogress.Value = startpoint;
            if(myprogress.Value == 100)
            {
                myprogress.Value = 0;
                timer1.Stop();
                LoginForm2 log = new LoginForm2();
                log.Show();
                this.Hide();
            }
        }

        private void SplashForm1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void myprogress_onValueChange(object sender, EventArgs e)
        {

        }
    }
}
