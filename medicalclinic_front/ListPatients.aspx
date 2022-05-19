<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPatients.aspx.cs" Inherits="medicalclinic.ListPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div style="height: 92.4vh; width: 80vw; margin-left: 5vw; border: 5px solid #507CD1; border-top-color: white; border-bottom-color: white">
    <div style="margin-left: 5vw; margin-top: 5vh">
        <asp:Label CssClass="Label" ID="LabelMessage" runat="server" Text="Patients Management" Font-Size="30px"></asp:Label>
        <br />
        <asp:Panel runat="server" Height="300px" Width="92%"  ScrollBars="Vertical">
            <asp:GridView
                ID="PatientsGridView"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                AllowSorting="True"
                HeaderStyle ="position:absolute; font-weight: bold"
                OnSorting="PatientsGridView_Sorting" Width="856px" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="PatientsGridView_SelectedIndexChanged">
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
    
    <div style="margin-left: 5vw; width: 875.5px; height: 190px">
        <div style="border: solid; border-color: #EDF1F9; width: 535px; float: left; height: 100%">
            <asp:Label CssClass="Label" ID="LabelFilterMethod" runat="server" Text="Filter values: "></asp:Label>
            <br />
            <div>
                <asp:TextBox ID="TextBoxName" runat="server" Width="290px" placeholder ="Patient's name"></asp:TextBox>
                <asp:CheckBox ID="CheckBox_name" runat="server" Text="Filter by name"/>
            </div>
            <div>
                <asp:TextBox ID="TextBoxSurname" runat="server" Width="290px" placeholder ="Patient's surname"></asp:TextBox>
                <asp:CheckBox ID="CheckBox_surname" runat="server" Text="Filter by surname"/>
            </div>
            <div>
                <asp:TextBox ID="TextBoxPesel" runat="server" Width="290px" placeholder ="Patient's Pesel"></asp:TextBox>
                <asp:CheckBox ID="CheckBox_pesel" runat="server" Text="Filter by Pesel number"/>
            </div>
            <div>
                <asp:TextBox ID="TextBoxLastAppointmentDate" runat="server" Width="290px" placeholder ="Patient's last appointment date" MaxLength="10" TextMode="Date"></asp:TextBox>
                <asp:CheckBox ID="CheckBox_last_appointment_date" runat="server" Text="Filter by last appointment date"/>
            </div>
            <asp:Button CssClass="Button" ID="ButtonFilter" runat="server" OnClick="ButtonFilter_Click" Text="Filter"/>
            <asp:Button CssClass="Button" ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset"/>
        </div>


        <div style="border: solid; border-color: #EDF1F9; width: 340.5px; float: right; height: 100%">
            <asp:Label CssClass="Label" ID="Label1" runat="server" Text="Other options: "></asp:Label>
            <br />
            <div style="width: 37%; margin-left: 31.5%; margin-top: 15%">
                <asp:Button CssClass="Button" ID="ButtonAddNewPatient" runat="server" OnClick="ButtonAddNewPatient_Click"  Text="Add a patient"/>
                <br />
                <asp:Button CssClass="Button" ID="ButtonBack" runat="server" OnClick="ButtonClose_Click" Text="Close"/>
            </div>
        </div>
    </div>
</div>
    <style type="text/css">  
        .Button
        {
            background-color: #507CD1;
            border: 2px solid;
            border-color: #507CD1;
            border-radius: 3px;
            width: 122px;
            height: 25px;
            font-size: 15px;
            color: white;
            font-weight: bold;
            margin: 2px;
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
            font-size: 20px;
            width: 100%;
            float: right;
            margin: 5px;
        }
        
        
    </style> 
</asp:Content>