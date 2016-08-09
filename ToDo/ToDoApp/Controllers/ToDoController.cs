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

        // GET: api/todo
        [HttpGet]
        public ToDo Get(int id)
        {
            return toDoRepository.Get(id);
        }

        // POST api/todo
        [HttpPost]
        public ToDo Post(ToDo toDo)
        {
            return toDoRepository.Insert(toDo);
        }

        // PUT api/todo
        [HttpPut]
        public void Put(ToDo toDo)
        {
            toDoRepository.Update(toDo);
        }

        // DELETE api/todo
        [HttpPut]
        public void Delete(int id)
        {
            toDoRepository.Delete(id);
        }
    }
}
