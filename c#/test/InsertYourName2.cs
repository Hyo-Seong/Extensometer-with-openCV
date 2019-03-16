using Extensometer_with_openCV;
using System;
using System.IO;
using System.Windows.Forms;

namespace test
{
    public partial class InsertYourName2 : Form
    {
        public InsertYourName2()
        {
            InitializeComponent();
        }

        private MysqlConnection mysql = new MysqlConnection();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			//TODO: hyoeong - 여기 오류 (개인점수 확인)
            System.IO.StreamReader file = new System.IO.StreamReader(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\result_data.txt");
            //키 등신 어깨 어깨기울기 점수
            string a = file.ReadLine();
            using (StreamWriter wr = new StreamWriter(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\name.txt"))
            {
                wr.WriteLine(textBox1.Text);
            }
            Personal_Statistics personal = new Personal_Statistics();
            this.Close();
            personal.Show();
            personal.Focus();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}