<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="medicalclinic.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="TextBoxLogin" placeholder="Login" runat="server"></asp:TextBox><br />
         <asp:DropDownList ID="DropDownListPermissions" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="ButtonOK" runat="server" Text="OK" OnClick="ButtonOK_Click" /><br />
        <asp:Button ID="ButtonSKIP" runat="server" Text="SKIP" OnClick="ButtonSKIP_Click" /><br />
    </form>
</body>
</html>
