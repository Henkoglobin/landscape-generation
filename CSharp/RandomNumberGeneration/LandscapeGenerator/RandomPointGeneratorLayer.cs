using System;
using System.Linq;
using LandscapeGenerator.Core;
using ParameterParsing.Core;
using RandomNumberGenerators;

namespace LandscapeGenerator {
    public class RandomPointGeneratorLayer : IGeneratorLayer {
        public ILandscape Generate(ILandscape input, IParameterProvider paramProvider) {
            var pointsCount = paramProvider.Get<int>("num");
            var width = paramProvider.Get<int>("w");
            var height = paramProvider.Get<int>("h");
            var rng = new BlumBlumShub(DateTime.Now.Ticks);

            return new ImmutableLandscapeBuilder()
                .SetWidth(width)
                .SetHeight(height)
                .SetPoints(
                    Enumerable.Range(0, pointsCount)
                        .Select(x => new Point(rng.Next(width), rng.Next(height)))
                        .ToList()
                )
                .Build();
        }
    }
}
