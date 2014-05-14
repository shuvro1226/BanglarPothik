using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class JqueryEdit : System.Web.UI.Page
{
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "Edit";
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql2 = "SELECT * FROM Place";
            con.Open();
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            DataSet ds2 = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(ds2);
            DropDownList1.DataSource = ds2;
            DropDownList1.DataTextField = "Place_name";
            DropDownList1.DataValueField = "Place_id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Search For A Place", "-1"));
            con.Close();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && DropDownList1.SelectedValue.ToString() != "-1")
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Imagegrid (Placeid,Image) VALUES(@place,@image)";

            try
            {
                FileUpload1.SaveAs(Server.MapPath("~/images/ImageGrid/" + FileUpload1.FileName));
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] para = new SqlParameter[2];

                para[0] = new SqlParameter("@place", SqlDbType.VarChar, 6);
                para[0].Value = DropDownList1.SelectedValue;
                cmd.Parameters.Add(para[0]);
                para[1] = new SqlParameter("@image", SqlDbType.VarChar, 100);
                para[1].Value = FileUpload1.FileName.ToString();
                cmd.Parameters.Add(para[1]);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Label3.Visible = true;
                Label3.Text = "Item added successfully";
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
    }
}