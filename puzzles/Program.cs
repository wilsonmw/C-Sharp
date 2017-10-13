using System;
using System.Linq;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            Console.WriteLine(TossMultipleCoins(10));
            Console.WriteLine(Names());

        }

        static int[] RandomArray(){
            int[] myArray = new int[10];
            Random randObj = new Random();
            for (int i=0;i<myArray.Length; i++){
                myArray[i] = randObj.Next(5,26);
            }
            Console.WriteLine(myArray.Min());
            Console.WriteLine(myArray.Max());
            Console.WriteLine(myArray.Sum());
            return myArray;
        }

        static string TossCoin(Random r){
            Console.WriteLine("Tossing a coin...");
            int coinToss = r.Next(0,2);
            string result = "Tails";
            if (coinToss == 0){
                Console.WriteLine("Heads");
                result = "Heads";
            }
            else {
                Console.WriteLine("Tails");
            }
            return result;           
        }
        
        static double TossMultipleCoins(int num){
            int countHeads = 0;
            Random r = new Random();
            for (int i=0; i<num; i++){
                if(TossCoin(r)== "Heads"){
                    countHeads++;
                }
            }
            
            return (Double)countHeads/num;
        }
        static List<string> Names(){
            string[] myNames = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random randName = new Random();
            for (int i=0;i<myNames.Length;i++){
                int idx = randName.Next(0,5);
                string temp = myNames[idx];
                myNames[idx] = myNames[i];
                myNames[i] = temp;
            }
            for (int i=0; i<myNames.Length; i++){
                Console.WriteLine(myNames[i]);
            }
            List<string> names = new List<string>();
            for (int i=0;i<myNames.Length;i++){
                if(myNames[i].Length >5){
                    names.Add(myNames[i]);
                }
            }
            return names;
            

        }
    }
}
