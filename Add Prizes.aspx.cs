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
    public partial class Add_Prizes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPrizes();
            }
        }
        protected void btnAddPrize_Click(object sender, EventArgs e)
        {
            {
                string prizeName = txtPrizeName.Text;
                string quantity = txtQuantity.Text;
                string price = txtPrice.Text;
                string imagePath = null;

                // Handle file upload
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                    imagePath = "~/Uploads/" + fileName;
                    fileUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                }

                // Database connection string
                string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "INSERT INTO Prizes (Pname, Pimage, Pquantity, Pprice) VALUES (@Pname, @Pimage, @Pquantity, @Pprice)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Pname", prizeName);
                        cmd.Parameters.AddWithValue("@Pimage", (object)imagePath ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Pquantity", quantity);
                        cmd.Parameters.AddWithValue("@Pprice", price);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            lblMessage.Text = "تم إضافة الجائزة بنجاح";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = "خطأ في قاعدة البيانات: " + ex.Message;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }

                // Clear form fields
                txtPrizeName.Text = "";
                txtQuantity.Text = "";
                txtPrice.Text = "";

                // Reload prizes
                LoadPrizes();
            }
        }
        private void LoadPrizes()
        {
            // Database connection string
            string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT Pname, Pimage, Pquantity, Pprice FROM Prizes";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewPrizes.DataSource = dt;
                    GridViewPrizes.DataBind();
                }
            }
        }
    }
}