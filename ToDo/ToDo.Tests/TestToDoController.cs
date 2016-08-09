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

            ToDoDataAccess.ToDo expectedToDo = TestSample;
            //first, insert the todo we will be testing the 'Get' with
            expectedToDo = controller.Post(expectedToDo);

            var actualToDo = controller.Get(expectedToDo.Id);

            //now, see if the 'getting' part actually works
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
            var controller = new ToDoController();

            ToDoDataAccess.ToDo insertToDo = TestSample;
            var actualToDo = controller.Post(insertToDo);

            CompareToDos(insertToDo, actualToDo);
        }

        [TestMethod]
        public void Put_ShouldUpdateToDo()
        {
            var controller = new ToDoController();

            ToDoDataAccess.ToDo updateToDo = TestSample;
            updateToDo = controller.Post(updateToDo);

            updateToDo.Text = "update test";
            updateToDo.Added = updateToDo.Added.AddDays(1);
            updateToDo.Completed = true;

            controller.Put(updateToDo);

            var actualToDo = controller.Get(updateToDo.Id);

            CompareToDos(updateToDo, actualToDo);
        }

        [TestMethod]
        public void Delete_ShouldDeleteToDo()
        {
            var controller = new ToDoController();

            ToDoDataAccess.ToDo deleteToDo = TestSample;
            deleteToDo = controller.Post(deleteToDo);

            controller.Delete(deleteToDo.Id);

            var actualToDo = controller.Get(deleteToDo.Id);

            CompareToDos(null, actualToDo);
        }

        private ToDoDataAccess.ToDo TestSample = new ToDoDataAccess.ToDo
        {
            Text = "test",
            Added = DateTime.Now,
            Completed = false,
            UserId = 1
        };
        private void CompareToDos(ToDoDataAccess.ToDo expected, ToDoDataAccess.ToDo actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.UserId, actual.UserId);
            Assert.AreEqual(expected.Text, actual.Text);
            Assert.AreEqual(expected.Added.ToShortDateString(), actual.Added.ToShortDateString());
            Assert.AreEqual(expected.Completed, actual.Completed);
        }
    }
}
