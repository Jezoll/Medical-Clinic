<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Calendar.aspx.cs" Inherits="medicalclinic.Calendar" %>

<asp:Content ID="Calendar" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <center>
                <h1> CALENDAR </h1>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Calendar" Width="103px" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Month visits" Width="105px" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Sort by:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Visible="False">
                    <asp:ListItem>A-Z</asp:ListItem>
                    <asp:ListItem>Z-A</asp:ListItem>
                </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Sort" Visible="False" Width="93px" />
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Filter by:" Visible="False"></asp:Label>
                <br />
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" style="margin-left: 0px" Visible="False" Width="160px">
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Surname</asp:ListItem>
                    <asp:ListItem>Pesel</asp:ListItem>
                    <asp:ListItem>Sex</asp:ListItem>
                    <asp:ListItem>Date of birth</asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="223px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Filter" Width="93px" Visible="False" />
                <br />
                <br />
                
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False" SelectedDate="03/30/2022 19:44:03"></asp:Calendar>             
               
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" Visible="False"></asp:GridView>
                <br />
                <br />
                <br />
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
                <br />
            </center>

        </div>
</asp:Content>