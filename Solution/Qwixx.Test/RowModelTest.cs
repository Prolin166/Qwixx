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

        [TestMethod]
        public void LockRdAndYe_IsTrue()
        {
            var row = new RowModel(FieldCode.rd)
            {
                Eleven = true,
                Four = true,
                Six = true,
                Five = true,
                Three = true
            };

            row.Twelve = true;
            bool value = row.Lock;

            Assert.IsNotNull(value);
            Assert.AreEqual(value, true);
        }

        [TestMethod]
        public void LockGnAndBu_IsTrue()
        {
            var row = new RowModel(FieldCode.gn)
            {
                Eleven = true,
                Four = true,
                Six = true,
                Five = true,
                Three = true
            };

            row.Two = true;
            bool value = row.Lock;

            Assert.IsNotNull(value);
            Assert.AreEqual(value, true);
        }
    }
}
