<%@ Page Title="" Language="C#" MasterPageFile="~/TheSite.Master" AutoEventWireup="true" CodeBehind="Add Prizes.aspx.cs" Inherits="Points_and_Prizes.Add_Prizes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
            <h2>إضافة جوائز</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <asp:TextBox ID="txtPrizeName" runat="server" Placeholder="أسم الجائزة"></asp:TextBox>
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:TextBox ID="txtQuantity" runat="server" Placeholder="الكمية"></asp:TextBox>
            <asp:TextBox ID="txtPrice" runat="server" Placeholder="السعر بالنقاط"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="إضافة" OnClick="btnSubmit_Click" />
        </div>
</asp:Content>
