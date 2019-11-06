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
    public class ZooTests
    {
        /// Tests behaviour no animals are in zoo if none have been passed.
        [TestMethod()]
        public void Zoo_NoAnimals_Test()
        {
            var zoo = new Zoo(0,0,0);
            
            Assert.IsFalse(zoo.Animals.Any());
        }

        /// Tests if giraffe exists if 1 giraffe is created in the zoo.
        [TestMethod()]
        public void Zoo_Giraffe_Test()
        {
            var zoo = new Zoo(1, 0, 0);

            Assert.IsTrue(zoo.Animals.Exists(IsGiraffe));
        }

        /// Tests if giraffe exists if 1 elephant is created in the zoo.
        [TestMethod()]
        public void Zoo_Elephant_Test()
        {
            var zoo = new Zoo(0, 1, 0);

            Assert.IsTrue(zoo.Animals.Exists(IsElephant));
        }


        /// Tests if giraffe exists if 1 monkey is created in the zoo.
        [TestMethod()]
        public void Zoo_Monkey_Test()
        {
            var zoo = new Zoo(0, 0, 1);

            Assert.IsTrue(zoo.Animals.Exists(IsMonkey));
        }

        /// Tests behaviour when animals are fed in the zoo their health increases.
        [TestMethod()]
        public void Zoo_FeedAnimals_Test()
        {
            var zoo = new Zoo(1, 1, 1);

            foreach (Animal a in zoo.Animals)
            {
                a.Health = 50;
            }

            zoo.FeedAnimals();

            Assert.IsTrue(zoo.Animals.TrueForAll(HasIncreased));
        }

        /// Tests behaviour dead animals cannot be fed.
        [TestMethod()]
        public void Zoo_FeedDeadAnimals_Test()
        {
            var zoo = new Zoo(1, 1, 1);

            foreach (Animal a in zoo.Animals)
            {
                a.Health = 0;
                a.Status = "Dead";
            }

            zoo.FeedAnimals();

            Assert.IsTrue(zoo.Animals.TrueForAll(IsUnmodified));
        }

        /// Tests behaviour health gained from feed is generated within correct values.
        [TestMethod()]
        public void Zoo_GenerateFeedValue_Test()
        {
            var value = Zoo.GenerateFeedValue();

            var valid = ((value >= 10) && (value <= 25));

            Assert.IsTrue(valid );
        }

        /// Tests behaviour animals health decrease after 20 seconds.
        [TestMethod()]
        public void Zoo_Timer_Test()
        {
            var zoo = new Zoo(1, 1, 1);

            System.Threading.Thread.Sleep(22000);

            Assert.IsTrue(zoo.Animals.TrueForAll(HasDecreased));
        }

        private static bool HasDecreased(Animal a)
        {
            return a.Health < 100;
        }

        private static bool IsGiraffe(Animal a)
        {
            return a is Giraffe;
        }

        private static bool IsElephant(Animal a)
        {
            return a is Elephant;
        }

        private static bool IsMonkey(Animal a)
        {
            return a is Monkey;
        }

        private static bool HasIncreased(Animal a)
        {
            return a.Health > 50;
        }

        private static bool IsUnmodified(Animal a)
        {
            return a.Health == 0;
        }
    }
}