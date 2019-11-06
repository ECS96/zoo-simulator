using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void Utils_GetRandomNumber_Test()
        {
            var min = 1;
            var max = 10;
            var value = Utils.GetRandomNumber(min, max);

            var valid = ((value >= min) && (value <= 10));

            Assert.IsTrue(valid);
        }

        [TestMethod()]
        public void Utils_MinCap_Test()
        {
            var actual = -1;
            var expected = 0;

            var min = 0;
            var max = 100;

            var value = Utils.Cap(actual, min, max);

            Assert.AreEqual(value, expected);
        }

        [TestMethod()]
        public void Utils_MaxCap_Test()
        {
            var actual = 101;
            var expected = 100;

            var min = 0;
            var max = 100;

            var value = Utils.Cap(actual, min, max);

            Assert.AreEqual(value, expected);
        }
    }
}