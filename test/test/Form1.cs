//주석 ctrl+k+c 풀때 ctrl+k+u
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using Newtonsoft.Json.Linq;
using System.IO;
using Extensometer_with_openCV;

namespace test
{
    public partial class Form1 : Form
    {
        const int frameWidth = 640;    // 화면 가로
        const int frameHeight = 480;    // 화면 세로

        VideoCapture capture;
        Mat frame = new Mat();
        MysqlConnection mysqlConnection = new MysqlConnection();
        public Form1()
        {
            mysqlConnection.Connection();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened())  //카메라 오픈 후 
            {
                capture.Read(frame);
                
                frame = findFace(frame);    //와꾸 찾기

                frame = frame.Flip(FlipMode.Y);     //좌우 반전

                pictureBoxIpl1.ImageIpl = frame;
            }
            else  //  카메라 오픈 전 
            {
                
                frame = new Mat(@"C:\opencv_data\logo.png");
                
                pictureBoxIpl1.ImageIpl = frame;
            }
        }

        // 화면 켜기
        private void onpen_btn_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(3000);
            timer2.Start();

            capture = VideoCapture.FromCamera(CaptureDevice.DShow, 0);
            capture.FrameWidth = frameWidth;
            capture.FrameHeight = frameHeight;  //종료
            capture.Open(0);    //종료
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Stop();

        }

        private Mat findFace(Mat srcMat)
        {
            using (CascadeClassifier detectFace = new CascadeClassifier(@"C:\opencv_data\haarcascade_frontalface_alt.xml"))
            {
                Mat result = new Mat();
                Mat output = new Mat();
                Cv2.CvtColor(srcMat, result, ColorConversionCodes.BGR2GRAY);

                int gr_thr = 4;
                double scale_step = 1.1;

                OpenCvSharp.Size min_obj_sz = new OpenCvSharp.Size(48, 96);
                OpenCvSharp.Size max_obj_sz = new OpenCvSharp.Size(100, 200);

                int x1, x2;
                int y1, y2;

                // detect
                Rect[] found;
                found = detectFace.DetectMultiScale(result, scale_step, gr_thr);
                
                if (found.Length == 1)
                {
                    output = srcMat.Clone();

                    srcMat.Rectangle(found[0], Scalar.Red, 5);

                    OpenCvSharp.Cv2.ImWrite(@"C:\opencv_data\test.jpg", output);    //jpg파일 저장

                    x1 = found[0].X;
                    y1 = found[0].Y;
                    x2 = found[0].X + found[0].Width;
                    y2 = found[0].Y + found[0].Height;
                    /*
                    var json = new JObject();
                    json.Add("x1", x1);
                    json.Add("y1", y1);
                    json.Add("x2", x2);
                    json.Add("y2", y2);
                    */
                    //Console.WriteLine(json.ToString());
                    using (StreamWriter wr = new StreamWriter(@"C:\opencv_data\data.txt"))
                    {
                        wr.WriteLine(x1);
                        wr.WriteLine(y1);
                        wr.WriteLine(x2);
                        wr.WriteLine(y2);
                    }
                }

                output.Dispose();
                found = null;
                detectFace.Dispose();
                result.Dispose();
                found = null;
            }

            return srcMat;
        }

        private void pictureBoxIpl1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (capture != null)
            {
                capture.Release();  //화면종료
                pictureBoxIpl1.Image = null;    //화면종료
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            MysqlConnection mysqlConnection = new MysqlConnection();
            mysqlConnection.Connection();
            mysqlConnection.SelectOne();
            */
            Personal_Statistics ps = new Personal_Statistics();
            ps.Owner = this;
            ps.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RankerList rank = new RankerList();
            rank.Owner = this ;
            rank.ShowDialog();
        }
    }
}

