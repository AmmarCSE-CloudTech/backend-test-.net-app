using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDataAccess
{
    //nothing fancy(example, base entities with child entities)
    //just a simple gateway to the ToDo table
    public class ToDoRepository 
    {
        private ToDoEntities dbContext { get; set; }

        public ToDo Get(int id, string userId)
        {
            //Logger.info(id, userId);
            using (dbContext = new ToDoEntities())
            {
                //double check by comparing against userId
                var todo = dbContext.ToDoes.FirstOrDefault(t => t.Id == id && t.UserId == userId);
                //Cache.DetermineWrite(todo);
                return todo;
            }
        }

        public List<ToDo> GetBatch(string userId)
        {
            //Logger.info(userId);
            using (dbContext = new ToDoEntities())
            {
                //this and the 'batch' method both exhibit redundancy
                //its probably better to just return the full entities here
                List<int> toDoIds =
                    dbContext
                        .ToDoes
                        .Where(t => t.UserId == userId)
                        .Select(t => t.Id)
                        .ToList();

                return GetBatch(toDoIds, userId);
            }
        }

        public List<ToDo> GetBatch(List<int> ids, string userId)
        {
            using (dbContext = new ToDoEntities())
            {
                var result = dbContext
                    .ToDoes
                    .Where(t => ids.Contains(t.Id) && t.UserId == userId)
                    .ToList();
                //Cache.DetermineWrite(result);

                return result;
            }
        }

        public ToDo Insert(ToDo toDo, string userId)
        {
            //Logger.info(toDo, userId);
            toDo.UserId = userId;

            using (dbContext = new ToDoEntities())
            {
                dbContext.ToDoes.Add(toDo);
                dbContext.SaveChanges();

                //some frameworks like to return the new id
                //however, the whole entity is more useful to our current application
                return toDo;
            }
        }

        public List<ToDo> InsertBatch(List<ToDo> toDoBatch, string userId)
        {
            //Logger.info(toDoBatch, userId);
            //ideally, this would be handled in some business layer
            foreach(var todo in toDoBatch)
            {
                todo.UserId = userId;
            }
            using (dbContext = new ToDoEntities())
            {
                dbContext.ToDoes.AddRange(toDoBatch);
                dbContext.SaveChanges();

                return toDoBatch;
            }
        }

        //some frameworks like to return a bool if the update succeeded
        //however, that is not relevant to our current application
        public void Update(ToDo toDo, string userId)
        {
            //Logger.info(toDo, userId);
            using (dbContext = new ToDoEntities())
            {
                var toDoEntry = dbContext.Entry(toDo);
                //check that todo is for the authenticated user
                if (toDoEntry.Entity.UserId == userId)
                {
                    toDoEntry.State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
        }

        public void UpdateBatch(List<ToDo> toDos, string userId)
        {
            //Logger.info(toDos, userId);
            using (dbContext = new ToDoEntities())
            {
                foreach (var toDo in toDos)
                {
                    var toDoEntry = dbContext.Entry(toDo);
                    //check that todo is for the authenticated user
                    if (toDoEntry.Entity.UserId == userId)
                    {
                        toDoEntry.State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }

                dbContext.SaveChanges();
            }
        }

        public void Delete(int id, string userId)
        {
            //Logger.info(id, userId);
            using (dbContext = new ToDoEntities())
            {
                //double check that todo is for user by comparing ids
                var toDo = dbContext.ToDoes.FirstOrDefault(t => t.Id == id && t.UserId == userId);
                if (toDo != null)
                {
                    var toDoEntry = dbContext.Entry(toDo);
                    toDoEntry.State = System.Data.Entity.EntityState.Deleted;
                    dbContext.SaveChanges();
                    //Cache.DetermineRemove(toDoEntry);
                }
            }
        }

        public void DeleteBatch(List<int> ids, string userId)
        {
            //Logger.info(ids, userId);
            using (dbContext = new ToDoEntities())
            {
                var toDos = 
                    dbContext
                        .ToDoes
                        .Where(t => ids.Contains(t.Id) && t.UserId == userId);

                foreach(var toDo in toDos)
                {
                    var toDoEntry = dbContext.Entry(toDo);
                    toDoEntry.State = System.Data.Entity.EntityState.Deleted;
                }

                dbContext.SaveChanges();
                //Cache.DetermineRemove(toDos);
            }
        }
    }
}
