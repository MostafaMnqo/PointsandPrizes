<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add Prizes old.aspx.cs" Inherits="Points_and_Prizes.Add_prizes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Prize</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 50px;
            text-align: center;
        }
        .form-container {
            width: 300px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .form-container h2 {
            margin-bottom: 20px;
        }
        .form-container input, .form-container button {
            width: calc(100% - 20px);
            padding: 10px;
            margin: 10px 0;
        }
        .form-container button {
            background-color: #007BFF;
            border: none;
            color: white;
            cursor: pointer;
        }
        .form-container button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="form-container">
            <h2>إضافة جوائز</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtPrizeName" runat="server" Placeholder="أسم الجائزة"></asp:TextBox>
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:TextBox ID="txtQuantity" runat="server" Placeholder="الكمية"></asp:TextBox>
            <asp:TextBox ID="txtPrice" runat="server" Placeholder="السعر بالنقاط"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="إضافة" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
