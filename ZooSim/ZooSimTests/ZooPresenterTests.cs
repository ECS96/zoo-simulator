using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooSim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooSim.Tests
{   
    [TestClass()]
    public class ZooPresenterTests
    {
        /// Tests behaviour that timer label in the ui updates from the zoo model.
        [TestMethod()]
        public void Presenter_SetTimerLabel_Test()
        {
            var zoo = new Zoo(5, 5, 5);
            var view = new ZooView(zoo);
            var presenter = new ZooPresenter(view, zoo);
            var expected = "Hours: 0";

            presenter.SetTextValue();

            
            Assert.AreEqual(expected,view.LabelValue);
        }

        /// Tests behaviour of the feed button in the ui to feed the animals in the zoo model.
        [TestMethod()]
        public void Presenter_FeedAction_Test()
        {
            var zoo = new Zoo(5, 5, 5);
            var view = new ZooView(zoo);
            var presenter = new ZooPresenter(view, zoo);

            foreach (Animal a in zoo.Animals)
            {
                a.Health = 50;
            }

            presenter.FeedAnimals();

            Assert.IsTrue(zoo.Animals.TrueForAll(HasIncreased));

        }

        /// Tests behaviour of the listview to display and update values of animals on changes
        [TestMethod()]
        public void Presenter_AnimalValues_Test()
        {
            var zoo = new Zoo(1, 0, 0);
            var view = new ZooView(zoo);
            var presenter = new ZooPresenter(view, zoo);
            var expected = "50%";

            foreach (Animal a in zoo.Animals)
            {
                a.Health = 50;
            }

            presenter.SetListViewValues();

            ListViewItem item = view.ListViewItems[0];
            
            ListViewItem.ListViewSubItem subItem = item.SubItems[1];
            
            Assert.AreEqual(expected,subItem.Text);
        }

        [TestMethod()]
        private static bool HasIncreased(Animal a)
        {
            return a.Health > 50;
        }
    }
}