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
        public mainTeacher()
        {
            InitializeComponent();
        }

        private void btnCheckSubmissions_Click(object sender, EventArgs e)
        {
            InsertingQuestions i_q = new InsertingQuestions();
            i_q.Show();
        }

        private void mainTeacher_Load(object sender, EventArgs e)
        {

        }
    }
}
