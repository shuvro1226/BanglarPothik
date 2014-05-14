using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;

public partial class ContentPage : System.Web.UI.Page
{
    protected string distance;
    protected string dis_name;
    protected string division;
    protected string district;

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["District"] != null)
        {
            district = Request["District"].ToString();
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "SELECT District.Dis_name,District.Area,District.Distance,District.Rivers,District.Map,District.Details,Division.Div_name FROM District INNER JOIN Division ON District.Div_id = Division.Div_id WHERE Dis_id = '" + district + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Image1.ImageUrl = "~/images/Districts/" + dr["Map"].ToString();
                Bitmap myBitmap = new Bitmap(Server.MapPath("~/images/Districts/" + dr["Map"].ToString()));
                double width = myBitmap.Width;
                double height = myBitmap.Height;
                double a = width / height;
                double b = 450 / a;
                int c = Convert.ToInt32(b);
                Image1.Height = c;
                Image1.Width = 450;
                division = dr["Div_name"].ToString();
                Label1.Text = dr["Dis_name"].ToString();
                this.Title = dr["Dis_name"].ToString();
                dis_name = Label1.Text;
                Label2.Text = dr["Area"].ToString();
                Label3.Text = dr["Details"].ToString();
                Label5.Text = dr["Rivers"].ToString(); ;
                Label6.Text = division;
                distance = dr["Distance"].ToString();
            }
            con.Close();

            string sql1 = "SELECT Place_name,Place_id FROM Place WHERE Dis_id = '"+ district +"'";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            con.Close();

            string sql2 = "SELECT TripDetail.Tripname,TripDetail.Tripid,TripDetail.Agencyid,TravelAgency.Agencyname FROM TripDetail INNER JOIN TravelAgency ON TripDetail.Agencyid=TravelAgency.Agencyid WHERE (Disid1 = '" + district + "' OR Disid2 = '" + district + "' OR Disid3 = '" + district + "' OR Disid4 = '" + district + "' OR Disid5 = '" + district + "' OR Disid1 = '" + district + "') GROUP BY TripDetail.Tripname,TripDetail.Tripid,TripDetail.Agencyid,TravelAgency.Agencyname";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            Repeater2.DataSource = ds2;
            Repeater2.DataBind();
            con.Close();
        }
    }
}