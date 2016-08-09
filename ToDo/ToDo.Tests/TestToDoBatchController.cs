using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Controllers;

namespace ToDo.Tests
{
    [TestClass]
    public class TestToDoBatchController
    {
        [TestMethod]
        public void Get_ShouldReturnToDoList()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> expectedToDoBatch = TestSample;
            //first, insert the todo batch we will be testing the 'Get' with
            expectedToDoBatch = controller.Post(expectedToDoBatch);

            List<int> toDoIds = expectedToDoBatch.Select(t => t.Id).ToList();

            //now, see if the 'getting' part actually works
            var actualToDoBatch = controller.Get(toDoIds);
            TestHelper.CompareToDos(expectedToDoBatch, actualToDoBatch);
        }

        private List<ToDoDataAccess.ToDo> TestSample = new List<ToDoDataAccess.ToDo>
        {
            new ToDoDataAccess.ToDo {
                Text = "test 1",
                Added = DateTime.Now,
                Completed = false,
                UserId = 1
            },
            new ToDoDataAccess.ToDo {
                Text = "test 2",
                Added = DateTime.Now,
                Completed = false,
                UserId = 1
            },
            new ToDoDataAccess.ToDo {
                Text = "test 3",
                Added = DateTime.Now,
                Completed = false,
                UserId = 1
            }
        };
    }
}
