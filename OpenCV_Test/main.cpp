#include <opencv2/opencv.hpp>
#include <iostream>
#include <thread>
#include <math.h>
#include <time.h>
#include <Windows.h>
#include <cstring>

using namespace cv;
using namespace std;

int Angle = 45;

void rotate(Mat src,int degree)
{
	Point centralPoint = Point(src.rows / 2, src.cols / 2);
	Mat matRotation = getRotationMatrix2D(centralPoint, (degree - 180), 1);
	Mat dst(500, 500, CV_8UC1);

	warpAffine(src, dst, matRotation, src.size());

	imshow("rotated image", dst);
}

int main()
{
	Mat img(500, 500, CV_8UC1,Scalar(0));
	line(img, Point(250,250), Point(300,200),Scalar(255), 1, 1);
	imshow("image", img);
	rotate(img,Angle);
	waitKey(0);
	return 0;
}