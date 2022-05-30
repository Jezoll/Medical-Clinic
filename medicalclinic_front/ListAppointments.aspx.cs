﻿using medicalclinic_back;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;

namespace medicalclinic
{
    public partial class ListAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selected_date = Request.QueryString["selected_date"];
            int employee_id = Int32.Parse(Request.QueryString["employee_id"]);
            int patient_id = Int32.Parse(Request.QueryString["patient_id"]);
            int office_id = Int32.Parse(Request.QueryString["office_id"]);
 
            List<Appointment> appointments = Appointment.GetAppointments(employee_id, patient_id, office_id, selected_date);
            GridViewAppointments.DataSource = appointments;
            GridViewAppointments.DataBind();
        }
    }
}