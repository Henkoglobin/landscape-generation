namespace RandomNumberGenerators.Utils.Primality {
    public class MillerRabinPrimalityTest : IPrimalityTest {
        private static long[] tests = new long[] { 2, 7, 61 };

        // TODO: There seems to be a bug somewhere...
        // 7 and 61 are reported as being non-prime.
        // based on http://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23
        public bool Test(long number) {
            if(number < 2) return false;
            if(number != 2 && number % 2 == 0) return false;

            var s = number - 1;
            while(s % 2 == 0) {
                s >>= 1;
            }

            foreach(var a in tests) {
                var temp = s;
                var mod = MathUtil.ModPow(a, temp, number);
                while(temp != number - 1 && mod != 1 && mod != number - 1) {
                    mod = (mod * mod) % number;
                    temp = temp * 2;
                }
                if(mod != number - 1 && temp % 2 == 0) {
                    return false;
                }
            }

            return true;
        }
    }
}
