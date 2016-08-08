using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Controllers;
using ToDoDataAccess; 

namespace ToDo.Tests
{
    [TestClass]
    public class TestToDoController 
    {
        [TestMethod]
        public void Get_ShouldReturnToDo()
        {
            var controller = new ToDoController();

            ToDoDataAccess.ToDo expectedToDo = new ToDoDataAccess.ToDo();
            expectedToDo.Id = 1;
            expectedToDo.UserId = 1;
            expectedToDo.Text = "test";
            expectedToDo.Added = new DateTime(2016, 8, 4);
            expectedToDo.Completed = false;
            var actualToDo = controller.Get(1);
            Assert.AreEqual(expectedToDo.Id, actualToDo.Id);
            Assert.AreEqual(expectedToDo.UserId, actualToDo.UserId);
            Assert.AreEqual(expectedToDo.Text, actualToDo.Text);
            Assert.AreEqual(expectedToDo.Added, actualToDo.Added);
            Assert.AreEqual(expectedToDo.Completed, actualToDo.Completed);
        }
    }
}
