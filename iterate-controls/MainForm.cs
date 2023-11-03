using System.Collections.Generic;
using System.Diagnostics;

namespace iterate_controls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            IterateControls();
        }
        void IterateControls()
        {
            foreach (Control control in Controls) 
            {
                localIterateControls(control.Controls);
            }
            void localIterateControls(Control.ControlCollection controls)
            {
                foreach (Control child in controls)
                {
                    localIterateControls(child.Controls);
                }
            }
        }
    }
}