using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Welcome to Banglar Pothik";
        SqlConnection con = new SqlConnection(GetConnectionString());
        if (!IsPostBack)
        {
            this.PopulateList1();

            string sql3 = "SELECT Dis_name,Dis_id FROM District";
            con.Open();
            SqlCommand cmd3 = new SqlCommand(sql3, con);
            DataSet ds3 = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(ds3);
            DropDownList6.DataSource = ds3;
            DropDownList6.DataTextField = "Dis_name";
            DropDownList6.DataValueField = "Dis_id";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, new ListItem("All", "-1"));
            DropDownList2.DataSource = ds3;
            DropDownList2.DataTextField = "Dis_name";
            DropDownList2.DataValueField = "Dis_id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("All", "-1"));
            con.Close();

            string sql1 = "SELECT Cat_id,Cat_name FROM Category";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);
            DropDownList5.DataSource = ds1;
            DropDownList5.DataTextField = "Cat_name";
            DropDownList5.DataValueField = "Cat_id";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("All", "-1"));
            con.Close();

            string sql2 = "SELECT * FROM Place";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds2);
            DropDownList7.DataSource = ds2;
            DropDownList7.DataTextField = "Place_name";
            DropDownList7.DataValueField = "Place_id";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("All", "-1"));
            con.Close();

            string sql5 = "SELECT * FROM TripType";
            con.Open();
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            DataSet ds5 = new DataSet();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            da5.Fill(ds5);
            DropDownList8.DataSource = ds5;
            DropDownList8.DataTextField = "Typename";
            DropDownList8.DataValueField = "Typeid";
            DropDownList8.DataBind();
            DropDownList8.Items.Insert(0, new ListItem("All", "-1"));
            con.Close();

            string query = "SELECT Imagegrid.*,Place.Place_name FROM Imagegrid INNER JOIN Place ON Place.Place_id=Imagegrid.Placeid";
            con.Open();
            SqlCommand cmd4 = new SqlCommand(query, con);
            DataSet ds4 = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(ds4);
            cmd4.ExecuteNonQuery();
            Repeater1.DataSource = ds4;
            Repeater1.DataBind();
            con.Close();

            string query7 = "SELECT * FROM TravelAgency";
            con.Open();
            SqlCommand cmd7 = new SqlCommand(query7, con);
            DataSet ds7 = new DataSet();
            SqlDataAdapter da7 = new SqlDataAdapter(cmd7);
            da7.Fill(ds7);
            cmd7.ExecuteNonQuery();
            Repeater3.DataSource = ds7;
            Repeater3.DataBind();
            con.Close();

            string query6 = "SELECT * FROM (SELECT Friends.Friendid FROM Friends JOIN Users ON Users.Userid=Friends.Userid WHERE Users.Username = '"+ Page.User.Identity.Name +"') AS query1 " +
                            "INNER JOIN (SELECT DISTINCT(Comment.datetime),Comment.status,Users.Name,Users.Userid,Place.Place_id,Place.Place_name FROM Comment " +
                            "JOIN Users ON Users.Userid=Comment.Userid JOIN Place ON Comment.Placeid=Place.Place_id UNION ALL " +
                            "SELECT DISTINCT(Checkin.datetime),Checkin.status,Users.Name,Users.Userid,Place.Place_id,Place.Place_name FROM Checkin " +
                            "JOIN Users ON Users.Userid=Checkin.Userid JOIN Place ON Checkin.Place_id=Place.Place_id) AS query2 " +
                            "ON query2.Userid=query1.Friendid ORDER BY query2.datetime desc";
            con.Open();
            SqlCommand cmd6 = new SqlCommand(query6, con);
            DataSet ds6 = new DataSet();
            SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
            da6.Fill(ds6);
            cmd6.ExecuteNonQuery();
            Repeater2.DataSource = ds6;
            Repeater2.DataBind();
            con.Close();

            if (Page.User.Identity.Name == String.Empty)
            {
                Label2.Text = "You must login to see friends update!";
            }
            else
            {
                string sql7 = "SELECT COUNT(*) FROM Friends WHERE Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "')";
                con.Open();
                cmd6 = new SqlCommand(sql7, con);
                int count = (Int32)cmd6.ExecuteScalar();
                if (count == 0)
                {
                    Label2.Text = "You must add one or more friends to get friends updates.";
                }
            }
        }

        Page.MaintainScrollPositionOnPostBack = true;
    }

    private void PopulateList1()
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "SELECT Div_name,Div_id FROM Division";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "Div_name";
        DropDownList1.DataValueField = "Div_id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("All", "0"));
        con.Close();
    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.ToString() == "All" && DropDownList2.SelectedItem.ToString() == "All" && DropDownList5.SelectedItem.ToString() == "All")
        {
            Label1.Text = "You need to select at least 1 filter.";
        }
        else
        {
            Session["division"] = DropDownList1.SelectedItem.ToString();
            Session["district"] = DropDownList2.SelectedItem.ToString();
            Session["category"] = DropDownList5.SelectedItem.ToString();
            Response.Redirect("SearchResult.aspx?division="+DropDownList1.SelectedItem.ToString()+"&district="+DropDownList2.SelectedItem.ToString()+"&category="+DropDownList5.SelectedItem.ToString());
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DropDownList6.SelectedItem.ToString() == "All" && DropDownList7.SelectedItem.ToString() == "All" && DropDownList8.SelectedItem.ToString() == "All" && DropDownList3.SelectedValue.ToString() == "0" && DropDownList4.SelectedValue.ToString() == "0")
        {
            Label3.Text = "You need to select at least 1 filter.";
        }
        else
        {
            int min = Convert.ToInt32(DropDownList3.SelectedValue);
            int max = Convert.ToInt32(DropDownList4.SelectedValue);
            Session["district"] = DropDownList6.SelectedValue;
            Session["place"] = DropDownList7.SelectedValue;
            Session["type"] = DropDownList8.SelectedValue;
            Response.Redirect("SearchResult.aspx?min="+ min +"&max="+ max);
        }
    }

    protected void Max_Changed(object sender, EventArgs e)
    {
        int max = Convert.ToInt32(DropDownList4.SelectedValue);
        if  (max == 0)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
        }
        if (max == 500)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
        } 
        if (max == 2000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
        }
        if (max == 4000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
        }
        if (max == 6000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
        }
        if (max == 8000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
        }
        if (max == 10000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
            DropDownList3.Items.Insert(5, new ListItem("8000", "8000"));
        }
        if (max == 12000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
            DropDownList3.Items.Insert(5, new ListItem("8000", "8000"));
            DropDownList3.Items.Insert(6, new ListItem("10000", "10000"));
        }
        if (max == 14000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
            DropDownList3.Items.Insert(5, new ListItem("8000", "8000"));
            DropDownList3.Items.Insert(6, new ListItem("10000", "10000"));
            DropDownList3.Items.Insert(7, new ListItem("12000", "12000"));
        }
        if (max == 16000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
            DropDownList3.Items.Insert(5, new ListItem("8000", "8000"));
            DropDownList3.Items.Insert(6, new ListItem("10000", "10000"));
            DropDownList3.Items.Insert(7, new ListItem("12000", "12000"));
            DropDownList3.Items.Insert(8, new ListItem("14000", "14000"));
        }
        if (max == 18000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
            DropDownList3.Items.Insert(5, new ListItem("8000", "8000"));
            DropDownList3.Items.Insert(6, new ListItem("10000", "10000"));
            DropDownList3.Items.Insert(7, new ListItem("12000", "12000"));
            DropDownList3.Items.Insert(8, new ListItem("14000", "14000"));
            DropDownList3.Items.Insert(9, new ListItem("16000", "16000"));
        }
        if (max == 20000)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("Select", "0"));
            DropDownList3.Items.Insert(1, new ListItem("500", "500"));
            DropDownList3.Items.Insert(2, new ListItem("2000", "2000"));
            DropDownList3.Items.Insert(3, new ListItem("4000", "4000"));
            DropDownList3.Items.Insert(4, new ListItem("6000", "6000"));
            DropDownList3.Items.Insert(5, new ListItem("8000", "8000"));
            DropDownList3.Items.Insert(6, new ListItem("10000", "10000"));
            DropDownList3.Items.Insert(7, new ListItem("12000", "12000"));
            DropDownList3.Items.Insert(8, new ListItem("14000", "14000"));
            DropDownList3.Items.Insert(9, new ListItem("16000", "16000"));
        }
    }
}