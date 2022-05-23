<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPatients.aspx.cs" Inherits="medicalclinic.ListPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div style="height: 92.4vh; width: 80vw; margin-left: 5vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
    <div style="margin-left: 5vw; margin-top: 5vh">
        <asp:Label CssClass="Title" ID="LabelMessage" runat="server" Text="Patients Management"></asp:Label>
        <br />
        <asp:Panel runat="server" Height="300px" Width="92%"  ScrollBars="Vertical">
            <asp:GridView
                CssClass="GridView"
                ID="PatientsGridView"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                AllowSorting="True"
                HeaderStyle ="position:absolute; font-weight: bold;"
                OnSorting="PatientsGridView_Sorting" Width="100%" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PatientsGridView_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true" SortExpression="Id" />
                    <asp:BoundField DataField="First_name" HeaderText="First Name" SortExpression="First_name" />
                    <asp:BoundField DataField="Second_name" HeaderText="Surname" SortExpression="Second_name"/>
                    <asp:BoundField DataField="Pesel" HeaderText="Pesel" SortExpression="Pesel"/>
                    <asp:BoundField DataField="Date_of_last_appointment" HeaderText="Last Appointment Date" DataFormatString="{0:yyyy/MM/dd}"/>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
         </asp:Panel>
    </div>
    
    <div style="margin-left: 5vw; width: 86.2%; display: flex">
        <div style="border: solid; border-color: #EDF1F9; width: 61.5%; float: left; height: 100%">
            <asp:Label CssClass="Label" ID="LabelFilterMethod" runat="server" Text="Filter values"></asp:Label>
            <br />
            <div>
                <asp:TextBox CssClass="TextBox" ID="TextBoxName" runat="server" placeholder ="Patient's name"></asp:TextBox>
                <asp:CheckBox CssClass="CheckBox" ID="CheckBox_name" runat="server" Text="Filter by name"/>
            </div>
            <div>
                <asp:TextBox CssClass="TextBox" ID="TextBoxSurname" runat="server" placeholder ="Patient's surname"></asp:TextBox>
                <asp:CheckBox CssClass="CheckBox" ID="CheckBox_surname" runat="server" Text="Filter by surname"/>
            </div>
            <div>
                <asp:TextBox CssClass="TextBox" ID="TextBoxPesel" runat="server" placeholder ="Patient's Pesel"></asp:TextBox>
                <asp:CheckBox CssClass="CheckBox" ID="CheckBox_pesel" runat="server" Text="Filter by Pesel number"/>
            </div>
            <div>
                <asp:TextBox CssClass="TextBox" ID="TextBoxLastAppointmentDate" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
                <asp:CheckBox CssClass="CheckBox" ID="CheckBox_last_appointment_date" runat="server" Text="Filter by last appointment"/>
            </div>
            <div style="margin-left: 20%">
                <asp:Button CssClass="Button" ID="ButtonFilter" runat="server" OnClick="ButtonFilter_Click" Text="Filter"/>
                <asp:Button CssClass="Button" ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset"/>
            </div>
            
        </div>


        <div style="border: solid; border-color: #EDF1F9; width: 20%; float: left; flex: 1">
            <asp:Label CssClass="Label" ID="Label1" runat="server" Text="Other options"></asp:Label>
            <br />
            <div style="width: 37%; margin-left: 25%; margin-top: 15%">
                <div style="margin-top: 5%">
                    <asp:Button CssClass="Button" ID="ButtonAddNewPatient" runat="server" OnClick="ButtonAddNewPatient_Click"  Text="Add a patient"/>
                </div>
                <div style="margin-top: 5%">
                    <asp:Button CssClass="Button" ID="ButtonBack" runat="server" OnClick="ButtonClose_Click" Text="Close"/>
                </div>           
            </div>
        </div>
    </div>
</div>
    <style type="text/css">
        .Title
        {
            text-align: center;
            font-weight: bold;
            font-size: 3vw;
            color: #507CD1;
            width: 100%;
            float: right;
            margin: 5px;
        }
        .GridView
        {
            font-size: 1.25vw;
        }
        .Button
        {
            background-color: #507CD1;
            border: 2px solid;
            border-color: #507CD1;
            border-radius: 3px;
            width: 12vw; 
            font-size: 1.35vw;
            color: white;
            font-weight: bold;
            margin: 0.2vmin;
        }
        .Button:hover
        {
            background-color: white;
            color: #507CD1;
        }
        .Label
        {
            text-align: center;
            color: #507CD1;
            font-weight: bold;
            font-size: 1.8vw;
            width: 100%;
            float: right;
            margin: 5px;
        }
        .TextBox
        {
            width: 50%;
            font-size: 1.35vw;
            margin-top: 0.5vh;
            height: 2.8vh;
            
        }
        .CheckBox
        {
            font-weight: lighter;
            font-size: 1.35vw;
            font-weight: lighter;
        }
        input[type=checkbox]
        {
            width: 1.5vmin;
            height: 1.5vmin;
        }
        input[type=checkbox]:checked
        {
            width: 1.5vmin;
            height: 1.5vmin;
        }
        
        
    </style> 
</asp:Content>