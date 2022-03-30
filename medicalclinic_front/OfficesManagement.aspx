<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesManagement.aspx.cs" Inherits="medicalclinic.OfficesManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <asp:GridView
            ID="OfficesGridView"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            CssClass="table table-hover table-condensed"
            >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True"/>
                <asp:BoundField DataField="Number_of_office" HeaderText="Number of office"/>
                <asp:CheckBoxField DataField="Avalibility" HeaderText="Is available"/>
                <asp:BoundField DataField="Office_specialization.Name" HeaderText="Specialization" />
                <asp:BoundField DataField="Office_role.Name" HeaderText="Office role"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="OfficeEditButton" OnClick="OfficeEditButton_Click" runat="server" Text='Edit data'
                        CommandArgument='<%# Eval("Id") %>'>
                        </asp:LinkButton>
                     </ItemTemplate>
                </asp:TemplateField>
                </Columns>
             </asp:GridView>
            <asp:Label ID="LabelNumberOfOffice" runat="server" Text="Number Of Office"></asp:Label>
            <br />
            <asp:TextBox runat="server" ID="TextBoxNumberOfOffice" AutoPostBack="True" OnTextChanged="TextBoxNumberOfOffice_TextChanged" MaxLength="10" />
             <br />
            <asp:Label ID="LabelSpecialization" runat="server" Text="Office Specialization"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownListSpecializations" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSpecializations_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelRole" runat="server" Text="Role Of Office"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownListOfficeRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListOfficeRole_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Button ID="ButtonInsertOffice" runat="server" Text="Add New Office" OnClick="ButtonInsertOffice_Click" />
            <br />

</asp:Content>
