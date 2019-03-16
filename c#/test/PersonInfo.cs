namespace Extensometer_with_openCV
{
    internal class PersonInfo
    {
        public int? Height { get; set; }
        public int? ShoulderLength { get; set; }
        public int? ShoulderAngle { get; set; }
        public int? Head { get; set; }
        public int? Score { get; set; }
        public string Name;

        public PersonInfo(int? height = null, int? shoulderLength = null, int? shoulderAngle = null, int? head = null, int? score = null, string name = null)
        {
            Height = height;
            ShoulderLength = shoulderLength;
            ShoulderAngle = shoulderAngle;
            Head = head;
            Score = score;
            Name = name;
        }

        public void SetPer()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(System.Windows.Forms.Application.StartupPath + "\\opencv-data\\result_data.txt");
            //키 등신 어깨 어깨기울기 점수
            string a = file.ReadLine();
        }
    }
}