<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reception.aspx.cs" Inherits="medicalclinic.Reception" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div>
            <asp:Button ID="Button_patients" runat="server" Text="Patients Management" OnClick="Button_patients_Click" />
            <asp:Button ID="Button_appointments" runat="server" Text="Appointments Management" OnClick="Button_appointments_Click" />
        </div>
    </center>
</asp:Content>
