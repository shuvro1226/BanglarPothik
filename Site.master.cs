using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Configuration;

public partial class Site : System.Web.UI.MasterPage
{
    public string SuggestionList = "";

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Attributes.Add("onFocus", "javascript:if(this.value=='Search for Districts, Places and Travel Agents'){this.value='';}");
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string query = "SELECT * FROM Division";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            rptMenu.DataSource = ds;
            rptMenu.DataBind();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            con.Close();

            con.Open();
            string query1 = "SELECT * FROM District WHERE Div_id=1";
            cmd = new SqlCommand(query1, con);
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            cmd.ExecuteNonQuery();
            Repeater2.DataSource = ds1;
            Repeater2.DataBind();
            con.Close();

            con.Open();
            string query2 = "SELECT * FROM District WHERE Div_id=2";
            cmd = new SqlCommand(query2, con);
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(ds2);
            cmd.ExecuteNonQuery();
            Repeater3.DataSource = ds2;
            Repeater3.DataBind();
            con.Close();

            con.Open();
            string query3 = "SELECT * FROM District WHERE Div_id=3";
            cmd = new SqlCommand(query3, con);
            DataSet ds3 = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd);
            da3.Fill(ds3);
            cmd.ExecuteNonQuery();
            Repeater4.DataSource = ds3;
            Repeater4.DataBind();
            con.Close();

            con.Open();
            string query4 = "SELECT * FROM District WHERE Div_id=4";
            cmd = new SqlCommand(query4, con);
            DataSet ds4 = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd);
            da4.Fill(ds4);
            cmd.ExecuteNonQuery();
            Repeater5.DataSource = ds4;
            Repeater5.DataBind();
            con.Close();

            con.Open();
            string query5 = "SELECT * FROM District WHERE Div_id=5";
            cmd = new SqlCommand(query5, con);
            DataSet ds5 = new DataSet();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd);
            da5.Fill(ds5);
            cmd.ExecuteNonQuery();
            Repeater6.DataSource = ds5;
            Repeater6.DataBind();
            con.Close();

            con.Open();
            string query6 = "SELECT * FROM District WHERE Div_id=6";
            cmd = new SqlCommand(query6, con);
            DataSet ds6 = new DataSet();
            SqlDataAdapter da6 = new SqlDataAdapter(cmd);
            da6.Fill(ds6);
            cmd.ExecuteNonQuery();
            Repeater7.DataSource = ds6;
            Repeater7.DataBind();
            con.Close();

            con.Open();
            string query7 = "SELECT * FROM District WHERE Div_id=8";
            cmd = new SqlCommand(query7, con);
            DataSet ds7 = new DataSet();
            SqlDataAdapter da7 = new SqlDataAdapter(cmd);
            da7.Fill(ds7);
            cmd.ExecuteNonQuery();
            Repeater8.DataSource = ds7;
            Repeater8.DataBind();
            con.Close();

            string name = Page.User.Identity.Name;
            if(name == "Administrator")
            {
                admin.Visible = true;
            }

            if (Page.User.Identity.Name != String.Empty)
            {
                con.Open();
                string sql4 = "SELECT ProPic FROM Users WHERE Username='" + Page.User.Identity.Name + "'";
                cmd = new SqlCommand(sql4, con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Image1.ImageUrl = "~/images/ProPic/" + dr["ProPic"].ToString();
                }
                con.Close();
            }
            else
            {
                Image1.ImageUrl = "~/images/ProPic/1.jpg";
                ImageButton2.Visible = false;
            }

            con.Open();
            string sql3 = "SELECT COUNT(*) FROM Request WHERE Req_to=(SELECT Userid FROM Users WHERE Username='"+ Page.User.Identity.Name +"')";
            SqlCommand cmd2 = new SqlCommand();
            cmd2 = new SqlCommand(sql3, con);
            int count = (Int32)cmd2.ExecuteScalar();
            if (count > 0)
            {
                ImageButton2.ImageUrl = "~/images/Notify.png";
                ImageButton2.Enabled = true;
                ImageButton2.ToolTip = "You have " + count + " new notifications.";
                Label1.Text = count.ToString();
            }
            con.Close();

            Place();
            Districts();
            Agencies();
        }
    }

    protected void Profile_Visit(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql4 = "SELECT Userid FROM Users WHERE Username='" + Page.User.Identity.Name + "'";
        con.Open();
        SqlCommand cmd2 = new SqlCommand(sql4, con);
        cmd2 = new SqlCommand(sql4, con);
        SqlDataReader dr = null;
        dr = cmd2.ExecuteReader();
        while (dr.Read())
        {
            string userid = dr["Userid"].ToString();
            Response.Redirect("Profile.aspx?Userid=" + userid);
        }
    }

    protected void Requests(object sender, EventArgs e)
    {
        Response.Redirect("Requests.aspx");
    }

    protected void Item_Changed(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "0")
        {
            Place();
            Districts();
            Agencies();
        }
        if (DropDownList1.SelectedValue.ToString() == "1")
        {
            Districts();
        }
        if (DropDownList1.SelectedValue.ToString() == "2")
        {
            Place();
        }
        if (DropDownList1.SelectedValue.ToString() == "3")
        {
            Agencies();
        }
    }

    protected void Place()
    {
        string queryString = "SELECT * FROM Place ORDER BY Place_name";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
        {

            using (SqlCommand command = new SqlCommand(queryString, connection))
            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        if (string.IsNullOrEmpty(SuggestionList))
                        {
                            SuggestionList += "{ label:" + "\"" + reader["Place_name"].ToString() + "\"" + ", category: " + "\"" + "Places" + "\" }";
                        }
                        else
                        {
                            SuggestionList += ", { label:" + "\"" + reader["Place_name"].ToString() + "\"" + ", category: " + "\"" + "Places" + "\" }";
                        }

                    }
                }
            }
        }
    }

    protected void Districts()
    {
        string queryString2 = "SELECT * FROM District ORDER BY Dis_name";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
        {

            using (SqlCommand command = new SqlCommand(queryString2, connection))
            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        if (string.IsNullOrEmpty(SuggestionList))
                        {
                            SuggestionList += "{ label:" + "\"" + reader["Dis_name"].ToString() + "\"" + ", category: " + "\"" + "Districts" + "\" }";
                        }
                        else
                        {
                            SuggestionList += ", { label:" + "\"" + reader["Dis_name"].ToString() + "\"" + ", category: " + "\"" + "Districts" + "\" }";
                        }

                    }
                }
            }
        }
    }

    protected void Agencies()
    {
        string queryString3 = "SELECT * FROM TravelAgency ORDER BY Agencyname";

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
        {

            using (SqlCommand command = new SqlCommand(queryString3, connection))
            {

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        if (string.IsNullOrEmpty(SuggestionList))
                        {
                            SuggestionList += "{ label:" + "\"" + reader["Agencyname"].ToString() + "\"" + ", category: " + "\"" + "Travel Agents" + "\" }";
                        }
                        else
                        {
                            SuggestionList += ", { label:" + "\"" + reader["Agencyname"].ToString() + "\"" + ", category: " + "\"" + "Travel Agents" + "\" }";
                        }

                    }
                }
            }
        }
    }

    protected void Searching()
    {
        if (DropDownList1.SelectedValue.ToString() == "0")
        {
            string queryString0 = "SELECT Place_id FROM Place WHERE Place_name='" + TextBox1.Text.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString0, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Response.Redirect("Place.aspx?Place=" + reader["Place_id"].ToString());
                        }
                    }
                }
            }

            string queryString3 = "SELECT Agencyid FROM TravelAgency WHERE Agencyname='" + TextBox1.Text.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(queryString3, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Response.Redirect("AgencyDetail.aspx?Agencyid=" + reader["Agencyid"].ToString());
                        }
                    }
                }
            }

            string queryString2 = "SELECT Dis_id FROM District WHERE Dis_name='" + TextBox1.Text.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(queryString2, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Response.Redirect("ContentPage.aspx?District=" + reader["Dis_id"].ToString());
                        }
                    }
                }
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "1")
        {
            string queryString2 = "SELECT Dis_id FROM District WHERE Dis_name='" + TextBox1.Text.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(queryString2, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Response.Redirect("ContentPage.aspx?District=" + reader["Dis_id"].ToString());
                        }
                    }
                }
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "2")
        {
            string queryString0 = "SELECT Place_id FROM Place WHERE Place_name='" + TextBox1.Text.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString0, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Response.Redirect("Place.aspx?Place=" + reader["Place_id"].ToString());
                        }
                    }
                }
            }
        }
        if (DropDownList1.SelectedValue.ToString() == "3")
        {
            string queryString3 = "SELECT Agencyid FROM TravelAgency WHERE Agencyname='" + TextBox1.Text.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand(queryString3, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Response.Redirect("AgencyDetail.aspx?Agencyid=" + reader["Agencyid"].ToString());
                        }
                    }
                }
            }
        }
    }

    protected void Search(object sender, EventArgs e)
    {
        if (TextBox1.Text != "Search for Districts, Places and Travel Agents")
        {
            Searching();
        }
    }
}
