<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewPatient.aspx.cs" Inherits="medicalclinic.AddNewPatient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="text-align: center">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medical Clinic - Add new patient</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; padding: 15px; display: inline-block;">
        <div style="border: 1px solid #000000; font-size: medium; color: #FFFFFF; text-align: center; padding: 30px; background-color: #507CD1; width: 320px;">
            <asp:Label ID="AddPatient" runat="server" Text="Add new patient" Font-Bold="True"></asp:Label> 
        </div>
            <div style="border-style: solid; border-width: 1px; color: #000000; background-color: #FFFFFF; padding: 30px; display: inline-table; text-align: left; width: 320px;";>

                <asp:Label ID="LabelName" runat="server" Text="First name:" Width="120px" ></asp:Label><asp:TextBox ID="TextBoxName" runat="server" placeholder="Patient name" Height="20px" Width="180px" Font-Bold="False" MaxLength="30"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelSurname" runat="server" Text="Surname:" Width="120px"></asp:Label><asp:TextBox ID="TextBoxSurname" runat="server" placeholder="Patient surname" Height="20px" Width="180px" MaxLength="30"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Sex:" Width="120px"></asp:Label><asp:DropDownList ID="DropDownListSex" runat="server" Width="180px">
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="LabelPesel" runat="server" Text="Pesel number" Width="120px"></asp:Label><asp:TextBox ID="TextBoxPesel" runat="server" placeholder="Patient pesel number" Height="20px" Width="180px" MaxLength="11" style="margin-left: 0px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelDate" runat="server" Text="Date of birth:" Width="120px"></asp:Label><asp:TextBox ID="TextBoxDateOfBirth"  runat="server" TextMode="Date" Height="20px" Width="180px" ></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelPhoneNumber" runat="server" Text="Phone number:" Width="120px"></asp:Label><asp:TextBox ID="TextBoxPhoneNumber" runat="server" placeholder="Patient phone number" Height="20px" Width="180px" MaxLength="9"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LabelEmail" runat="server" Text="Email address:" Width="120px"></asp:Label><asp:TextBox ID="TextBoxEmail" runat="server" placeholder="Patient e-mail address" Height="20px" Width="180px" MaxLength="100"></asp:TextBox>
                <br />
                
                <br />
                <div style="padding-right: 15px; padding-left: 15px; float: left;">
                <asp:Button ID="ButtonAddNewPatient" runat="server" Text="Add" Width="130px" OnClick="ButtonAddNewPatient_Click" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="25px"/>
                </div>
                <div style="padding-right: 15px; padding-left: 15px; float: right;">
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" Width="130px" OnClick="ButtonCancel_Click" BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="25px"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>