using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Notebook;Integrated Security=True;";
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                var ds = new DataSet();
                var da = new SqlDataAdapter("select * from People", cn);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
