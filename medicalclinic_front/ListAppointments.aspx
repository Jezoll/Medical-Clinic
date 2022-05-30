<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAppointments.aspx.cs" Inherits="medicalclinic.ListAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewAppointments" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true"/>
            <asp:BoundField DataField="Employee" HeaderText="Doctor"/>
            <asp:BoundField DataField="Office_number" HeaderText="Office"/>
            <asp:BoundField DataField="Date_of_appointment" HeaderText="Appointment Date" DataFormatString="{0:yyyy/MM/dd}"/>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label: "></asp:Label>
</asp:Content>
