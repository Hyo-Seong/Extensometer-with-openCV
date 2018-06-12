using Extensometer_with_openCV;
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
