using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHooks
{
    public partial class GraphWebHooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "plain/text";
            if (Request.QueryString["validationToken"] != null)
            {
                Response.Write(Request.QueryString["validationToken"]);
                //using (StreamReader reader = new StreamReader(Request.InputStream))
                //{
                //    string body = reader.ReadToEnd();
                //    Trace.Write(body);
                //}

            }
            else
            {
                Response.StatusCode = 202;
            }
             

        }


    }
}