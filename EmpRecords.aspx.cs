using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodingTest
{
    public partial class EmpRecords : System.Web.UI.Page
    {
        readonly SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-P4PLEO7;Initial Catalog=EmpRecords;Integrated Security=SSPI;");

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetEmployees", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@EmployeeID", getEmpID.Text);
            DataTable empID = new DataTable();
            sqlDa.Fill(empID);
            sqlCon.Close();
            myDataGrid.DataSource = empID;
            myDataGrid.DataBind();
        }
    }
}