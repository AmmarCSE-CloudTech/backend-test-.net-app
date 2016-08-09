using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoDataAccess;

namespace ToDoApp.Controllers
{
    public class ToDoBatchController : ApiController
    {
        private ToDoRepository toDoRepository { get; set; }

        public ToDoBatchController()
        {
            toDoRepository = new ToDoRepository();
        }

        /*overload GET methods to allow either user id or list of ids for convenience*/

        // GET: api/todo - for user
        [HttpGet]
        public List<ToDo> Get(int userId)
        {
            return toDoRepository.GetBatch(userId);
        }

        // GET: api/todo - list of ids
        [HttpGet]
        public List<ToDo> Get(List<int> ids)
        {
            return toDoRepository.GetBatch(ids);
        }

        // POST: api/todo
        [HttpPost]
        public List<ToDo> Post(List<ToDo> toDos)
        {
            return toDoRepository.InsertBatch(toDos);
        }
    }
}
