<%@ Page Title="" Language="C#" MasterPageFile="~/TheSite.Master" AutoEventWireup="true" CodeBehind="Add Students.aspx.cs" Inherits="Points_and_Prizes.Add_Students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2>إضافة طالب</h2>
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        
            <div class="form-group">
                <label for="txtName">اسم الطالب:</label>
                <asp:TextBox ID="txtName" runat="server" />
            </div>
            <div class="form-group">
                <label for="fileUpload">تحميل الصورة:</label>
                <asp:FileUpload ID="fileUpload" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtPoints">النقاط:</label>
                <asp:TextBox ID="txtPoints" runat="server" TextMode="Number" />
            </div>
            <div class="form-group">
                <label for="ddlClass">الفصل:</label>
                <asp:DropDownList ID="ddlClasses" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="إضافة الطالب" OnClick="btnSubmit_Click" />
            </div>
            
            <div class="form-container">
        <h2>قائمة الطلاب</h2>
        <asp:Repeater ID="StudentsRepeater" runat="server">
            <HeaderTemplate>
                <table width="100%" border="1">
                    <tr>
                        <th>معرف الطالب</th>
                        <th>الاسم</th>
                        <th>الصورة</th>
                        <th>النقاط</th>
                        <th>معرف الصف</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("StuId") %></td>
                    <td><%# Eval("StuName") %></td>
                    <td><img src='<%# Eval("StuImage") %>' alt="صورة الطالب" style="width:100px;height:100px;" /></td>
                    <td><%# Eval("StuPoints") %></td>
                    <td><%# Eval("ClassId") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="Label1" runat="server" CssClass="message"></asp:Label>
    </div>
            
        
    </div>
</asp:Content>
