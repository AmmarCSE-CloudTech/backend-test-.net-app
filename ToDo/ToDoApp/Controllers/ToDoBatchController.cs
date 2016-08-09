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

        // GET: api/todo-batch - for user
        [HttpGet]
        public List<ToDo> Get(int userId)
        {
            return toDoRepository.GetBatch(userId);
        }

        // GET: api/todo-batch - list of ids
        [HttpGet]
        public List<ToDo> Get(List<int> ids)
        {
            return toDoRepository.GetBatch(ids);
        }

        // POST: api/todo-batch
        [HttpPost]
        public List<ToDo> Post(List<ToDo> toDos)
        {
            return toDoRepository.InsertBatch(toDos);
        }

        // PUT: api/todo-batch
        [HttpPut]
        public void Put(List<ToDo> toDos)
        {
            toDoRepository.UpdateBatch(toDos);
        }

        // DELETE: api/todo-batch
        [HttpDelete]
        public void Delete(List<int> toDoIds)
        {
            toDoRepository.DeleteBatch(toDoIds);
        }
    }
}
