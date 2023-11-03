To iterate the control hierarchy of the `Form`, make an [iterator](https://learn.microsoft.com/en-us/dotnet/csharp/iterators) method similar to this:

```
public partial class MainForm : Form
{
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
```

___

First, demonstrate the iterator by listing ALL the controls:

```
// Iterate all names
Debug.WriteLine("ALL CONTROLS");
foreach (var control in IterateControls(Controls))
{
    Debug.WriteLine(
        string.IsNullOrWhiteSpace(control.Name) ?
            $"Unnamed {control.GetType().Name}"  :
            control.Name);
}
```
[![all controls list][1]][1]

___

Your question is how about getting just the `DataGridView` controls, so specify `OfType()`

```

// Iterate DataGridView only
Debug.WriteLine("\nDATA GRID VIEW CONTROLS");
foreach (var control in IterateControls(Controls).OfType<DataGridView>())
{
    Debug.WriteLine(control.Name);
}
```
[![data grid view controls][2]][2]


  [1]: https://i.stack.imgur.com/Fd8ML.png
  [2]: https://i.stack.imgur.com/l2K6t.png