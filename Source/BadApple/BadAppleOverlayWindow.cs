using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace CopyDialogLunarLander
{
    public class BadAppleOverlayWindow : OverlayWindow
    {
        private BadApple _video;

        private static ToolStripMenuItem _menuEasy;
        private static ToolStripMenuItem _menuHard;

        long lastTicks = 0;
        public BadAppleOverlayWindow()
        {
        }

        static void FillOptions(System.Windows.Forms.ToolStripMenuItem optionsMenu) {
            optionsMenu.DropDownItems.Add(":tf:");
        }

        public override void Init(Size size) {
            _video = new BadApple(size);
        }

        public override void DeInit()
        {
            _video.Dispose();
        }

        public override void HeightFieldUpdated(float[] heightField, System.Drawing.Color color)
        {

        }

        public override void Update(DrawingGroup _backingStore, OverlayStats stats)
        {
            if (lastTicks == 0)
                lastTicks = DateTime.Now.Ticks;

            var drawingContext = _backingStore.Open();

            long currentTicks = DateTime.Now.Ticks;

            _video.DrawNextFrame(drawingContext, (currentTicks - lastTicks));

            lastTicks = currentTicks;

            drawingContext.Close();
        }
    }
}
