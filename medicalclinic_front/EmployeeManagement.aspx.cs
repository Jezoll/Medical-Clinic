using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class EmployeeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //popout dodano pracownika ma mieć OK co go zamyka i tyle
            if (!Page.IsPostBack)
                employeesGridRefresh();
        }

        private void employeesGridRefresh(string sort_column = "employees.id", string sort_direction = "DESC", FilterColumnEmployee filter_column = FilterColumnEmployee.Undefined, string filter_query = null)
        {
            List<Employee> employees = Employee.getAllEmployees(sort_column, sort_direction, filter_column, filter_query);
            fillDropDownListsWithValues();
            EmployeesGridView.DataSource = employees;
            EmployeesGridView.DataBind();
        }

        private void fillDropDownListsWithValues()
        {
            List<UserRole> data = UserRole.getAllRoles();
            DropDownListRoles.Items.Clear();
            foreach (UserRole role in data)
            {
                DropDownListRoles.Items.Add(role.Name);
            }
        }

        protected void ButtonFilterRoles_Click(object sender, EventArgs e)
        {
            string query = DropDownListRoles.SelectedValue;
            employeesGridRefresh(filter_column: FilterColumnEmployee.Role, filter_query: query);
        }

        protected void ButtonFilterActive_Click(object sender, EventArgs e)
        {
            string query = "";
            if (CheckBoxIsActive.Checked) query = "1";
            else query = "0";
            employeesGridRefresh(filter_column: FilterColumnEmployee.Active, filter_query: query);
        }

        protected void ButtonFilterClear_Click(object sender, EventArgs e)
        {
            employeesGridRefresh();
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
                case "Id":
                    sort_column = "employees.id";
                    if (dir == "ASC")
                    {
                        sort_direction = "ASC";
                    }
                    else
                    {
                        sort_direction = "DESC";
                    }
                    break;
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

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }


    }
}
