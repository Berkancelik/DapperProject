using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        string sql = "";

        void CUD(DynamicParameters dynamic = null)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            connection.Execute(sql, dynamic, commandType: CommandType.Text);
            connection.Close();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
            dataGridView1.DataSource = connection.Query<Departments>("Select * From Departments");
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DynamicParameters dynamic = new DynamicParameters();
            //dynamic.Add("@p1", txtDepartmen.Text);
            //dynamic.Add("@p2", txtDescription.Text);

            sql = "Insert Into Departments values (@p1, @p2)";
            CUD(dynamic);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DynamicParameters dynamic = new DynamicParameters();
            //dynamic.Add("@p1", txtDepartmen.Text);
            //dynamic.Add("@p2", txtDescription.Text);
            //dynamic.Add("p3", int.Parse(txtDepartmenId.Text));

            sql = "Update Departments set Department Deparment=@p1, Description=@p2 where Id=@p3)";
            CUD(dynamic);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //sql = "Delete from Departments Where Id='" + int.Parse(txtDepartmenId.Text) + "'";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = connection.Query<Departments>("Select * from Departments");

        }
    }
}
