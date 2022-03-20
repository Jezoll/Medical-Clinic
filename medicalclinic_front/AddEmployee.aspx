<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="medicalclinic.WebForm1" %>

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
        <asp:TextBox ID="TextBoxName" placeholder="Name*" runat="server" OnTextChanged="TexBoxName_TextChanged" AutoPostBack="True"> </asp:TextBox><br />
        <asp:TextBox ID="TextBoxSurname" placeholder="Surname*" runat="server" OnTextChanged="TextBoxSurname_TextChanged" AutoPostBack="True"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxPESEL" placeholder="PESEL*" runat="server" MaxLength="11" OnTextChanged="TextBoxPESEL_TextChanged" AutoPostBack="True"></asp:TextBox><br />
        <asp:Calendar ID="CalendarBirthDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>       
        <asp:DropDownList ID="DropDownListYears" runat="server" OnSelectedIndexChanged="DropDownListYears_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="DropDownListRole" runat="server" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListSpecialization" runat="server" Visible="False">
        </asp:DropDownList><br />
        <asp:TextBox ID="TextBoxCountry" placeholder="Country" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxState" placeholder="State" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxCity" placeholder="City" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxPostalCode" placeholder="Postal Code" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxStreet" placeholder="Street" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxHouseNumber" placeholder="House Number" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBoxPhoneNumber" placeholder="Phone Number" runat="server" MaxLength="9"></asp:TextBox><br />
        <asp:DropDownList ID="DropDownListSex" runat="server">
            <asp:ListItem Value="false">Female</asp:ListItem>
            <asp:ListItem Value="true">Male</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Button ID="ButtonNext" runat="server" Text="Next" Enabled="False" OnClick="ButtonNext_Click" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
        <br />
    </form>
</body>
</html>
