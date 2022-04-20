<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar_AddAppointment.aspx.cs" Inherits="medicalclinic.Calendar_AddAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="550px" Width="361px">
                Name<br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                Surname<br />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                Phone<br />
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                Email<br />
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                <br />
                Date<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
                <br />
                Time<br />
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button_accept_appo" runat="server" OnClick="Button_accept_appo_Click" Text="Accept" Width="160px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_cancel_appo" runat="server" OnClick="Button_cancel_appo_Click" Text="Cancel" Width="160px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
