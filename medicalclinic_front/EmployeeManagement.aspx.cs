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
            if (!Page.IsPostBack)
                employeesGridRefresh();
        }

        private void employeesGridRefresh(string sort_column = "employees.id", SortDirection sort_direction = SortDirection.Ascending, FilterColumnEmployee filter_column = FilterColumnEmployee.Undefined, string filter_query = "1")
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

        protected SortDirection GetSortDirection(string column)
        {
            SortDirection nextDir = SortDirection.Ascending;
            if (ViewState["sort"] != null && ViewState["sort"].ToString() == column)
            {
                nextDir = SortDirection.Descending;
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
            string sort_column;
            SortDirection sort_direction = GetSortDirection(e.SortExpression);
            switch (e.SortExpression)
            {
                case "Id":
                    sort_column = "employees.id";
                    break;
                case "First_name":
                    sort_column = "first_name";
                    break;
                case "Second_name":
                    sort_column = "second_name";
                    break;
                case "Pesel":
                    sort_column = "pesel";
                    break;
                case "Sex":
                    sort_column = "sex";
                    break;
                case "Phone_number":
                    sort_column = "phone_number";
                    break;
                case "Date_of_birth":
                    sort_column = "date_of_birth";
                    break;
                case "Email":
                    sort_column = "email";
                    break;
                case "Is_active":
                    sort_column = "is_active";
                    break;
                case "User_department.Name":
                    sort_column = "departments.name";
                    break;
                case "Medical_specialization.Name":
                    sort_column = "medical_specializations.name";
                    break;
                case "User_role.Name":
                    sort_column = "user_roles.name";
                    break;
                case "Address.Country":
                    sort_column = "country";
                    break;
                case "Address.State":
                    sort_column = "state";
                    break;
                case "Address.City":
                    sort_column = "city";
                    break;
                case "Address.Postal_code":
                    sort_column = "postal_code";
                    break;
                case "Address.Street":
                    sort_column = "street";
                    break;
                case "Address.Number":
                    sort_column = "number";
                    break;
                default:
                    sort_column = "employees.id";
                    break;
            }
            employeesGridRefresh(sort_column, sort_direction);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        //protected void editEmployee(object sender, EventAgrs e)
        //{

        //}

    }
}
