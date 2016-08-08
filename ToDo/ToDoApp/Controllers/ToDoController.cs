using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoDataAccess;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ApiController
    {
        private ToDoRepository toDoRepository { get; set; }

        public ToDoController()
        {
            toDoRepository = new ToDoRepository();
        }

        // GET: api/values
        [HttpGet]
        public ToDo Get(int id)
        {
            return toDoRepository.Get(id);
        }
    }
}
