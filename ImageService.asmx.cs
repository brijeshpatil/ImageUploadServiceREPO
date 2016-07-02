using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StoreImageServiceApp
{
    /// <summary>
    /// Summary description for ImageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ImageService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        [WebMethod]
        public string uploadimage(string ImageName, byte[] Image)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO imgtbl (imagename,uimage) VALUES (@imagename,@imagedata)", con);
            cmd.Parameters.Add("@imagename", SqlDbType.VarChar, 50).Value = ImageName;
            cmd.Parameters.Add("@imagedata", SqlDbType.Image).Value = Image;
            int count = cmd.ExecuteNonQuery();
            con.Close();

            if (count != 0)
            {
                return "Image Saved.!!";
            }
            else
            {
                return "There should be some problem";
            }
        }

        [WebMethod]
        public DataSet GetImage(int ImageID)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from imgtbl where imageid=@ID", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", ImageID);
            DataSet dt = new DataSet();
            da.Fill(dt,"imgtbl");
            return dt;
        }

        [WebMethod]
        public DataSet GetAllImages()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from imgtbl", con);
            DataSet dt = new DataSet();
            da.Fill(dt, "imgtbl");
            return dt;
        }
    }
}
