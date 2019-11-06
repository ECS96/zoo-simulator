using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{   /// <summary>
     /// Elephant Class extends abstract Animal class calling the base constructor and setting the 
     /// different FatalHealth value. DecreaseHealth and IncreaseHealth are overriden to implement the staggered
     /// death after FatalHealth is reached.
     /// </summary>
    public class Elephant:Animal
    {
        
        public Elephant()
            :base()
        {
            this.FatalHealth = 70;
        }

        /// <summary>
        /// DecreaseHealth An elephant is not dead when its Health falls below fatal health, the status is set to
        /// crippled until the next hour and therefore can be saved by feeding it. If it remains in fatal health 
        /// then it is pronounced dead the next time the method is called. Base Method cannot be called but similar
        /// behaviour implemented.
        /// </summary>
        public override void DecreaseHealth()
        {
            if ((Health < FatalHealth) && (Status is "Crippled"))
            {
                this.Health = 0;
                this.Status = "Dead";
            }
            else
            {
                int healthLoss = Utils.GetRandomNumber(0, 20);

                this.Health = Utils.Cap(Health - healthLoss, MinHealth, MaxHealth);

                if ((Health < FatalHealth) && !(Status is "Dead"))
                {
                    Status = "Crippled";
                }
            }
        }

        /// <summary>
        /// IncreaseHealth An elephant can changes status by increasing its health above fatal health. So the method
        /// is overriden to allow the status to be changed in the even of this.
        /// </summary>
        /// <param name="healthGain"></param>
        public override void IncreaseHealth(float healthGain)
        {
            base.IncreaseHealth(healthGain);

            if((Health > FatalHealth) && (Status is "Crippled"))
            {
                Status = "Alive";
            }
        }
    }
}
