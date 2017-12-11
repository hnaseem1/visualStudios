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
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;


namespace WindowsFormsApplication3
{
    public partial class frmrpttrhistory : Form
    {
        SqlConnection cnstring = new SqlConnection("Persist Security Info=False;User ID=sa;password=sgc;Initial Catalog=snacklab2017;Data Source=HNASEEM");
        SqlCommand cmd;
        SqlDataAdapter adab;
        DataTable dtlogin = new DataTable();
        ReportDocument smreport = new ReportDocument();

        public frmrpttrhistory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnstring.Open();
            adab = new SqlDataAdapter("SELECT SalesRoot.TSerial, ContactRoot.ContactName, SalesRoot.Through, SalesRoot.LessDisc, SalesRoot.Cartons FROM SalesRoot INNER JOIN ContactRoot ON ContactRoot.ContactId = SalesRoot.Contact WHERE Through <> '' Order by tdate desc;", cnstring);
            adab.Fill(dtlogin);
            cnstring.Close();
            
        }


    }
}
