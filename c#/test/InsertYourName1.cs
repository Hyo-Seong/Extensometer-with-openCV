using System;
using System.Windows.Forms;

namespace Extensometer_with_openCV
{
    public partial class InsertYourName1 : Form
    {
        private MysqlConnection mysql = new MysqlConnection();

        public InsertYourName1()
        {
            mysql.Connection();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(textBox1.Text);
            mysql.SetData(textBox1.Text);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}