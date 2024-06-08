using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Data.SqlClient;

namespace Hotel
{
    public partial class reggrid : System.Web.UI.Page
    {
        public void getdata()
        {

            SqlConnection con = new SqlConnection("data source=DESKTOP-JLVACP3\\SQLEXPRESS;database=Project;integrated security=yes");
            string query = "select * from Registration";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }
        //Row Editing
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //When ever user click on edit button we need to catch the row index and need to fill.
            //Bydefault row index is -1.
            GridView1.EditIndex = e.NewEditIndex;
            getdata();
        }


        //Row Updating

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            TextBox t1 = (TextBox)rows.FindControl("TextBox1");
            TextBox t2 = (TextBox)rows.FindControl("TextBox2");
            TextBox t3 = (TextBox)rows.FindControl("TextBox3");
            TextBox t4 = (TextBox)rows.FindControl("TextBox4");
            //TextBox t5 = (TextBox)rows.FindControl("TextBox5");
            //TextBox t6 = (TextBox)rows.FindControl("TextBox6");
            TextBox t7 = (TextBox)rows.FindControl("TextBox7");
            TextBox t8 = (TextBox)rows.FindControl("TextBox8");
            TextBox t9 = (TextBox)rows.FindControl("TextBox9");
            TextBox t10 = (TextBox)rows.FindControl("TextBox10");
            // TextBox t11= (TextBox)rows.FindControl("TextBox11");


            SqlConnection con = new SqlConnection("data source=DESKTOP-JLVACP3\\SQLEXPRESS;database=Project;integrated security=yes");
            con.Open();
            //pass the query
            var query = ("UPDATE  Registration  SET  [Last Name] = '" + t2.Text + "',Username='" + t3.Text + "',Gender='" + t4.Text + "',Email='" + t7.Text + "',Phone='" + t8.Text + "',Address='" + t9.Text + "',[Language known]='" + t10.Text + "'Where [First Name]='" + t1.Text + "' ");
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            getdata();
        }

        //Row Cancel
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getdata();
        }

        //Row Deleting
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            Label lbl = (Label)rows.FindControl("Label1");
            SqlConnection con = new SqlConnection("data source=DESKTOP-JLVACP3\\SQLEXPRESS;database=Project;integrated security=yes");
            con.Open();
            //pass the query
            var query = "DELETE  Registration Where [First Name] ='" + lbl.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            getdata();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Button1.Text = "Hotel registration";
            Response.Redirect("Room.aspx");

        }
    }
}