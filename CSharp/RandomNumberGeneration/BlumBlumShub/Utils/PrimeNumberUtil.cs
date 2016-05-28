using System;
using System.Collections.Generic;
using RandomNumberGenerators.Utils.Primality;

namespace RandomNumberGenerators.Utils {
    public static class PrimeNumberUtil {
        public static IEnumerable<long> GetPrimes(IPrimalityTest test) {
            yield return 2;
            for(long i = 3; i < Int64.MaxValue; i += 2) {
                if(test.Test(i)) {
                    yield return i;
                }
            }
        }
    }
}
