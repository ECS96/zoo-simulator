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
    public class AnimalTests
    {
        /// Test for starting health of 100 behaviour.
        [TestMethod()]
        public void Animal_Health_Test()
        {
            var expected = 100;

            var animal = new Giraffe();

            Assert.AreEqual(expected, animal.Health);
        }
        /// Test for starting status of alive behaviour
        [TestMethod()]
        public void Animal_Status_Test()
        {
            var expected = "Alive";

            var animal = new Giraffe();

            Assert.AreEqual(expected, animal.Status);
        }
        /// Test for fatal health of giraffe behaviour
        [TestMethod()]
        public void Giraffe_FatalHealth_Test()
        {
            float expected = 50;

            var animal = new Giraffe();

            Assert.AreEqual(expected, animal.FatalHealth);
        }

        /// Test for fatal health of elephant behaviour
        [TestMethod()]
        public void Elephant_FatalHealth_Test()
        {
            float expected = 70;

            var animal = new Elephant();

            Assert.AreEqual(expected, animal.FatalHealth);
        }

        /// Test for fatal health of monkey behaviour
        [TestMethod()]
        public void Monkey_FatalHealth_Test()
        {
            float expected = 30;

            var animal = new Monkey();

            Assert.AreEqual(expected, animal.FatalHealth);
        }

        /// Tests behaviour for decrease health between correct values
        [TestMethod()]
        public void Animal_DecreaseHealth_Test()
        {
            var animal = new Giraffe();

            var healthBefore = animal.Health;

            animal.DecreaseHealth();

            var valid = (animal.Health >= healthBefore - 20) && (animal.Health <= healthBefore);

            Assert.IsTrue(valid);
        }

        /// Tests behaviour for increase health between correct values.
        [TestMethod()]
        public void Animal_IncreaseHealth_Test()
        {
            var animal = new Giraffe();

            animal.Health = 50;

            var healthBefore = animal.Health;

            animal.IncreaseHealth(Zoo.GenerateFeedValue());

            var valid = (animal.Health >= healthBefore + 10) && (animal.Health <= healthBefore + 25);

            Assert.IsTrue(valid);
        }

        /// Tests behaviour health remains at minimum when decreased below.
        [TestMethod()]
        public void Animal_HealthMinimum_Test()
        {
            var animal = new Giraffe();
            animal.Health = 0;
            var healthBefore = animal.Health;

            animal.DecreaseHealth();
            
            Assert.AreEqual(healthBefore, animal.Health);
        }

        /// Tests behaviour health remains at maximum when increased above.
        [TestMethod()]
        public void Animal_HealthMaximum_Test()
        {
            var animal = new Giraffe();

            var healthBefore = animal.Health;

            animal.IncreaseHealth(Zoo.GenerateFeedValue());
            
            Assert.AreEqual(healthBefore, animal.Health);
        }

        /// Tests behaviour giraffe status is set to dead when health is below fatal health.
        [TestMethod()]
        public void Giraffe_DeadStatus_Test()
        {
            var animal = new Giraffe();

            var expected = "Dead";

            animal.Health = 49;

            animal.DecreaseHealth();

            Assert.AreEqual(animal.Status, expected);
        }

        /// Tests behaviour monkey status is set to dead when health is below fatal health.
        [TestMethod()]
        public void Monkey_DeadStatus_Test()
        {
            var animal = new Monkey();

            var expected = "Dead";

            animal.Health = 29;

            animal.DecreaseHealth();

            Assert.AreEqual(animal.Status, expected);
        }

        /// Tests behaviour elephant status is set to dead when health is below fatal health after an hour.
        [TestMethod()]
        public void Elephant_DeadStatus_Test()
        {
            var animal = new Elephant();

            var expected = "Dead";

            animal.Status = "Crippled";
            animal.Health = 69;

            animal.DecreaseHealth();

            Assert.AreEqual(animal.Status, expected);
        }

        /// Tests behaviour elephant status is set to crippled when health is first below fatal health.
        [TestMethod()]
        public void Elephant_CrippledStatus_Test()
        {
            var animal = new Elephant();

            var expected = "Crippled";

            animal.Status = "Health";
            animal.Health = 69;

            animal.DecreaseHealth();

            Assert.AreEqual(animal.Status, expected);
        }

        /// Tests behaviour elephant status is set to alive when health is above fatal health after being crippled.
        [TestMethod()]
        public void Elephant_AliveStatus_Test()
        {
            var animal = new Elephant();

            var expected = "Alive";

            animal.Status = "Crippled";
            animal.Health = 69;

            animal.IncreaseHealth(Zoo.GenerateFeedValue());

            Assert.AreEqual(animal.Status, expected);
        }
        
    }
}