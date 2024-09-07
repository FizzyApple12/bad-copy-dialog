using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CopyDialogLunarLander
{
    class BadApple : IDisposable
    {
        System.Windows.Size size;
        Rect videoSize;

        //Stream videoStream;
        //MediaPlayer mediaPlayer;

        public BadApple(System.Windows.Size size) {
            this.size = size;

            double videoHeight = size.Height - 9;
            double videoWidth = videoHeight * (4.0 / 3.0);
            this.videoSize = new Rect((size.Width / 2.0) - (videoWidth / 2.0), 7, videoWidth, videoHeight);

            BadAppleFrameSource.init();
            BadAppleFrameSource.reset();
        }

        public void DrawNextFrame(DrawingContext drawingContext, long delta) {
            //drawingContext.DrawRectangle(new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0)), null, videoSize);

            BitmapSource frame = BadAppleFrameSource.frame(delta);

            drawingContext.DrawImage(frame, videoSize);
            //drawingContext.DrawVideo(mediaPlayer, videoSize);
        }

        public void Dispose() {

        }
    }
}
