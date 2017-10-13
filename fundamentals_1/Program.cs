using System;

namespace fundamentals_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i<256; i++)
                Console.WriteLine(i);



            for (int i = 1; i<=100; i++){
                if (i%3==0 && i%5==0)
                    Console.WriteLine("FizzBuzz");
                else if (i%3 == 0)
                    Console.WriteLine("Fizz");
                else if (i%5==0)
                    Console.WriteLine("Buzz");
            }

            for (int i = 1; i<=100; i++){
                if ((i/3)*3==i && (i/5)*5==i)
                    Console.WriteLine("FizzBuzz" + i);
                else if ((i/3*3) == i)
                    Console.WriteLine("Fizz" + i/3, (i/3)*3);
                else if ((i/5)*5==i)
                    Console.WriteLine("Buzz" + i/5, "Buzz" + (i/5)*5);
            }                        
        }
    }
}
