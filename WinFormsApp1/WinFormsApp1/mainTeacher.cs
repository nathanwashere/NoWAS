using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class mainTeacher : Form
    {
        private bool isCLosing = false;
        public mainTeacher()
        {
            InitializeComponent();
        }

        private void btnCheckSubmissions_Click(object sender, EventArgs e)
        {
            InsertingQuestions i_q = new InsertingQuestions();
            i_q.Show();
        }
        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            TestCreation testCreation = new TestCreation();
            testCreation.Show();
        }
        private void mainTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isCLosing)
            {
                Application.Exit();
            }
        }
        private void Button1_click(object sender,EventArgs e)
        {
            StudentStatisticsForm studentStatisticsForm = new StudentStatisticsForm();
            studentStatisticsForm.Show();
        }
    }
}
