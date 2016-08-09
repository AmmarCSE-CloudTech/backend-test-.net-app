﻿using System;
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

        [TestMethod]
        public void Get_ShouldReturnNullForNonExistantIDs()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> expectedToDoBatch = TestSample;
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

            List<ToDoDataAccess.ToDo> insertToDoBatch = TestSample;
            List<ToDoDataAccess.ToDo> actualToDoBatch = controller.Post(insertToDoBatch);

            TestHelper.CompareToDos(actualToDoBatch, insertToDoBatch);
        }

        [TestMethod]
        public void Put_ShouldUpdateToDoBatch()
        {
            var controller = new ToDoBatchController();

            List<ToDoDataAccess.ToDo> updateToDoBatch = TestSample;
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