using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

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
        public object Alms()
        {
            DataTable dataList = new DataTable();
            using (SqlConnection connection = new SqlConnection("Server =.; Database = Advancity; Trusted_Connection = True"))
            {
                DataTable Dt = new DataTable();
                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM ALMS", connection))
                {
                    Cmd.CommandTimeout = 0;
                    connection.Open();
                    using (SqlDataReader Sdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)) { Dt.Load(Sdr); Sdr.Close(); }
                }
                dataList.Merge(Dt);
            };
            object JSON = new { data = JsonConvert.SerializeObject(dataList) };

            return JSON;
        }


        [WebMethod]
        public object Perculus()
        {
            DataTable dataList = new DataTable();
            using (SqlConnection connection = new SqlConnection("Server =.; Database = Advancity; Trusted_Connection = True"))
            {
                DataTable Dt = new DataTable();
                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM PERCULUS", connection))
                {
                    Cmd.CommandTimeout = 0;
                    connection.Open();
                    using (SqlDataReader Sdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)) { Dt.Load(Sdr); Sdr.Close(); }
                }
                dataList.Merge(Dt);
            };
            object JSON = new { data = JsonConvert.SerializeObject(dataList) };

            return JSON;
        }

        [WebMethod]
        public object Customers()
        {
            DataTable dataList = new DataTable();
            using (SqlConnection connection = new SqlConnection("Server =.; Database = Advancity; Trusted_Connection = True"))
            {
                DataTable Dt = new DataTable();
                using (SqlCommand Cmd = new SqlCommand("SELECT * FROM Customers", connection))
                {
                    Cmd.CommandTimeout = 0;
                    connection.Open();
                    using (SqlDataReader Sdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)) { Dt.Load(Sdr); Sdr.Close(); }
                }
                dataList.Merge(Dt);
            };
            object JSON = new { data = JsonConvert.SerializeObject(dataList) };

            return JSON;
        }

        [WebMethod]
        public object KurumAra()
        {
            DataTable dataList = new DataTable();
            using (SqlConnection connection = new SqlConnection("Server =.; Database = Advancity; Trusted_Connection = True"))
            {
                DataTable Dt = new DataTable();
                using (SqlCommand Cmd = new SqlCommand(@"SELECT '1000' + CAST(id AS VARCHAR) + '|' + CAST(Alms_OrganizationID AS VARCHAR) AS ID, Alms_OrganizationName AS 'KurumAdi'FROM Alms
UNION ALL
SELECT '2000' + CAST(id AS VARCHAR) + '|' + CAST(Perculus_Orgid AS VARCHAR) AS ID, Organizasyon_adi AS 'KurumAdi' FROM Perculus
UNION ALL
SELECT '3000' + CAST(id AS VARCHAR) + '|' + CAST(Kisi_orgid AS VARCHAR) AS ID, Kurum_adi AS 'KurumAdi' FROM  Customers
ORDER BY KurumAdi ASC", connection)) 
                                    {
                    Cmd.CommandTimeout = 0;
                    connection.Open();
                    using (SqlDataReader Sdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)) { Dt.Load(Sdr); Sdr.Close(); }
                }
                dataList.Merge(Dt);
            };
            object JSON = new { data = JsonConvert.SerializeObject(dataList) };

            return JSON;
        }
    }
}
