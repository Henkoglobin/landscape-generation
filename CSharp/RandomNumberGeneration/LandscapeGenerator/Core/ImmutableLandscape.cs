using System.Collections.Generic;

namespace LandscapeGenerator.Core {
    public class ImmutableLandscape : ILandscape {
        public int Width { get; }
        public int Height { get; }

        public IList<Point> Points { get; }

        
        public ImmutableLandscape(int width, int height, IList<Point> points) {
            this.Width = width;
            this.Height = height;
            this.Points = points;
        }
    }
}
