<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;

public class ImageHandler : IHttpHandler {

    System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
    public void ProcessRequest(HttpContext context)
    {
        string imageid = context.Request.QueryString["ImID"];
        con.Open();
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("select uimage from imgtbl where imageid=" + imageid, con);
        System.Data.SqlClient.SqlDataReader dr = command.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((Byte[])dr[0]);
        con.Close();
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
   

}