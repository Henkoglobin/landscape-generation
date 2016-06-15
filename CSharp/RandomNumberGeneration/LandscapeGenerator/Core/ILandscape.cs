using System.Collections.Generic;

namespace LandscapeGenerator.Core {
    public interface ILandscape {
        IList<Point> Points { get; }
        int Width { get; }
        int Height { get; }
    }
}
