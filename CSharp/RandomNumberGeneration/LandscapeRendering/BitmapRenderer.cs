using System.Drawing;
using LandscapeGenerator.Core;
using LandscapeRendering.Core;

namespace LandscapeRendering {
    public class BitmapRenderer : ILandscapeRenderer {
        private const int PointSize = 4;

        public string Description => "Renders a landscape to a Bitmap";

        public string[] OutputFormats => new[] { "bmp" };

        public void RenderTo(ILandscape landscape, string filename) {
            using(var bitmap = new Bitmap(landscape.Width, landscape.Height)) {
                using(var graphics = Graphics.FromImage(bitmap)) {
                    var pointBrush = Brushes.CornflowerBlue;
                    var pointPen = Pens.Orange;

                    foreach(var point in landscape.Points) {
                        var rect = new Rectangle(point.X - PointSize / 2, point.Y - PointSize / 2, PointSize, PointSize);
                        graphics.FillEllipse(pointBrush, rect);
                        graphics.DrawEllipse(pointPen, rect);
                    }

                    bitmap.Save(filename);
                }
            }
        }
    }
}
