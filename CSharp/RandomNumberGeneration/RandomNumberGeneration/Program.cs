using System;
using System.Diagnostics;
using System.Linq;
using RandomNumberGenerators;
using RandomNumberGenerators.Utils;
using RandomNumberGenerators.Utils.Primality;

namespace RandomNumberGeneration {
    class Program {
        static void Main(string[] args) {
            GeneratePrimes();
            TestBlumBlumShub();
            BenchmarkPrimalityTests();
            ComparePrimalityTests();

            if(Debugger.IsAttached) {
                Console.ReadKey();
            }
        }

        private static void GeneratePrimes() {
            // Find two prime numbers, each greater than
            // a randomly chosen threshold
            long p, q;
            GetPQ(3500, 17500, out p, out q);

            Console.WriteLine($"p = {p}, q = {q}");
        }

        private static void GetPQ(long minP, long minQ, out long p, out long q) {
            p = PrimeNumberUtil.GetPrimes(new FermatPrimalityTest())
                .Where(x => x % 4 == 3)
                .Where(x => x > minP)
                .First();
            q = PrimeNumberUtil.GetPrimes(new FermatPrimalityTest())
                .Where(x => x % 4 == 3)
                .Where(x => x > minQ)
                .First();
        }

        private static void TestBlumBlumShub() {
            RandomNumberGenerator rng = new BlumBlumShub(12);
            var nums = new int[10];
            for(int i = 0; i < 10; i++) {
                nums[i] = rng.Next(1, 100);
            }

            for(int i = 0; i < 10; i++) {
                Console.WriteLine(nums[i]);
            }
        }

        private static void BenchmarkPrimalityTests() {
            var limit = (int)1e6;

            var sw = Stopwatch.StartNew();
            var last = PrimeNumberUtil.GetPrimes(new IterativePrimalityTest()).First(x => x > limit);
            sw.Stop();
            var timeIterativePrimalityTest = sw.Elapsed;

            Console.WriteLine($"Iterative test took    {timeIterativePrimalityTest} for {limit} iterations.");

            sw = Stopwatch.StartNew();
            last = PrimeNumberUtil.GetPrimes(new FermatPrimalityTest()).First(x => x > limit);
            sw.Stop();
            var timeFermatPrimalityTest = sw.Elapsed;

            Console.WriteLine($"Fermat test took       {timeFermatPrimalityTest} for {limit} iterations.");

            sw = Stopwatch.StartNew();
            last = PrimeNumberUtil.GetPrimes(new MillerRabinPrimalityTest()).First(x => x > limit);
            sw.Stop();
            var timeMillerRabinPrimalityTest = sw.Elapsed;

            Console.WriteLine($"Miller-Rabin test took {timeMillerRabinPrimalityTest} for {limit} iterations.");
        }

        private static void ComparePrimalityTests() {
            const int limit = (int)1e3;

            var iterativeResult = PrimeNumberUtil.GetPrimes(new IterativePrimalityTest())
                .TakeWhile(x => x < limit).ToList();
            var fermatResult = PrimeNumberUtil.GetPrimes(new FermatPrimalityTest())
                .TakeWhile(x => x < limit).ToList();
            var millerRabinResult = PrimeNumberUtil.GetPrimes(new MillerRabinPrimalityTest())
                .TakeWhile(x => x < limit).ToList();

            Console.WriteLine($"Iterative Method yielded    {iterativeResult.Count} primes < {limit}");
            Console.WriteLine(String.Join(", ", iterativeResult));
            Console.WriteLine($"Fermat Method yielded       {fermatResult.Count} primes < {limit}");
            Console.WriteLine(String.Join(", ", fermatResult));
            Console.WriteLine($"Miller-Rabin Method yielded {millerRabinResult.Count} primes < {limit}");
            Console.WriteLine(String.Join(", ", millerRabinResult));
            Console.WriteLine("Miller-Rabin is missing: " + String.Join(", ", iterativeResult.Except(millerRabinResult)));
        }
    }
}
