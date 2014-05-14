using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Trips : System.Web.UI.Page
{
    protected string trip;

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Tripid"] != null)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            trip = Request["Tripid"].ToString();
            string sql = "SELECT TripDetail.*,TravelAgency.Agencyname,TripType.Typename FROM TripDetail INNER JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid INNER JOIN TripType ON TripType.Typeid=TripDetail.Type WHERE TripDetail.Tripid = '" + trip + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                HyperLink1.NavigateUrl = "AgencyDetail.aspx?Agencyid=" + dr["Agencyid"].ToString();
                HyperLink1.Text = dr["Agencyname"].ToString();
                Label1.Text = dr["Tripname"].ToString();
                this.Title = dr["Tripname"].ToString();
                Label2.Text = dr["Typename"].ToString();
                Label4.Text = dr["Duration"].ToString();
                if (dr["Cost"].ToString() != "Unknown")
                {
                    Label5.Text = "BDT " + dr["Cost"].ToString();
                }
                else
                {
                    Label5.Text = "Call agency for price";
                }
                Label3.Text = dr["Detail"].ToString();
                if (dr["Disid1"].ToString() != "-1")
                {
                    string sql1 = "SELECT Dis_name FROM District WHERE Dis_id = '" + dr["Disid1"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink2.NavigateUrl = "ContentPage.aspx?District=" + dr["Disid1"].ToString();
                        HyperLink2.Text = dr1["Dis_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Disid2"].ToString() != "-1")
                {
                    string sql1 = "SELECT Dis_name FROM District WHERE Dis_id = '" + dr["Disid2"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink3.NavigateUrl = "ContentPage.aspx?District=" + dr["Disid2"].ToString();
                        HyperLink3.Text = dr1["Dis_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Disid3"].ToString() != "-1")
                {
                    string sql1 = "SELECT Dis_name FROM District WHERE Dis_id = '" + dr["Disid3"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink4.NavigateUrl = "ContentPage.aspx?District=" + dr["Disid3"].ToString();
                        HyperLink4.Text = dr1["Dis_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Disid4"].ToString() != "-1")
                {
                    string sql1 = "SELECT Dis_name FROM District WHERE Dis_id = '" + dr["Disid4"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink5.NavigateUrl = "ContentPage.aspx?District=" + dr["Disid4"].ToString();
                        HyperLink5.Text = dr1["Dis_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Disid5"].ToString() != "-1")
                {
                    string sql1 = "SELECT Dis_name FROM District WHERE Dis_id = '" + dr["Disid5"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink6.NavigateUrl = "ContentPage.aspx?District=" + dr["Disid5"].ToString();
                        HyperLink6.Text = dr1["Dis_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Disid6"].ToString() != "-1")
                {
                    string sql1 = "SELECT Dis_name FROM District WHERE Dis_id = '" + dr["Disid6"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink7.NavigateUrl = "ContentPage.aspx?District=" + dr["Disid6"].ToString();
                        HyperLink7.Text = dr1["Dis_name"].ToString();
                    }
                    dr1.Close();
                }

                if (dr["Placeid1"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid1"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink8.NavigateUrl = "Place.aspx?Place=" + dr["Placeid1"].ToString();
                        HyperLink8.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                } 
                if (dr["Placeid2"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid2"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink9.NavigateUrl = "Place.aspx?Place=" + dr["Placeid2"].ToString();
                        HyperLink9.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                } 
                if (dr["Placeid3"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid3"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink10.NavigateUrl = "Place.aspx?Place=" + dr["Placeid3"].ToString();
                        HyperLink10.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                } 
                if (dr["Placeid4"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid4"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink11.NavigateUrl = "Place.aspx?Place=" + dr["Placeid4"].ToString();
                        HyperLink11.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                } 
                if (dr["Placeid5"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid5"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink12.NavigateUrl = "Place.aspx?Place=" + dr["Placeid5"].ToString();
                        HyperLink12.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Placeid6"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid6"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink13.NavigateUrl = "Place.aspx?Place=" + dr["Placeid6"].ToString();
                        HyperLink13.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Placeid7"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid7"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink14.NavigateUrl = "Place.aspx?Place=" + dr["Placeid7"].ToString();
                        HyperLink14.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Placeid8"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid8"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink15.NavigateUrl = "Place.aspx?Place=" + dr["Placeid8"].ToString();
                        HyperLink15.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                }
                if (dr["Placeid9"].ToString() != "-1")
                {
                    string sql1 = "SELECT Place_name FROM Place WHERE Place_id = '" + dr["Placeid9"].ToString() + "'";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader dr1 = null;
                    dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        HyperLink16.NavigateUrl = "Place.aspx?Place=" + dr["Placeid9"].ToString();
                        HyperLink16.Text = dr1["Place_name"].ToString();
                    }
                    dr1.Close();
                }
            }
            con.Close();
        }
    }

    protected void Recom_Friend(object sender, EventArgs e)
    {
        Panel5.Visible = true;

        Drop1();
    }

    protected void Drop1()
    {
        if (Request["Tripid"] != null)
        {
            trip = Request["Tripid"].ToString();
        }
        SqlConnection con1 = new SqlConnection(GetConnectionString());
        string sql5 = "SELECT Friends.Friendid,Users.Name FROM Friends INNER JOIN Users ON Friends.Friendid=Users.Userid WHERE Friends.Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Friends.Friendid NOT IN (SELECT Req_to From Request WHERE Req_by=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Req_trip='" + trip + "')";
        con1.Open();
        SqlCommand cmd6 = new SqlCommand(sql5, con1);
        cmd6 = new SqlCommand(sql5, con1);
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter(cmd6);
        da5.Fill(ds5);
        DropDownList1.DataSource = ds5;
        DropDownList1.DataTextField = "Name";
        DropDownList1.DataValueField = "Friendid";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select friend", "-1"));
        con1.Close();
    }

    protected void Recommend(object sender, EventArgs e)
    {
        if (Request["Tripid"] != null && DropDownList1.Items.Count != 0)
        {
            trip = Request["Tripid"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Request (Req_by,Req_to,Req_type,Req_trip) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , @to,@type, '" + trip + "')";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@to", DropDownList1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@type", "requested you to check out the trip ");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                con.Close();
                Label12.Text = "Recommendation sent to " + DropDownList1.SelectedItem.ToString() + ".";
                Drop1();
            }
        }
        else
        {
            Label12.Text = "No friends to recommend.";
        }
    }
}