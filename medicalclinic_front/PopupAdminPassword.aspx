<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopupAdminPassword.aspx.cs" Inherits="medicalclinic.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
            
            <asp:Label ID="MessageLabel" runat="server" Text="Log in with your admin password to continue"></asp:Label><br />
        <asp:TextBox ID="TextBoxPassword" type="password" runat="server" AutoPostBack="true" OnTextChanged="TextBoxPassword_TextChanged" ></asp:TextBox><br />
        <asp:Button ID="ConfirmButton" runat="server" Text="Confirm" OnClick="ConfirmButton_Click" Enabled="False" /><br />
    </form>
</body>
</html>
