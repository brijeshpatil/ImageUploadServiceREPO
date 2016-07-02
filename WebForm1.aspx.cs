using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreImageServiceApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridData();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileuploadImage.HasFile)
            {
                int length = fileuploadImage.PostedFile.ContentLength;
                byte[] imgbyte = new byte[length];
                HttpPostedFile img = fileuploadImage.PostedFile;
                img.InputStream.Read(imgbyte, 0, length);
                string imagename = txtImageName.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO imgtbl (imagename,uimage) VALUES (@imagename,@imagedata)", con);
                cmd.Parameters.Add("@imagename", SqlDbType.VarChar, 50).Value = imagename;
                cmd.Parameters.Add("@imagedata", SqlDbType.Image).Value = imgbyte;
                int count = cmd.ExecuteNonQuery();
                con.Close();
                if (count == 1)
                {
                    BindGridData();
                    txtImageName.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('" + imagename + " image inserted successfully')", true);
                }
            }
        }

        private void BindGridData()
        {
            SqlCommand command = new SqlCommand("SELECT imagename,ImageID from [imgtbl]", con);
            SqlDataAdapter daimages = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            daimages.Fill(dt);
            gvImages.DataSource = dt;
            gvImages.DataBind();
            gvImages.Attributes.Add("bordercolor", "black");
        }
    }
}