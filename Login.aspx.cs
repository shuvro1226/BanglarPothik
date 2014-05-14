using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Login";
        if (Page.User.Identity.Name != String.Empty)
        {
            Response.Redirect("Default.aspx");
        }

        if (Request["msg"] != null)
        {
            lblMessage.Text = Request["msg"].ToString();
        }
    }

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUname.Text != String.Empty && txtPass.Text != String.Empty)
        {
            string sql = "SELECT * FROM Users WHERE Username = '" + txtUname.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                    if (txtPass.Text == dr["Password"].ToString())
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtUname.Text, false);
                    }
                    else
                    {
                        lblMessage.Text = "Invalid username & password combination!";
                    }
            }

            string sql2 = "SELECT COUNT(*) FROM Users WHERE Username = '" + txtUname.Text + "'";
            cmd = new SqlCommand(sql2, con);
            int count = (Int32)cmd.ExecuteScalar(); 
            if (count == 0)
            {
                lblMessage.Text = "Username does not exist!";
            }
            
        }
        else
        {
            lblMessage.Text = "Provide username & password!";
        }
    }
}