<%@ Page Title="" Language="C#" MasterPageFile="~/TheSite.Master" AutoEventWireup="true" CodeBehind="Add Classes.aspx.cs" Inherits="Points_and_Prizes.Add_Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <h2>إضافة فصل</h2>
        <div class="form-group">
            <label for="txtClassName" dir="rtl">اسم الفصل:</label>
            <asp:TextBox ID="txtClassName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnAddClass" runat="server" Text="إضافة فصل" CssClass="btn btn-primary" OnClick="btnAddClass_Click" />
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <asp:Repeater ID="ClassesRepeater" runat="server">
            <HeaderTemplate>
                <table width="400" border="1">
                    <tr>
                        <th>رقم الفصل</th>
                        <th>أسم الفصل</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ClassId") %></td>
                    <td><%# Eval("ClassName") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        
    </div>
</asp:Content>
