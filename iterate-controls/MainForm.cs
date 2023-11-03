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
            foreach (var control in this.IterateControls())
            {
                var indent = 
                    string.Join(
                        string.Empty, 
                        Enumerable.Repeat(" ", control.ControlDepth()));
                var title = 
                    string.IsNullOrWhiteSpace(control.Name) ?
                        $"Unnamed {control.GetType().Name}" :
                        control.Name;
                Debug.WriteLine($"{indent}{title}");
            }

            // Iterate DataGridView only
            Debug.WriteLine("\nDATA GRID VIEW CONTROLS");
            foreach (var control in this.IterateControls().OfType<DataGridView>())
            {
                Debug.WriteLine(control.Name);
            }
        }
    }
    static class Extensions
    {
        public static IEnumerable<Control> IterateControls(this Control control) =>
            IterateControls(control.Controls);
        private static IEnumerable<Control> IterateControls(Control.ControlCollection controls)
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
        public static int ControlDepth(this Control control)
        {
            int depth = -1;
            Control? parent = control;
            while (true)
            {
                parent = parent.Parent;
                if (parent == null)
                {
                    return depth;
                }
                else
                {
                    depth++;
                }
            }
        }
    }
}