using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{   /// <summary>
    /// Giraffe Class extends abstract Animal class calling the base constructor and setting the different FatalHealth
    /// value. 
    /// </summary>
    public class Giraffe:Animal
    {
        public Giraffe()
            :base()
        {
            this.FatalHealth = 50;
        }

    }
}
