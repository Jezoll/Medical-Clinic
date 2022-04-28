<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientDetails.aspx.cs" Inherits="medicalclinic.PatientDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <script>     
        function DeleteAlertFunction()
        {
            if (confirm('Are you sure you want to remove this patient from the database?'))
            {
                $('#ConfirmMessageResponseDelete').val('Yes');
            }
            else
            {
                $('#ConfirmMessageResponseDelete').val('No');
            }
        }
        function ModifyAlertFunction() {
            if (confirm('Are you sure you want to modify data of this patient?')) {
                $('#ConfirmMessageResponseModify').val('Yes');
            }
            else {
                $('#ConfirmMessageResponseModify').val('No');
            }
        }
    </script>


     <div style=" float: right">
        <asp:Label ID="Label_appointments" runat="server" Text="Patient appointments:" Font-Names="Arial" Font-Size="18pt"></asp:Label>
        <asp:GridView ID="GridViewAppointments" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" HeaderStyle ="position:absolute" width ="600px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="false" ReadOnly="true" />
                <asp:BoundField DataField="Duration" HeaderText="Duration"/>
                <asp:BoundField DataField="Type" HeaderText="Type"/>
                <asp:BoundField DataField="Employee" HeaderText="Employee"/>
                <asp:BoundField DataField="Office_number" HeaderText="Office number" />
                <asp:BoundField DataField="Date_of_appointment" HeaderText="Appointment date" DataFormatString="{0:yyyy/MM/dd}"/>
            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    <div style=""height: 500px">
        <asp:Label ID="Label_paient" runat="server" Text="Patient details:" Font-Names="Arial" Font-Size="18pt"></asp:Label>
    <div>
        <asp:Label ID="Label_id" runat="server" Text="ID: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_id_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_first_name" runat="server" Text="First name: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_first_name_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_surname" runat="server" Text="Second name: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_surname_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_sex" runat="server" Text="Sex:" Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_sex_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_date_of_birth" runat="server" Text="Date of birth: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_date_of_birth_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_pesel" runat="server" Text="Pesel: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_pesel_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
         <asp:Label ID="Label_phone_number" runat="server" Text="Phone number: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_phone_number_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_email" runat="server" Text="Email: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_email_value" runat="server" Text="Label"></asp:Label>
        
    </div>
        <div>
        <asp:Label ID="Label_activity" runat="server" Text="Status: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_activity_value" runat="server" Text="Not Active"></asp:Label>
        
    </div>
    </div>

    <div >
        <asp:Label ID="Label_modify" runat="server" Text="Modify patient:" Font-Names="Arial" Font-Size="18pt"></asp:Label>

    <div>
        <asp:Label ID="Label3" runat="server" Text="New first name: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:TextBox ID="TextBox_first_name" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="New second name: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:TextBox ID="TextBox_surname" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label7" runat="server" Text="New sex:" Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:RadioButton ID="RadioButton_sex_male" Text="Male" GroupName="sex" runat="server" />
        <asp:RadioButton ID="RadioButton_sex_female" Text="Female" GroupName="sex" runat="server"/>
    </div>
    <div>
        <asp:Label ID="Label9" runat="server" Text="New date of birth: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:TextBox ID="TextBox_date_of_birth" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label11" runat="server" Text="New Pesel: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:TextBox ID="TextBox_pesel" runat="server" MaxLength="11"></asp:TextBox>
    </div>
    <div>
         <asp:Label ID="Label13" runat="server" Text="New phone number: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
         <asp:TextBox ID="TextBox_phone_number" runat="server" MaxLength="9"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label15" runat="server" Text="New email: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:TextBox ID="TextBox_email" runat="server"></asp:TextBox>
        
    </div>
    </div>
    <div>
        <asp:Button ID="Button_delete" runat="server" OnClick="Button_Delete_Click" OnClientClick ="return DeleteAlertFunction()" Text="Delete" />
        <asp:HiddenField ID="ConfirmMessageResponseDelete" runat="server" ClientIDMode="Static" />
    </div>
    <div>
        <asp:Button ID="Button_modify" runat="server" OnClientClick ="return ModifyAlertFunction()" Text="Modify" OnClick="Button_Modify_Click" />
        <asp:HiddenField ID="ConfirmMessageResponseModify" runat="server" ClientIDMode="Static" />
    </div>
    <asp:Button ID="Button_activity" runat="server" Text="Activate Patient" OnClick="Button_activity_Click" />
    <asp:Button ID="Button_close" runat="server" OnClick="Button_close_Click" Text="Close" />
    </asp:Content>