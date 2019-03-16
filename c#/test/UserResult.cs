using System;
using System.Windows.Forms;
using test;

namespace Extensometer_with_openCV
{
    public partial class UserResult : Form
    {
        private MysqlConnection sql = new MysqlConnection();
        private PersonInfo per;
        private Form1 form1;

        public UserResult()
        {
            //PictureBox picbox = new PictureBox();
            //picbox.SetBounds(640,480,)


            sql.Connection();
            InitializeComponent();
            System.IO.StreamReader file = new System.IO.StreamReader(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\result_data.txt");
            //키 등신 어깨 어깨기울기 점수
            label1.Text = file.ReadLine();
            label4.Text = file.ReadLine();
            label8.Text = file.ReadLine();
            label6.Text = file.ReadLine();
            label12.Text = file.ReadLine();
            ResultPictureBox.Focus();
            pictureBox1.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\result.jpg");
            string label = label4.Text;
            Console.WriteLine(label);
            if (label == "1")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\1.png");
            }
            else if (label == "2")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\2.png");
            }
            else if (label == "3")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\3.png");
            }
            else if (label == "4")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\4.png");
            }
            else if (label == "5")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\5.png");
            }
            else if (label == "6")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\6.png");
            }
            else if (label == "7")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\7.png");
            }
            else if (label == "8")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\8.png");
            }
            else if (label == "9")
            {
                ResultPictureBox.Image = System.Drawing.Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\opencv_data\\9.png");
            }
            ResultPictureBox.Height = ResultPictureBox.Image.Height;
            ResultPictureBox.Width = ResultPictureBox.Image.Width;

            ResultPictureBox.Show();
            ResultPictureBox.Focus();
        }


        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserResult_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertYourName1 in1 = new InsertYourName1();
            in1.Owner = this;
            in1.ShowDialog();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResultPictureBox.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}