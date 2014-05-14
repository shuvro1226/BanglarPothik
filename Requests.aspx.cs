using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Requests : System.Web.UI.Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;

        if (!IsPostBack)
        {
            this.Title = "Notification";
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "SELECT Request.*,Users.* FROM Request INNER JOIN Users ON Request.Req_by=Users.Userid WHERE Req_to=(SELECT Userid FROM Users WHERE Username='" + Page.User.Identity.Name + "') AND Req_place IS NULL AND Req_trip IS NULL AND Req_friend IS NULL";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            cmd.Dispose();
            con.Close();

            string sql2 = "SELECT Request.*,Users.*,Place.* FROM Request INNER JOIN Users ON Request.Req_by=Users.Userid INNER JOIN Place ON Request.Req_place=Place.Place_id WHERE Req_to=(SELECT Userid FROM Users WHERE Username='" + Page.User.Identity.Name + "') AND Req_place IS NOT NULL AND Req_trip IS NULL";
            con.Open();
            cmd = new SqlCommand(sql2, con);
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(ds2);
            cmd.ExecuteNonQuery();
            Repeater2.DataSource = ds2;
            Repeater2.DataBind();
            cmd.Dispose();
            con.Close();

            string sql3 = "SELECT Request.*,Users.*,TripDetail.* FROM Request INNER JOIN Users ON Request.Req_by=Users.Userid INNER JOIN TripDetail ON Request.Req_trip=TripDetail.Tripid WHERE Req_to=(SELECT Userid FROM Users WHERE Username='" + Page.User.Identity.Name + "') AND Req_place IS NULL AND Req_trip IS NOT NULL";
            con.Open();
            cmd = new SqlCommand(sql3, con);
            DataSet ds3 = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd);
            da3.Fill(ds3);
            cmd.ExecuteNonQuery();
            Repeater3.DataSource = ds3;
            Repeater3.DataBind();
            cmd.Dispose();
            con.Close();

            string sql4 = "SELECT Request.*,Users.* FROM Request INNER JOIN Users ON Request.Req_by=Users.Userid WHERE Req_to=(SELECT Userid FROM Users WHERE Username='" + Page.User.Identity.Name + "') AND Req_friend IS NOT NULL";
            con.Open();
            cmd = new SqlCommand(sql4, con);
            DataSet ds4 = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd);
            da4.Fill(ds4);
            cmd.ExecuteNonQuery();
            Repeater4.DataSource = ds4;
            Repeater4.DataBind();
            cmd.Dispose();
            con.Close();
        }
    }

    protected void ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Accept")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='"+e.CommandArgument+"'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();

            Label label3 = (Label)e.Item.FindControl("Label3");

            string sql2 = "INSERT INTO Friends (Userid,Friendid) VALUES((SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "') , '" + label3.Text + "')" +
                "INSERT INTO Friends (Userid,Friendid) VALUES('" + label3.Text + "',(SELECT Userid FROM Users WHERE Username = '" + Page.User.Identity.Name + "'))";

            try
            {
                SqlCommand cmd = new SqlCommand(sql2, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                Response.Redirect(Request.RawUrl);
            }

            con.Close();
        }

        if (e.CommandName == "Reject")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='" + e.CommandArgument + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void Repeater1_Databound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptDemo = sender as Repeater; 
        if (Repeater1 != null && Repeater1.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblErrorMsg = e.Item.FindControl("lblErrorMsg1") as Label;
                if (lblErrorMsg != null)
                {
                    lblErrorMsg.Visible = true;
                }
            }
        }
    }

    protected void ItemCommand2(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Check")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='"+e.CommandArgument+"'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();

            Label label4 = (Label)e.Item.FindControl("Label4");
            Response.Redirect("Place.aspx?Place=" + label4.Text);
            
        }

        if (e.CommandName == "Ignore")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='" + e.CommandArgument + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void Repeater2_Databound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptDemo = sender as Repeater; 
        if (Repeater2 != null && Repeater2.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblErrorMsg = e.Item.FindControl("lblErrorMsg") as Label;
                if (lblErrorMsg != null)
                {
                    lblErrorMsg.Visible = true;
                }
            }
        }
    }

    protected void ItemCommand3(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Check2")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='" + e.CommandArgument + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();

            Label label5 = (Label)e.Item.FindControl("Label5");
            Response.Redirect("Trips.aspx?Tripid=" + label5.Text);

        }

        if (e.CommandName == "Ignore2")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='" + e.CommandArgument + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void Repeater3_Databound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptDemo = sender as Repeater;
        if (Repeater3 != null && Repeater3.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblErrorMsg2 = e.Item.FindControl("lblErrorMsg2") as Label;
                if (lblErrorMsg2 != null)
                {
                    lblErrorMsg2.Visible = true;
                }
            }
        }
    }

    protected void ItemCommand4(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Accept")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='" + e.CommandArgument + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();

            Label label3 = (Label)e.Item.FindControl("Label3");

            Response.Redirect("Profile.aspx?Userid=" + label3.Text);
        }

        if (e.CommandName == "Reject")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql = "DELETE FROM Request WHERE Requestid='" + e.CommandArgument + "'";
            SqlCommand com = new SqlCommand(sql, con);
            com.ExecuteNonQuery();
            com.Dispose();
            con.Close();
            Response.Redirect(Request.RawUrl);
        }
    }

    protected void Repeater4_Databound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptDemo = sender as Repeater;
        if (Repeater4 != null && Repeater4.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblErrorMsg = e.Item.FindControl("lblErrorMsg1") as Label;
                if (lblErrorMsg != null)
                {
                    lblErrorMsg.Visible = true;
                }
            }
        }
    }
}