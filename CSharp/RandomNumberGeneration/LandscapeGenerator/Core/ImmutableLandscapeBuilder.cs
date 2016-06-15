using System;
using System.Collections.Generic;

namespace LandscapeGenerator.Core {
    public class ImmutableLandscapeBuilder {
        private int? width;
        private int? height;
        private IList<Point> points;

        public ImmutableLandscapeBuilder() { }

        public ImmutableLandscapeBuilder(int width, int height) {
            this.width = width;
            this.height = height;
        }

        public ImmutableLandscapeBuilder SetWidth(int width) {
            this.width = width;
            return this;
        }

        public ImmutableLandscapeBuilder SetHeight(int height) {
            this.height = height;
            return this;
        }

        public ImmutableLandscapeBuilder SetPoints(IList<Point> points) {
            this.points = points;
            return this;
        }

        public ImmutableLandscape Build() {
            if(!width.HasValue || !height.HasValue) {
                throw new InvalidOperationException($"At least {nameof(width)} and {nameof(height)} must be provided.");
            }

            return new ImmutableLandscape(width.Value, height.Value,
                points: points);
        }
    }
}
