using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class AddInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Add Info";
        SqlConnection con = new SqlConnection(GetConnectionString());
        if (!IsPostBack)
        {
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
            DropDownList1.Items.Insert(0, new ListItem("Select", "-1"));
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "Div_name";
            DropDownList3.DataValueField = "Div_id";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Select", "-1"));

            string sql1 = "SELECT Cat_id,Cat_name FROM Category";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);
            DropDownList5.DataSource = ds1;
            DropDownList5.DataTextField = "Cat_name";
            DropDownList5.DataValueField = "Cat_id";
            DropDownList5.DataBind();

            string sql3 = "SELECT * FROM District";
            SqlCommand cmd3 = new SqlCommand(sql3, con);
            DataSet ds3 = new DataSet();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            da3.Fill(ds3);
            DropDownList16.DataSource = ds3;
            DropDownList16.DataTextField = "Dis_name";
            DropDownList16.DataValueField = "Dis_id";
            DropDownList16.DataBind();
            DropDownList16.Items.Insert(0, new ListItem("District 1", "-1"));
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
            SqlCommand cmd4 = new SqlCommand(sql4, con);
            DataSet ds4 = new DataSet();
            SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
            da4.Fill(ds4);
            DropDownList7.DataSource = ds4;
            DropDownList7.DataTextField = "Place_name";
            DropDownList7.DataValueField = "Place_id";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, new ListItem("Place 1", "-1"));
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
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            DataSet ds5 = new DataSet();
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            da5.Fill(ds5);
            DropDownList2.DataSource = ds5;
            DropDownList2.DataTextField = "Agencyname";
            DropDownList2.DataValueField = "Agencyid";
            DropDownList2.DataBind();

            string sql6 = "SELECT * FROM TripType";
            SqlCommand cmd6 = new SqlCommand(sql6, con);
            DataSet ds6 = new DataSet();
            SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
            da6.Fill(ds6);
            DropDownList6.DataSource = ds6;
            DropDownList6.DataTextField = "Typename";
            DropDownList6.DataValueField = "Typeid";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, new ListItem("Select Type", "-1"));
        }

        Page.MaintainScrollPositionOnPostBack = true;
        
    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "INSERT INTO Division (Div_name) VALUES (@division)";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlParameter[] para = new SqlParameter[1];

            para[0] = new SqlParameter("@division", SqlDbType.VarChar, 20);
            para[0].Value = TextBox3.Text.ToString();
            cmd.Parameters.Add(para[0]);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            Label3.Visible = true;
            Label3.Text = "Division added successfully";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (MapUpload.HasFile && District.Text.ToString() != "" && DropDownList1.SelectedItem.ToString() != "Select" && Area.Text.ToString() != "" && Distance.Text.ToString() != "" && Details.InnerText.ToString() != "")
        {
            string division = DropDownList1.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO District (Dis_name,Div_id,Area,Distance,Map,Rivers,Details) VALUES (@district,(SELECT Div_id FROM Division WHERE Div_name = '"+division+"'),@area,@distance,@map,@rivers,@details)";

            try
            {
                MapUpload.SaveAs(Server.MapPath("~/images/Districts/" + MapUpload.FileName));
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] para = new SqlParameter[8];

                para[0] = new SqlParameter("@district", SqlDbType.VarChar, 20);
                para[0].Value = District.Text.ToString();
                cmd.Parameters.Add(para[0]);
                para[2] = new SqlParameter("@area", SqlDbType.VarChar, 10);
                para[2].Value = Area.Text.ToString();
                cmd.Parameters.Add(para[2]);
                para[3] = new SqlParameter("@distance", SqlDbType.VarChar, 50);
                para[3].Value = Distance.Text.ToString();
                cmd.Parameters.Add(para[3]);
                para[4] = new SqlParameter("@map", SqlDbType.VarChar, 50);
                para[4].Value = MapUpload.FileName.ToString();
                cmd.Parameters.Add(para[4]);
                para[5] = new SqlParameter("@rivers", SqlDbType.VarChar, 50);
                para[5].Value = Rivers.Text.ToString();
                cmd.Parameters.Add(para[5]);
                para[6] = new SqlParameter("@details", SqlDbType.VarChar);
                para[6].Value = Details.InnerText.ToString();
                cmd.Parameters.Add(para[6]);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Label1.Visible = true;
                Label1.Text = District.Text.ToString()  + " added successfully";
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
        else
        {
            Label1.Visible = true;
            Label1.Text = "You must select & fill all fields";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox4.Text.ToString() != "" && TextBox5.Text.ToString() != "" && TextBox7.Text.ToString() != "" && TextBox8.Text.ToString() != "" && textarea1.InnerText.ToString() != "")
        {
            string division = DropDownList1.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO TravelAgency (Agencyname,Address,Contact,Email,Url,About) VALUES (@agency,@address,@contact,@email,@url,@about)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] para = new SqlParameter[7];

                para[0] = new SqlParameter("@agency", SqlDbType.VarChar, 100);
                para[0].Value = TextBox4.Text.ToString();
                cmd.Parameters.Add(para[0]);
                para[1] = new SqlParameter("@address", SqlDbType.VarChar, 200);
                para[1].Value = TextBox5.Text.ToString();
                cmd.Parameters.Add(para[1]);
                para[3] = new SqlParameter("@contact", SqlDbType.VarChar, 500);
                para[3].Value = TextBox7.Text.ToString();
                cmd.Parameters.Add(para[3]);
                para[4] = new SqlParameter("@email", SqlDbType.VarChar, 100);
                para[4].Value = TextBox9.Text.ToString();
                cmd.Parameters.Add(para[4]);
                para[5] = new SqlParameter("@url", SqlDbType.VarChar, 50);
                para[5].Value = TextBox8.Text.ToString();
                cmd.Parameters.Add(para[5]);
                para[6] = new SqlParameter("@about", SqlDbType.VarChar);
                para[6].Value = textarea1.InnerText.ToString();
                cmd.Parameters.Add(para[6]);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Label4.Visible = true;
                Label4.Text = TextBox4.Text.ToString() + " added successfully";
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
        else
        {
            Label1.Visible = true;
            Label1.Text = "You must select & fill all fields";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload2.HasFile && DropDownList3.SelectedItem.ToString() != "Select" && DropDownList4.SelectedItem.ToString() != "Select" && DropDownList5.SelectedItem.ToString() != "Select" && TextBox2.Text.ToString() != "" && textarea2.InnerText.ToString() != "")
        {
            string division = DropDownList3.SelectedItem.ToString();
            string district = DropDownList4.SelectedItem.ToString();
            string category = DropDownList5.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Place (Place_name,Div_id,Dis_id,Cat_id,Image,Details,Coordinates) VALUES(@name,(SELECT Div_id FROM Division WHERE Div_name = '" + division + "') , (SELECT Dis_id FROM District WHERE Dis_name = '" + district + "'),(SELECT Cat_id FROM Category WHERE Cat_name = '" + category + "'),@image,@details,@coordinates)";

            try
            {
                FileUpload2.SaveAs(Server.MapPath("~/images/Place/" + FileUpload2.FileName));
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] para = new SqlParameter[7];

                para[0] = new SqlParameter("@name", SqlDbType.VarChar, 100);
                para[0].Value = TextBox2.Text.ToString();
                cmd.Parameters.Add(para[0]);
                para[4] = new SqlParameter("@image", SqlDbType.VarChar, 50);
                para[4].Value = FileUpload2.FileName.ToString();
                cmd.Parameters.Add(para[4]);
                para[5] = new SqlParameter("@details", SqlDbType.VarChar);
                para[5].Value = textarea2.InnerText.ToString();
                cmd.Parameters.Add(para[5]);
                para[6] = new SqlParameter("@coordinates", SqlDbType.VarChar, 50);
                para[6].Value = TextBox1.Text.ToString();
                cmd.Parameters.Add(para[6]);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Label2.Visible = true;
                Label2.Text = TextBox2.Text.ToString() + " added successfully";
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
        else
        {
            Label1.Visible = true;
            Label1.Text = "You must select & fill all fields";
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox6.Text.ToString() != "" && DropDownList7.SelectedValue.ToString() != "-1" && DropDownList16.SelectedValue.ToString() != "-1" && DropDownList6.SelectedValue.ToString() != "-1" && textarea3.InnerText.ToString() != "")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO TripDetail (Agencyid,Placeid1,Placeid2,Placeid3,Placeid4,Placeid5,Placeid6,Placeid7,Placeid8,Placeid9,Disid1,Disid2,Disid3,Disid4,Disid5,Disid6,Tripname,Duration,Cost,Type,Detail) VALUES (@agency,@place1,@place2,@place3,@place4,@place5,@place6,@place7,@place8,@place9,@district1,@district2,@district3,@district4,@district5,@district6,@tripname,@duration,@cost,@type,@detail)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] para = new SqlParameter[21];

                para[0] = new SqlParameter("@agency", SqlDbType.VarChar, 5);
                para[0].Value = DropDownList2.SelectedValue.ToString();
                cmd.Parameters.Add(para[0]);
                para[1] = new SqlParameter("@place1", SqlDbType.VarChar, 6);
                para[1].Value = DropDownList7.SelectedValue;
                cmd.Parameters.Add(para[1]);
                para[2] = new SqlParameter("@place2", SqlDbType.VarChar, 6);
                para[2].Value = DropDownList8.SelectedValue;
                cmd.Parameters.Add(para[2]);
                para[3] = new SqlParameter("@place3", SqlDbType.VarChar, 6);
                para[3].Value = DropDownList9.SelectedValue;
                cmd.Parameters.Add(para[3]);
                para[4] = new SqlParameter("@place4", SqlDbType.VarChar, 6);
                para[4].Value = DropDownList10.SelectedValue;
                cmd.Parameters.Add(para[4]);
                para[5] = new SqlParameter("@place5", SqlDbType.VarChar, 6);
                para[5].Value = DropDownList11.SelectedValue;
                cmd.Parameters.Add(para[5]);
                para[6] = new SqlParameter("@place6", SqlDbType.VarChar, 6);
                para[6].Value = DropDownList12.SelectedValue;
                cmd.Parameters.Add(para[6]);
                para[7] = new SqlParameter("@place7", SqlDbType.VarChar, 6);
                para[7].Value = DropDownList13.SelectedValue;
                cmd.Parameters.Add(para[7]);
                para[8] = new SqlParameter("@place8", SqlDbType.VarChar, 6);
                para[8].Value = DropDownList14.SelectedValue;
                cmd.Parameters.Add(para[8]);
                para[9] = new SqlParameter("@place9", SqlDbType.VarChar, 6);
                para[9].Value = DropDownList15.SelectedValue;
                cmd.Parameters.Add(para[9]);
                para[10] = new SqlParameter("@district1", SqlDbType.VarChar, 5);
                para[10].Value = DropDownList16.SelectedValue;
                cmd.Parameters.Add(para[10]);
                para[11] = new SqlParameter("@district2", SqlDbType.VarChar, 5);
                para[11].Value = DropDownList17.SelectedValue;
                cmd.Parameters.Add(para[11]);
                para[12] = new SqlParameter("@district3", SqlDbType.VarChar, 5);
                para[12].Value = DropDownList18.SelectedValue;
                cmd.Parameters.Add(para[12]);
                para[13] = new SqlParameter("@district4", SqlDbType.VarChar, 5);
                para[13].Value = DropDownList19.SelectedValue;
                cmd.Parameters.Add(para[13]);
                para[14] = new SqlParameter("@district5", SqlDbType.VarChar, 5);
                para[14].Value = DropDownList20.SelectedValue;
                cmd.Parameters.Add(para[14]);
                para[15] = new SqlParameter("@district6", SqlDbType.VarChar, 5);
                para[15].Value = DropDownList21.SelectedValue;
                cmd.Parameters.Add(para[15]);
                para[16] = new SqlParameter("@tripname", SqlDbType.VarChar, 100);
                para[16].Value = TextBox6.Text.ToString();
                cmd.Parameters.Add(para[16]);
                para[17] = new SqlParameter("@duration", SqlDbType.VarChar, 50);
                para[17].Value = TextBox10.Text.ToString();
                cmd.Parameters.Add(para[17]);
                para[18] = new SqlParameter("@cost", SqlDbType.VarChar, 20);
                para[18].Value = TextBox11.Text.ToString();
                cmd.Parameters.Add(para[18]);
                para[19] = new SqlParameter("@type", SqlDbType.VarChar, 20);
                para[19].Value = DropDownList6.SelectedValue;
                cmd.Parameters.Add(para[19]);
                para[20] = new SqlParameter("@detail", SqlDbType.VarChar);
                para[20].Value = textarea3.InnerText.ToString();
                cmd.Parameters.Add(para[20]);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Label5.Visible = true;
                Label5.Text = TextBox6.Text.ToString() + " added successfully";
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
        else
        {
            Label5.Visible = true;
            Label5.Text = "You must select & fill all fields";
        }
    }

    protected void PlaceIndex_Changed(object sender, EventArgs e)
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
        DropDownList4.Items.Insert(0, new ListItem("All", "-1"));
        con.Close();
        if (DropDownList3.SelectedItem.ToString() == "Select")
        {
            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("Select");
        }
    }

    protected void List1_Changed(object sender, EventArgs e)
    {
        if (DropDownList0.SelectedItem.ToString() == "Add a district")
        {
            Table1.Visible = true;
            Table2.Visible = false;
            Table3.Visible = false;
            Table4.Visible = false;
            Table5.Visible = false;
        }
        else if (DropDownList0.SelectedItem.ToString() == "Add a new Place")
        {
            Table1.Visible = false;
            Table2.Visible = true;
            Table3.Visible = false;
            Table4.Visible = false;
            Table5.Visible = false;
        }
        else if (DropDownList0.SelectedItem.ToString() == "Add a division")
        {
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = true;
            Table4.Visible = false;
            Table5.Visible = false;
        }
        else if (DropDownList0.SelectedItem.ToString() == "Add a new Travel Agency")
        {
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            Table4.Visible = true;
            Table5.Visible = false;
        }
        else if (DropDownList0.SelectedItem.ToString() == "Add a new Trip Detail")
        {
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            Table4.Visible = false;
            Table5.Visible = true;
        }
        else if (DropDownList0.SelectedItem.ToString() == "Add a new hotel")
        {
            Table1.Visible = false;
            Table2.Visible = false;
        }
        else if (DropDownList0.SelectedItem.ToString() == "Select")
        {
            Table1.Visible = false;
            Table2.Visible = false;
            Table3.Visible = false;
            Table4.Visible = false;
            Table5.Visible = false;
        }
    }
}