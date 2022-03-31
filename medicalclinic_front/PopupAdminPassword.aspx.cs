using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace medicalclinic
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            TextBoxPassword.Text = "";
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text!="1234")
            {
                return;
            }

        }

        protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text.Length<1)
            {
                ConfirmButton.Enabled = false;
                return;
            }

            ConfirmButton.Enabled = true;
        }
    }
}