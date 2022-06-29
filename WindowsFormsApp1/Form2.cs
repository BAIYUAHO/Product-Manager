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
    public partial class Form2 : Form
    {
        int _type = 0;
        public Form2(Person person, int type)
        {
            InitializeComponent();
            _type = type;
            if (person != null)
            {
                txtId.Text = person.ID.ToString();
                txtName.Text = person.ProName;
                txtCode.Text = person.ProCode.ToString();
                txtSpecification.Text = person.ProSpecification;
                txtQuantity.Text = person.ProQuantity.ToString();
                txtTime.Text = person.CreationTime.ToString();
            }
            if(type == 1)
            {
                btnEdit.Text = "Add";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_type == 1)
            {
                Person person = new Person();

                person.ProName = txtName.Text;

                string _ProCode = person.ProCode.ToString();
                _ProCode = txtCode.Text;

                person.ProSpecification = txtSpecification.Text;

                string _ProQuantity = person.ProQuantity.ToString();
                _ProQuantity = txtQuantity.Text;

                string _CreationTime = person.CreationTime.ToString();
                _CreationTime = txtTime.Text;

                string sqlStr = "insert into product (pro_name,pro_code,pro_specification,pro_inventory,creat_time) value(@pro_name,@pro_code,@pro_specification,@pro_inventory,@creat_time)";
                MySqlParameter[] para = new MySqlParameter[]
                {
                    new MySqlParameter("@pro_name",person.ProName),
                    new MySqlParameter("@pro_code",txtCode.Text),
                    new MySqlParameter("@pro_specification",person.ProSpecification),
                    new MySqlParameter("@pro_inventory",txtQuantity.Text),
                    new MySqlParameter("@creat_time",txtTime.Text)
                };
                if (MySqlHelper.ExecSql(sqlStr, para))
                {
                    MessageBox.Show("Add Successful!");
                }
                else
                {
                    MessageBox.Show("Add Fail!");
                }
            }
            else
            {
                string sqlStr = "update product set pro_name=@pro_name, pro_code=@pro_code, pro_specification=@pro_specification, pro_inventory=@pro_inventory, creat_time=@creat_time where ID=@id";
                MySqlParameter[] para = new MySqlParameter[]
                {
                    new MySqlParameter("@id",txtId.Text),
                    new MySqlParameter("@pro_name",txtName.Text),
                    new MySqlParameter("@pro_code",txtCode.Text),
                    new MySqlParameter("@pro_specification",txtSpecification.Text),
                    new MySqlParameter("@pro_inventory",txtQuantity.Text),
                    new MySqlParameter("@creat_time",txtTime.Text)
                };
                if (MySqlHelper.ExecSql(sqlStr, para))
                {
                    MessageBox.Show("Edit Successful!");

                }
                else
                {
                    MessageBox.Show("Edit Fail!");
                }
            }

            this.DialogResult = DialogResult.OK;
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
