<%@ Page Title="" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagment.aspx.cs" Inherits="medicalclinic.UserManagment" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="wrapper">

        <a href="./CreateNewUser.aspx" class="btn-new-user">Dodaj użytkownika</a>

        <div class="filters-box">
            <input type="text" value="" id="search-input" placeholder="Znajdź użytkownika" />
            <fieldset>
                <input type="checkbox" id="cb-firstname" class="check-box" checked />
                <label for="cb-firstname">Po imieniu</label>
                <input type="checkbox" id="cb-secondname" class="check-box" />
                <label for="cb-secondname">Po nazwisku</label>
            </fieldset>
        </div>

        <asp:GridView ID="UserTable" CssClass="user-managment-table" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField ="id" HeaderText ="ID" />
                <asp:BoundField DataField ="login" HeaderText ="Login" />
                <asp:BoundField DataField ="first_name" HeaderText ="Imię" />
                <asp:BoundField DataField ="second_name" HeaderText ="Nazwisko" />
                <asp:BoundField DataField ="email" HeaderText ="E-mail" />                   
            </Columns>
        </asp:GridView>
    </div>

    <script src="./Scripts/TableSort.js"></script>
</asp:Content>
