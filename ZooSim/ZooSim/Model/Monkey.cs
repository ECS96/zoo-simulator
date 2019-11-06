using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{   /// <summary>
    /// Monkey Class extends abstract Animal class calling the base constructor and setting the different FatalHealth
    /// value. 
    /// </summary>
    public class Monkey:Animal
    {

        public Monkey()
            :base()
        {
            this.FatalHealth = 30;
        }
    }
}
