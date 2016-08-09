using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDataAccess
{
    public class ToDoRepository 
    {
        private ToDoEntities dbContext { get; set; }

        public ToDo Get(int id)
        {
            using (dbContext = new ToDoEntities())
            {
                return dbContext.ToDoes.FirstOrDefault(t => t.Id == id);
            }
        }

        //some frameworks like to the new id
        //however, the whole entity is more useful to our current application
        public ToDo Insert(ToDo toDo)
        {
            using (dbContext = new ToDoEntities())
            {
                dbContext.ToDoes.Add(toDo);
                dbContext.SaveChanges();

                return dbContext.ToDoes.FirstOrDefault(t => t.Id == toDo.Id);
            }
        }

        //some frameworks like to return a bool if the update succeeded
        //however, that is not relevant to our current application
        public void Update(ToDo toDo)
        {
            using (dbContext = new ToDoEntities())
            {
                var toDoEntry = dbContext.Entry(toDo);
                toDoEntry.State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (dbContext = new ToDoEntities())
            {
                var toDo = dbContext.ToDoes.FirstOrDefault(t => t.Id == id);
                if (toDo != null)
                {
                    var toDoEntry = dbContext.Entry(toDo);
                    toDoEntry.State = System.Data.Entity.EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
