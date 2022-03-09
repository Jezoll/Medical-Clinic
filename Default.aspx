<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webapp.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Logowanie</title>
    <link href="./Content/Site.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="text-section">
                <h2>logowanie</h2>
                <p>medical clinic</p>
            </div>
            <div class="inputs">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Login"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" placeholder="Hasło" type="password"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Zaloguj się" OnClick="Button1_Click" />
                <p class="forgot-pass"><a href="#">zapomniałeś hasła?</a></p>
                <asp:Label ID="IncorrectDataLabel" runat="server" Text="Nieprawidłowe dane logowania"></asp:Label>
            </div>
        </div>
    </form>
</body>

</html>
