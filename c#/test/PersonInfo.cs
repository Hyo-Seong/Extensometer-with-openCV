using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensometer_with_openCV
{
    class PersonInfo
    {
        public int Height { get; set; }
        public int ShoulderLength { get; set; }
        public int ShoulderAngle { get; set; }
        public int Head { get; set; }
        public int Score { get; set; }
        public string Name;

        public PersonInfo(int height, int shoulderLength, int shoulderAngle, int head, int score, string name)
        {

        }
        public void setPer()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\opencv-data\result_data.txt");
            //키 등신 어깨 어깨기울기 점수
            string a = file.ReadLine();
        }
    }
}
