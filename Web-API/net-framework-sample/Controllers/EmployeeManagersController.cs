using Dapper;
using net_framework_sample.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace net_framework_sample.Controllers
{
    public class AtTimeTagsController : ApiController
    {
        [HttpPost]
        [Route("api/EmployeeManagers")]
        public EmployeeManager Post([FromBody] EmployeeManagersParameter _param)
        {
            EmployeeManager rtnVal = new EmployeeManager();

            string CONNECTIONSTRING = ConfigEx.CONNECTIONSTRING;

            using (var conn = new SqlConnection(CONNECTIONSTRING))
            {
                string sql = $@"uspGetEmployeeManagers";

                var p = new DynamicParameters();

                p.Add("@BusinessEntityID", _param.businessEntityID);

                rtnVal = conn.Query<EmployeeManager>(sql, p, commandType: CommandType.Text).FirstOrDefault();
            }

            return rtnVal;
        }

        [HttpGet]
        [Route("api/EmployeeManagers")]
        public EmployeeManager Get([FromUri] EmployeeManagersParameter _param)
        {
            EmployeeManager rtnVal = new EmployeeManager();

            string CONNECTIONSTRING = ConfigEx.CONNECTIONSTRING;

            using (var conn = new SqlConnection(CONNECTIONSTRING))
            {
                string sql = $@"uspGetEmployeeManagers";

                var p = new DynamicParameters();

                p.Add("@BusinessEntityID", _param.businessEntityID);

                rtnVal = conn.Query<EmployeeManager>(sql, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return rtnVal;
        }

        public class EmployeeManagersParameter
        {
            public string businessEntityID { get; set; }
        }

        public class EmployeeManager
        {
            public string recursionLevel { get; set; }
            public string businessEntityID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string organizationNode { get; set; }
            public string managerFirstName { get; set; }
            public string managerLastName { get; set; }
        }
    }
}
