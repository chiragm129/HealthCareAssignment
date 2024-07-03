using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Healthcare_Informatics
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeeTable"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO Employee (EmployeeCode, EmployeeName, DateOfBirth, Gender, Department, Designation, BasicSalary) VALUES (@EmployeeCode, @EmployeeName, @DateOfBirth, @Gender, @Department, @Designation, @BasicSalary)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeCode", Convert.ToInt32(txtEmployeeCode.Text));
                cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(txtDateOfBirth.Text));

                // Convert the dropdown selected value to boolean
                bool gender = ddlGender.SelectedValue == "1";
                cmd.Parameters.AddWithValue("@Gender", gender);

                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                cmd.Parameters.AddWithValue("@BasicSalary", Convert.ToDouble(txtBasicSalary.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Log or display the error message
                    Response.Write("SQL Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            BindGridView();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Enable editing mode
            EnableEditMode(true);
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            // Save changes or new entry
            SaveOrUpdateEmployee();
            // Disable editing mode
            EnableEditMode(false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear form fields and disable editing mode
            ClearForm();
            EnableEditMode(false);
        }

        

        private bool IsEditMode()
        {
            // You can add logic here to determine if the form is in edit mode
            // For example, check if a specific control is enabled or disabled
            return txtEmployeeCode.Enabled;
        }

         private void EnableEditMode(bool enable)
        {
            if (enable)
            {
                // Enable editing controls
                txtEmployeeCode.Enabled = true;
                txtEmployeeName.Enabled = true;
                txtDateOfBirth.Enabled = true;
                ddlGender.Enabled = true;
                txtDepartment.Enabled = true;
                txtDesignation.Enabled = true;
                txtBasicSalary.Enabled = true;
                btnEdit.Visible = false; // Hide Edit button in edit mode
                btnEnter.Visible = true; // Show Enter button in edit mode
                btnCancel.Visible = true; // Show Cancel button in edit mode
            }
            else
            {
                // Disable editing controls
                txtEmployeeCode.Enabled = false;
                txtEmployeeName.Enabled = false;
                txtDateOfBirth.Enabled = false;
                ddlGender.Enabled = false;
                txtDepartment.Enabled = false;
                txtDesignation.Enabled = false;
                txtBasicSalary.Enabled = false;
                btnEdit.Visible = true; // Show Edit button in non-edit mode
                btnEnter.Visible = false; // Hide Enter button in non-edit mode
                btnCancel.Visible = false; // Hide Cancel button in non-edit mode
            }
        }

        private void SaveOrUpdateEmployee()
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeeTable"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "";
                if (IsEditMode())
                {
                    query = "UPDATE Employee SET EmployeeName = @EmployeeName, DateOfBirth = @DateOfBirth, Gender = @Gender, Department = @Department, Designation = @Designation, BasicSalary = @BasicSalary WHERE EmployeeCode = @EmployeeCode";
                }
                else
                {
                    query = "INSERT INTO Employee (EmployeeCode, EmployeeName, DateOfBirth, Gender, Department, Designation, BasicSalary) VALUES (@EmployeeCode, @EmployeeName, @DateOfBirth, @Gender, @Department, @Designation, @BasicSalary)";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeCode", Convert.ToInt32(txtEmployeeCode.Text));
                cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", Convert.ToDateTime(txtDateOfBirth.Text));
                bool gender = ddlGender.SelectedValue == "1";
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                cmd.Parameters.AddWithValue("@BasicSalary", Convert.ToDouble(txtBasicSalary.Text));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Log or display the error message
                    Response.Write("SQL Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            BindGridView(); // Refresh the GridView after saving/updating
        }

        private void ClearForm()
        {
            txtEmployeeCode.Text = "";
            txtEmployeeName.Text = "";
            txtDateOfBirth.Text = "";
            ddlGender.SelectedIndex = 0;
            txtDepartment.Text = "";
            txtDesignation.Text = "";
            txtBasicSalary.Text = "";
        }


        private void BindGridView()
        {
            string connString = ConfigurationManager.ConnectionStrings["EmployeeTable"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM Employee";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("DearnessAllowance", typeof(double));
                dt.Columns.Add("ConveyanceAllowance", typeof(double));
                dt.Columns.Add("HouseRentAllowance", typeof(double));
                dt.Columns.Add("TotalSalary", typeof(double));

                foreach (DataRow row in dt.Rows)
                {
                    double basicSalary = Convert.ToDouble(row["BasicSalary"]);
                    double dea = basicSalary * 0.4;
                    double ca = Math.Min(dea * 0.1, 250);
                    double hra = Math.Max(basicSalary * 0.25, 1500);
                    double grossSalary = basicSalary + dea + ca + hra;
                    double pt = (grossSalary <= 3000) ? 100 : (grossSalary > 3000 && grossSalary <= 6000) ? 150 : 200;
                    double totalSalary = grossSalary - pt;

                    row["DearnessAllowance"] = dea;
                    row["ConveyanceAllowance"] = ca;
                    row["HouseRentAllowance"] = hra;
                    row["TotalSalary"] = totalSalary;
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

    }
}
