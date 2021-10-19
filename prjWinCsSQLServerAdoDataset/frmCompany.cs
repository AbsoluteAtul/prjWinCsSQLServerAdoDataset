using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace prjWinCsSQLServerAdoDataset
{
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }
        // Form global variable
        DataSet mySet;
        DataTable tabcompany;
        SqlConnection myConn;
        int currentindex = 0;
        string mode;

        private void frmCompany_Load(object sender, EventArgs e)
        {
            mySet = new DataSet();
            // Create a connection to the database and open it
            myConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Business;Integrated Security=True");
            myConn.Open();

            //Create a command to the DataBase to recuperiate the table Company
            SqlCommand myCmd = new SqlCommand("SELECT * FROM Companies",myConn);

            SqlDataAdapter myAdp = new SqlDataAdapter(myCmd);
            myAdp.Fill(mySet, "Companies");

            tabcompany = mySet.Tables["Companies"];

            
        }
        private void DisplayData2Text()
        {
            txtCompany.Text = mySet.Tables["Companies"].Rows[currentindex]["CompanyName"].ToString();
            // Replace with tabCompany
            txtType.Text = tabcompany.Rows[currentindex]["Type"].ToString();
            txtLocation.Text = tabcompany.Rows[currentindex]["Location"].ToString();
            txtWebsite.Text = tabcompany.Rows[currentindex]["Website"].ToString();
            txtBudget.Text = tabcompany.Rows[currentindex]["Budget"].ToString();
            lblDisplay.Text = "Company " + (currentindex + 1) + " on the total of " + (tabcompany.Rows.Count - 1);

        }

     
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentindex < (tabcompany.Rows.Count - 1))
            {
                currentindex++;
                DisplayData2Text();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentindex > 0)
            {
                currentindex--;
                DisplayData2Text();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentindex = tabcompany.Rows.Count - 1;
            DisplayData2Text();

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

            // Display the first datarow (index 0) or record in the text box
            DisplayData2Text();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";

        }
    }

}
