using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace VisualStudioFreezingRepro
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bitmatRgbData = CreateRGBByteArray(1000, 500);


            bitmatRgbData.ShouldBe(new byte[0]);
        }

        private static byte[] CreateRGBByteArray(int width, int height)
        {
            var dv = new DrawingVisual();
            TextOptions.SetTextRenderingMode(dv, TextRenderingMode.Aliased);
            TextOptions.SetTextFormattingMode(dv, TextFormattingMode.Ideal);

            using (var dc = dv.RenderOpen())
            {
                dc.DrawRectangle(new SolidColorBrush(Colors.White), null, new Rect(0, 0, width, height));
                var radius = width / 2;
                dc.DrawEllipse(
                    new SolidColorBrush(Colors.Crimson),
                    null,
                    new System.Windows.Point(0.5 * width, 0.5 * height),
                    radius,
                    radius);
            }
            RenderTargetBitmap rtb = new RenderTargetBitmap(
                width,
                height,
                96,
                96,
                PixelFormats.Pbgra32);
            rtb.Render(dv);

            var converted = new FormatConvertedBitmap(rtb, PixelFormats.Bgr24, null, 0);

            var imageBytes = new byte[rtb.PixelHeight * rtb.PixelWidth * 3];
            converted.CopyPixels(imageBytes, rtb.PixelWidth * 3, 0);

            return imageBytes;
        }
    }
}
