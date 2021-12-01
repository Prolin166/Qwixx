using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qwixx.Enums;
using Qwixx.Models;

namespace Qwixx.Test
{
    [TestClass]
    public class MissModelTest
    {
        [TestMethod]
        public void Count_IsCorrectValue()
        {
            var row = new MissModel(FieldCode.ms)
            {
                Four = true,
                Three = true
            };

            int value = row.Count(true);

            Assert.IsNotNull(value);
            Assert.AreEqual(value, 2);
        }
    }
}
