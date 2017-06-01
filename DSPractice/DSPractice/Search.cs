using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class LinearSearch
    {
        public int SearchMyNo(int n, int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (n == array[i])
                    return i;
            }

            return -1;
        }

    }

    public class BinarySearch
    {
        public int SearchMyNo(int n, int[] array)
        {
            int low = 0, mid = 0, high = array.Length - 1, loopCnt = 0;
            while (low <= high)
            {
                ++loopCnt;
                mid = (low + high) / 2;
                if (array[mid] == n)
                { Console.WriteLine("Loop Cnt:{0}", loopCnt); return mid; }
                else if (n > array[mid])
                    low = mid + 1;
                else if (n < array[mid])
                    high = mid - 1;


            }


            return -1;
        }
    }

    public class InterPolationSeach
    {
        public int SearchMyNo(int n, int[] array)
        {
            int low = 0, mid = 0, high = array.Length - 1, loopCnt = 0;
            while (low <= high)
            {
                ++loopCnt;
                mid = low + ((high - low) / (array[high] - array[low])) * (n - array[low]);
                if (n == array[mid])
                { Console.WriteLine("Loop Cnt:{0}", loopCnt); return mid; }
                else if (n > array[mid])
                    low = mid + 1;
                else if (n < array[mid])
                    high = mid - 1;
            }
            return -1;
        }
    }
}
