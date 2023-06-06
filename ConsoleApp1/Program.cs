
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 786;
            int exp = 2;
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i + ": " + i % 9);
        }
        static int AddDigits(int num)
        {
            Console.WriteLine(num % 9);
            if (num == 0)
                return 0;
            if (num % 9 == 0)
                return 0;
            else
                return num % 9;
        }
    }
}