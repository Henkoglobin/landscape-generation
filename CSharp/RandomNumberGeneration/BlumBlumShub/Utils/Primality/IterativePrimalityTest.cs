using System;

namespace RandomNumberGenerators.Utils.Primality {
    public class IterativePrimalityTest : IPrimalityTest {
        public bool Test(long number) {
            if(number <= 1) return false;
            if(number == 2) return true;

            for(int i = 2; i <= (int)Math.Ceiling(Math.Sqrt(number)); i++) {
                if(number % i == 0) return false;
            }

            return true;
        }
    }
}
