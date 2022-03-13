using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            employeesGridRefresh();
        }

        private void employeesGridRefresh(string sort_column = "employees.id", string sort_direction = "DESC")
        {
            List<Employee> employees = Employee.getAllEmployees(sort_column, sort_direction);
            fillDropDownListWithValues();
            EmployeesGridView.DataSource = employees;
            EmployeesGridView.DataBind();
        }

        private void fillDropDownListWithValues()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRoles.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownListRoles.Items.Add(role.Name);
            }
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            //if (RadioButtonName.Checked)
            //{
            //    string name = TextBoxName.Text;
            //    if (name == "")
            //    {
            //        LabelName.Text = "Enter name before pressing filter button!!";
            //    }
            //    else
            //    {
            //        employeesGridRefresh(Employee.listEmployees.Where(emp => emp.First_name == name).ToList());
            //        LabelName.Text = "Name";
            //        TextBoxName.Text = "";
            //    }
            //}
            //else if (RadioButtonSurname.Checked)
            //{
            //    string surname = TextBoxSurname.Text;
            //    if (surname == "")
            //    {
            //        LabelSurname.Text = "Enter surname before pressing filter button!!";
            //    }
            //    else
            //    {
            //        employeesGridRefresh(Employee.listEmployees.Where(emp => emp.Last_name == surname).ToList());
            //        LabelSurname.Text = "Surname";
            //        TextBoxSurname.Text = "";
            //    }
            //}
            //else if (RadioButtonUserRole.Checked)
            //{
            //    string role = DropDownListRoles.SelectedValue;
            //    //role = "recepcjonista";
            //    employeesGridRefresh(Employee.listEmployees.Where(emp => emp.User_role.Role == role).ToList());
            //    // nie wiem dlaczego nie działa selected value i nawet jeśli zmienimy role to cały czas zaznaczona jest ta domyślna
            //}
        }

        protected string GetSortDirection(string column)
        {
            string nextDir = "ASC";
            if (ViewState["sort"] != null && ViewState["sort"].ToString() == column)
            {
                nextDir = "DESC";
                ViewState["sort"] = null;
            }
            else
            {
                ViewState["sort"] = column;
            }
            return nextDir;
        }

        protected void EmployeesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sort_column, sort_direction;
            string dir = GetSortDirection(e.SortExpression);
            switch (e.SortExpression)
            {
                case "First_name":
                    sort_column = "first_name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Second_name":
                    sort_column = "second_name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Pesel":
                    sort_column = "pesel";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Sex":
                    sort_column = "sex";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Phone_number":
                    sort_column = "phone_number";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Date_of_birth":
                    sort_column = "date_of_birth";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Email":
                    sort_column = "email";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Is_active":
                    sort_column = "is_active";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "User_department.Name":
                    sort_column = "departments.name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Medical_specialization.Name":
                    sort_column = "medical_specializations.name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "User_role.Name":
                    sort_column = "user_roles.name";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Address.Country":
                    sort_column = "country";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Address.State":
                    sort_column = "state";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Address.City":
                    sort_column = "city";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Address.Postal_code":
                    sort_column = "postal_code";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Address.Street":
                    sort_column = "street";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                case "Address.Number":
                    sort_column = "number";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
                default:
                    {
                        sort_column = "employees.id";
                        sort_direction = "DESC";
                    }
                    break;
            }
            employeesGridRefresh(sort_column, sort_direction);
        }
    }
}