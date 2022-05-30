<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppointmentManagement.aspx.cs" Inherits="medicalclinic.AppointmentManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        
        <div>                
            <center>
                <asp:Calendar ID="Calendar_appointments" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellPadding="1" CellSpacing="5" Font-Names="MS UI Gothic" Font-Size="Large" ForeColor="Black" Height="900px" Width="1200px" OnDayRender="Calendar_appointments_DayRender" OnSelectionChanged="Calendar_appointments_SelectionChanged">
                    <DayHeaderStyle BorderStyle="Inset" Font-Bold="True" Font-Size="12pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="AliceBlue" BorderColor="White" BorderStyle="Solid" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                    <NextPrevStyle Font-Bold="True" Font-Size="12pt" Font-Strikeout="False" ForeColor="White" HorizontalAlign="Left"/>  
                    <OtherMonthDayStyle BackColor="#F2F2F2" ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#C7E8F8" BorderStyle="Double" ForeColor="White" />
                    <SelectorStyle BorderColor="Black" BorderStyle="Dotted" />
                    <TitleStyle BackColor="#99BADD" BorderColor="#99BADD" BorderStyle="Double" Font-Bold="True" Font-Size="18pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#91E3FF" ForeColor="White" />
                    <WeekendDayStyle Font-Bold="True" Font-Italic="False" />
                </asp:Calendar>
                <div>
                    <asp:Label ID="Label_Doctor" runat="server" Text="Doctor: "></asp:Label>
                    <asp:DropDownList ID="DropDownList_doctor" runat="server">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="Label_Patient" runat="server" Text="Patient: "></asp:Label>
                    <asp:DropDownList ID="DropDownList_patient" runat="server">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="Label_Office" runat="server" Text="Office: "></asp:Label>
                    <asp:DropDownList ID="DropDownList_office" runat="server">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label ID="Label_Status" runat="server" Text="Status: "></asp:Label>
                    <asp:DropDownList ID="DropDownList_status" runat="server">
                    </asp:DropDownList>
                </div>
                <asp:Label ID="LabelTest" runat="server" Text="Wartość DDL: "></asp:Label>
                <asp:Button ID="ButtonFilter" runat="server" Text="Filter" OnClick="ButtonFilter_Click" />
                
                
                
            </center>
        </div>

</asp:Content>
