using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoApi.Tests
{
    public static class TestHelper
    {
        //use fake id to simulate mocking during testing
        public static string psuedoUserId = Guid.NewGuid().ToString();

        public static ToDoDataAccess.ToDo TestSample = new ToDoDataAccess.ToDo
        {
            Text = "test",
            Added = DateTime.Now,
            Completed = false
        };

        public static List<ToDoDataAccess.ToDo> TestBatchSample = new List<ToDoDataAccess.ToDo>
        {
            new ToDoDataAccess.ToDo {
                Text = "test 1",
                Added = DateTime.Now,
                Completed = false
            },
            new ToDoDataAccess.ToDo {
                Text = "test 2",
                Added = DateTime.Now,
                Completed = false
            },
            new ToDoDataAccess.ToDo {
                Text = "test 3",
                Added = DateTime.Now,
                Completed = false
            }
        };

        public static void CompareToDos(ToDoDataAccess.ToDo expected, ToDoDataAccess.ToDo actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.UserId, actual.UserId);
            Assert.AreEqual(expected.Text, actual.Text);
            //sometimes, millisecond differences cause false negatives
            //therefore, for our purposes, comparing strings will suffice
            Assert.AreEqual(expected.Added.ToShortDateString(), actual.Added.ToShortDateString());
            Assert.AreEqual(expected.Completed, actual.Completed);
        }
        public static void CompareToDos(List<ToDoDataAccess.ToDo> expected, List<ToDoDataAccess.ToDo> actual)
        {
            //test immediately fails if the collection lengthes are not equal
            if(expected.Count != actual.Count)
            {
                throw new AssertFailedException();
            }

            for(int i = 0; i < expected.Count; i++)
            {
                //one downside to this approach is that it is assumed that both collections will be in order
                //this can be solved by devising a way to pre-order based on a field and fail immediately if
                //not all match
                CompareToDos(expected[i], actual[i]);
            }
        }
    }
}
