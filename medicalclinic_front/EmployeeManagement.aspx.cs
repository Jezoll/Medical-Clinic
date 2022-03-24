using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Data;
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
            ViewState["SortColumn"] = sort_column;
            ViewState["SortDirection"] = sort_direction;
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
            sort_column = e.SortExpression.ToString();
            employeesGridRefresh(sort_column, sort_direction);
        }
        protected void EmployeesGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    if (tc.HasControls())
                    {
                        LinkButton lnk = (LinkButton)tc.Controls[0];
                        if (lnk != null && ViewState["SortColumn"].ToString() == lnk.CommandArgument)
                        {
                            string sortArrow = (SortDirection)ViewState["SortDirection"] == SortDirection.Ascending ? " &#9650;" : " &#9660;";
                            lnk.Text += sortArrow;
                        }
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }

        protected void EmployeeReviewButton_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("EmployeeReview.aspx?id =" + lnk.CommandArgument);
        }

        protected void EmployeeEditButton_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("EmployeeEdit.aspx?id =" + lnk.CommandArgument);
        }
    }
}
