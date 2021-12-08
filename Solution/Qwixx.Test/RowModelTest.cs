using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx.Enums;
using Qwixx.Models;

namespace Qwixx.Test
{
    [TestClass]
    public class RowModelTest
    {
        [TestMethod]
        public void Count_IsCorrectValue()
        {
            var row = new RowModel(FieldCode.rd)
            {
                Eleven = true,
                Four = true,
                Six = true
            };

            int value = row.Count(true);

            Assert.IsNotNull(value);
            Assert.AreEqual(value, 3);
        }     
    }
}
