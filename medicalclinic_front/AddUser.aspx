<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddUser.aspx.cs" Inherits="medicalclinic.WebForm2" %>

<asp:Content ID="AddUser" ContentPlaceHolderID="MainContent" runat="server">
    <div class="employee-add-user">
        <div class="employee-show__item">
            <asp:TextBox ID="TextBoxLogin" placeholder="Login" runat="server"></asp:TextBox><br />
        </div>
        <div class="employee-show__item">
            <asp:TextBox ID="TextBoxPassword" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox><br />
        </div>
        <asp:Button ID="ButtonOK" runat="server" Text="OK" CssClass="btn btn-default" OnClick="ButtonOK_Click" /><br />
        <asp:Button ID="ButtonSKIP" runat="server" Text="SKIP" CssClass="btn btn-default" OnClick="ButtonSKIP_Click" /><br />
    </div>
</asp:Content>
