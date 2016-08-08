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

        public ToDoRepository()
        {
            dbContext = new ToDoEntities();
        }

        public ToDo Get(int id)
        {
            return dbContext.ToDoes.FirstOrDefault(t => t.Id == id);
        }

        public ToDo Insert(ToDo toDo)
        {
            dbContext.ToDoes.Add(toDo);
            dbContext.SaveChanges();

            return dbContext.ToDoes.FirstOrDefault(t => t.Id == toDo.Id);
        }
    }
}
