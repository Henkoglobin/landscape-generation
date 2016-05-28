namespace RandomNumberGenerators.Utils {
    public static class MathUtil {
        public static long ModPow(long number, long exponent, long modulus) {
            if(modulus == 1) return 0;

            long result = 1;
            number = number % modulus;
            while(exponent > 0) {
                if(exponent % 2 == 1) {
                    result = (result * number) % modulus;
                }
                exponent >>= 1;
                number = (number * number) % modulus;
            }

            return result;
        }
    }
}
