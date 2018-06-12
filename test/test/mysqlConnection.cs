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
            Console.WriteLine("not con");
            conn.Open();
            Console.WriteLine("Hello Mysql");
        }

        public void ShowRank()
        {
            string selectString = string.Format("SELECT * FROM user_score where idx=(select max(idx) from user_score);");
        }

        public PersonData SelectOne()
        {
            string selectString = string.Format("SELECT * FROM user_score where idx=(select max(idx) from user_score);");
            MySqlCommand cmd = new MySqlCommand(selectString, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("aaa");
            rdr.Read();
            PersonData per = new PersonData();
            per.height = (float)rdr["height"];
            per.shoulder_length = (float)rdr["shoulder_length"];
            per.shoulder_angle = (float)rdr["shoulder_angle"];
            per.head = (float)rdr["head"];
            per.score = (int)rdr["score"];
            Console.WriteLine(per.score);
            rdr.Close();
            return per;
        }
    }


}
