using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ZooSim
{
    /// <summary>
    /// <c>Zoo</c> class stores all the animals within the class. Animals can be fed and lose health every hour
    /// which is handled through a timer. Each animal can be fed where a value is generated for each type of
    /// animal.
    /// </summary>
    public class Zoo : IZoo
    {
        private List<Animal> _animals;
        private Timer _zooTimer;
        private int _timeElapsed = 0;
        private const double ZooTimerInterval = 20000;

        /// <value> Gets the time value of the Zoo</value>
        public String TimeLabel{
            get
            {
                return _timeElapsed.ToString();
            }
            }

        /// <value> Gets a list of animals in the Zoo</value>
        public List<Animal> Animals
        {
            get
            {
                return _animals;
            }
            
        }

        /// <summary>
        /// <c>Zoo</c> constructor which takes three int parameters for each quanity of animals to be created
        /// within the zoo. Each animal is instantiated and added to a list of animals. A timer is setup to 
        /// monitor the time passed at the zoo.
        /// </summary>
        /// <param name="giraffes">Giraffe Quantity</param>
        /// <param name="elephants">Elephant Quantity</param>
        /// <param name="monkeys">Monkey Quantity</param>
        public Zoo(int giraffes, int elephants, int monkeys)
        {
            _animals = new List<Animal>();

            SetupZooTimer();

            for(int i = 0; i < giraffes; i++)
            {
                _animals.Add(new Giraffe());
            }

            for(int i = 0; i < elephants; i++)
            {
                _animals.Add(new Elephant());
            }

            for (int i = 0; i < monkeys; i++)
            {
                _animals.Add(new Monkey());
            }
        }

        /// <summary>
        /// UpdatesZoo called on every simulated hour (20 seconds) at the interval of a timer to decrease health of animals.
        /// Ensures that animal objects are no longer being manipulated once they are dead.
        /// </summary>
        private void UpdateZoo()
        {
            foreach (Animal a in _animals)
            {
                if(!(a.Status is "Dead"))
                {
                    a.DecreaseHealth();
                }
            }
        }

        /// <summary>
        /// FeedAnimals Each animal is fed increasing their health by a value which is computed for each animal
        /// type. Each animals health is increased by the value of the feed that was generated.
        /// </summary>
        public void FeedAnimals()
        {

            float giraffeFeed = GenerateFeedValue();
            float monkeyFeed = GenerateFeedValue();
            float elephantFeed = GenerateFeedValue();

            foreach (Animal a in _animals)
            {
                if (a is Giraffe)
                {
                    a.IncreaseHealth(giraffeFeed);
                }

                if (a is Elephant)
                {
                    a.IncreaseHealth(elephantFeed);
                }

                if (a is Monkey)
                {
                    a.IncreaseHealth(monkeyFeed);
                }
                
            }   
        }

        /// <summary>
        /// Generates random value between 10 and 25 for the feed value to increase health of an animal.
        /// </summary>
        /// <returns>Feed Value</returns>
        public static float GenerateFeedValue()
        {
            return Utils.GetRandomNumber(10, 25);
        }
        
        /// <summary>
        /// <c>SetupZooTimer</c> Intialises a Timer that has intervals of 20 seconds to decrease health of animals.
        /// Ensures timer is enabled and events are continually fired. Elapsed method is pointed to the EventHandler.
        /// </summary>
        private void SetupZooTimer()
        {
            _zooTimer = new Timer();
            _zooTimer.Interval = ZooTimerInterval;

            _zooTimer.Elapsed += OnTimedEvent;

            _zooTimer.AutoReset = true;

            _zooTimer.Enabled = true;
        }

        /// <summary>
        /// EventHandler for the timer increments time by 1 simulated hour (20 seconds) and updates animals 
        /// within the zoo.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            _timeElapsed += 1;
            this.UpdateZoo();
        }
    }
}
