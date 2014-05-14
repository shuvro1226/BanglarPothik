using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class Division : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Division"] != null)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            con.Open();
            string query = "SELECT * FROM District WHERE Div_id='"+ Request["Division"].ToString() +"'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            Label2.Text = Request["Name"].ToString() + " Division";
            this.Title = Request["Name"].ToString() + " Division";

            string sql = "SELECT Div_map From Division WHERE Div_id='" + Request["Division"].ToString() + "'";
            cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Image2.ImageUrl = "~/images/Divisions/" + dr["Div_map"].ToString();
                Bitmap myBitmap = new Bitmap(Server.MapPath("~/images/Divisions/" + dr["Div_map"].ToString()));
                double width = myBitmap.Width;
                double height = myBitmap.Height;
                double a = width / height;
                double b = 450 / a;
                int c = Convert.ToInt32(b);
                Image2.Height = c;
                Image2.Width = 450;
            }

            string sql1 = "SELECT Place_name,Place_id FROM Place WHERE Div_id = '" + Request["Division"].ToString() + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            Repeater2.DataSource = ds1;
            Repeater2.DataBind();
            con.Close();
        }
    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }
}