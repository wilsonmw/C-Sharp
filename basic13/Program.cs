using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        public static void print1255(){
            for (int i=1;i<=255;i++){
                Console.WriteLine(i);
            }
        }
        public static void printOdd(){
            for (int i =1; i<=255; i=i+2){
                Console.WriteLine(i);
            }
        }
        public static void printSum(){
            int sum = 0;
            for(int i=0;i<=255;i++){
                sum+=i;
                Console.WriteLine("New Number: "+ i + " Sum: " + sum);
            }
        }
        public static void IttArray(int[] array){
            for (int i =0;i<array.Length;i++){
                Console.WriteLine(array[i]);
            }
        }
        public static void FindMax(int[]array){
            int max = array[0];
            for(int i = 1;i<array.Length;i++){
                if (array[i]>max){
                    max = array[i];
                }
            }
            Console.WriteLine(max);
            
        }
        public static void GetAverage(int[]array){
            double sum = 0;
            for (int i =0;i<array.Length;i++){
                sum = sum+array[i];
            }
            double avg = sum/array.Length;
            Console.WriteLine(avg);
        }
        public static void OddArray(){
            List<int> odds = new List<int>();
            int count = 0;
            for (int i =1;i<=255;i=i+2){
                odds.Add(i);
                count++;
            }
            int[] y = new int[count];
            for(int i =0;i<y.Length;i++){
                y[i]=odds[i];
                Console.WriteLine(y[i]);
            }
        }
        public static int GreaterThanY(int[]arr, int y){
            int count = 0;
            for(int i =0;i<arr.Length;i++){
                if(arr[i]>y){
                    count++;
                }
            }
            Console.WriteLine(count);
            return count;
        }
        public static void SquareVals(int[]x){
            for(int i =0;i<x.Length;i++){
                x[i]=x[i]*x[i];
                Console.WriteLine(x[i]);
            }
        }
        public static void EliminateNegs(int[]x){
            for(int i =0;i<x.Length;i++){
                if(x[i]<0){
                    x[i]=0;
                }
                Console.WriteLine(x[i]);
            }
        }
        public static void MinMaxAvg(int[]x){
            double sum = 0;
            double min = x[0];
            double max = x[0];
            for(int i =0;i<x.Length;i++){
                sum = sum+x[i];
                if (x[i]<min){
                    min=x[i];
                }
                if (x[i]>max){
                    max=x[i];
                }
            }
            double avg = sum/x.Length;
            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(avg);
        }
        public static void ShiftArray(int[]x){
            int idx = 0;
            for(int i =1;i<x.Length;i++){
                x[idx]=x[i];
                idx+=1;
            }
            x[idx]=0;
            for(int i =0;i<x.Length;i++){
                Console.WriteLine(x[i]);
            }
        }
        public static void NumToString(int[]x){
            object[] nums = new object[x.Length];
            for (int i = 0;i<x.Length;i++){
                if (x[i] < 0){
                    nums[i] = "Dojo";
                }
                else{
                    nums[i]=x[i];
                }
            }   
        }
        static void Main(string[] args)
        {
            


        }
    }
}
