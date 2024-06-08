using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Hotel
{
    public partial class USER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string username = TextBox1.Text;
            string password = string.Empty;
            SqlConnection con = new SqlConnection("data source=DESKTOP-JLVACP3\\SQLEXPRESS;database=Project;integrated security=yes");
            con.Open();
            string query = "select password from Registration where username='" + username + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            password = cmd.ExecuteScalar().ToString();

            if (password == TextBox2.Text)
            {
                Response.Write("valid cred");
                Response.Redirect("reggrid.aspx");

            }
            else
            {
                Response.Write("invalid cred");
            }
            con.Close();
        }
    }
    }
