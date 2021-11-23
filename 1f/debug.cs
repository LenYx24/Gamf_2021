using System;
using System.Collections.Generic;
using System.Linq;

namespace debug
{
    class prog
    {
        static int maxN = 1000000;
        
        // Create an array for storing primes
        static int []arr = new int[1000001];
        
        // Create a prefix array that will
        // contain whether sum is prime or not
        static int []prefix = new int[1000001];
        
        // Function to find primes in the range
        // and check whether the sum of digits
        // of a prime number is prime or not
        static void findPrimes()
        {
            // Initialise Prime array arr[]
            for (int i = 1; i <= maxN; i++)
                arr[i] = 1;
        
            // Since 0 and 1 are not prime
            // numbers we mark them as '0'
            arr[0] = 0;
            arr[1] = 0;
        
            // Using Sieve Of Eratosthenes
            for (int i = 2; i * i <= maxN; i++)
            {
        
                // if the number is prime
                if (arr[i] == 1)
                {
        
                    // Mark all the multiples
                    // of i starting from square
                    // of i with '0' ie. composite
                    for (int j = i * i;
                            j <= maxN; j += i)
                    {
        
                        //'0' represents not prime
                        arr[j] = 0;
                    }
                }
            }
        
            // Initialise a sum variable as 0
            int sum = 0;
            prefix[0] = 0;
        
            for (int i = 1; i <= maxN; i++)
            {
        
                // Check if the number is prime
                if (arr[i] == 1)
                {
        
                    // A temporary variable to
                    // store the number
                    int temp = i;
                    sum = 0;
        
                    // Loop to calculate the
                    // sum of digits
                    while (temp > 0)
                    {
                        int x = temp % 10;
                        sum += x;
                        temp = temp / 10;
        
                        // Check if the sum of prime
                        // number is prime
                        if (arr[sum] == 1)
                        {
        
                            // if prime mark 1
                            prefix[i] = 1;
                        }
        
                        else
                        {
        
                            // If not prime mark 0
                            prefix[i] = 0;
                        }
                    }
                }
            }
        
            // computing prefix array
            for (int i = 1; i <= maxN; i++)
            {
                prefix[i] += prefix[i - 1];
            }
        }
        
        // Function to count the prime numbers
        // in the range [L, R]
        static void countNumbersInRange(int l, int r)
        {
            // Function Call to find primes
            findPrimes();
            int result = prefix[r] - prefix[l - 1];
        
            // Print the result
            Console.Write(result + "\n");
        }
        
        // Driver Code
        public static void test()
        {
            // Input range
            int l, r;
            l = 10;
            r = 100000;
        
            // Function Call
            countNumbersInRange(l, r);
        }
    }
}