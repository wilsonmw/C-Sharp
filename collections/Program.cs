using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] intarr = {0,1,2,3,4,5,6,7,8,9};
           string[] names = {"Tim","Martin","Nikki","Sara"};
           bool[] tf = {true, false, true, false, true, false, true, false, true, false};

            int[,] multTable = new int[10,10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    multTable[x, y] = (x+1)*(y+1);
                }
            }
            
            for (int x = 0; x < 10; x++)
            {
                Console.Out.NewLine = ", ";
                for (int y = 0; y < 10; y++)
                {
                    Console.WriteLine(multTable[x,y]);
                }
                Console.WriteLine("\r\n");
            }

            Console.Out.NewLine = "\r\n";
            Console.WriteLine();
            List<string> iceCream = new List<string>();
            iceCream.Add("Vanilla");
            iceCream.Add("Chocolate");
            iceCream.Add("Strawberry");
            iceCream.Add("Chocolate Chip");
            iceCream.Add("Rocky Road");

            Console.WriteLine("There are {0} ice cream flavors in the list", iceCream.Count);
            Console.WriteLine(iceCream[2]);

            iceCream.RemoveAt(2);
            Console.WriteLine("There are {0} ice cream flavors in the list", iceCream.Count);

            Dictionary<string,string> info = new Dictionary<string,string>();
            Random rand = new Random();
            foreach (string name in names)
            {
                info[name] = iceCream[rand.Next(iceCream.Count)];
            }
            Console.WriteLine("People and Flavors");
            foreach (KeyValuePair<string,string> item in info)
            {
                Console.WriteLine(item.Key + "-" + item.Value);

            }
        }
    }
}
