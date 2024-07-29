using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Points_and_Prizes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Dummy validation for demonstration
            if (username == "admin" && password == "password")
            {
                lblMessage.Text = "تم تسجيل الدخول";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                lblMessage.Text = "خطأ في اسم المستخدم او كلمة المرور";
            }
        }
    }
}