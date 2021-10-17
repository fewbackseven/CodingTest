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
    public partial class _Default : Page
    {
        readonly SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-P4PLEO7;Initial Catalog=EmpRecords;Integrated Security=SSPI;");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("spSaveRecords", sqlCon)
            {
                CommandType = CommandType.StoredProcedure
            };
            sqlCmd.Parameters.AddWithValue("@EmployeeID", txtEmpID.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@EmployeeName", txtEmpName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Desigantion", txtDesignation.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Department",txtDepartment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Salary",int.Parse(txtSalary.Text));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            statusLbl.Text = "Saved Successfully";
            Clear();

        }

        private void Clear()
        {
            txtEmpID.Text = txtEmpName.Text = txtDesignation.Text = txtDepartment.Text = txtSalary.Text ="";
        }
    }
}