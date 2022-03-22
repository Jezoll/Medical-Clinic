<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddUser.aspx.cs" Inherits="medicalclinic.WebForm2" %>

<asp:Content ID="AddUser" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        </div>
        <asp:TextBox ID="TextBoxLogin" placeholder="Login" runat="server"></asp:TextBox><br />
         <asp:DropDownList ID="DropDownListPermissions" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="ButtonOK" runat="server" Text="OK" OnClick="ButtonOK_Click" /><br />
        <asp:Button ID="ButtonSKIP" runat="server" Text="SKIP" OnClick="ButtonSKIP_Click" /><br />
</asp:Content>
