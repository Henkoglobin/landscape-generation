using ParameterParsing.Core;

namespace LandscapeGenerator.Core {
    public interface IGeneratorLayer {
        ILandscape Generate(ILandscape input, IParameterProvider paramProvider);
    }
}
