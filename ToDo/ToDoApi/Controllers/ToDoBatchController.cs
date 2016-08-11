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
    public class ToDoBatchController : ApiController
    {
        private ToDoRepository toDoRepository { get; set; }

        public ToDoBatchController()
        {
            toDoRepository = new ToDoRepository();
        }

        /*overload GET methods to allow all or list of ids for convenience*/

        // GET: api/todobatch - for user
        [HttpGet]
        public List<ToDo> Get()
        {
            //Logger.info(toDo, userId);
            //Cache.DetermineRead(User.Identity.Name);
            return toDoRepository.GetBatch(User.Identity.Name);
        }

        // GET: api/todobatch - list of ids
        [HttpGet]
        public List<ToDo> Get(List<int> ids)
        {
            //Logger.info(ids);
            //Cache.DetermineRead(ids, User.Identity.Name);
            //user GetBatch overload
            return toDoRepository.GetBatch(ids, User.Identity.Name);
        }

        // POST: api/todobatch
        [HttpPost]
        public List<ToDo> Post(List<ToDo> toDos)
        {
            //Logger.info(toDos);
            return toDoRepository.InsertBatch(toDos, User.Identity.Name);
        }

        // PUT: api/todobatch
        [HttpPut]
        public void Put(List<ToDo> toDos)
        {
            //Logger.info(toDos);
            toDoRepository.UpdateBatch(toDos, User.Identity.Name);
        }

        // DELETE: api/todobatch
        [HttpDelete]
        public void Delete(List<int> toDoIds)
        {
            //Logger.info(toDoIds);
            toDoRepository.DeleteBatch(toDoIds, User.Identity.Name);
        }
    }
}
