<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Points_and_Prizes.WebForm1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 50px;
            text-align: center;
        }
        .login-container {
            width: 300px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .login-container h2 {
            margin-bottom: 20px;
        }
        .login-container input {
            width: calc(100% - 20px);
            padding: 10px;
            margin: 10px 0;
        }
        .login-container button {
            width: calc(100% - 20px);
            padding: 10px;
            background-color: #007BFF;
            border: none;
            color: white;
            cursor: pointer;
        }
        .login-container button:hover {
            background-color: #0056b3;
        }
        .image-container {
            margin-bottom: 20px;
        }
        .image-container img {
            max-width: 100px;
            border-radius: 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="image-container">
            <img src="NewFolder1/تكافل.jpg" alt="Logo" />
        </div>
        <div class="login-container">
            <h2>تسجيل الدخول</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="اسم المستخدم"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="كلمة المرور"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="تسجيل الدخول" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
