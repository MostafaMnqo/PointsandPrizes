using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Points_and_Prizes
{
    public partial class Add_Classes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClasses();
            }

        }
        protected void BindClasses()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT ClassId, ClassName FROM Classes";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ClassesRepeater.DataSource = dt;
                    ClassesRepeater.DataBind();
                }
            }
        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            string className = txtClassName.Text.Trim();

            if (string.IsNullOrEmpty(className))
            {
                lblMessage.Text = "Please enter a class name.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "INSERT INTO Classes (ClassName) VALUES (@ClassName)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClassName", className);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblMessage.Text = "تم إضافة الفصل بنجاح!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        txtClassName.Text = "";
                        BindClasses();
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Database error: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}