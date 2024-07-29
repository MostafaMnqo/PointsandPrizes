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
    public partial class Add_Prizes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            /* if (fileUpload.FileName != "")
           {
               string imagefile = fileUpload.FileName;
               fileUpload.PostedFile.SaveAs(Server.MapPath("UpLoads") + "\\" +imagefile);
           }

           SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30");
               String sql;
               sql = "insert into Prizes(Pname,Pimage,Pquantity,Pprice) values ('" + txtPrizeName + "','"+ fileUpload+"','" +txtQuantity+ "','"+txtPrice+"')";
           SqlCommand comm = new SqlCommand(sql, conn);
           conn.Open();
           comm.ExecuteNonQuery();

           txtPrizeName.Text = "";
           txtQuantity.Text = "";
           txtPrice.Text = "";
           lblMessage.Text = ("تم إضافة الجائزة بنجاح");
           lblMessage.ForeColor = System.Drawing.Color.Green; */

            string prizeName = txtPrizeName.Text.Trim();
            int quantity;
            decimal price;

            if (string.IsNullOrEmpty(prizeName) ||
                !int.TryParse(txtQuantity.Text.Trim(), out quantity) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out price))
            {
                lblMessage.Text = "الرجاء إدخال بيانات صحيحة.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // image path variable
            string imagePath = null;

            // Check if the file upload control has a file
            if (fileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUpload.FileName);
                    imagePath = "~/Uploads/" + filename;
                    string serverPath = Server.MapPath(imagePath);
                    fileUpload.SaveAs(serverPath);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "حدث خطأ : " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            // Database connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Asus\\Documents\\PointsandPrizes.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Prizes (Pname, Pimage, Pquantity, Pprice) VALUES (@PrizeName, @ImagePath, @Quantity, @Price)";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@PrizeName", prizeName);
                    comm.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    comm.Parameters.AddWithValue("@Quantity", quantity);
                    comm.Parameters.AddWithValue("@Price", price);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        lblMessage.Text = "!تم إضافة الجائزة بنجاح";
                        lblMessage.ForeColor = System.Drawing.Color.Green;

                        // Clear the form fields after successful submission
                        txtPrizeName.Text = "";
                        txtQuantity.Text = "";
                        txtPrice.Text = "";
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