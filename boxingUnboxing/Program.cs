using System;
using System.Collections.Generic;

namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> stuff = new List<object>();
            stuff.Add(7);
            stuff.Add(28);
            stuff.Add(-1);
            stuff.Add(true);
            stuff.Add("chair");

            foreach (var item in stuff)
            {
                Console.WriteLine(item);
            }
            int sum = 0;
            foreach (var item in stuff)
            {
                if (item is int)
                {
                    int digit = (int)item;
                    sum = sum + digit;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
