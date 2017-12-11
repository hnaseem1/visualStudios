using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        SqlConnection cnstring = new SqlConnection("Persist Security Info=False;User ID=sa;password=sgc;Initial Catalog=PractiseDB;Data Source=HNASEEM");
        SqlCommand cmd;
        SqlDataAdapter adab;
        DataTable dtlogin = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnstring.Open();

            adab = new SqlDataAdapter("select * from login where userid = '"+ txtUN.Text.Trim()+"' ", cnstring);
            adab.Fill(dtlogin);

            string id = dtlogin.Rows[0]["userid"].ToString();

            if (txtUN.Text.Trim() == dtlogin.Rows[0]["userid"].ToString() && txtPW.Text.Trim() == dtlogin.Rows[0]["password"].ToString())
            {
                MessageBox.Show("Successful");
                Form1 frm1 = new Form1();
                Form2 frm2 = new Form2();
                frm2.Show();
                adab.Dispose();
                dtlogin.Clear();

            }

            else

                MessageBox.Show("Username or Password Incorrect");

            cnstring.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmrpttrhistory form3 = new frmrpttrhistory();
            form3.Show();
        }

    }
}
