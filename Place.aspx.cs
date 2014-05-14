using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

public partial class Place : System.Web.UI.Page
{
    protected string distance;
    protected string dis_name;
    protected string division;
    protected string place;
    protected double avg;

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        if (Page.User.Identity.Name == String.Empty)
        {
            Button5.Visible = false;
        }

        if (Request["Place"] != null)
        {
            place = Request["Place"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "SELECT Place.Place_name,Place.Coordinates,Place.Image,Place.Details,District.Dis_name,Division.Div_name,Category.Cat_name FROM Place INNER JOIN Division ON Place.Div_id = Division.Div_id INNER JOIN District ON Place.Dis_id = District.Dis_id INNER JOIN Category ON Place.Cat_id = Category.Cat_id WHERE Place_id = '" + place + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                Panel1.Visible = false;
                Label14.Text = "The place you requested is not present in our database.";
            }
            while (dr.Read())
            {
                Image1.ImageUrl = "~/images/Place/" + dr["Image"].ToString();
                Bitmap myBitmap = new Bitmap(Server.MapPath("~/images/Place/" + dr["Image"].ToString()));
                double width = myBitmap.Width;
                double height = myBitmap.Height;
                double a = width / height;
                double b = 450 / a;
                int c = Convert.ToInt32(b);
                Image1.Height = c;
                Image1.Width = 450;
                division = dr["Div_name"].ToString();
                Label1.Text = dr["Place_name"].ToString();
                this.Title = dr["Place_name"].ToString();
                dis_name = Label1.Text;
                Label2.Text = dr["Cat_name"].ToString();
                Label3.Text = dr["Details"].ToString();
                Label5.Text = dr["Dis_name"].ToString(); ;
                Label6.Text = division;
                distance = dr["Coordinates"].ToString();
            }
        }

        if (Page.User.Identity.Name == string.Empty || place == null)
        {
            com.Visible = true;
            Comment.Visible = false;
            ImageButton1.Visible = false;
        }
        else
        {
            com.Visible = false;
            Comment.Visible = true;
        }

        if (!IsPostBack)
        {
            BindRepeater1();
        }

        SqlConnection con1 = new SqlConnection(GetConnectionString());
        con1.Open();

        string sql4 = "SELECT COUNT(*) FROM Comment WHERE Placeid='" + place + "'";
        SqlCommand cmd5 = new SqlCommand(sql4, con1);
        Int32 rating = (Int32)cmd5.ExecuteScalar();
        if (rating != 0)
        {
            string sql3 = "SELECT SUM(Rating) FROM Comment WHERE Placeid='" + place + "'";
            SqlCommand cmd4 = new SqlCommand(sql3, con1);
            Double sum = (Int32)cmd4.ExecuteScalar();
            avg = sum / rating;
            if (avg < 1.50)
            {
                comrating.Attributes["class"] = "rating1";
            }
            if (avg > 1.49 && avg < 2.00)
            {
                comrating.Attributes["class"] = "rating2";
            }
            if (avg > 1.99 && avg < 2.50)
            {
                comrating.Attributes["class"] = "rating3";
            }
            if (avg > 2.49 && avg < 3.00)
            {
                comrating.Attributes["class"] = "rating4";
            }
            if (avg > 2.99 && avg < 3.50)
            {
                comrating.Attributes["class"] = "rating5";
            }
            if (avg > 3.49 && avg < 4.00)
            {
                comrating.Attributes["class"] = "rating6";
            }
            if (avg > 3.99 && avg < 4.50)
            {
                comrating.Attributes["class"] = "rating7";
            }
            if (avg > 4.49 && avg < 5.00)
            {
                comrating.Attributes["class"] = "rating8";
            }
            if (avg == 5.00)
            {
                comrating.Attributes["class"] = "rating9";
            }
        }
        else
        {
            Label7.Text = "No One rated this place yet!";
        }

        string sql2 = "SELECT COUNT(*) FROM Checkin WHERE Place_id=(SELECT Place_id FROM Place WHERE Place_name = '" + Label1.Text + "')";
        SqlCommand cmd3 = new SqlCommand(sql2, con1);
        Int32 count1 = (Int32)cmd3.ExecuteScalar();
        if (count1 == 0)
        {
            Label4.Text = "No one checked in yet!";
        }

        string sql1 = "SELECT COUNT(*) FROM Checkin WHERE Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Place_id=(SELECT Place_id FROM Place WHERE Place_name = '" + Label1.Text + "')";
        SqlCommand cmd2 = new SqlCommand(sql1, con1);
        Int32 count = (Int32)cmd2.ExecuteScalar();
        if (count == 1 && count1 != 0)
        {
            count1 = count1 - 1;
            ImageButton1.Visible = false;
            Label4.Text = "You and " + count1 + " others have checked in this place.";
        }
        if (count == 1 && count1 == 0)
        {
            count1 = count1 - 1;
            ImageButton1.Visible = false;
            Label4.Text = "Only You have checked in this place.";
        }
        if (count != 1 && count1 != 0)
        {
            Label4.Text = count1 + " people checked in!";
        }


        string sql6 = "SELECT TripDetail.Tripname,TripDetail.Tripid,TripDetail.Agencyid,TravelAgency.Agencyname FROM TripDetail INNER JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Placeid1 = '" + place + "' OR Placeid2 = '" + place + "' OR Placeid3 = '" + place + "' OR Placeid4 = '" + place + "' OR Placeid5 = '" + place + "' OR Placeid6 = '" + place + "' OR Placeid7 = '" + place + "' OR Placeid8 = '" + place + "' OR Placeid9 = '" + place + "') GROUP BY TripDetail.Tripname,TripDetail.Tripid,TripDetail.Agencyid,TravelAgency.Agencyname";
        SqlCommand cmd6 = new SqlCommand(sql6, con1);
        cmd6.ExecuteNonQuery();
        SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
        DataSet ds6 = new DataSet();
        da6.Fill(ds6);
        Repeater2.DataSource = ds6;
        Repeater2.DataBind();
        cmd6.Dispose();
        con1.Close();
    }

    protected void BindRepeater1()
    {
        SqlConnection con1 = new SqlConnection(GetConnectionString());
        con1.Open();
        string query = "SELECT Comment.*,Users.Name,Users.Username,Users.ProPic FROM Comment INNER JOIN Users ON Comment.Userid=Users.Userid WHERE Placeid='" + place + "'";
        SqlCommand cmd1 = new SqlCommand(query, con1);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd1);
        da.Fill(ds);
        cmd1.ExecuteNonQuery();
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    protected void Recom_Friend(object sender, EventArgs e)
    {
        Panel5.Visible = true;

        Drop1();
    }

    protected void Drop1()
    {
        SqlConnection con1 = new SqlConnection(GetConnectionString());
        string sql5 = "SELECT Friends.Friendid,Users.Name FROM Friends INNER JOIN Users ON Friends.Friendid=Users.Userid WHERE Friends.Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Friends.Friendid NOT IN (SELECT Req_to From Request WHERE Req_by=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Req_place='" + place + "')";
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

    protected void Repeater1_Bound(object sender, RepeaterItemEventArgs e)
    {
        ImageButton mybutton = (ImageButton)e.Item.FindControl("ImageButton4");
        Label username = (Label)e.Item.FindControl("Label11");
        ImageButton imgbutup = (ImageButton)e.Item.FindControl("ImageButton2");
        ImageButton imgbutdown = (ImageButton)e.Item.FindControl("ImageButton3");
        if (Page.User.Identity.Name == "")
        {
            imgbutup.ImageUrl = "~/images/Arrow-Up.png";
            imgbutup.Enabled = false;
            imgbutdown.ImageUrl = "~/images/ArrowDown.png";
            imgbutdown.Enabled = false;
        }
        if (Page.User.Identity.Name == "Administrator" || Page.User.Identity.Name == username.Text)
        {
            mybutton.Visible = true;
        }

        Label label10 = (Label)e.Item.FindControl("Label10");
        string sql = "SELECT COUNT(*) FROM VoteComment WHERE userid='" + Page.User.Identity.Name + "' AND commentid='" + label10.Text + "'";
        SqlConnection con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        int count = (Int32)cmd.ExecuteScalar();
        if (count > 0)
        {
            imgbutup.ImageUrl = "~/images/Arrow-Up.png";
            imgbutup.Enabled = false;
            imgbutdown.ImageUrl = "~/images/ArrowDown.png";
            imgbutdown.Enabled = false;
        }
    }

    protected void Repeater1_Command(object sender, RepeaterCommandEventArgs e)
    {
        ImageButton imgbutup = (ImageButton)e.Item.FindControl("ImageButton2");
        ImageButton imgbutdown = (ImageButton)e.Item.FindControl("ImageButton3");

        if (e.CommandName == "Delete")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Comment WHERE Commentid=@comid";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@comid", e.CommandArgument);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            string sql1 = "DELETE FROM VoteComment WHERE commentid=@comid";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue("@comid", e.CommandArgument);
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();

            con.Close();
            BindRepeater1();
        }
        if (e.CommandName == "UpVote")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "INSERT INTO VoteComment (userid, commentid) VALUES(@userid,@comid)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userid", Page.User.Identity.Name);
            cmd.Parameters.AddWithValue("@comid", e.CommandArgument);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            string sql2 = "SELECT upvote FROM Comment WHERE Commentid='" + e.CommandArgument + "'";
            cmd = new SqlCommand(sql2, con);
            int up = (Int32)cmd.ExecuteScalar();
            int a = up + 1;
            string sql1 = "UPDATE Comment SET upvote=@up WHERE Commentid='" + e.CommandArgument + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue("@up", a);
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();

            con.Close();
            BindRepeater1();
        }
        if (e.CommandName == "DownVote")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "INSERT INTO VoteComment (userid, commentid) VALUES(@userid,@comid)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userid", Page.User.Identity.Name);
            cmd.Parameters.AddWithValue("@comid", e.CommandArgument);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            Label labeldown = (Label)e.Item.FindControl("Label9");
            int down = Convert.ToInt32(labeldown.Text);
            int a = down + 1;
            string sql1 = "UPDATE Comment SET downvote=@down WHERE Commentid='" + e.CommandArgument + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Parameters.AddWithValue("@down", a);
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();

            con.Close();
            BindRepeater1();
        }
    }

    protected void Button2_click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "INSERT INTO Comment (Userid,Placeid,Comment,Rating,datetime,status,upvote,downvote) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , (SELECT Place_id FROM Place WHERE Place_name = '" + Label1.Text + "'),@comment,@rating,@datetime,@status,@upvote,@down)";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlParameter[] para = new SqlParameter[8];

            para[2] = new SqlParameter("@comment", SqlDbType.VarChar);
            para[2].Value = TextBox3.Text.Trim();
            cmd.Parameters.Add(para[2]);
            para[3] = new SqlParameter("@rating", SqlDbType.Int);
            para[3].Value = RadioButtonList1.SelectedValue;
            cmd.Parameters.Add(para[3]);
            para[4] = new SqlParameter("@datetime", SqlDbType.DateTime);
            para[4].Value = DateTime.Now;
            cmd.Parameters.Add(para[4]);
            para[5] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            para[5].Value = "commented on";
            cmd.Parameters.Add(para[5]);
            cmd.Parameters.AddWithValue("@upvote", 0);
            cmd.Parameters.AddWithValue("@down", 0);
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
            BindRepeater1();
        }
    }

    protected void checkin(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "INSERT INTO Checkin (Userid,Place_id,datetime,status) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , (SELECT Place_id FROM Place WHERE Place_name = '" + Label1.Text + "'),@datetime,@status)";
        string checkin = "checked in";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlParameter[] para = new SqlParameter[4];

            para[2] = new SqlParameter("@datetime", SqlDbType.DateTime);
            para[2].Value = DateTime.Now;
            cmd.Parameters.Add(para[2]);
            para[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            para[3].Value = checkin;
            cmd.Parameters.Add(para[3]);
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
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void Recommend(object sender, EventArgs e)
    {
        if (Request["Place"] != null && DropDownList1.Items.Count != 0)
        {
            place = Request["Place"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Request (Req_by,Req_to,Req_type,Req_place) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , @to,@type, '" + place + "')";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@to", DropDownList1.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@type", "requested you to check out ");
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