using System;
using System.Windows;

namespace CopyDialogLunarLander
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CopyWatcherApplication app = new CopyWatcherApplication();
            BadAppleFrameSource.init();
            app.Run();
        }
    }
}
