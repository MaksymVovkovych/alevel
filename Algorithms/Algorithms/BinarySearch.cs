using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BinarySearch
    {
        public static int BinarySearchFunc(int[] sortedArray , int target)
        {
            int left = 0;
            int right = sortedArray.Length - 1;
            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                if (sortedArray[middle] == target)
                    return middle;
                else if (sortedArray[middle] < target)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;
            
        }
    }
}
