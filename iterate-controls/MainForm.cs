using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace iterate_controls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Iterate all names
            Debug.WriteLine("\n\nALL CONTROLS");
            foreach (var control in IterateControls(Controls))
            {
                Debug.WriteLine(
                    string.IsNullOrWhiteSpace(control.Name) ?
                        $"Unnamed {control.GetType().Name}"  :
                        control.Name);
            }

            // Iterate DataGridView only
            Debug.WriteLine("\nDATA GRID VIEW CONTROLS");
            foreach (var control in IterateControls(Controls).OfType<DataGridView>())
            {
                Debug.WriteLine(control.Name);
            }
        }
        IEnumerable<Control> IterateControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls) 
            {
                yield return control;
                foreach (Control child in IterateControls(control.Controls))
                { 
                    yield return child;
                }
            }
        }
    }
}