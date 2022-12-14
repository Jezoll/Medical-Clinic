<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesManagement.aspx.cs" Inherits="medicalclinic.OfficesManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table-container">
        <div class="table-content">
            <asp:GridView
                ID="OfficesGridView"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                CssClass="table table-hover table-condensed">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="Number_of_office" HeaderText="Number of office" />
                    <asp:CheckBoxField DataField="Avalibility" HeaderText="Is available" />
                    <asp:BoundField DataField="Office_specialization.Name" HeaderText="Specialization" />
                    <asp:BoundField DataField="Office_role.Name" HeaderText="Office role" />
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
                                CancelControlID="ButtonCancel" BackgroundCssClass="popout-background">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ID="Panel1" runat="server" CssClass="popup" align="center" Style="display: none">
                                <iframe style="width: 200px; height: 200px;" id="irm1" src="PopupConfirmOfficeDeletion.aspx" runat="server"></iframe>
                                <br />
                                <asp:Button CssClass="btn btn-default" ID="ButtonCancel" runat="server" Text="Cancel" />
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="office-add-container">
            <div class="office-add__element">
                <asp:Label ID="LabelNumberOfOffice" runat="server" Text="Number Of Office"></asp:Label>
                <asp:TextBox runat="server" ID="TextBoxNumberOfOffice" AutoPostBack="True" OnTextChanged="TextBoxNumberOfOffice_TextChanged" MaxLength="10" />
            </div>
            <div class="office-add__element">
                <asp:Label ID="LabelSpecialization" runat="server" Text="Office Specialization"></asp:Label>
                <asp:DropDownList ID="DropDownListSpecializations" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSpecializations_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="office-add__element">
                <asp:Label ID="LabelRole" runat="server" Text="Role Of Office"></asp:Label>
                <asp:DropDownList ID="DropDownListOfficeRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListOfficeRole_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <asp:Button ID="ButtonInsertOffice" runat="server" Text="Add New Office" CssClass="btn btn-default btn-filter-office" OnClick="ButtonInsertOffice_Click" />
        </div>
    </div>
</asp:Content>
