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
    /// <c>ZooForm</c> refactored to MVP to seperate logic, element setup and model access.
    /// </summary>
    public class ZooForm : Form
    {
        private Zoo zoo;

        private ListView zooView = new ListView();
        private Button feedButton =  new Button();
        private Label timeLabel = new Label();

        private Timer updateTimer = new Timer();

        private long zooTime = 0;

        public ZooForm()
        {

            SetupForm();
            SetupLabels();
            SetupButtons();
            SetupZooTimer();
            SetupListViews();

            zoo = new Zoo(5, 5, 5);
            
            PopulateListView();

            this.Controls.Add(zooView);
            this.Controls.Add(timeLabel);
            this.Controls.Add(feedButton);

        }

        private void SetupForm()
        {

            this.Text = "Zoo Simulator";
            this.MinimumSize = new Size(512, 300);
        }

        private void SetupLabels()
        {
            timeLabel.BorderStyle = BorderStyle.Fixed3D;
            timeLabel.Text = "Hours: ";
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Font = new Font("Arial", 12);
        }
        
        private void SetupButtons()
        {

            feedButton.Text = "Feed";
            feedButton.Click += new EventHandler(feedButton_Click);
            feedButton.Dock = DockStyle.Bottom;
        }

        private void SetupListViews()
        {
            zooView.Dock = DockStyle.Fill;
            zooView.View = View.Tile;
            zooView.TileSize = new Size(100, 45);

            zooView.Columns.Add("Animal", -2, HorizontalAlignment.Left);
            zooView.Columns.Add("Health", -2, HorizontalAlignment.Left);
            zooView.Columns.Add("Status", -2, HorizontalAlignment.Left);
        }
        
        private void feedButton_Click(object sender, EventArgs e)
        {
            zoo.FeedAnimals();
        }

        private void SetupZooTimer()
        {
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            zooTime += 3;
            TimeSpan timeSpan = TimeSpan.FromMinutes(zooTime);
            timeLabel.Text = "Hours: " + timeSpan.Hours;
            PopulateListView();
        }
        
        private void PopulateListView()
        {
            zooView.Items.Clear();
            
            foreach (Animal a in zoo.Animals)
            {
                string animal = a.GetType().ToString();
                ListViewItem animalItem = new ListViewItem(animal.Replace("ZooSim.",""));

                animalItem.SubItems.Add(a.Health.ToString()+"%");
                animalItem.SubItems.Add(a.Status);

                zooView.Items.Add(animalItem);
                
            }

        }
    }
}