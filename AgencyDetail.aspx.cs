using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class AgencyDetail : System.Web.UI.Page
{
    protected string agency;

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Agencyid"] != null)
        {
            agency = Request["Agencyid"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());


            string sql2 = "SELECT TripDetail.Tripname,TripDetail.Tripid,TripDetail.Agencyid,TravelAgency.Agencyname FROM TripDetail INNER JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE TripDetail.Agencyid='"+ agency +"' GROUP BY TripDetail.Tripname,TripDetail.Tripid,TripDetail.Agencyid,TravelAgency.Agencyname";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            Repeater2.DataSource = ds2;
            Repeater2.DataBind();
            con.Close();

            string sql = "SELECT * FROM TravelAgency WHERE Agencyid = '" + agency + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Label6.Text = dr["Contact"].ToString();
                Label1.Text = dr["Agencyname"].ToString();
                this.Title = dr["Agencyname"].ToString();
                Label2.Text = dr["Address"].ToString();
                Label4.Text = dr["Email"].ToString();
                HyperLink1.NavigateUrl = dr["Url"].ToString();
                Label3.Text = dr["About"].ToString();
            }
            con.Close();
        }
    }
}