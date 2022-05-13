using medicalclinic_back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class PopupConfirmOfficeDeletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = $"Do you want to delete office with ID: {Request.QueryString[0]}?";
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int officeID = int.Parse(Request.QueryString[0]);
            string message;

            if (Office.CheckIfPlannedForFutureVisits(officeID))
            {
                message = "This office is planned for future visits so it can not be deleted!";
                AlertBox(message);
                ButtonConfirm.Enabled = false;
                return;
            }

            Office.DeleteOffice(officeID);
            message = "Office deleted successfully";
            ButtonConfirm.Enabled = false;
            AlertBox(message);
        }

        private void AlertBox(string AlertMessage)
        {
            string alert = "alert('" + AlertMessage + "');";

            ClientScript.RegisterStartupScript(this.GetType(), "myalert", alert, true);
        }
    }
}