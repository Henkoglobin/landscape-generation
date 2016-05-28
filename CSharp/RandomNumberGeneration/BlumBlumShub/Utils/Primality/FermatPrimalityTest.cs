using System.Linq;

namespace RandomNumberGenerators.Utils.Primality {
    public class FermatPrimalityTest : IPrimalityTest {
        private static readonly long[] tests = new long[] { 2, 3 };

        public bool Test(long number) {
            if(number < 2) return false;
            if(number != 2 && number % 2 == 0) return false;

            foreach(var test in tests.Where(x => x < number)) {
                if(MathUtil.ModPow(test, number - 1, number) != 1) {
                    return false;
                }
            }

            return true;
        }
    }
}
