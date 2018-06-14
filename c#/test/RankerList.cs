using Extensometer_with_openCV;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class RankerList : Form
    {
        
        public RankerList()
        {
            MySqlConnection conn;
            string strconn = "Server=localhost;Database=extensometer;Uid=root;Pwd=1234;SslMode=none;Character Set=utf8;";
            conn = new MySqlConnection(strconn);
            conn.Open();

            string selectString = string.Format("SELECT * FROM user_score order by score DESC;");
            MySqlCommand cmd = new MySqlCommand(selectString, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            Label bel2 = new Label();
            bel2.Text = "이름";
            bel2.SetBounds(35, 25, 100, 30);
            Controls.Add(bel2);

            Label bel7 = new Label();
            bel7.Text = "점수";
            bel7.SetBounds(135, 25, 100, 30);
            Controls.Add(bel7);

            Label bel3 = new Label();
            bel3.Text = "키";
            bel3.SetBounds(235, 25, 100, 30);
            Controls.Add(bel3);

            Label bel4 = new Label();
            bel4.Text = "어깨길이";
            bel4.SetBounds(335, 25, 100, 30);
            Controls.Add(bel4);

            Label bel5 = new Label();
            bel5.Text = "기울기";
            bel5.SetBounds(435, 25, 100, 30);
            Controls.Add(bel5);

            Label bel6 = new Label();
            bel6.Text = "등신";
            bel6.SetBounds(535, 25, 50, 30);
            Controls.Add(bel6);
            int x = 60;
            int i = 1;
            try
            {
                while (rdr.Read())
                {

                    Label label4 = new Label();
                    label4.Text = i.ToString() + ".";
                    i++;
                    label4.SetBounds(15, x, 20, 30);
                    Controls.Add(label4);

                    Label label3 = new Label();
                    label3.Text = rdr["user_name"].ToString();
                    label3.SetBounds(35, x, 100, 30);
                    Controls.Add(label3);

                    Label label2 = new Label();
                    label2.Text = rdr["score"].ToString();
                    label2.SetBounds(135, x, 100, 30);
                    Controls.Add(label2);

                    Label label7 = new Label();
                    label7.Text = rdr["height"].ToString();
                    label7.SetBounds(235, x, 100, 30);
                    Controls.Add(label7);

                    Label label8 = new Label();
                    label8.Text = rdr["shoulder_length"].ToString();
                    label8.SetBounds(335, x, 100, 30);
                    Controls.Add(label8);

                    Label label9 = new Label();
                    label9.Text = rdr["shoulder_angle"].ToString();
                    label9.SetBounds(435, x, 100, 30);
                    Controls.Add(label9);

                    Label label19 = new Label();
                    label19.Text = rdr["head"].ToString();
                    label19.SetBounds(535, x, 50, 30);
                    Controls.Add(label19);
                    x += 35;
                    if (i == 11)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("aaa");
                Label label5 = new Label();
                string a = "기록된 데이터가 없습니다.";
                label5.SetBounds(150, 150, 200, 30);
                Controls.Add(label5);
            }

            InitializeComponent();
        }

        private void RankerList_Load(object sender, EventArgs e)
        {
            MysqlConnection mysqlConnection = new MysqlConnection();
            mysqlConnection.Connection();
            //mysqlConnection.SelectOne();
            mysqlConnection.ShowRank();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
