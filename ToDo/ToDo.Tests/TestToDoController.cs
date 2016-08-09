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

            //now, see if the 'getting' part actually works
            var actualToDo = controller.Get(expectedToDo.Id);
            TestHelper.CompareToDos(expectedToDo, actualToDo);
        }

        [TestMethod]
        public void Get_ShouldReturnNullForNonExistantID()
        {
            var controller = new ToDoController();
            var actualToDo = controller.Get(-1);

            Assert.AreEqual(null, actualToDo);
        }

        //yes, there is redundancy since the insert is implicitly tested in the get test
        //this is useful regardless, since the test area is broken down
        [TestMethod]
        public void Post_ShouldInsertToDo()
        {
            var controller = new ToDoController();

            ToDoDataAccess.ToDo insertToDo = TestSample;
            var actualToDo = controller.Post(insertToDo);

            TestHelper.CompareToDos(insertToDo, actualToDo);
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

            TestHelper.CompareToDos(updateToDo, actualToDo);
        }

        [TestMethod]
        public void Delete_ShouldDeleteToDo()
        {
            var controller = new ToDoController();

            ToDoDataAccess.ToDo deleteToDo = TestSample;
            deleteToDo = controller.Post(deleteToDo);

            controller.Delete(deleteToDo.Id);

            var actualToDo = controller.Get(deleteToDo.Id);

            Assert.AreEqual(null, actualToDo);
        }

        private ToDoDataAccess.ToDo TestSample = new ToDoDataAccess.ToDo
        {
            Text = "test",
            Added = DateTime.Now,
            Completed = false,
            UserId = 1
        };
    }
}
