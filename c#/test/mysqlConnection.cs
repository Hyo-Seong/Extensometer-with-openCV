using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Threading;

namespace Extensometer_with_openCV
{
    class MysqlConnection
    {
        MySqlConnection conn;
        public void Connection()
        {
            string strconn = "Server=localhost;Database=extensometer;Uid=root;Pwd=1234;SslMode=none;Character Set=utf8;";
            conn = new MySqlConnection(strconn);
            conn.Open();
        }

        public void ShowRank()
        {
            string selectString = string.Format("SELECT * FROM user_score where idx=(select max(idx) from user_score);");
        }

        public void SetData(string name)
        {
            Connection();
            string selectString = string.Format("SELECT user_name FROM user where user_name=\"{0}\";",name);
            MySqlCommand cmd = new MySqlCommand(selectString, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                rdr.Close();
                Console.WriteLine("aaa");
                selectString = string.Format("insert into user values('{0}',null);", name);
                cmd = new MySqlCommand(selectString, conn);
                cmd.ExecuteNonQuery();
            }
            rdr.Close();
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\opencv_data\result_data.txt");
            //키 등신 어깨 어깨기울기 점수
            //file.ReadLine();
            selectString = string.Format("insert into user_score(user_name, height, head, shoulder_length, shoulder_angle, score) values('{0}',{1},{2},{3},{4},{5});", name,file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine(), file.ReadLine());
            MySqlCommand cmd2 = new MySqlCommand(selectString, conn);
            cmd2.ExecuteNonQuery();
        }

        internal void searchData(string text)
        {
            Connection();
        }
        //public PersonInfo SelectOne()
        //{
        //    string selectString = string.Format("SELECT * FROM user_score where idx=(select max(idx) from user_score);");
        //    MySqlCommand cmd = new MySqlCommand(selectString, conn);
        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    rdr.Read();
        //    PersonInfo per = new PersonInfo();
        //    per.height = (float)rdr["height"];
        //    per.shoulder_length = (float)rdr["shoulder_length"];
        //    per.shoulder_angle = (float)rdr["shoulder_angle"];
        //    per.head = (float)rdr["head"];
        //    per.score = (int)rdr["score"];
        //    Console.WriteLine(per.score);
        //    rdr.Close();
        //    return per;
        //}
    }


}
