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

namespace prjWinCsSQLServerAdoDataset
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            //create dataset
            DataSet myset = new DataSet();
            SqlConnection myConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Business;Integrated Security=True");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * From Companies", myConn);
            SqlDataAdapter myAdp = new SqlDataAdapter(myCmd);

            myAdp.Fill(myset, "Companies");


            gridResult.DataSource = myset.Tables["Companies"];


        }
    }
}
