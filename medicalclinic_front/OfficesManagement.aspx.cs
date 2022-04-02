using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class OfficesManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                officesGridViewRefresh();
                ButtonInsertOffice.Enabled = false;
                ComboBoxSpecializationFill();
                ComboBoxOfficeRolesFill();
            }
        }

        private void officesGridViewRefresh()
        {
            List<Office> offices = Office.GetAllOffices();
            OfficesGridView.DataSource = offices;
            OfficesGridView.DataBind();
        }

        protected void TextBoxNumberOfOffice_TextChanged(object sender, EventArgs e)
        {
            foreach(char ch in TextBoxNumberOfOffice.Text)
            {
                if (!char.IsDigit(ch))
                {
                    TextBoxNumberOfOffice.Text = "";
                }
            }
            valuesPicked();
        }

        protected void DropDownListSpecializations_SelectedIndexChanged(object sender, EventArgs e)
        {
            valuesPicked();
        }

        protected void DropDownListOfficeRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            valuesPicked();
        }

        private void valuesPicked()
        {
            if (TextBoxNumberOfOffice.Text =="" || DropDownListSpecializations.SelectedValue == null || DropDownListOfficeRole.SelectedValue == null)
            {
                ButtonInsertOffice.Enabled = false;
                return;
            }
            ButtonInsertOffice.Enabled = true;
            
        }

        private void ComboBoxSpecializationFill()
        {
            List<OfficeSpecialization> specializations = OfficeSpecialization.GetAllSpecializations();
            DropDownListSpecializations.Items.Clear();
            foreach(OfficeSpecialization spec in specializations)
            {
                DropDownListSpecializations.Items.Add(spec.Name);
            }
        }
        private void ComboBoxOfficeRolesFill()
        {
            List<OfficeUsedFor> roles = OfficeUsedFor.GetAllTypes();
            DropDownListOfficeRole.Items.Clear();
            foreach (OfficeUsedFor role in roles)
            {
                DropDownListOfficeRole.Items.Add(role.Name);
            }
        }

        protected void ButtonInsertOffice_Click(object sender, EventArgs e)
        {
            Office.InsertNewOffice(TextBoxNumberOfOffice.Text, DropDownListSpecializations.SelectedValue, DropDownListOfficeRole.SelectedValue);
            officesGridViewRefresh();
        }

        protected void OfficeEditButton_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("EditOfficeData.aspx?id =" + lnk.CommandArgument);
        }
    }
}