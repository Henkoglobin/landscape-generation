using System;

namespace RandomNumberGenerators {
    public abstract class RandomNumberGenerator {
        public int Next()
            => Next(0, Int32.MaxValue);

        public int Next(int max)
            => Next(0, max);

        public int Next(int min, int max)
            => (int)Math.Ceiling(this.Sample() * (max - min) + min);

        public abstract double Sample();
    }
}
