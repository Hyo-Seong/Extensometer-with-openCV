using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensometer_with_openCV
{
    class PersonInfo
    {
        public int height;
        public int shoulder_length;
        public int shoulder_angle;
        public int head;
        public int score;
        public string name;
        public void setPer()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\opencv-data\result_data.txt");
            //키 등신 어깨 어깨기울기 점수
            string a = file.ReadLine();
        }
    }
}
