using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooSim
{
    /// <summary>
    /// Interface for <c>ZooView</c> that allows access via <c>ZooPresenter</c> to set elements 
    /// to display <c>Zoo</c> model data
    /// </summary>
    public interface IZooView
    {
        string LabelValue { set; get; }

        List<Animal> ListViewValues { set; }

        ListView.ListViewItemCollection ListViewItems { get; }
        
        void ShowZooData();

        void UpdateTimer();
    }
}
