<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditOfficeData.aspx.cs" Inherits="medicalclinic.EditOfficeData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LabelID" runat="server" Text="Office ID"></asp:Label>
    <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="LabelNumberOfOffice" runat="server" Text="Number Of Office"></asp:Label>
    <asp:TextBox ID="TextBoxNumberOfOffice" runat="server" AutoPostBack="true"></asp:TextBox>
    <br />
    <asp:Label ID="LabelAvailibility" runat="server" Text="Availibility"></asp:Label>
    <asp:CheckBox ID="CheckBoxAvailibility" runat="server" />
    <br />
    <asp:Label ID="LabelSpecialization" runat="server" Text="Office Specialization"></asp:Label>
    <asp:DropDownList ID="DropDownListSpecializations" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="LabelRole" runat="server" Text="Office Role"></asp:Label>
    <asp:DropDownList ID="DropDownListRoles" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Button ID="ButtonEdit" runat="server" Text="Edit Data" OnClick="ButtonEdit_Click" />
    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
    <br />
</asp:Content>
