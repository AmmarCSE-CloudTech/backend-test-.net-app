using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDo.Tests
{
    public static class TestHelper
    {
        public static void CompareToDos(ToDoDataAccess.ToDo expected, ToDoDataAccess.ToDo actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.UserId, actual.UserId);
            Assert.AreEqual(expected.Text, actual.Text);
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
                CompareToDos(expected[i], actual[i]);
            }
        }
    }
}
