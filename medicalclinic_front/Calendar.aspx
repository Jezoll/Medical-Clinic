<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Calendar.aspx.cs" Inherits="medicalclinic.Calendar" %>

<asp:Content ID="Calendar" ContentPlaceHolderID="MainContent" runat="server">
        <div>                
            <center>
                <h1> CALENDAR</h1>
                <br />
                <asp:Button ID="Button_new_appointment" runat="server" BorderStyle="Solid" Text="New appointment" Visible="False" />
                &nbsp;&nbsp;<br />

              <div style="float:right;"> 
                  <asp:ImageButton ID="ImageButton_refresh" runat="server" Height="34px" ImageUrl="~/Content/img/Calendar_refresh_button.png" OnClick="ImageButton_refresh_Click" Width="34px" />
              </div>  




                <asp:Calendar ID="Calendar_main" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellPadding="1" CellSpacing="5" Font-Names="MS UI Gothic" Font-Size="Large" ForeColor="Black" Height="900px" NextPrevFormat="ShortMonth" OnDayRender="Calendar_main_DayRender" Width="1200px" OnSelectionChanged="Calendar_main_SelectionChanged">
                    <DayHeaderStyle BorderStyle="Inset" Font-Bold="True" Font-Size="12pt" ForeColor="#333333" Height="8pt" />
                    <DayStyle BackColor="AliceBlue" BorderColor="White" BorderStyle="Solid" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                    <NextPrevStyle Font-Bold="True" Font-Overline="False" Font-Size="12pt" Font-Strikeout="False" Font-Underline="True" ForeColor="White" HorizontalAlign="Left" />
                    <OtherMonthDayStyle BackColor="#F2F2F2" ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#C7E8F8" BorderStyle="Double" ForeColor="White" />
                    <SelectorStyle BorderColor="Black" BorderStyle="Dotted" />
                    <TitleStyle BackColor="#99BADD" BorderColor="#99BADD" BorderStyle="Double" Font-Bold="True" Font-Size="18pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#91E3FF" ForeColor="White" />
                    <WeekendDayStyle Font-Bold="True" Font-Italic="False" />
                </asp:Calendar>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <div style="float: right;">
                    <asp:Label ID="Label5" runat="server" BackColor="#4EB7E9" ForeColor="#4EB7E9" Text="[.] "></asp:Label>
                    &nbsp;<asp:Label ID="Label6" runat="server" Text="  - Actual date "></asp:Label>
                    <asp:Label ID="Label4" runat="server" BackColor="LightSteelBlue" BorderColor="LightSteelBlue" ForeColor="LightSteelBlue" Text="[.]  "></asp:Label>
                    &nbsp;<asp:Label ID="Label7" runat="server" Text="  - Appointment "></asp:Label>
                    <asp:Label ID="Label1" runat="server" BackColor="#98D7E4" BorderColor="#98D7E4" ForeColor="#98D7E4" Text="[.] "></asp:Label>
                    &nbsp;<asp:Label ID="Label2" runat="server" Text="  - Selected day "></asp:Label>
                    <br />
                     <br />
                     <asp:Button ID="Button_details" runat="server" BorderStyle="Solid" OnClick="Button_details_Click" SelectedDate="<%# DateTime.Today %>" Text="Show month details" />

                    <br />

                </div>

                <br />
                <br />
                <asp:Panel ID="Panel1" runat="server" Height="196px" Width="723px" >
                    <br />
                    <asp:GridView ID="GridView_raportMonthly" runat="server" Height="85px" Width="724px" BorderColor="Black" CellPadding="6" CellSpacing="6" HorizontalAlign="Center" style="text-align: right;" EnableSortingAndPagingCallbacks="True" AllowSorting="True">
                        <EmptyDataRowStyle Font-Underline="True" />


                        <FooterStyle BackColor="Black" />
                        <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" Font-Italic="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="5px" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:GridView>
                </asp:Panel>
                <br />
                <br />



            </center>

        </div>
                    <div style="float:left; text-align:left; margin:10px; padding: 15px; width: 216px;">
                <br/>
                        <h1> Search </h1>
<asp:Label ID="Label3" runat="server" Text="Label">Find by
</asp:Label>

                                    <br />
                        <asp:CheckBox ID="CheckBox_name" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_name_CheckedChanged" Text="Name" />
                        &nbsp;<asp:TextBox ID="TextBox_name_filter" runat="server" Enabled="False"></asp:TextBox>
                        <br />
                        <asp:CheckBox ID="CheckBox_surname" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_surname_CheckedChanged" Text="Surname" />
                        <asp:TextBox ID="TextBox_surname_filter" runat="server" Enabled="False"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button_filter" runat="server" Text="Find" Width="178px" OnClick="Button_filter_Click" />

                </div>
        <br />
        <br />
        <asp:GridView ID="GridView_Filter" runat="server" BorderColor="Black" CellPadding="6" CellSpacing="6" Height="85px"  style="text-align: right; margin-left: 0px;" Width="751px">
            <EmptyDataRowStyle Font-Underline="True" />
            <FooterStyle BackColor="Black" />
            <HeaderStyle BackColor="LightSteelBlue" Font-Bold="True" Font-Italic="False" HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" Wrap="True" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>

                </asp:Content>