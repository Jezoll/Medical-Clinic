using System;
using medicalclinic_back;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace medicalclinic
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) //bez tego nie ładuje poprzednich dat 
            {
                Calendar_main.VisibleDate = DateTime.Today;
            }
            try
            {
                Database.openConnection();
                MySqlConnection dbconn = new MySqlConnection();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        //renderowanie na "kafelkach" w kalendarzu
        protected void Calendar_main_DayRender(object sender, DayRenderEventArgs e)
        {
            DataTable datatab = Dates;
            DateTime eventDate;

            if (datatab.Rows.Count > 0)
            {
                for (int i = 0; i < datatab.Rows.Count; i++)
                {
                    eventDate = Convert.ToDateTime(datatab.Rows[i]["date"]);

                    if (e.Day.Date == eventDate)
                    {
                        e.Cell.BackColor = System.Drawing.Color.FromArgb(176, 196, 222);
                        e.Cell.Controls.Add(new LiteralControl("<br/> An appointment(s)"));
                    }
                }
            }
        }

        public DataTable Dates
        {
            get
            {
                DataTable datatab = new DataTable();
                MySqlCommand command = Database.command("SELECT vis.date AS Date, pat.first_name AS Name, pat.second_name AS Surname, pat.pesel AS PESEL, pat.sex as Sex, pat.date_of_birth AS Birth, pat.phone_number AS Phone, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id");
                MySqlDataAdapter mysqlDataAd = new MySqlDataAdapter(command);
                mysqlDataAd.Fill(datatab);

                return datatab;

            }
        }

        protected void Calendar_main_SelectionChanged(object sender, EventArgs e)
        {
            GridView_raportMonthly.Visible = true;
            int day = Calendar_main.SelectedDate.Day;
            int month = Calendar_main.VisibleDate.Month;

            GridView_raportMonthly.DataSource = Calendar_Appointments.Calendar_sectionchanged(day, month);
            GridView_raportMonthly.DataBind();
            Database.closeConnection();
        }

        protected void Button_details_Click(object sender, EventArgs e)
        {
            int month = Calendar_main.VisibleDate.Month;
            int year = Calendar_main.VisibleDate.Year;
            GridView_raportMonthly.Visible = true;

            GridView_raportMonthly.DataSource = Calendar_Appointments.Calendar_details(month, year);
            GridView_raportMonthly.DataBind();

            Database.closeConnection();
        }

        protected void CheckBox_surname_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_surname.Checked == true)
            {
                TextBox_surname_filter.Enabled = true;
            }
            else
            {
                TextBox_surname_filter.Enabled = false;
                TextBox_surname_filter.Text = "";
            }
        }

        protected void CheckBox_name_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_name.Checked == true)
            { 
                TextBox_name_filter.Enabled = true;
            }
            else
            {
                TextBox_name_filter.Enabled = false;
                TextBox_name_filter.Text = "";
            }
        }

        protected void Button_filter_Click(object sender, EventArgs e)
        {
            GridView_Filter.DataBind();
            string name = TextBox_name_filter.Text;
            string surname = TextBox_surname_filter.Text;



            if (CheckBox_name.Checked == true & TextBox_name_filter.Text != "")
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_byname(name);
                GridView_Filter.DataBind();
            }
            else if (CheckBox_surname.Checked == true & TextBox_surname_filter.Text != "")
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_bysurname(surname);
                GridView_Filter.DataBind();
            }
            if (CheckBox_name.Checked == true & CheckBox_surname.Checked == true & TextBox_name_filter.Text != "" & TextBox_surname_filter.Text != "")
            {
                GridView_Filter.DataSource = Calendar_Appointments.Filtr_byname_and_surname(name, surname);
                GridView_Filter.DataBind();
            }
           else if (TextBox_name_filter.Text == "" & TextBox_surname_filter.Text == "")
            {
               Response.Write("<script>alert('Empty values')</script>");

            }
        }
       
        protected void ImageButton_refresh_Click(object sender, ImageClickEventArgs e)
        {
            Calendar_main.VisibleDate = DateTime.Today;
            GridView_raportMonthly.Visible = false;
        }
    }
}
