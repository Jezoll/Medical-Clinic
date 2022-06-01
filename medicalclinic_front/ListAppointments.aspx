<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAppointments.aspx.cs" Inherits="medicalclinic.ListAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" Height="300px" Width="92%"  ScrollBars="Vertical">
            <asp:GridView
                ID="GridViewAppointments"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                AllowSorting="True"
                HeaderStyle ="position:absolute; font-weight: bold;"
                Width="100%" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewAppointments_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true"/>
                    <asp:BoundField DataField="Employee" HeaderText="Doctor"/>
                    <asp:BoundField DataField="Patient" HeaderText="Patient"/>
                    <asp:BoundField DataField="Office_number" HeaderText="Office number"/>
                    <asp:BoundField DataField="Date_of_appointment" HeaderText="Appointment Date" DataFormatString="{0:yyyy/MM/dd}"/>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:GridView>
         </asp:Panel>
    <asp:Button ID="Button_addnewappointment" runat="server" Text="Add new appointment" OnClick="Button_addnewappointment_Click" />
    <asp:Button ID="Button_close" runat="server" Text="Close" OnClick="Button_close_Click" />
</asp:Content>
