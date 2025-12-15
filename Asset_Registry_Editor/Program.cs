using System;
using System.Windows.Forms;

namespace Asset_Registry_Editor;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(defaultValue: false);
        if (args.Length != 0)
        {
            Application.Run(new AREditor(args[0]));
        }
        else
        {
            Application.Run(new AREditor());
        }
    }
}
