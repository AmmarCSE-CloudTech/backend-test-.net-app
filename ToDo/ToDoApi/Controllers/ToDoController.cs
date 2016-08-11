using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoDataAccess;

namespace ToDoApi.Controllers
{
    [Authorize]
    public class ToDoController : ApiController
    {
        private ToDoRepository toDoRepository { get; set; }

        public ToDoController()
        {
            toDoRepository = new ToDoRepository();
        }

        // GET: api/todo/id
        [HttpGet]
        public ToDo Get(int id)
        {
            //Logger.info(id);
            //Cache.DetermineRead(id, User.Identity.Name);
            return toDoRepository.Get(id, User.Identity.Name);
        }

        // POST api/todo
        [HttpPost]
        public ToDo Post(ToDo toDo)
        {
            //Logger.info(toDo);
            return toDoRepository.Insert(toDo, User.Identity.Name);
        }

        // PUT api/todo
        [HttpPut]
        public void Put(ToDo toDo)
        {
            //Logger.info(toDo);
            toDoRepository.Update(toDo, User.Identity.Name);
        }

        // DELETE api/todo/id
        [HttpDelete]
        public void Delete(int id)
        {
            //Logger.info(id);
            toDoRepository.Delete(id, User.Identity.Name);
        }
    }
}
