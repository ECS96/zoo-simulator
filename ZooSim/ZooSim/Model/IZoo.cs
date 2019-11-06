using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{
    /// <summary>
    /// <c>IZoo</c> interface for presenter to access Animal and Timer information and perform the action to
    /// feed the animals through the ZooView Button passed by the presenter.
    /// </summary>
    public interface IZoo
    {
        String TimeLabel { get; }

        List<Animal> Animals { get; }

        void FeedAnimals();
    }
}
