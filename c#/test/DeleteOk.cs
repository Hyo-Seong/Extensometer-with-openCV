using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;

namespace Extensometer_with_openCV
{
    public partial class DeleteOk : Form
    {
        private UserResult userResult;

        public DeleteOk()
        {
            InitializeComponent();
        }

        public DeleteOk(UserResult userResult)
        {
            this.userResult = userResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
