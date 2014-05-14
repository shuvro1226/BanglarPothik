using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class DataEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(GetConnectionString());
        if (!IsPostBack)
        {
            this.Title = "Edit Data";
            string sql = "SELECT Div_name,Div_id FROM Division";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "Div_name";
            DropDownList1.DataValueField = "Div_id";
            DropDownList1.DataBind();
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "Div_name";
            DropDownList3.DataValueField = "Div_id";
            DropDownList3.DataBind();
            
            string sql1 = "SELECT Cat_id,Cat_name FROM Category";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);
            DropDownList5.DataSource = ds1;
            DropDownList5.DataTextField = "Cat_name";
            DropDownList5.DataValueField = "Cat_id";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("Select", "-1"));

            string sql3 = "SELECT * FROM District";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            DataSet ds3 = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(ds3);
            DropDownList16.DataSource = ds3;
            DropDownList16.DataTextField = "Dis_name";
            DropDownList16.DataValueField = "Dis_id";
            DropDownList16.DataBind();
            DropDownList16.Items.Insert(0, new ListItem("", "-1"));
            DropDownList17.DataSource = ds3;
            DropDownList17.DataTextField = "Dis_name";
            DropDownList17.DataValueField = "Dis_id";
            DropDownList17.DataBind();
            DropDownList17.Items.Insert(0, new ListItem("", "-1"));
            DropDownList18.DataSource = ds3;
            DropDownList18.DataTextField = "Dis_name";
            DropDownList18.DataValueField = "Dis_id";
            DropDownList18.DataBind();
            DropDownList18.Items.Insert(0, new ListItem("", "-1"));
            DropDownList19.DataSource = ds3;
            DropDownList19.DataTextField = "Dis_name";
            DropDownList19.DataValueField = "Dis_id";
            DropDownList19.DataBind();
            DropDownList19.Items.Insert(0, new ListItem("", "-1"));
            DropDownList20.DataSource = ds3;
            DropDownList20.DataTextField = "Dis_name";
            DropDownList20.DataValueField = "Dis_id";
            DropDownList20.DataBind();
            DropDownList20.Items.Insert(0, new ListItem("", "-1"));
            DropDownList21.DataSource = ds3;
            DropDownList21.DataTextField = "Dis_name";
            DropDownList21.DataValueField = "Dis_id";
            DropDownList21.DataBind();
            DropDownList21.Items.Insert(0, new ListItem("", "-1"));

            string sql4 = "SELECT * FROM Place";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            DataSet ds4 = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(ds4);
            DropDownList7.DataSource = ds4;
            DropDownList7.DataTextField = "Place_name";
            DropDownList7.DataValueField = "Place_id";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("", "-1"));
            DropDownList8.DataSource = ds4;
            DropDownList8.DataTextField = "Place_name";
            DropDownList8.DataValueField = "Place_id";
            DropDownList8.DataBind();
            DropDownList8.Items.Insert(0, new ListItem("", "-1"));
            DropDownList9.DataSource = ds4;
            DropDownList9.DataTextField = "Place_name";
            DropDownList9.DataValueField = "Place_id";
            DropDownList9.DataBind();
            DropDownList9.Items.Insert(0, new ListItem("", "-1"));
            DropDownList10.DataSource = ds4;
            DropDownList10.DataTextField = "Place_name";
            DropDownList10.DataValueField = "Place_id";
            DropDownList10.DataBind();
            DropDownList10.Items.Insert(0, new ListItem("", "-1"));
            DropDownList11.DataSource = ds4;
            DropDownList11.DataTextField = "Place_name";
            DropDownList11.DataValueField = "Place_id";
            DropDownList11.DataBind();
            DropDownList11.Items.Insert(0, new ListItem("", "-1"));
            DropDownList12.DataSource = ds4;
            DropDownList12.DataTextField = "Place_name";
            DropDownList12.DataValueField = "Place_id";
            DropDownList12.DataBind();
            DropDownList12.Items.Insert(0, new ListItem("", "-1"));
            DropDownList13.DataSource = ds4;
            DropDownList13.DataTextField = "Place_name";
            DropDownList13.DataValueField = "Place_id";
            DropDownList13.DataBind();
            DropDownList13.Items.Insert(0, new ListItem("", "-1"));
            DropDownList14.DataSource = ds4;
            DropDownList14.DataTextField = "Place_name";
            DropDownList14.DataValueField = "Place_id";
            DropDownList14.DataBind();
            DropDownList14.Items.Insert(0, new ListItem("", "-1"));
            DropDownList15.DataSource = ds4;
            DropDownList15.DataTextField = "Place_name";
            DropDownList15.DataValueField = "Place_id";
            DropDownList15.DataBind();
            DropDownList15.Items.Insert(0, new ListItem("", "-1"));

            string sql5 = "SELECT * FROM TravelAgency";
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            DataSet ds5 = new DataSet();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            da5.Fill(ds5);
            DropDownList22.DataSource = ds5;
            DropDownList22.DataTextField = "Agencyname";
            DropDownList22.DataValueField = "Agencyid";
            DropDownList22.DataBind();

            string sql2 = "SELECT Dis_name,Dis_id FROM District WHERE Div_id = '" + DropDownList3.SelectedValue + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds2);
            DropDownList4.DataSource = ds2;
            DropDownList4.DataTextField = "Dis_name";
            DropDownList4.DataValueField = "Dis_id";
            DropDownList4.DataBind();

            string sql6 = "SELECT * FROM TripType";
            SqlCommand cmd6 = new SqlCommand(sql6, conn);
            DataSet ds6 = new DataSet();
            SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
            da6.Fill(ds6);
            DropDownList6.DataSource = ds6;
            DropDownList6.DataTextField = "Typename";
            DropDownList6.DataValueField = "Typeid";
            DropDownList6.DataBind();
            DropDownList15.Items.Insert(0, new ListItem("Select Type", "-1"));
        }


        GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
        GridView2.RowStyle.HorizontalAlign = HorizontalAlign.Center;

        Page.MaintainScrollPositionOnPostBack = true;
    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Row(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Panel1.Visible = true;
            string name = e.CommandArgument.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql1 = "SELECT * FROM District WHERE Dis_id = '" + name + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlDataReader dr = null;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                dis.Text = dr["Dis_name"].ToString();
                DropDownList1.SelectedValue = dr["Div_id"].ToString();
                Area.Text = dr["Area"].ToString();
                Distance.Text = dr["Distance"].ToString();
                Rivers.Text = dr["Rivers"].ToString();
                Details.InnerText = dr["Details"].ToString();
                Button1.Text = "Update " + dr["Dis_name"].ToString();
                Session["Disid"] = dr["Dis_id"].ToString();
            }
        }

        if (e.CommandName == "Delete")
        {
            Session["name"] = e.CommandArgument.ToString();
            Panel2.Visible = true;
        }
    }

    protected void Row2(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Panel4.Visible = true;
            string name = e.CommandArgument.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql1 = "SELECT * FROM Place WHERE Place_id = '" + name + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlDataReader dr = null;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                SqlConnection conn = new SqlConnection(GetConnectionString());
                string sql2 = "SELECT Dis_name,Dis_id FROM District WHERE Div_id = '" + dr["Div_id"].ToString() + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds2);
                DropDownList4.DataSource = ds2;
                DropDownList4.DataTextField = "Dis_name";
                DropDownList4.DataValueField = "Dis_id";
                DropDownList4.DataBind();
                TextBox2.Text = dr["Place_name"].ToString();
                TextBox1.Text = dr["Coordinates"].ToString();
                DropDownList3.SelectedValue = dr["Div_id"].ToString();
                DropDownList4.SelectedValue = dr["Dis_id"].ToString();
                DropDownList5.SelectedValue = dr["Cat_id"].ToString();
                textarea2.InnerText = dr["Details"].ToString();
                Button6.Text = "Update " + dr["Place_name"].ToString();
                Session["Placeid"] = dr["Place_id"].ToString();
            }
        }

        if (e.CommandName == "Delete")
        {
            Session["name2"] = e.CommandArgument.ToString();
            Panel5.Visible = true;
        }
    }

    protected void Row3(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Panel7.Visible = true;
            string name = e.CommandArgument.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql1 = "SELECT * FROM TravelAgency WHERE Agencyid = '" + name + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlDataReader dr = null;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                TextBox4.Text = dr["Agencyname"].ToString();
                TextBox5.Text = dr["Address"].ToString();
                TextBox7.Text = dr["Contact"].ToString();
                TextBox9.Text = dr["Email"].ToString();
                TextBox8.Text = dr["Url"].ToString();
                textarea1.InnerText = dr["About"].ToString();
                Button9.Text = "Update " + dr["Agencyname"].ToString();
                Session["Agencyid"] = dr["Agencyid"].ToString();
            }
        }

        if (e.CommandName == "Delete")
        {
            Session["name3"] = e.CommandArgument.ToString();
            Panel8.Visible = true;
        }
    }

    protected void Row4(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            Panel10.Visible = true;
            string name = e.CommandArgument.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string sql1 = "SELECT * FROM TripDetail WHERE Tripid = '" + name + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlDataReader dr = null;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                TextBox6.Text = dr["Tripname"].ToString();
                TextBox10.Text = dr["Duration"].ToString();
                TextBox11.Text = dr["Cost"].ToString();
                DropDownList16.SelectedValue = dr["Disid1"].ToString();
                DropDownList17.SelectedValue = dr["Disid2"].ToString();
                DropDownList18.SelectedValue = dr["Disid3"].ToString();
                DropDownList19.SelectedValue = dr["Disid4"].ToString();
                DropDownList20.SelectedValue = dr["Disid5"].ToString();
                DropDownList21.SelectedValue = dr["Disid6"].ToString();
                DropDownList7.SelectedValue = dr["Placeid1"].ToString();
                DropDownList8.SelectedValue = dr["Placeid2"].ToString();
                DropDownList9.SelectedValue = dr["Placeid3"].ToString();
                DropDownList10.SelectedValue = dr["Placeid4"].ToString();
                DropDownList11.SelectedValue = dr["Placeid5"].ToString();
                DropDownList12.SelectedValue = dr["Placeid6"].ToString();
                DropDownList13.SelectedValue = dr["Placeid7"].ToString();
                DropDownList14.SelectedValue = dr["Placeid8"].ToString();
                DropDownList15.SelectedValue = dr["Placeid9"].ToString();
                DropDownList22.SelectedValue = dr["Agencyid"].ToString();
                DropDownList6.SelectedValue = dr["Type"].ToString();
                textarea3.InnerText = dr["Detail"].ToString();
                Button12.Text = "Update " + dr["Tripname"].ToString();
                Session["Tripid"] = dr["Tripid"].ToString();
            }
        }

        if (e.CommandName == "Delete")
        {
            Session["name4"] = e.CommandArgument.ToString();
            Panel11.Visible = true;
        }
    }

    protected void drpdwn2chng(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue == "1")
        {
            Panel1.Visible = true;
            Panel3.Visible = true;
            Panel4.Visible = false;
            Panel6.Visible = false;
            Panel7.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel12.Visible = false;
        }
        if (DropDownList2.SelectedValue == "2")
        {
            Panel4.Visible = true;
            Panel6.Visible = true;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel7.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = false;
            Panel12.Visible = false;
        }
        if (DropDownList2.SelectedValue == "3")
        {
            Panel4.Visible = false;
            Panel6.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel7.Visible = true;
            Panel9.Visible = true;
            Panel10.Visible = false;
            Panel12.Visible = false;
        }
        if (DropDownList2.SelectedValue == "4")
        {
            Panel4.Visible = false;
            Panel6.Visible = false;
            Panel1.Visible = false;
            Panel3.Visible = false;
            Panel7.Visible = false;
            Panel9.Visible = false;
            Panel10.Visible = true;
            Panel12.Visible = true;
        }
    }

    protected void Yes(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "DELETE FROM District WHERE Dis_id = '" + Session["name"].ToString() + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        GridView1.DataBind();
        Panel2.Visible = false;
    }

    protected void Yes1(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "DELETE FROM Place WHERE Place_id = '" + Session["name2"].ToString() + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        GridView2.DataBind();
        Panel5.Visible = false;
    }

    protected void Yes3(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "DELETE FROM TravelAgency WHERE Agencyid = '" + Session["name3"].ToString() + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        GridView2.DataBind();
        Panel8.Visible = false;
    }

    protected void Yes4(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "DELETE FROM TripDetail WHERE Tripid = '" + Session["name4"].ToString() + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
        GridView2.DataBind();
        Panel11.Visible = false;
    }

    protected void No(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel5.Visible = false;
        Panel8.Visible = false;
        Panel11.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "UPDATE District SET Dis_name=@district, Div_id=@divid, Area=@area, Distance=@distance, Rivers=@rivers, Details=@details WHERE Dis_id='"+ Session["Disid"].ToString() +"'";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@district", dis.Text.Trim());
            cmd.Parameters.AddWithValue("@divid", DropDownList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@area", Area.Text.Trim());
            cmd.Parameters.AddWithValue("@distance", Distance.Text.Trim());
            cmd.Parameters.AddWithValue("@rivers", Rivers.Text.Trim());
            cmd.Parameters.AddWithValue("@details", Details.InnerText.Trim());
            cmd.ExecuteNonQuery();
            Label2.Text = dis.Text + " updated successfully";
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
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "UPDATE Place SET Place_name=@place, Div_id=@divid, Dis_id=@disid, Cat_id=@catid, Coordinates=@coordinates, Details=@details WHERE Place_id='" + Session["Placeid"].ToString() + "'";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@place", TextBox2.Text.Trim().ToString());
            cmd.Parameters.AddWithValue("@divid", DropDownList3.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@disid", DropDownList4.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@catid", DropDownList5.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@coordinates", TextBox1.Text.Trim().ToString());
            cmd.Parameters.AddWithValue("@details", textarea2.InnerText.ToString());
            cmd.ExecuteNonQuery();
            Label5.Text = TextBox2.Text + " updated successfully";
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
        }
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "UPDATE TravelAgency SET Agencyname=@name, Address=@address, Contact=@contact, Email=@email, Url=@url, About=@about WHERE Agencyid='" + Session["Agencyid"].ToString() + "'";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@address", TextBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@contact", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@email", TextBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@url", TextBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@about", textarea1.InnerText.Trim());
            cmd.ExecuteNonQuery();
            Label8.Text = TextBox4.Text.Trim().ToString() + " updated successfully";
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
        }
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "UPDATE TripDetail SET Agencyid=@agency,Placeid1=@place1,Placeid2=@place2,Placeid3=@place3,Placeid4=@place4,Placeid5=@place5,Placeid6=@place6,Placeid7=@place7,Placeid8=@place8,Placeid9=@place9,Disid1=@dis1,Disid2=@dis2,Disid3=@dis3,Disid4=@dis4,Disid5=@dis5,Disid6=@dis6,Tripname=@name,Duration=@duration,Cost=@cost,Type=@type,Detail=@detail WHERE Tripid='" + Session["Tripid"].ToString() + "'";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@duration", TextBox10.Text.Trim());
            cmd.Parameters.AddWithValue("@cost", TextBox11.Text.Trim());
            cmd.Parameters.AddWithValue("@dis1", DropDownList16.SelectedValue);
            cmd.Parameters.AddWithValue("@dis2", DropDownList17.SelectedValue);
            cmd.Parameters.AddWithValue("@dis3", DropDownList18.SelectedValue);
            cmd.Parameters.AddWithValue("@dis4", DropDownList19.SelectedValue);
            cmd.Parameters.AddWithValue("@dis5", DropDownList20.SelectedValue);
            cmd.Parameters.AddWithValue("@dis6", DropDownList21.SelectedValue);
            cmd.Parameters.AddWithValue("@place1", DropDownList7.SelectedValue);
            cmd.Parameters.AddWithValue("@place2", DropDownList8.SelectedValue);
            cmd.Parameters.AddWithValue("@place3", DropDownList9.SelectedValue);
            cmd.Parameters.AddWithValue("@place4", DropDownList10.SelectedValue);
            cmd.Parameters.AddWithValue("@place5", DropDownList11.SelectedValue);
            cmd.Parameters.AddWithValue("@place6", DropDownList12.SelectedValue);
            cmd.Parameters.AddWithValue("@place7", DropDownList13.SelectedValue);
            cmd.Parameters.AddWithValue("@place8", DropDownList14.SelectedValue);
            cmd.Parameters.AddWithValue("@place9", DropDownList15.SelectedValue);
            cmd.Parameters.AddWithValue("@agency", DropDownList22.SelectedValue);
            cmd.Parameters.AddWithValue("@type", DropDownList6.SelectedValue);
            cmd.Parameters.AddWithValue("@detail", textarea3.InnerText.Trim());
            cmd.ExecuteNonQuery();
            Label11.Visible = true;
            Label11.Text = TextBox6.Text.Trim().ToString() + " updated successfully";
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
        }
    }

    protected void Division_Changed(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        DropDownList4.Items.Clear();
        string sql1 = "SELECT Dis_name,Dis_id FROM District WHERE Div_id = '" + DropDownList3.SelectedValue + "'";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(sql1, con);
        DataSet ds1 = new DataSet();
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        da1.Fill(ds1);
        DropDownList4.DataSource = ds1;
        DropDownList4.DataTextField = "Dis_name";
        DropDownList4.DataValueField = "Dis_id";
        DropDownList4.DataBind();
        con.Close();
    }
}