//주석 ctrl+k+c 풀때 ctrl+k+u
using Extensometer_with_openCV;
using OpenCvSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        private const int frameWidth = 640;    // 화면 가로
        private const int frameHeight = 480;    // 화면 세로

        private VideoCapture capture;
        private Mat frame = new Mat();
        private MysqlConnection mysqlConnection = new MysqlConnection();

        public Form1()
        {
            mysqlConnection.Connection();
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (capture != null && capture.IsOpened())  //카메라가 오픈되었으면
            {
                capture.Read(frame);

                frame = findFace(frame);    //얼굴 찾기

                frame = frame.Flip(FlipMode.Y);     //좌우 반전

                frame = DrawLine(frame);

                pictureBoxIpl1.ImageIpl = frame;
            }
            else  //  카메라 오픈 전
            {
                try
                {
                    frame = new Mat(@"C:\opencv_data\logo.png"); //경로설정 다 해야할듯,,

                    pictureBoxIpl1.ImageIpl = frame;
                }
                catch
                {
                    MessageBox.Show("파일이 존재하지 않습니다.");
                    pictureBoxIpl1.ImageIpl = null;
                }
            }
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

        private Mat DrawLine(Mat srcMat)
        {
            Mat result = new Mat(srcMat.Size(), MatType.CV_8UC1, 3);
            srcMat.CopyTo(result);

            result.Line(320, 0, 320, 480, Scalar.Black, 3);

            return result;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Release();  //화면종료
                pictureBoxIpl1.Image = null;    //화면종료
                Thread.Sleep(500);
                string strappname = @"C:\opencv_data\cpp_opencv\OpenCV_Test.exe";
                Process pro = Process.Start(strappname);
                Thread.Sleep(1000);
                timer2.Stop();
                UserResult user = new UserResult();
                user.Owner = this;
                user.ShowDialog();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new InsertYourName2().ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new RankerList().ShowDialog();
        }

        private void Open_btn_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(3000);
            timer2.Start();

            capture = VideoCapture.FromCamera(CaptureDevice.DShow, 0);
            capture.FrameWidth = frameWidth;
            capture.FrameHeight = frameHeight;  //종료
            capture.Open(1);    //종료
        }
    }
}