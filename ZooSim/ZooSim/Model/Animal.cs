﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{
    /// <summary>
    /// <c>Animal</c> class stores information on each Animal within the Zoo. The status, health and
    /// fatal health are stored and manipulated through the simluation. An abstract animal ensures that an
    /// overriden constructor needs to be a specific animal subclass.
    /// </summary>
    public abstract class Animal
    {
        protected const float MinHealth = 0;
        protected const float MaxHealth = 100;

        /// <value> Gets the health at which the animal is pronounced dead or near death</value>
        public float FatalHealth { get; protected set; }
        
        /// <value> Gets the current health of the animal</value>
        public float Health { get; set; }

        /// <value> Gets the health status of the animal </value>
        public string Status { get; set; }

        /// <summary>
        /// Animal constructor every animal is created with maximum health 100 with the status alive.
        /// </summary> 
        public Animal()
        {
            this.Health = 100;
            this.Status = "Alive";
        }

        /// <summary>
        /// DecreaseHealth Checks If the animal is not dead and decreases the animals health. Health is capped
        /// within a minimum and maximum health. Status is updated if the animals health is decreased below the fatal
        /// health then it is pronounced dead. <c>virtual</c> qualifier allows overriding the method 
        /// if animal is different.
        /// </summary>
        public virtual void DecreaseHealth()
        {
            if (!(Status is "Dead"))
            {
                int healthLoss = Utils.GetRandomNumber(0, 20);

                this.Health = Utils.Cap(Health - healthLoss, MinHealth, MaxHealth);

                if (Health < FatalHealth)
                {
                    this.Health = 0;
                    this.Status = "Dead";
                }
            }
        }

        /// <summary>
        /// IncreaseHealth Checks if the animal is not dead and increases the animals health. Ensures the health does
        /// not go beyond its max health. <c>virtual</c> qualifier allows overriding the method
        /// if animal is different.
        /// </summary>
        /// <param name="healthGain"> Feed value generated by the Zoo</param>
        public virtual void IncreaseHealth(float healthGain)
        {
            if (!(Status is "Dead"))
            {
                this.Health = Utils.Cap(Health + healthGain, MinHealth, MaxHealth);
            }  
        }

    }
}