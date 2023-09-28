using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class QuickSort
    {
        public static int[]  Sort(int[] collection, int lowwerBound, int upperBound)
        {
            if (lowwerBound < upperBound)
            {
                int pivot = Partition(collection, lowwerBound,upperBound);
                Sort(collection, lowwerBound, pivot - 1);
                Sort(collection, pivot + 1, pivot + 1);
            }


            return collection;
        }
        private static int Partition(int[] array , int lowwerBound,int upperBound)
        {
            int pivot = array[upperBound];

            int i = lowwerBound - 1;
            for (int j  = lowwerBound; j <= upperBound; j++)
            {
                if (array[j] < pivot)
                {
                    i = i + 1;
                    Swap(ref array[i], ref array[j]);
                }

            }
            Swap(ref array[i+1], ref array[upperBound]);
            return i + 1;
        }
        private static void Swap(ref int a, ref int b)
        {
            int temp = a; a = b; b = temp;
        }
    }
}
