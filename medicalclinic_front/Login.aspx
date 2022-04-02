<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="medicalclinic.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Logowanie</title>
    <script src="https://kit.fontawesome.com/714b427abb.js" crossorigin="anonymous"></script>
    <link href="./Content/Login.css" rel="stylesheet" />
    <script type="text/javascript">
        window.history.forward(-1);
</script>

</head>

<body>
    <div class="back-to-home">
        <a href="./HomePage.html">powrót</a>
    </div>
    <div class="aspNetHidden">
        <input type="hidden" name="reference" id="reference" runat="server" />
    </div>
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
                <p class="forgot-pass"><a href="ForgetPassword.aspx">zapomniałeś hasła?</a></p>
                <asp:Label ID="IncorrectDataLabel" runat="server" Text="Nieprawidłowe dane logowania"></asp:Label>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
        </div>
    </form>
</body>

</html>
