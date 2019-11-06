using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooSim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /// <remarks>
            /// Create a View to display Zoo and initializes the Zoo with 5 Giraffes, 5 Elephants
            /// and 5 Monkeys.
            /// Ideally these parameters should be stored in a system preferences 
            /// or retrieved by a Zoo Setup View.
            /// </remarks> 
            Application.Run(new ZooView(new Zoo(5,5,5)));

            /// <remarks>
            /// Obsolete <c>ZooForm</c> created at the start of the project.
            /// Refactored to a preferred MVP design pattern 
            /// </remarks>
            //Application.Run(new ZooForm());
        }
    }
}
