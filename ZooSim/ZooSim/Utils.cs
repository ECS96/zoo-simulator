using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{   /// <summary>
    /// General Utilities class which contains methods that are globally used.
    /// GetRandomNumber to generates health and feed changes within the Zoo and Animal classes
    /// Cap to ensures health stays within bounds.
    /// </summary>
    public static class Utils
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Random number generator method is static to ensure numbers are truely random with each
        /// execution by locking a single instance of random. As multiple instances tend to read same system 
        /// clock values.
        /// </summary>
        /// <param name="min">lower bound of random possible number</param>
        /// <param name="max">upper bound of random possible number</param>
        /// <returns></returns>
        public static int GetRandomNumber(int min, int max)
        {
            lock(Random)
            {
                return Random.Next(min, max);
            }
        }

        /// <summary>
        /// Check a values is set between a lower and upper bound if not assigns it rounds to the lower
        /// or upper bound.
        /// </summary>
        /// <param name="value">input value</param>
        /// <param name="min">lower bound</param>
        /// <param name="max">upper bound</param>
        /// <returns></returns>
        public static float Cap (float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
    }
}
