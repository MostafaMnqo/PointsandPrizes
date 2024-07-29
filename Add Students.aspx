<%@ Page Title="" Language="C#" MasterPageFile="~/TheSite.Master" AutoEventWireup="true" CodeBehind="Add Students.aspx.cs" Inherits="Points_and_Prizes.Add_Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2>إضافة طالب</h2>
        <div class="form-group">
            <label for="txtStudentName">اسم الطالب:</label>
            <asp:TextBox ID="txtStudentName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="fileUpload">الصورة (اختياري):</label>
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtPoints">النقاط (اختياري):</label>
            <asp:TextBox ID="txtPoints" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <!-- add later OnClick="btnAddStudent_Click" -->
        <div class="form-group">
            <asp:Button ID="btnAddStudent" runat="server" Text="إضافة الطالب" CssClass="btn btn-primary"  />
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
