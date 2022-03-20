<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeManagement.aspx.cs" Inherits="medicalclinic.EmployeeManagement" %>

<asp:Content ID="EmployeeManagementContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-container">
        <div class="table-content">
            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New Employee" />
        <asp:GridView
            ID="EmployeesGridView"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            AllowSorting="true"
            OnSorting="EmployeesGridView_Sorting"
            >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="First_name" HeaderText="First name" SortExpression="First_name" />
                <asp:BoundField DataField="Second_name" HeaderText="Last name" SortExpression="Second_name"/>
                <asp:BoundField DataField="Pesel" HeaderText="PESEL" SortExpression="Pesel"/>
                <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex"/>
                <asp:BoundField DataField="Phone_number" HeaderText="Phone number" SortExpression="Phone_number"/>
                <asp:BoundField DataField="Date_of_birth" DataFormatString="{0:d}" HeaderText="Date of birth" SortExpression="Date_of_birth"/>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"/>
                <asp:CheckBoxField DataField="Is_active" HeaderText="Is active employee" SortExpression="Is_active"/>
                <asp:BoundField DataField="User_department.Name" HeaderText="Department" SortExpression="User_department.Name"/>
                <asp:BoundField DataField="Medical_specialization.Name" HeaderText="Medical specialization" SortExpression="Medical_specialization.Name"/>
                <asp:BoundField DataField="User_role.Name" HeaderText="Role" SortExpression="User_role.Name"/>
                <asp:BoundField DataField="Address.Country" HeaderText="Country" SortExpression="Address.Country"/>
                <asp:BoundField DataField="Address.State" HeaderText="State" SortExpression="Address.State"/>
                <asp:BoundField DataField="Address.City" HeaderText="City" SortExpression="Address.City"/>
                <asp:BoundField DataField="Address.Postal_code" HeaderText="Postal code" SortExpression="Address.Postal_code"/>
                <asp:BoundField DataField="Address.Street" HeaderText="Street" SortExpression="Address.Street"/>
                <asp:BoundField DataField="Address.Number" HeaderText="Number" SortExpression="Address.Number"/>
            </Columns>
        </asp:GridView>
        </div>
        <div class="container">
            <div class="row align-items-start">
                <asp:Label ID="LabelRoles" runat="server" Text="Roles"></asp:Label>
                <asp:DropDownList ID="DropDownListRoles" runat="server"></asp:DropDownList>
                <asp:Button ID="ButtonFilterRoles" runat="server" OnClick="ButtonFilterRoles_Click" Text="Filter" class="btn btn-secondary"/>
            </div>
            <div class="row align-items-start">
                <asp:Label ID="LabelIsActive" runat="server" Text="Is active?"></asp:Label>
                <asp:CheckBox ID="CheckBoxIsActive" runat="server" />
                <asp:Button ID="ButtonFilterActive" runat="server" OnClick="ButtonFilterActive_Click" Text="Filter" class="btn btn-secondary" />
            </div>
            <div class="row align-items-start">
                <asp:Button ID="ButtonFilterClear" runat="server" OnClick="ButtonFilterClear_Click" Text="Clear filters" class="btn btn-secondary" />
            </div>
        </div>
</asp:Content>
