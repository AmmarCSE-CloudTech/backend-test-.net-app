using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using ToDoApi.Controllers;

namespace ToDoApi.Tests
{
    [TestClass]
    public class TestToDoBatchController
    {
        [TestMethod]
        public void Get_ShouldReturnToDoList()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> expectedToDoBatch = TestHelper.TestBatchSample;
            //first, insert the todo batch we will be testing the 'Get' with
            expectedToDoBatch = controller.Post(expectedToDoBatch);

            List<int> toDoIds = expectedToDoBatch.Select(t => t.Id).ToList();

            //now, see if the 'getting' part actually works
            var actualToDoBatch = controller.Get(toDoIds);
            TestHelper.CompareToDos(expectedToDoBatch, actualToDoBatch);
        }

        [TestMethod]
        public void Get_ShouldReturnNullForNonExistantIDs()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> expectedToDoBatch = TestHelper.TestBatchSample;
            expectedToDoBatch = controller.Post(expectedToDoBatch);

            List<int> toDoIds = expectedToDoBatch.Select(t => t.Id).ToList();
            //change one of the array items to check if its null
            toDoIds[1] = -1;

            //now, see if the length is 2 long instead of 3
            var actualToDoBatch = controller.Get(toDoIds);
            Assert.AreEqual(2, actualToDoBatch.Count);
        }

        //yes, there is redundancy since the insert is implicitly tested in the get test
        //this is useful regardless, since the test area is broken down
        [TestMethod]
        public void Post_ShouldInsertToDoBatch()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> insertToDoBatch = TestHelper.TestBatchSample;
            List<ToDoDataAccess.ToDo> actualToDoBatch = controller.Post(insertToDoBatch);

            TestHelper.CompareToDos(actualToDoBatch, insertToDoBatch);
        }

        [TestMethod]
        public void Put_ShouldUpdateToDoBatch()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> updateToDoBatch = TestHelper.TestBatchSample;
            updateToDoBatch = controller.Post(updateToDoBatch);

            foreach(var toDo in updateToDoBatch)
            {
                toDo.Text += " update";
                toDo.Completed = true;
                toDo.Added.AddDays(1);
            }

            controller.Put(updateToDoBatch);

            List<int> toDoIds = updateToDoBatch.Select(t => t.Id).ToList();

            var actualToDoBatch = controller.Get(toDoIds);

            TestHelper.CompareToDos(actualToDoBatch, updateToDoBatch);
        }

        [TestMethod]
        public void Delete_ShouldDeleteToDoBatch()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> deleteToDoBatch = TestHelper.TestBatchSample;
            deleteToDoBatch = controller.Post(deleteToDoBatch);

            List<int> toDoIds = deleteToDoBatch.Select(t => t.Id).ToList();

            controller.Delete(toDoIds);

            var actualToDoBatch = controller.Get(toDoIds);

            Assert.AreEqual(0, actualToDoBatch.Count);
        }

    }
}
