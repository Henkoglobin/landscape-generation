using System.Diagnostics;
using LandscapeGenerator;
using LandscapeRendering;
using ParameterParsing;

namespace LandscapeGeneratorConsole {
    class Program {
        static void Main(string[] args) {
            var layerName = args[0];
            var provider = new ParameterParser().Parse(args[1]);
            var rendererName = args[2];

            Debug.Assert(layerName == "RandomPointGeneratorLayer");
            Debug.Assert(rendererName == "BitmapRenderer");


            var layer = new RandomPointGeneratorLayer();
            var landscape = layer.Generate(null, provider);
            var renderer = new BitmapRenderer();
            renderer.RenderTo(landscape, "out.bmp");
        }
    }
}
