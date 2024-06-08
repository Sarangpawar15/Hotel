using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string FirstName = TextBox1.Text;
            string LastName = TextBox2.Text;
            string Username = TextBox3.Text;
            string Gender = string.Empty;
            string Password = TextBox4.Text;
            string ConfirmPassword = TextBox5.Text;
            string Email = TextBox6.Text;
            string Phone = TextBox7.Text;
            string Address = TextBox8.Text;
            string LanguagesKnown = string.Empty;
            string Country = string.Empty;
            if (DropDownList1 != null)
            {
                Country = DropDownList1.SelectedValue.ToString();
            }
            if (RadioButton1.Checked == true)
            {
                Gender = RadioButton1.Text;
            }
            else if (RadioButton2.Checked == true)
            {
                Gender = RadioButton2.Text;
            }
            if (CheckBox1.Checked == true)
            {
                LanguagesKnown = LanguagesKnown + CheckBox1.Text + ",";

            }
            if (CheckBox2.Checked == true)
            {
                LanguagesKnown = LanguagesKnown + CheckBox2.Text + ",";

            }
            if (CheckBox3.Checked == true)
            {
                LanguagesKnown = LanguagesKnown + CheckBox3.Text + ",";
            }
            //create sql connection
            SqlConnection connection = new SqlConnection("data source=DESKTOP-JLVACP3\\SQLEXPRESS; database=Project;integrated security=yes");
            connection.Open();
            string query = "insert into Registration values('" + FirstName + "','" + LastName + "','" + Username + "','" + Gender + "','" + Password + "','" + ConfirmPassword + "','" + Email + "','" + Phone + "','" + Address + "','" + LanguagesKnown + "','" + Country + "')";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            Response.Write("<script>alert('success');</script>");
            Response.Redirect("log.aspx");
        }

    }
}
