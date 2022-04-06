﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeEdit.aspx.cs" Inherits="medicalclinic.WebForm5" %>


<asp:Content ID="AddEmployee" ContentPlaceHolderID="MainContent" runat="server">
    <div class="employee-show">
        <asp:Label ID="IdLabel" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="TextBoxID" placeholder="ID" runat="server" Enabled="False"></asp:TextBox>
        <asp:HiddenField ID="HideFieldIDAddress" runat="server"></asp:HiddenField>
        <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBoxName" placeholder="Name*" runat="server" AutoPostBack="True" OnTextChanged="TextBoxName_TextChanged"></asp:TextBox>
        <asp:Label ID="SurnameLabel" runat="server" Text="Surname"></asp:Label>
        <asp:TextBox ID="TextBoxSurname" placeholder="Surname*" runat="server" AutoPostBack="True" OnTextChanged="TextBoxSurname_TextChanged"></asp:TextBox>
        <asp:Label ID="PESELLabel" runat="server" Text="PESEL"></asp:Label>
        <asp:TextBox ID="TextBoxPESEL" placeholder="PESEL*" runat="server" MaxLength="11" AutoPostBack="True" OnTextChanged="TextBoxPESEL_TextChanged"></asp:TextBox>
        <asp:Label ID="DateOfBirthLabel" runat="server" Text="Date of birth"></asp:Label>
        <asp:TextBox ID="CalendarTextBox" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="CalendarBirthDate" PopupButtonID="imgPopup" runat="server" TargetControlID="CalendarTextBox" Format="yyyy-MM-dd"></ajaxToolkit:CalendarExtender>

        <asp:Label ID="RoleLabel" runat="server" Text="Role"></asp:Label>
        <asp:DropDownList ID="DropDownListRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListRole_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="SpecializationLabel" runat="server" Text="Specialization" Visible="False"></asp:Label>
        <asp:DropDownList ID="DropDownListSpecialization" runat="server" Visible="False">
        </asp:DropDownList>
        <asp:Panel ID="AddressPanel" runat="server" CssClass="employee-show__address">
            <asp:Label ID="CountryLabel" runat="server" Text="Country"></asp:Label>
            <asp:TextBox ID="TextBoxCountry" placeholder="Country" runat="server"></asp:TextBox>
            <asp:Label ID="StateLabel" runat="server" Text="State"></asp:Label>
            <asp:TextBox ID="TextBoxState" placeholder="State" runat="server"></asp:TextBox>
            <asp:Label ID="CityLabel" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBoxCity" placeholder="City" runat="server"></asp:TextBox>
            <asp:Label ID="PostalCodeLabel" runat="server" Text="Postal code"></asp:Label>
            <asp:TextBox ID="TextBoxPostalCode" placeholder="Postal Code" runat="server"></asp:TextBox>
            <asp:Label ID="StreetLabel" runat="server" Text="Street"></asp:Label>
            <asp:TextBox ID="TextBoxStreet" placeholder="Street" runat="server"></asp:TextBox>
            <asp:Label ID="HouseNumerLabel" runat="server" Text="House humber"></asp:Label>
            <asp:TextBox ID="TextBoxHouseNumber" placeholder="House Number" runat="server"></asp:TextBox>
        </asp:Panel>
        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TextBoxEmail" placeholder="Email" runat="server"></asp:TextBox>
        <asp:Label ID="PhoneNumberLabel" runat="server" Text="Phone number"></asp:Label>
        <asp:TextBox ID="TextBoxPhoneNumber" placeholder="Phone Number" runat="server" MaxLength="9"></asp:TextBox>
        <asp:Label ID="SexLabel" runat="server" Text="Sex"></asp:Label>
        <asp:DropDownList ID="DropDownListSex" runat="server">
            <asp:ListItem>Female</asp:ListItem>
            <asp:ListItem>Male</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="IsActiveStatusLabel" runat="server" Text="IsActive"></asp:Label>
        <asp:CheckBox ID="CheckBoxIsActive" runat="server" />

        <asp:Button ID="ButtonConfirm" CssClass="btn btn-default" runat="server" Text="Confirm" OnClick="ButtonConfirm_Click" />
        <asp:Button ID="ButtonCancel" CssClass="btn btn-default" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" />
    </div>
    </asp:Content>