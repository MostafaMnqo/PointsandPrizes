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
            <h2>Students List</h2>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="StuId" HeaderText="Student ID" />
                        <asp:BoundField DataField="ClassId" HeaderText="Class ID" />
                        <asp:BoundField DataField="StuName" HeaderText="Name" />
                        <asp:ImageField DataImageUrlField="StuImage" HeaderText="Image">
                            <ControlStyle Width="100px" Height="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="StuPoints" HeaderText="Points" />
                    </Columns>
                </asp:GridView>
            </div>
            
        
    </div>
</asp:Content>
