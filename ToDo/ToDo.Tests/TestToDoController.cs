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
            expectedToDo.UserId = 1;
            expectedToDo.Text = "get test";
            expectedToDo.Added = new DateTime(2016, 8, 4);
            expectedToDo.Completed = false;

            expectedToDo = controller.Post(expectedToDo);

            var actualToDo = controller.Get(expectedToDo.Id);

            CompareToDos(expectedToDo, actualToDo);
        }

        [TestMethod]
        public void Get_ShouldReturnNullForNonExistantID()
        {
            var controller = new ToDoController();
            var actualToDo = controller.Get(-1);

            Assert.AreEqual(null, actualToDo);
        }

        [TestMethod]
        public void Post_ShouldInsertToDo()
        {
            ToDoDataAccess.ToDo insertToDo = new ToDoDataAccess.ToDo();
            insertToDo.UserId = 1;
            insertToDo.Text = "insert test";
            insertToDo.Added = new DateTime(2016, 8, 5);
            insertToDo.Completed = false;

            var controller = new ToDoController();
            insertToDo = controller.Post(insertToDo);

            var actualToDo = controller.Get(insertToDo.Id);

            CompareToDos(insertToDo, actualToDo);
        }

        private void CompareToDos(ToDoDataAccess.ToDo expected, ToDoDataAccess.ToDo actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.UserId, actual.UserId);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Added, actual.Added);
            Assert.AreEqual(expected.Completed, actual.Completed);
        }
    }
}
