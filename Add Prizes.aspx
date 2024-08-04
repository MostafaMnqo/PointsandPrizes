<%@ Page Title="" Language="C#" MasterPageFile="~/TheSite.Master" AutoEventWireup="true" CodeBehind="Add Prizes.aspx.cs" Inherits="Points_and_Prizes.Add_Prizes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-container">
        <h2>إضافة جائزة</h2>
            <div class="form-group">
                <label for="txtPrizeName">اسم الجائزة:</label>
                <asp:TextBox ID="txtPrizeName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="fileUpload">تحميل صورة (اختياري):</label>
                <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtQuantity">الكمية:</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPrice">السعر:</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddPrize" runat="server" Text="إضافة جائزة" CssClass="btn" OnClick="btnAddPrize_Click" />
            </div>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
    </div>
    <div class="form-container">
        <h2>قائمة الجوائز</h2>
        <asp:GridView ID="GridViewPrizes" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Pname" HeaderText="اسم الجائزة" />
                <asp:ImageField DataImageUrlField="Pimage" HeaderText="صورة الجائزة" ControlStyle-Width="100px" ControlStyle-Height="100px" />
                <asp:BoundField DataField="Pquantity" HeaderText="الكمية" />
                <asp:BoundField DataField="Pprice" HeaderText="السعر" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
