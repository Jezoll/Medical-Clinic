<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmployeeManagement.aspx.cs" Inherits="medicalclinic.EmployeeManagement" %>

<asp:Content ID="EmployeeManagementContent" ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:BoundField DataField="Date_of_birth" HeaderText="Date of birth" SortExpression="Date_of_birth"/>
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
        <div>
            <asp:Label ID="LabelName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <asp:RadioButton ID="RadioButtonName" runat="server" Text="Filter By Name" GroupName="FilterEmployeesGroup"/>
        </div>
        <div>
            <asp:Label ID="LabelSurname" runat="server" Text="Surname"></asp:Label>
            <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
            <asp:RadioButton ID="RadioButtonSurname" runat="server" Text="Filter By Surname" GroupName="FilterEmployeesGroup"/>
        </div>
        <div>
            <asp:Label ID="LabelRole" runat="server" Text="Role In The System"></asp:Label>
            <asp:DropDownList ID="DropDownListRoles" runat="server"></asp:DropDownList>
            <asp:RadioButton ID="RadioButtonUserRole" runat="server" Text="Filter By Role In The System" GroupName="FilterEmployeesGroup"/>
        </div>
            <asp:Button ID="ButtonFilter" runat="server" OnClick="ButtonFilter_Click" Text="Filter" Width="122px" />
</asp:Content>
