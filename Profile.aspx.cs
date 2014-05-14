using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Configuration;

public partial class ProfileUser : System.Web.UI.Page
{
    protected string user;

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox11.Attributes.Add("onFocus", "javascript:if(this.value=='Search for a user'){this.value='';}");
        if (Request["Userid"] != null)
        {
            user = Request["Userid"].ToString();
            Session["user"] = user;

            Page.MaintainScrollPositionOnPostBack = true;

            if (Page.User.Identity.Name == string.Empty || user == null)
            {
                Button8.Visible = false;
                Button10.Visible = false;
                TextBox11.Visible = false;
            }

            int y = DateTime.Now.Year;
            if (!IsPostBack)
            {
                for (int i = y - 10; i > y - 120; i--)
                {
                    Year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }

            SqlConnection con1 = new SqlConnection(GetConnectionString());
            DropDownList2.Items.Clear();
            string sqlq = "SELECT Dis_name,Dis_id FROM District";
            con1.Open();
            SqlCommand com = new SqlCommand(sqlq, con1);
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(com);
            da1.Fill(ds1);
            DropDownList2.DataSource = ds1;
            DropDownList2.DataTextField = "Dis_name";
            DropDownList2.DataValueField = "Dis_id";
            DropDownList2.DataBind();
            con1.Close();


            SqlConnection con2 = new SqlConnection(GetConnectionString());

            string sql4 = "SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "'";
            con2.Open();
            SqlCommand cmd4 = new SqlCommand(sql4, con2);
            SqlDataReader dr4 = null;
            dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                if (user == dr4["Userid"].ToString())
                {
                    Button8.Visible = false;
                }
            }
            con2.Close();

            string sql3 = "SELECT COUNT(*) FROM Friends WHERE (Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') OR Userid='" + user + "') AND (Friendid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') OR Friendid='" + user + "')";
            con2.Open();
            SqlCommand cmd2 = new SqlCommand(sql3, con2);
            Int32 count = (Int32)cmd2.ExecuteScalar();
            if (count == 2)
            {
                Button8.Enabled = false;
                Button9.Visible = true;
                Button6.Visible = true;
                Button8.Text = "You are Friends";
            }
            cmd2.Dispose();
            con2.Close();

            string sql5 = "SELECT COUNT(*) FROM Request WHERE Req_by=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Req_to='" + user + "' AND Req_type='wants to be your friend.'";
            con2.Open();
            cmd2 = new SqlCommand(sql5, con2);
            Int32 count1 = (Int32)cmd2.ExecuteScalar();
            if (count1 == 1)
            {
                Button8.Enabled = false;
                Button8.Text = "Request Sent";
            }
            con2.Close();

            string sql6 = "SELECT COUNT(*) FROM Request WHERE Req_to=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Req_by='" + user + "' AND Req_type='wants to be your friend.'";
            con2.Open();
            cmd2 = new SqlCommand(sql6, con2);
            Int32 count2 = (Int32)cmd2.ExecuteScalar();
            if (count2 == 1)
            {
                Button8.Enabled = false;
                Button8.Text = "Accept Friend Request";
            }
            con2.Close();


            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql1 = "SELECT Place.Place_name,Place.Place_id FROM Place INNER JOIN Checkin ON Checkin.Place_id = Place.Place_id WHERE Userid = '" + user + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            conn.Close();

            string sql2 = "SELECT Friends.*,Users.Name FROM Friends INNER JOIN Users ON Friends.Friendid=Users.Userid WHERE Friends.Userid = '" + user + "'";
            cmd1 = new SqlCommand(sql2, conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            Repeater2.DataSource = ds2;
            Repeater2.DataBind();
            conn.Close();

            string sql7 = "SELECT COUNT(*) FROM (SELECT Friends.*,Users.Name FROM Friends INNER JOIN Users ON Friends.Friendid=Users.Userid WHERE Friends.Userid = '" + user + "') as t";
            cmd1 = new SqlCommand(sql7, conn);
            conn.Open();
            int count3 = (Int32)cmd1.ExecuteScalar();
            Label13.Text = count3.ToString();
            conn.Close();

            string query6 = "SELECT * FROM (SELECT * From Users WHERE Userid = '" + user + "') AS query1 " +
                            "INNER JOIN (SELECT DISTINCT(Comment.datetime),Comment.status,Users.Name,Users.Userid,Place.Place_id,Place.Place_name FROM Comment " +
                            "JOIN Users ON Users.Userid=Comment.Userid JOIN Place ON Comment.Placeid=Place.Place_id UNION ALL " +
                            "SELECT DISTINCT(Checkin.datetime),Checkin.status,Users.Name,Users.Userid,Place.Place_id,Place.Place_name FROM Checkin " +
                            "JOIN Users ON Users.Userid=Checkin.Userid JOIN Place ON Checkin.Place_id=Place.Place_id) AS query2 " +
                            "ON query2.Userid=query1.Userid ORDER BY query2.datetime desc";
            conn.Open();
            SqlCommand cmd6 = new SqlCommand(query6, conn);
            DataSet ds6 = new DataSet();
            SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
            da6.Fill(ds6);
            cmd6.ExecuteNonQuery();
            Repeater3.DataSource = ds6;
            Repeater3.DataBind();
            conn.Close();

            string sql8 = "SELECT * FROM Users WHERE Name LIKE '%"+ TextBox11.Text +"%'";
            cmd1 = new SqlCommand(sql8, conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da8 = new SqlDataAdapter(cmd1);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8);
            Repeater4.DataSource = ds8;
            Repeater4.DataBind();
            conn.Close();

            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(GetConnectionString());
                string sql = "SELECT Users.*,District.Dis_name FROM Users INNER JOIN District ON Users.Dis_id = District.Dis_id WHERE Userid = '" + user + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    Panel6.Visible = false;
                    Label15.Text = "The user you requested is not present in our database.";
                }
                while (dr.Read())
                {
                    if (dr["ProPic"].ToString() != string.Empty)
                    {
                        Image1.ImageUrl = "~/images/ProPic/" + dr["ProPic"].ToString();
                        Bitmap myBitmap = new Bitmap(Server.MapPath("~/images/ProPic/" + dr["ProPic"].ToString()));
                        Image1.Height = 200;
                        Image1.Width = 200;
                    }
                    else
                    {
                        Image1.ImageUrl = "~/images/ProPic/1.jpg";
                        Bitmap myBitmap = new Bitmap(Server.MapPath("~/images/ProPic/1.jpg"));
                        Image1.Height = 200;
                        Image1.Width = 200;
                    }
                    string birth = dr["Birthday"].ToString() + "-" + dr["Birthmonth"].ToString() + "-" + dr["Birthyear"].ToString();

                    Label1.Text = dr["Name"].ToString();
                    this.Title = dr["Name"].ToString();
                    TextBox1.Text = dr["Name"].ToString();
                    Label2.Text = dr["Sex"].ToString();
                    DropDownList1.SelectedValue = dr["Sex"].ToString();
                    Label3.Text = birth;
                    if (dr["Birthyear"].ToString() != String.Empty)
                    {
                        Year.SelectedValue = dr["Birthyear"].ToString();
                    }
                    Session["day"] = dr["Birthday"].ToString();
                    if (dr["Birthmonth"].ToString() != String.Empty)
                    {
                        Month.SelectedValue = dr["Birthmonth"].ToString();
                    }
                    Label4.Text = dr["Occupation"].ToString();
                    if (dr["Occupation"].ToString() != String.Empty)
                    {
                        TextBox8.Text = dr["Occupation"].ToString();
                    }
                    Label5.Text = dr["Dis_name"].ToString();
                    if (dr["Dis_id"].ToString() != String.Empty)
                    {
                        DropDownList2.SelectedValue = dr["Dis_id"].ToString();
                    }
                    Label6.Text = dr["Details"].ToString();
                    if (dr["Details"].ToString() != String.Empty)
                    {
                        TextBox7.Text = dr["Details"].ToString();
                    }
                    Label7.Text = dr["Contact"].ToString();
                    if (dr["Contact"].ToString() != String.Empty)
                    {
                        TextBox4.Text = dr["Contact"].ToString();
                    }
                    Label8.Text = dr["Email"].ToString();
                    if (dr["Email"].ToString() != String.Empty)
                    {
                        TextBox6.Text = dr["Email"].ToString();
                    }

                    if (Page.User.Identity.Name == dr["Username"].ToString())
                    {
                        Button1.Visible = true;
                    }
                }
            }

            Users();
        }
    }

    public string SuggestionList = "";

    protected void Users()
    {
        string queryString = "SELECT * FROM Users ORDER BY Name";

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
                            SuggestionList += "{ label:" + "\"" + reader["Name"].ToString() + "\"" + ", category: " + "\"" + "" + "\" }";
                        }
                        else
                        {
                            SuggestionList += ", { label:" + "\"" + reader["Name"].ToString() + "\"" + ", category: " + "\"" + "" + "\" }";
                        }

                    }
                }
            }
        }
    }

    protected void Search_User(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel8.Visible = false;
        Panel7.Visible = true;
    }

    protected void Reload(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void Add_friend(object sender, EventArgs e)
    {
        if (Request["Userid"] != null)
        {
            user = Request["Userid"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Request (Req_by,Req_to,Req_type) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , '" + user + "',@type)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@type", "wants to be your friend.");
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
    }

    protected void Delete_friend(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        con.Open();
        string sql = "DELETE FROM Friends WHERE (Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Friendid='" + user + "') OR (Friendid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Userid='" + user + "')";
        SqlCommand com = new SqlCommand(sql, con);
        com.ExecuteNonQuery();
        com.Dispose();
        Response.Redirect(Request.RawUrl);
    }

    protected void Update(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = true;
        Panel4.Visible = true;
        Button5.Visible = true;
        Button1.Visible = false;
        Changed1(sender, e);
        if (Session["day"].ToString() != String.Empty)
        {
            Day.SelectedValue = Session["day"].ToString();
        }
    }

    protected void Go_Profile(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Button5.Visible = false;
        Button1.Visible = true;
    }

    protected void Changed1(object sender, EventArgs e)
    {
        if (Month.SelectedItem.ToString() == "January" || Month.SelectedItem.ToString() == "March" || Month.SelectedItem.ToString() == "May" || Month.SelectedItem.ToString() == "July" || Month.SelectedItem.ToString() == "August" || Month.SelectedItem.ToString() == "October" || Month.SelectedItem.ToString() == "December")
        {
            Day.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }
        if (Month.SelectedItem.ToString() == "April" || Month.SelectedItem.ToString() == "June" || Month.SelectedItem.ToString() == "September" || Month.SelectedItem.ToString() == "November")
        {
            Day.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }
        if (Month.SelectedItem.ToString() == "February")
        {
            Day.Items.Clear();
            for (int i = 1; i <= 29; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }
    }

    protected void Username_Changed(object sender, EventArgs e)
    {
        if (TextBox10.Text != string.Empty)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = '" + TextBox10.Text.Trim().ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int result = (Int32)cmd.ExecuteScalar();
            con.Close();
            if (result >= 1)
            {
                Label10.Text = "Username Unavailable!";
                Label10.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label10.Text = "Available!";
                Label10.ForeColor = System.Drawing.Color.Green;
            }
        }

        Page.MaintainScrollPositionOnPostBack = true;
    }

    protected void Update_Info(object sender, EventArgs e)
    {
        string birth = Day.SelectedItem.ToString() + " - " + Month.SelectedItem.ToString() + " - " + Year.SelectedItem.ToString();
        string sql = "UPDATE Users SET Name=@name,Sex=@sex,Birthday=@day,Birthmonth=@month,Birthyear=@year,Dis_id=@disid,Contact=@contact,Email=@email,Occupation=@occupation,Details=@about WHERE Userid='" + Session["user"] + "'";
        SqlConnection con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
        cmd.Parameters.AddWithValue("@sex", DropDownList1.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@day", Day.SelectedValue);
        cmd.Parameters.AddWithValue("@month", Month.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@year", Year.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@disid", DropDownList2.SelectedValue);
        cmd.Parameters.AddWithValue("@contact", TextBox4.Text.Trim());
        cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());
        cmd.Parameters.AddWithValue("@occupation", TextBox8.Text.Trim());
        cmd.Parameters.AddWithValue("@about", TextBox7.Text.Trim());
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        Response.Redirect("Profile.aspx?Userid=" + Session["user"]);
    }

    protected void Update_Password(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd;
        string sql1 = "SELECT Password From Users WHERE Userid='" + Session["user"] + "'";
        cmd = new SqlCommand(sql1, con);
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (TextBox3.Text == TextBox5.Text && TextBox2.Text == dr["Password"].ToString())
            {
                string sql = "UPDATE Users SET Password=@password WHERE Userid='" + Session["user"] + "'";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@password", TextBox3.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                Response.Redirect("Profile.aspx?Userid=" + Session["user"]);
            }
            string error = "";
            if (TextBox3.Text == TextBox5.Text)
            {
                error = "Password didn't Match! ";
                Label11.Text = error;
            }
            if (TextBox2.Text == dr["Password"].ToString())
            {
                error += "Old password is incorrect!";
                Label11.Text = error;
            }
        }
    }

    protected void Update_Username(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        con.Open();
        SqlCommand cmd;
        string sql1 = "SELECT Username From Users WHERE Userid='" + Session["user"] + "'";
        cmd = new SqlCommand(sql1, con);
        SqlDataReader dr = null;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            if (TextBox9.Text == dr["Username"].ToString() && Label10.Text == "Available!")
            {
                string sql = "UPDATE Users SET Username=@username WHERE Userid='" + Session["user"] + "'";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@username", TextBox10.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                Response.Redirect("Profile.aspx?Userid=" + Session["user"]);
            }
            else
            {
                Label12.Text = "Username didn't match!";
            }
        }
    }

    protected void Recom_Friend(object sender, EventArgs e)
    {
        if (Panel5.Visible == true)
        {
            Panel5.Visible = false;
        }
        else
        {
            Panel5.Visible = true;
        }

        Drop1();
    }

    protected void Drop1()
    {
        if (Request["Userid"] != null)
        {
            user = Request["Userid"].ToString();
        }
        SqlConnection con1 = new SqlConnection(GetConnectionString());
        string sql5 = "SELECT Friends.Friendid,Users.Name FROM Friends INNER JOIN Users ON Friends.Friendid=Users.Userid WHERE Friends.Userid=(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') AND Friends.Friendid NOT IN (SELECT Req_friend From Request WHERE Req_by=(SELECT Userid FROM Users WHERE Req_friend IS NOT NULL  AND Username = '" + Page.User.Identity.Name + "') AND Req_to='" + user + "') AND Friends.Friendid NOT IN ('" + user + "') AND Friends.Friendid NOT IN (SELECT Friends.Friendid From Friends WHERE Friends.Userid='" + user + "')";
        con1.Open();
        SqlCommand cmd6 = new SqlCommand(sql5, con1);
        cmd6 = new SqlCommand(sql5, con1);
        DataSet ds5 = new DataSet();
        SqlDataAdapter da5 = new SqlDataAdapter(cmd6);
        da5.Fill(ds5);
        DropDownList3.DataSource = ds5;
        DropDownList3.DataTextField = "Name";
        DropDownList3.DataValueField = "Friendid";
        DropDownList3.DataBind();
        con1.Close();
    }

    protected void Recommend(object sender, EventArgs e)
    {
        if (Request["Userid"] != null && DropDownList3.Items.Count != 0)
        {
            user = Request["Userid"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Request (Req_by,Req_to,Req_type,Req_friend) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , @to,@type, '" + DropDownList3.SelectedValue + "')";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@to", user);
                cmd.Parameters.AddWithValue("@type", "suggested you to add " + DropDownList3.SelectedItem.ToString() + " as friend.");
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
                Label14.Text = "Suggestion sent.";
                Drop1();
            }
        }
        else
        {
            Label14.Text = "No friends to suggest.";
        }
    }
}