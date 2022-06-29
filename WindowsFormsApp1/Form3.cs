using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3(Person person, int type)
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string sqlStr = "select * from product";
            DataSet ds = MySqlHelper.ExecSqlQuery(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.ProName = txtName.Text;

            string _ProCode = person.ProCode.ToString();
            _ProCode = txtCode.Text;

            string _ProSpecification = person.ProSpecification;
            _ProSpecification = txtSpecification.Text;


            string sqlStr = "select * from product where pro_name='"+ person.ProName + "' or pro_code = '"+ _ProCode + "' or pro_specification='"+ _ProSpecification+"'";
            DataSet ds = MySqlHelper.ExecSqlQuery(sqlStr);

            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
