using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSim
{
    /// <summary>
    /// <c>IZooPresenter</c> interface to enable ZooView to request information form the Zoo Model
    /// through the presenter.
    /// </summary>
    public interface IZooPresenter
    {
        void SetTextValue();
        void SetListViewValues();
    }
}
