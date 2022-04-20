using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class Calendar_AddAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_cancel_appo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Calendar.aspx");
        }

        protected void Button_accept_appo_Click(object sender, EventArgs e)
        {
        //    Calendar_AddAppointment.
            //Office.InsertNewOffice(TextBoxNumberOfOffice.Text, DropDownListSpecializations.SelectedValue, DropDownListOfficeRole.SelectedValue);
           // officesGridViewRefresh();
        }
    }
}