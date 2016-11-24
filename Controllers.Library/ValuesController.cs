using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Controllers.Library
{
    public class ValuesController : ApiController
    {

        public IHttpActionResult Get()
        {
            var list = new List<string>() {"Rahman", "Mahmoodi"};
            return Ok(list);
        }

        public IHttpActionResult Get(int id)
        {
            var result = string.Empty;

            if (id==1)
            {
                result = "Hosha";
            }

            if (id > 10)
            {
                return BadRequest("Id should be smaller than 10.");
            }

            return Ok(result);
        }

        public IHttpActionResult GetByName(string name)
        {
            var result = string.Empty;

            if (name == "hosha")
            {
                result = "Hosha";
            }

            if (name == "")
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
