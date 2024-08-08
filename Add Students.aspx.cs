using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Points_and_Prizes
{
    public partial class Add_Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateClasses();
                BindStudentData();
            }
        }
        private void PopulateClasses()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT ClassId, ClassName FROM Classes";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlClasses.DataSource = reader;
                    ddlClasses.DataTextField = "ClassName";
                    ddlClasses.DataValueField = "ClassName";
                    ddlClasses.DataBind();
                }
            }

            ddlClasses.Items.Insert(0, new ListItem("-- اختر الفصل --", "0"));
        }
        private void BindStudentData()
        {
            string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";
            string query = @"SELECT Students.StuId, Students.StuName, Students.StuImage, Students.StuPoints, Classes.ClassName 
                       FROM Students 
                       INNER JOIN Classes ON Students.ClassName = Classes.ClassName";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        StudentsRepeater.DataSource = dt;
                        StudentsRepeater.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        lblMessage.Text = "Database error: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string studentName = txtName.Text;
            string selectedClass = ddlClasses.SelectedValue;
            string points = txtPoints.Text;
            string className = ddlClasses.SelectedValue;
            string stuImagePath = null;

            // Handle file upload
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                stuImagePath = "~/Uploads/" + fileName;
                fileUpload.PostedFile.SaveAs(Server.MapPath(stuImagePath));
            }

            // Database connection
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Students (ClassName, StuName, StuImage, StuPoints) VALUES (@ClassName ,@Name, @Picture, @Points)";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ClassName", selectedClass);
                    comm.Parameters.AddWithValue("@Name", studentName);
                    comm.Parameters.AddWithValue("@Picture", (object)stuImagePath ?? DBNull.Value);
                    comm.Parameters.AddWithValue("@Points", points);
                    

                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }

            txtName.Text = "";
            txtPoints.Text = "";
            ddlClasses.SelectedIndex = 0;
            lblMessage.Text = "تم إضافة الطالب بنجاح";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            BindStudentData();
        }
    }
}