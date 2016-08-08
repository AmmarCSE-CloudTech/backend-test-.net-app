using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToDo.Controllers
{

    [Route("api/[controller]")]
    public class ToDoController : ApiController
    {
        // GET: api/values
        [HttpGet]
        public Object Get()
        {
            return null;
        }
    }
}
