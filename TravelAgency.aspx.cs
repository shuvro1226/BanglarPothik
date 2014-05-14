using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class TravelAgency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Travel Agents";
        SqlConnection con = new SqlConnection(GetConnectionString());
        con.Open();
        string query = "SELECT * FROM TravelAgency";
        SqlCommand cmd = new SqlCommand(query, con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }
}