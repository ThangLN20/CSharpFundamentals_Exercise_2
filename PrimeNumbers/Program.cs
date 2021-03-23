using System;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task task1 = TaskOne();
            await task1;
        }
         private static bool checkPrime(int a)
        {
            if (a <= 1) return false;
            for (int n = 2; n < a; n++)
            {
                if (a % n == 0)
                {
                    return false;
                }
            }
            return true;
        }
         private static async Task TaskOne()
        {
            await Task.Delay(1000);
            for (int i = 1; i <= 100; i++)
            {
                if (checkPrime(i))
                {
                    Console.WriteLine("Prime Number is : " + i);
                }
            }
        }
    }
}
