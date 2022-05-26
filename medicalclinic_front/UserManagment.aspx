<%@ Page Title="" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManagment.aspx.cs" Inherits="medicalclinic.UserManagment" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="UserTable" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField ="id" HeaderText ="ID" />
            <asp:BoundField DataField ="login" HeaderText ="Login" />
            <asp:BoundField DataField ="first_name" HeaderText ="Imię" />
            <asp:BoundField DataField ="second_name" HeaderText ="Nazwisko" />
            <asp:BoundField DataField ="email" HeaderText ="E-mail" />                   
        </Columns>
    </asp:GridView>

    <fieldset>
        <legend>Filtry</legend>

        <input type="text" value="" id="search-input" />

        <input type="checkbox" id="cb-firstname" class="check-box" checked />
        <label for="cb-firstname">Po imieniu</label>

        <input type="checkbox" id="cb-secondname" class="check-box" />
        <label for="cb-secondname">Po nazwisku</label>

    </fieldset>

    <asp:Button ID="Button1" runat="server" Text="Nowy użytkownik" OnClick="Button1_Click" OnClientClick="target ='_blank';"/>

    <script src="./Scripts/TableSort.js"></script>
</asp:Content>
