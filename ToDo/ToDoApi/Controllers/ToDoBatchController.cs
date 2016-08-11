using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoDataAccess;

namespace ToDoApi.Controllers
{
    public class ToDoBatchController : ApiController
    {
        private ToDoRepository toDoRepository { get; set; }

        public ToDoBatchController()
        {
            toDoRepository = new ToDoRepository();
        }

        /*overload GET methods to allow either user id or list of ids for convenience*/

        // GET: api/todobatch - for user
        [HttpGet]
        public List<ToDo> Get(string userId)
        {
            return toDoRepository.GetBatch(userId);
        }

        // GET: api/todobatch - list of ids
        [HttpGet]
        public List<ToDo> Get(List<int> ids)
        {
            return toDoRepository.GetBatch(ids, User.Identity.Name);
        }

        // POST: api/todobatch
        [HttpPost]
        public List<ToDo> Post(List<ToDo> toDos)
        {
            foreach(var toDo in toDos)
            {
                toDo.UserId = User.Identity.Name;
            }

            return toDoRepository.InsertBatch(toDos, User.Identity.Name);
        }

        // PUT: api/todobatch
        [HttpPut]
        public void Put(List<ToDo> toDos)
        {
            toDoRepository.UpdateBatch(toDos, User.Identity.Name);
        }

        // DELETE: api/todobatch
        [HttpDelete]
        public void Delete(List<int> toDoIds)
        {
            toDoRepository.DeleteBatch(toDoIds, User.Identity.Name);
        }
    }
}
