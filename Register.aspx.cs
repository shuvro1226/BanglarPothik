using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CodeCarvings.Piczard;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "Register";
        if (Page.User.Identity.Name != String.Empty)
        {
            Response.Redirect("Default.aspx");
        }
        Page.MaintainScrollPositionOnPostBack = true;

        if (this.ScriptManager1.IsInAsyncPostBack)
        {
            // After every Ajax postback re-initialize the JQuery UI elements
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "initializeUI", "initializeUI();", true);
        }

        if (!this.IsPostBack)
        {
            this.Upload.AutoOpenImageEditPopupAfterUpload = true;
            this.Upload.CropConstraint = new FixedCropConstraint(300, 300);
            this.Upload.CropConstraint.DefaultImageSelectionStrategy = CropConstraintImageSelectionStrategy.WholeImage;
            this.Upload.PreviewFilter = new FixedResizeConstraint(150, 150);

            SqlConnection con = new SqlConnection(GetConnectionString());
            DropDownList2.Items.Clear();
            string sql1 = "SELECT Dis_name,Dis_id FROM District";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            DataSet ds1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);
            DropDownList2.DataSource = ds1;
            DropDownList2.DataTextField = "Dis_name";
            DropDownList2.DataValueField = "Dis_id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("District", "-1"));
            con.Close();

            TextBox2.Text = String.Empty;
            Password.Text = String.Empty;
        }

        int y = DateTime.Now.Year;
        if (!IsPostBack)
        {
            for (int i = y - 10; i > y - 65; i--)
            {
                Year.Items.Add(i.ToString());
            }
        }
    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
    }

    protected void Changed1(object sender, EventArgs e)
    {
        if (Month.SelectedItem.ToString() == "January" || Month.SelectedItem.ToString() == "March" || Month.SelectedItem.ToString() == "May" || Month.SelectedItem.ToString() == "July" || Month.SelectedItem.ToString() == "August" || Month.SelectedItem.ToString() == "October" || Month.SelectedItem.ToString() == "December")
        {
            Day.Items.Clear();
            Day.Items.Insert(0, "Day");
            for (int i = 1; i <= 31; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }
        if (Month.SelectedItem.ToString() == "April" || Month.SelectedItem.ToString() == "June" || Month.SelectedItem.ToString() == "September" || Month.SelectedItem.ToString() == "November")
        {
            Day.Items.Clear();
            Day.Items.Insert(0, "Day");
            for (int i = 1; i <= 30; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }
        if (Month.SelectedItem.ToString() == "February")
        {
            Day.Items.Clear();
            Day.Items.Insert(0, "Day");
            for (int i = 1; i <= 29; i++)
            {
                Day.Items.Add(i.ToString());
            }
        }

        Page.MaintainScrollPositionOnPostBack = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(GetConnectionString());
        string sql = "UPDATE Users SET Birthday=@day,Birthmonth=@month,Birthyear=@year,Contact=@contact,Occupation=@occupation,Details=@details WHERE Username='" + TextBox2.Text + "'";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlParameter[] para = new SqlParameter[6];

            cmd.Parameters.AddWithValue("@day", Day.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@month", Month.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@year", Year.SelectedItem.ToString());
            para[2] = new SqlParameter("@contact", SqlDbType.VarChar, 50);
            para[2].Value = TextBox3.Text.ToString();
            cmd.Parameters.Add(para[2]);
            para[3] = new SqlParameter("@occupation", SqlDbType.VarChar, 50);
            para[3].Value = TextBox5.Text.ToString();
            cmd.Parameters.Add(para[3]);
            para[4] = new SqlParameter("@details", SqlDbType.VarChar);
            para[4].Value = TextBox6.Text.ToString();
            cmd.Parameters.Add(para[4]);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            Response.Redirect("Login.aspx?msg='" + TextBox1.Text + " , You have registered successfully to Banglar Pothik. You can login now using your username and password!'");
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
        string imgsource = Upload.SourceImageClientFileName;
        if (Label3.Text == "Available!" && Confirmation.Text == Password.Text && this.Upload.HasNewImage)
        {
            string imgoutname = CodeCarvings.Piczard.Helpers.IOHelper.GetUniqueFileName("~/images/ProPic/", imgsource);
            string imgoutpath = CodeCarvings.Piczard.Helpers.IOHelper.GetUniqueFilePath("~/images/ProPic/", imgsource);
            Upload.SaveProcessedImageToFileSystem(imgoutpath);
            this.Upload.SaveProcessedImageToFileSystem(imgoutpath, new JpegFormatEncoderParams(92));
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO Users(Name,Username,Email,Password,Sex,ProPic,Dis_id) VALUES(@name,@username,@email,@password,@sex,@propic,@disid)";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] para = new SqlParameter[5];

                para[0] = new SqlParameter("@name", SqlDbType.VarChar, 100);
                para[0].Value = TextBox1.Text.ToString();
                cmd.Parameters.Add(para[0]);
                para[1] = new SqlParameter("@username", SqlDbType.VarChar, 100);
                para[1].Value = TextBox2.Text.ToString();
                cmd.Parameters.Add(para[1]);
                para[2] = new SqlParameter("@email", SqlDbType.VarChar, 50);
                para[2].Value = Email.Text.ToString();
                cmd.Parameters.Add(para[2]);
                para[3] = new SqlParameter("@password", SqlDbType.VarChar, 50);
                para[3].Value = Password.Text.ToString();
                cmd.Parameters.Add(para[3]);
                para[4] = new SqlParameter("@sex", SqlDbType.VarChar, 10);
                para[4].Value = DropDownList1.SelectedItem.ToString();
                cmd.Parameters.Add(para[4]);
                cmd.Parameters.AddWithValue("@propic", imgoutname);
                cmd.Parameters.AddWithValue("@disid", DropDownList2.SelectedValue);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                Panel1.Visible = false;
                Panel2.Visible = true;
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
            Label1.Text = "Check whether username is available and password match!";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void fvPicture1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // Validate the Picture1 control (must contain a value)
        args.IsValid = this.Upload.HasImage;
        Page.MaintainScrollPositionOnPostBack = true;
    }


    protected void username_changed(object sender, EventArgs e)
    {
        if (TextBox2.Text != string.Empty)
        {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = '" + TextBox2.Text.Trim().ToString() + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            int result = (Int32)cmd.ExecuteScalar();
            con.Close();
            if (result >= 1)
            {
                Label3.Text = "Username Unavailable!";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label3.Text = "Available!";
                Label3.ForeColor = System.Drawing.Color.Green;
            }
        }

        Page.MaintainScrollPositionOnPostBack = true;
    }
}