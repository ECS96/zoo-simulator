using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooSim
{
    /// <summary>
    /// A <c>ZooPresenter</c> Class to access and manipulate data in <c>Zoo</c> model and retrieve
    /// information through interfaces for the <c>ZooView</c>.
    /// </summary>
    public class ZooPresenter : IZooPresenter
    {
        private IZooView _zooView;
        private IZoo _zoo;

        /// <summary>
        /// ZooPresenter takes the <c>ZooView</c> view and <c>Zoo</c> model objects to allow
        /// control between the user interface and back end.
        /// </summary>
        /// <param name="zooView">View for displau of zoo information</param>
        /// <param name="zoo">Model contains information on the animals</param>
        public ZooPresenter(IZooView zooView, IZoo zoo)
        {
            _zooView = zooView;
            _zoo = zoo;

        }

        /// <summary>
        /// <c>SetListViewValues</c> Passes Zoo Animals from model to ListView in ZooView.
        /// </summary>
        public void SetListViewValues()
        {
            _zooView.ListViewValues = _zoo.Animals;
        }

        /// <summary>
        /// <c>SetListViewValues</c> Passes Zoo Simulation Timer from model to Label in ZooView.
        /// </summary>
        public void SetTextValue()
        {
            _zooView.LabelValue = "Hours: "+_zoo.TimeLabel;
        }

        /// <summary>
        /// <c>FeedAnimals</c> Action to feed animals in the Zoo.
        /// </summary>
        public void FeedAnimals()
        {
            _zoo.FeedAnimals();
        }
    }
}
