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
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.id,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id where day(date) = '" + Calendar1.SelectedDate.Day + "'");
            
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();


                Database.closeConnection();
            
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
           
            GridView1.Visible = true;
            Button2.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            RadioButtonList2.Visible = true;
            RadioButtonList1.Visible = true;
         
            Button3.Visible = true;
            Button4.Visible = true;
            TextBox1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)

        {
            

            MySqlCommand command = Database.command("SELECT date FROM visits where month(date) = '" + Calendar1.SelectedDate.Month + "'");
                MySqlDataReader r = command.ExecuteReader();


                GridView2.DataSource = r;
                GridView2.DataBind();


                Database.closeConnection();
        }

        
        protected void Button3_Click(object sender, EventArgs e)
        {
            GridView2.DataBind();
           

            if(RadioButtonList1.SelectedIndex==0)
            {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id ORDER BY pat.first_name ASC ");
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();
                Database.closeConnection();
            }
            else
            {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id ORDER BY pat.first_name DESC ");
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();

                Database.closeConnection();

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            GridView2.DataBind();
        
            if(RadioButtonList2.SelectedIndex==0)
            {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id WHERE pat.first_name like '" + TextBox1.Text + "%'"); ;
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();

                Database.closeConnection();
            }
            else if(RadioButtonList2.SelectedIndex==1)
            {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id WHERE pat.second_name like '" + TextBox1.Text + "%'");
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();

                Database.closeConnection();
            }
            else if(RadioButtonList2.SelectedIndex==2)
            {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id WHERE pat.pesel like '" + TextBox1.Text + "%'");
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();

                Database.closeConnection();
            }
            else if(RadioButtonList2.SelectedIndex==3)
            {
                MySqlCommand command = Database.command("SELECT vis.date, vis.duration, vis.confirmed, vis.type, vis.id_patient, pat.first_name, pat.second_name, pat.pesel, pat.sex, pat.date_of_birth, pat.phone_number, pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id WHERE pat.sex = '" + TextBox1.Text + "'");
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();

                Database.closeConnection();
            }
            else if(RadioButtonList2.SelectedIndex==4)
            {
                MySqlCommand command = Database.command("SELECT vis.date,vis.duration,vis.confirmed,vis.type,vis.id_patient,pat.first_name,pat.second_name,pat.pesel,pat.sex,pat.date_of_birth,pat.phone_number,pat.email FROM visits vis INNER JOIN patients pat ON vis.id_patient = pat.id WHERE pat.date_of_birth like '" + TextBox1.Text + "%'");
                MySqlDataReader r = command.ExecuteReader();


                GridView1.DataSource = r;
                GridView1.DataBind();

                Database.closeConnection();
            }
            
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
