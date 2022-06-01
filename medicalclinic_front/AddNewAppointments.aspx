<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewAppointments.aspx.cs" Inherits="medicalclinic.Formularz_internetowy1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <center>
         <div>
             
                <br />
                <asp:DropDownList ID="DropDownList_Patient" runat="server" width="500px"></asp:DropDownList>
                <br />
                <asp:TextBox ID="TextBox_Date" TextMode="Date" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox_Time" TextMode="Time" runat="server"></asp:TextBox>
                <br />
                <asp:DropDownList ID="DropDownList_Specialization" runat="server" width="500px" OnSelectedIndexChanged="DropDownList_Specialization_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:DropDownList ID="DropDownList_Doctor" runat="server" width="500px" OnSelectedIndexChanged="DropDownList_Doctor_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:DropDownList ID="DropDownList_Office" runat="server"></asp:DropDownList>
                <br />
                 <asp:TextBox ID="TextBox_Duration" TextMode="Number" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox_Payment" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox_Description" runat="server" Height="150px" Width="250px"></asp:TextBox>
                <br />
                <asp:Button ID="Button_AddNewAppointment" runat="server" Text="Button" width="250px" OnClick="Button_AddNewAppointment_Click"/>
                <br />
                <asp:Button ID="Button_Cancel" runat="server" Text="Button" width="250px"/>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                
          </div>
          <div>
              
          </div>
        </center>


</asp:Content>
