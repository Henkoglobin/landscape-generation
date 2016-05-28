using System;
using System.Diagnostics;
using RandomNumberGenerators.Utils.Primality;

namespace RandomNumberGenerators {
    public class BlumBlumShub : RandomNumberGenerator {
        private const long DefaultP = 3511;
        private const long DefaultQ = 17519;

        private readonly long pq;
        private long state;

        public BlumBlumShub(long seed)
            : this(DefaultP, DefaultQ, seed) { }

        public BlumBlumShub(long p, long q, long seed) {
            if(!ValidatePrime(p)) {
                throw new ArgumentOutOfRangeException(nameof(p), $"Blum-Blum-Shub requires {nameof(p)} to be a prime congruent to 3 (mod 4).");
            }

            if(!ValidatePrime(q)) {
                throw new ArgumentOutOfRangeException(nameof(q), $"Blum-Blum-Shub requires {nameof(q)} to be a prime congruent to 3 (mod 4).");
            }

            if(!ValidateSeed(seed)) {
                throw new ArgumentOutOfRangeException(nameof(seed), $"Blum-Blum-Shub requires {nameof(seed)} to be greater than 1.");
            }

            this.pq = p * q;
            this.state = seed;
        }

        private bool ValidatePrime(long candidate) {
            return new FermatPrimalityTest().Test(candidate) && candidate % 4 == 3;
        }

        private bool ValidateSeed(long seed) {
            return seed > 1;
        }

        public override double Sample() {
            var value = (this.state * this.state) % pq;
            Debug.WriteLine($"Update, State = {this.state}, New State = {value}");
            this.state = value;
            return (double)value / (pq - 1);
        }
    }
}
