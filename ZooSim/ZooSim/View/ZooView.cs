using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooSim
{
     /// <summary>
     /// The <c>ZooView</c> Class
     /// Contains all the methods to update the windows form with Zoo information provided through
     /// the zoo presenter.
     /// </summary>
     /// <remarks>
     /// This class can update the Timer label and Animals ListView and provides an action to
     /// feed the zoo with a button.
     /// </remarks>
    public partial class ZooView : Form, IZooView 
    {
        private ZooPresenter _presenter = null;
        private readonly Zoo _zoo;

        /// <summary>
        /// ZooView Constructor initialize components of form, begins timer, passes the <c>ZooView</c>
        /// and <c>Zoo</c> to <c>ZooPresenter</c> class for manipulation outside <c>ZooView</c>. 
        /// Displays initial values of <c>Zoo</c>.
        /// </summary>
        /// <param name="zoo">Zoo object passed to View</param>
        public ZooView(Zoo zoo)
        {
            _zoo = zoo;
            InitializeComponent();
            UpdateTimer();
            _presenter = new ZooPresenter(this, _zoo);
            ShowZooData();
        }

        /// <value> Gets and sets the text label value of the Timer. </value>
        public string LabelValue
        {
            set
            {
                TimeLabel.Text = value;
            }

            get
            {
                return TimeLabel.Text;
            }
        }

        /// <value> Sets the <c>ListView</c> containg <c>Animal</c> information. </value>
        public List<Animal> ListViewValues
        {
            set
            {
                AnimalListView.Items.Clear();
                foreach (Animal a in value)
                {
                    string animal = a.GetType().ToString();
                    ListViewItem animalItem = new ListViewItem(animal.Replace("ZooSim.", ""));

                    animalItem.SubItems.Add(a.Health.ToString() + "%");
                    animalItem.SubItems.Add(a.Status);

                    AnimalListView.Items.Add(animalItem);
                    

                }
            }
        }

        /// <value> Gets the ListView Collection of Items. </value>
        public ListView.ListViewItemCollection ListViewItems
        {
            get
            {
                return AnimalListView.Items;
            }
        }

        /// <summary>
        /// ShowZooData updates the elements of the form with methods in <c>ZooPresenter/c> that
        /// has access to Zoo model.
        /// </summary>
        public void ShowZooData()
        {
            _presenter.SetListViewValues();
            _presenter.SetTextValue();
            AnimalListView.Refresh();
        }

        /// <summary>
        /// UpdateTimer controls the rate at which the form continues to update at once a second.
        /// </summary>
        public void UpdateTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        
        /// <summary>
        /// EventHandler for Timer thrown at every interval to call update on <c>ZooView</c>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.ShowZooData();
        }

        /// <summary>
        /// EventHandler for Button thrown on click to feed the animals in the zoo through
        /// the <c>ZooPresenter</c>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeedButton_Click(object sender, EventArgs e)
        {
            _presenter.FeedAnimals();
            this.ShowZooData();
        }
    }
}
