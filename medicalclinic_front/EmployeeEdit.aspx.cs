using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using medicalclinic_back;

namespace medicalclinic
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarTextBox.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                ComboboxRoleFill();
                ComboboxSpecializationFill();

                int id = int.Parse(Request.QueryString[0]);
                List<Employee> employees = Employee.getAllEmployees();

                foreach (Employee emp in employees)
                {
                    if (id != emp.Id)
                    {
                        continue;
                    }

                    TextBoxID.Text = emp.Id.ToString();
                    TextBoxName.Text = emp.First_name;
                    TextBoxSurname.Text = emp.Second_name;
                    TextBoxPESEL.Text = emp.Pesel;
                    CalendarBirthDate.SelectedDate = emp.Date_of_birth;
                    int i = 0;
                    foreach (var item in DropDownListRole.Items)
                    {
                        if (item.ToString() == emp.User_role.Name)
                        {
                            DropDownListRole.SelectedIndex = i;
                        }
                        i++;
                    }
                    if (emp.User_role.Name == "Lekarz")
                    {
                        DropDownListSpecialization.Visible = true;
                        SpecializationLabel.Visible = true;

                        i = 0;
                        foreach (var item in DropDownListSpecialization.Items)
                        {
                            if (item.ToString() == emp.Medical_specialization.Name)
                            {
                                DropDownListSpecialization.SelectedIndex = i;
                            }
                            i++;
                        }
                    }
                    TextBoxCountry.Text = emp.Address.Country;
                    TextBoxState.Text = emp.Address.State;
                    TextBoxCity.Text = emp.Address.City;
                    TextBoxPostalCode.Text = emp.Address.Postal_code;
                    TextBoxStreet.Text = emp.Address.Street;
                    TextBoxHouseNumber.Text = emp.Address.Number;
                    TextBoxEmail.Text = emp.Email;
                    TextBoxPhoneNumber.Text = emp.Phone_number;

                    if (emp.Sex == SexEnum.F)
                    {
                        DropDownListSex.SelectedIndex = 0;
                    }
                    else
                    {
                        DropDownListSex.SelectedIndex = 1;
                    }

                    if (emp.Is_active)
                    {
                        CheckBoxIsActive.Checked = true;
                    }
                    else
                    {
                        CheckBoxIsActive.Checked = false;
                    }

                    break;
                }
            }
            
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeManagement.aspx");
        }


        private void ComboboxRoleFill()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRole.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownListRole.Items.Add(role.Name);
            }
        }

        private void ComboboxSpecializationFill()
        {
            List<MedicalSpecialization> data = MedicalSpecialization.getAllMedicalSpecialization();
            DropDownListSpecialization.Items.Clear();
            foreach (MedicalSpecialization spec in data)
            {
                DropDownListSpecialization.Items.Add(spec.Name);
            }
        }

        protected void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        private void IsEmpty()
        {
            if (TextBoxName.Text == "" || TextBoxSurname.Text == "" || TextBoxPESEL.Text == "")
            {
                ButtonConfirm.Enabled = false;
                return;
            }

            ButtonConfirm.Enabled = true;
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (!Employee.validatePesel(TextBoxPESEL.Text, (DateTime)CalendarBirthDate.SelectedDate, DropDownListSex.SelectedValue))
            {
                AlertBox("incorrect pesel number");
                return;
            }

            if (!Employee.validatePeselUnique(TextBoxPESEL.Text))
            {
                AlertBox("This pesel is already in the database");
                return;
            }

            if (!AdressCheck())
            {
                AlertBox("To add an address, all address fields must be completed");
                return;
            }

            if (TextBoxEmail.Text.Length > 0)
            {
                if (!Employee.validateEmail(TextBoxEmail.Text))
                {
                    AlertBox("incorrect e-mail adress");
                    return;
                }
            }

            if (TextBoxPhoneNumber.Text != "" && TextBoxPhoneNumber.Text.Length != 9)
            {
                AlertBox("incorrect phone number");
                return;
            }



            string address_id = Address.insertNewAddress(TextBoxCountry.Text, TextBoxState.Text, TextBoxCity.Text, TextBoxPostalCode.Text, TextBoxStreet.Text, TextBoxHouseNumber.Text);

            string sexLongName = DropDownListSex.SelectedValue.ToString();
            string sex = "m";

            if (sexLongName == "Female")
            {
                sex = "k";
            }

            //TODO zrobić update
        }

        protected void TextBoxSurname_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void TextBoxPESEL_TextChanged(object sender, EventArgs e)
        {
            IsEmpty();
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListRole.SelectedValue != "Lekarz")
            {
                SpecializationLabel.Visible = false;
                DropDownListSpecialization.Visible = false;
                return;
            }

            SpecializationLabel.Visible = true;
            DropDownListSpecialization.Visible = true;
        }

        private void AlertBox(string AlertMessage)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + AlertMessage + "');", true);
        }

        private bool AdressCheck()
        {
            int notemptytextboxes = 0;
            int textboxescount = 0;
            TextBox currenttextbox;
            foreach (Control tbox in AddressPanel.Controls)
            {

                if (tbox is TextBox)
                {
                    textboxescount++;
                    currenttextbox = (TextBox)tbox;
                }
                else
                {
                    continue;
                }

                if (currenttextbox.Text.Length > 0)
                {
                    notemptytextboxes++;
                }
            }

            if (notemptytextboxes > 0 && notemptytextboxes < textboxescount)
            {
                return false;
            }

            return true;
        }
    }
}