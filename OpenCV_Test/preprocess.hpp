#include <opencv2/opencv.hpp>
using namespace std;
using namespace cv;
void load_cascade(CascadeClassifier& cascade, string fname) {
	String path = "C:/opencv-3.4/sources/data/haarcascades/";
	String full_name = path + fname;
	CV_Assert(cascade.load(full_name));
}
Mat preprocessing(Mat image) {
	Mat gray;
	cvtColor(image, gray, CV_BGR2GRAY);
	equalizeHist(gray, gray);
	return gray;
}