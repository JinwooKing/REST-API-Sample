using Dapper;
using net_framework_sample.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace net_framework_sample.Controllers
{
    public class VersionController : ApiController
    {
        [HttpPost]
        [Route("api/Version")]
        public string Post()
        {
            string rtnVal;

            string CONNECTIONSTRING = ConfigEx.CONNECTIONSTRING;

            using (var conn = new SqlConnection(CONNECTIONSTRING))
            {
                string sql = $@"SELECT @@VERSION";

                var p = new DynamicParameters();

                rtnVal = conn.Query<string>(sql, p, commandType: CommandType.Text).FirstOrDefault();
            }

            return rtnVal;
        }

        [HttpGet]
        [Route("api/Version")]
        public string Get()
        {
            string rtnVal;

            string CONNECTIONSTRING = ConfigEx.CONNECTIONSTRING;

            using (var conn = new SqlConnection(CONNECTIONSTRING))
            {
                string sql = $@"SELECT @@VERSION";

                var p = new DynamicParameters();

                rtnVal = conn.Query<string>(sql, p, commandType: CommandType.Text).FirstOrDefault();
            }

            return rtnVal;
        }
    }
}