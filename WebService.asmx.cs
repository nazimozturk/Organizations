using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Organizations
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string Alms()
        {
            using (SqlConnection connection = new SqlConnection("Server = .; Database = Alms; Trusted_Connectin = True"))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ALMS FOR JSON AUTO");
                connection.Close();
            };
            return "a";
        }
    }
}
