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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlStr = "select * from product";
            DataSet ds = MySqlHelper.ExecSqlQuery(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(new Person(), 1);
            form2.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string sqlStr = "select * from product";
            DataSet ds = MySqlHelper.ExecSqlQuery(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            if (dr == null)
            {
                MessageBox.Show("Please choose which one you want to change!");
                return;
            }
            Person person = new Person();
            person.ID = Dr2Int(dr.Cells["id"].Value);
            person.ProName = Dr2Str(dr.Cells["pro_name"].Value);
            person.ProCode = Dr2Int(dr.Cells["pro_code"].Value);
            person.ProSpecification = Dr2Str(dr.Cells["pro_specification"]. Value);
            person.ProQuantity = Dr2Int(dr.Cells["pro_inventory"].Value); 
            person.CreationTime =DateTime.Parse(Dr2Str(dr.Cells["creat_time"].Value));

            Form2 form2 = new Form2(person,0);
            form2.ShowDialog();
        }
        public string Dr2Str(object o)
        {
            if (o != null)
            {
                return o.ToString();
            }
            return string.Empty;
        }
        public int Dr2Int(object o)
        {
            int result = 0;
            if (o != null)
            {
                int.TryParse(o.ToString(), out result);
            }
            return result;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            if (dr == null)
            {
                MessageBox.Show("Please choose which one you want to delete!");
                return;
            }
            string sqlStr = "delete from product where id=@id";
            MySqlParameter para = new MySqlParameter("@id", dr.Cells["ID"].Value);
            if (MySqlHelper.ExecSql(sqlStr, para))
            {
                MessageBox.Show("Delete Successful!");

            }
            else
            {
                MessageBox.Show("Delete Fail!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(new Person(), 1);
            form3.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
