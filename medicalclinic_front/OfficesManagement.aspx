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
                 <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="OfficeDeleteButton" runat="server" Text='Delete Office'
                        CommandArgument='<%# Eval("Id") %>'>
                        </asp:LinkButton>
                          <ajaxToolkit:ModalPopupExtender ID="PopupDeleteOffice" runat="server" PopupControlID="Panel1" TargetControlID="OfficeDeleteButton"  
    CancelControlID="ButtonCancel" BackgroundCssClass="Background">  
</ajaxToolkit:ModalPopupExtender>  
<asp:Panel ID="Panel1" runat="server" CssClass="Popup" align="center" style = "display:none">  
    <iframe style=" width: 200px; height: 200px;" id="irm1" src="PopupConfirmOfficeDeletion.aspx" runat="server"></iframe>  
   <br/>  
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" /> 

</asp:Panel>
                          <style type="text/css">  
        .Background  
        {  
            background-color: Black;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  
        }  
        .Popup  
        {  
            background-color: #FFFFFF;  
            border-width: 3px;  
            border-style: solid;  
            border-color: black;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 300px;  
            height: 250px;  
        }  
        .lbl  
        {  
            font-size:16px;  
            font-style:italic;  
            font-weight:bold;  
        }  
    </style>  
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
