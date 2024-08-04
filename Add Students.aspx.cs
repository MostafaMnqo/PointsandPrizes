using System;
using System.Collections.Generic;
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
                    ddlClasses.DataValueField = "ClassId";
                    ddlClasses.DataBind();
                }
            }

            ddlClasses.Items.Insert(0, new ListItem("-- اختر الفصل --", "0"));
        }
        private void BindGrid()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT StuId, ClassId, StuName, StuImage, StuPoints FROM Students";
                SqlCommand comm = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string studentName = txtName.Text;
            string selectedClass = ddlClasses.SelectedValue;
            int points = 0;

            if (!string.IsNullOrEmpty(txtPoints.Text))
            {
                points = int.Parse(txtPoints.Text);
            }

            byte[] imageBytes = null;

            if (fileUpload.HasFile)
            {
                using (BinaryReader br = new BinaryReader(fileUpload.PostedFile.InputStream))
                {
                    imageBytes = br.ReadBytes(fileUpload.PostedFile.ContentLength);
                }
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Students (ClassId, StuName, StuImage, StuPoints) VALUES (@ClassId ,@Name, @Picture, @Points)";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@ClassId", selectedClass);
                    comm.Parameters.AddWithValue("@Name", studentName);
                    comm.Parameters.AddWithValue("@Picture", (object)imageBytes ?? DBNull.Value);
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
        }
    }
}