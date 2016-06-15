using LandscapeGenerator.Core;

namespace LandscapeRendering.Core {
    public interface ILandscapeRenderer {
        string Description { get; }
        string[] OutputFormats { get; }

        void RenderTo(ILandscape landscape, string filename);
    }
}
