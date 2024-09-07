using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CopyDialogLunarLander {
    internal class BadAppleFrameSource {
        static PixelFormat pixelFormat = PixelFormats.Rgb24;
        static int width = 114;
        static int height = 86;
        static int bytesPerPixel = pixelFormat.BitsPerPixel / 8;
        static int stride = width * bytesPerPixel;

        static byte[][] frames = new byte[6569][];

        //static long fps = (long) (1.0 / 60.0 * 10000000.0);
        static long fps = 166667 * 2;

        static long accumulator = 0;
        static int frameIndex = 0;

        static bool ready = false;

        public static void init() {
            if (ready)
                return;
            ready = true;

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CopyDialogLunarLander.Source.BadApple.BadAppleFrames.txt");

            byte[] line = new byte[9805];

            while (stream.Read(line, 0, 9805) >= 9804) {
                frames[frameIndex] = new byte[9804 * bytesPerPixel];

                for (int i = 0; i < 9804; i++) {
                    frames[frameIndex][(i * bytesPerPixel) + 0] = (byte) ((line[i] == '1') ? 0x06 : 0xa7);
                    frames[frameIndex][(i * bytesPerPixel) + 1] = (byte) ((line[i] == '1') ? 0xb0 : 0xe5);
                    frames[frameIndex][(i * bytesPerPixel) + 2] = (byte) ((line[i] == '1') ? 0x25 : 0x91);
                }
                
                frameIndex++;
            }

            frameIndex = 0;
        }

        public static void reset() {
            frameIndex = 0;
        }

        public static BitmapSource frame(long delta) {
            accumulator += delta;

            while (accumulator >= fps) {
                accumulator -= fps;
                frameIndex++;

                if (frameIndex >= frames.Length) frameIndex = 0;
            }

            return BitmapSource.Create(width, height, 96, 96, pixelFormat, null, frames[frameIndex], stride);
        }
    }
}
