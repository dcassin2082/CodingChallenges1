using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges1
{
    public class Helpers
    {
        public static int Fibonacci(int n)
        {
            if (n < 2)
                return n;

            int[] arr = new int[n + 1];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n];
        }

       public static bool IsPrime(long n)
        {
            if (n == 2) return true;
            else if (n < 2 || n % 2 == 0) return false;
            else
            {
                for (int i = 3; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                        return false;
                }
            }
            return true;
        }
        public static int[] GetPrimeFactors(long n, int sign)
        {

            List<int> factors = new List<int>();
            if (sign == -1)
            {
                factors.Add(-1);
            }
            // if (n <= 1)
            //     return new int[0];

            while (!IsPrime(n))
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    // first we need to check if i is prime
                    if (IsPrime(i))
                    {
                        // then we need to check if n is also divisible by it
                        //  just because i may be prime doesn't mean it satisfies our requirement
                        if (n % i == 0)
                        {
                            // now we have an i that is prime and that n is divisible by it so we add it to our list
                            factors.Add(i);
                            // now we chop n down and check if we have a prime yet... repeat until n is prime
                            n /= i;
                            if (IsPrime(n))
                                factors.Add((int)n);
                        }
                    }
                }
            }
            factors.Sort();
            return factors.ToArray();
        }

        public static int[] GetPrimeFactors(int n)
        {

            List<int> factors = new List<int>();
            // if (n <= 1)
            //     return new int[0];

            while (!IsPrime(n))
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    // first we need to check if i is prime
                    if (IsPrime(i))
                    {
                        // then we need to check if n is also divisible by it
                        //  just because i may be prime doesn't mean it satisfies our requirement
                        if (n % i == 0)
                        {
                            // now we have an i that is prime and that n is divisible by it so we add it to our list
                            factors.Add(i);
                            // now we chop n down and check if we have a prime yet... repeat until n is prime
                            n /= i;
                            if (IsPrime(n))
                                factors.Add((int)n);
                        }
                    }
                }
            }
            factors.Sort();
            return factors.ToArray();
        }
    }
}
