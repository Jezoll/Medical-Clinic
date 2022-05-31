<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceptionAppointmentDetails.aspx.cs" Inherits="medicalclinic.ReceptionAppointmentDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <script>     
        function CancelAlertFunction()
        {
            if (confirm('Are you sure you want to cancel this appointment?'))
            {
                $('#ConfirmMessageResponseDelete').val('Yes');
            }
            else
            {
                $('#ConfirmMessageResponseDelete').val('No');
            }
        }
        function ResheduleAlertFunction() {
            if (confirm('Are you sure you want to edit data of this appointment?')) {
                $('#ConfirmMessageResponseModify').val('Yes');
            }
            else {
                $('#ConfirmMessageResponseModify').val('No');
            }
        }
    </script>


    <div style=""height: 500px">
        <asp:Label ID="Label_appointment" runat="server" Text="Appoitment details:" Font-Names="Arial" Font-Size="18pt"></asp:Label>
     <div>
        <asp:Label ID="Label_id" runat="server" Text="ID: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
         <asp:Label ID="Label_id_value" runat="server" Text="Label"></asp:Label>
         </div>
    <div>
        <asp:Label ID="Label_date" runat="server" Text="Date: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_date_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_time" runat="server" Text="Time: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_time_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_duration" runat="server" Text="Duration: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_duration_value" runat="server" Text="Label"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label_status" runat="server" Text="Status: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_status_value" runat="server" Text="Label"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label_description" runat="server" Text="Description: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_description_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_doctor" runat="server" Text="Doctor ID: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_doctor_value" runat="server" Text="Label"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label_patient" runat="server" Text="Patient ID: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_patient_value" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <asp:Label ID="Label_office" runat="server" Text="Office_ID: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_office_value" runat="server" Text="Label"></asp:Label>
    </div>
     <div>
        <asp:Label ID="Label_payment" runat="server" Text="Payment: " Font-Names="Arial" Font-Size="12pt" width="110pt"></asp:Label>
        <asp:Label ID="Label_payment_value" runat="server" Text="Label"></asp:Label>
    </div>
    </div>
    <div>
        <asp:Label ID="Label_reshedule" runat="server" Text="Reshedule appointment:" Font-Names="Arial" Font-Size="18pt"></asp:Label>
    <div>
        <asp:Label ID="Label_ndate" runat="server" Text="New date of appoitment: " Font-Names="Arial" Font-Size="12pt" width="200pt"></asp:Label>
        <asp:TextBox ID="TextBox_ndate" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
    </div>
     <div>
        <asp:Label ID="Label_ntime" runat="server" Text="New time of appoitment: " Font-Names="Arial" Font-Size="12pt" width="200pt"></asp:Label>
        <asp:TextBox ID="TextBox_ntime_value" runat="server" MaxLength="10" TextMode="Time"></asp:TextBox>
    </div>
    </div>
     <div>
        <asp:Button ID="Button_cancel" runat="server" OnClick="Button_Cancel_Click" OnClientClick ="return CancelAlertFunction()" Text="Cancel" />
        <asp:HiddenField ID="ConfirmMessageResponseDelete" runat="server" ClientIDMode="Static" />
    </div>
    <div>
        <asp:Button ID="Button_reshedule" runat="server" OnClientClick ="return ResheduleAlertFunction()" Text="Reshedule" OnClick="Button_Reshedule_Click" />
        <asp:HiddenField ID="ConfirmMessageResponseModify" runat="server" ClientIDMode="Static" />
    </div>
    <div>
       <asp:Button CssClass="Button" ID="Button_close" runat="server" OnClick="Button_close_Click" Text="Close" />
    </div>
</asp:Content>
