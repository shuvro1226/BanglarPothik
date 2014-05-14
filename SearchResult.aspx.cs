using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Drawing;

public partial class SearchResult : System.Web.UI.Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["division"] != null && Request["district"] != null && Request["category"] != null)
        {
            string division = (string)Request["division"].ToString();
            string district = (string)Request["district"].ToString();
            string category = (string)Request["category"].ToString();
            if (division != "All" && district == "All" && category == "All")
            {
                this.Title = "Search Result";
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE Place.Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
            else if (division != "All" && district != "All" && category == "All")
            {
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE Place.Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "') OR Place.Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "') OR Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
            else if (division == "All" && district != "All" && category == "All")
            {
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE Place.Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
            else if (division != "All" && district == "All" && category != "All")
            {
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE Place.Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "') AND Place.Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "') AND Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
            else if (division == "All" && district == "All" && category != "All")
            {
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE Place.Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
            else if (division != "All" && district != "All" && category != "All")
            {
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE (Place.Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "') OR Place.Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')) AND Place.Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE (Div_id = (SELECT Div_id FROM Division WHERE Div_name = '" + division + "') OR Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')) AND Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
            else if (division == "All" && district != "All" && category != "All")
            {
                Repeater1.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Place.*,Division.Div_name,District.Dis_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id=Division.Div_id INNER JOIN District ON Place.Dis_id=District.Dis_id INNER JOIN Category ON Place.Cat_id=Category.Cat_id WHERE Place.Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "') AND Place.Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM Place WHERE Cat_id = (SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "') AND Dis_id = (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " place('s)";
            }
        }

        if (Session["district"] != null && Session["place"] != null && Session["type"] != null && Request["min"] != null && Request["max"] != null)
        {
            string dis = (string)Session["district"].ToString();
            string place = (string)Session["place"].ToString();
            string type = (string)Session["type"].ToString();
            int min = Convert.ToInt32(Request["min"]);
            int max = Convert.ToInt32(Request["max"]);
            if (dis != "-1" && place == "-1" && type == "-1" && min == 0 && max == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place != "-1" && type == "-1" && min == 0 && max == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place != "-1" && type != "-1" && min == 0 && max == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "'";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place != "-1" && type == "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "' AND Cost<='"+ max +"')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place != "-1" && type == "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place != "-1" && type != "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place != "-1" && type != "-1" && max == 0 && min !=0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "' OR Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place == "-1" && type != "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place == "-1" && type != "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND Type='" + type + "' AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND Type='" + type + "' AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place == "-1" && type != "-1" && max == 0 && min == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND Type='" + type + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND Type='" + type + "'";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place == "-1" && type == "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis != "-1" && place == "-1" && type == "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Disid1='" + dis + "' OR Disid2='" + dis + "'OR Disid3='" + dis + "'OR Disid4='" + dis + "'OR Disid5='" + dis + "'OR Disid6='" + dis + "') AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place != "-1" && type != "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place != "-1" && type != "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "' AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place != "-1" && type != "-1" && max == 0 && min == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND Type='" + type + "'";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place != "-1" && type == "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place != "-1" && type == "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "') AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place != "-1" && type == "-1" && max == 0 && min == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Placeid1='" + place + "' OR Placeid2='" + place + "' OR Placeid3='" + place + "' OR Placeid4='" + place + "' OR Placeid5='" + place + "' OR Placeid6='" + place + "' OR Placeid7='" + place + "' OR Placeid8='" + place + "' OR Placeid9='" + place + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place == "-1" && type != "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE Type='" + type + "' AND (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place == "-1" && type != "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE Type='" + type + "' AND (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE Type='" + type + "' AND (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place == "-1" && type != "-1" && max == 0 && min == 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE Type='" + type + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE Type='" + type + "'";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place == "-1" && type == "-1" && max != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Cost>='" + min + "' AND Cost<='" + max + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Cost>='" + min + "' AND Cost<='" + max + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
            else if (dis == "-1" && place == "-1" && type == "-1" && max == 0 && min != 0)
            {
                Repeater2.Visible = true;
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT TripDetail.*,TravelAgency.Agencyname FROM TripDetail JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Cost>='" + min + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                Repeater2.DataSource = ds;
                Repeater2.DataBind();

                cmd.CommandText = "SELECT COUNT(*) FROM TripDetail WHERE (Cost>='" + min + "')";
                Int32 count = (Int32)cmd.ExecuteScalar();
                Label2.Text = "Search result returned " + count + " trip('s)";
            }
        }
    }
}