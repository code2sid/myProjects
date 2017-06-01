using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    static class swap
    {
        public static void fnSwap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }

    public class BubbleSort
    {
        //o(n2)
        public int[] sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                        swap.fnSwap(ref array[j], ref array[j + 1]);
                }
            }

            return array;
        }
    }

    public class InsertionSort
    {
        //o(n2)
        public int[] sort(int[] array)
        {
            int item, pos;
            for (int i = 1; i < array.Length; i++)
            {
                item = array[i];
                pos = i;
                while (pos > 0 && array[pos - 1] > item)
                {
                    array[pos] = array[pos - 1];
                    pos--;
                }

                if (pos != i)
                    array[pos] = item;
            }
            return array;
        }
    }

    public class SelectionSort
    {
        //o(n2)
        public int[] sort(int[] array)
        {
            int min = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }

                if (min != i)
                    swap.fnSwap(ref array[i], ref array[min]);

            }

            return array;
        }
    }

    public class MergeSort
    {
        //o(n2)
        private void merge(int[] arr, int l, int m, int r)
        {
            // Merges two subarrays of arr[].
            // First subarray is arr[l..m]
            // Second subarray is arr[m+1..r]

            int n1 = m - l + 1;
            int n2 = r - m;
            /* create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /* Copy data to temp arrays L[] and R[] */
            int i, j, k;

            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + j];
            int a = 1;
            if (m == 7)
                a = 1;
            /* Merge the temp arrays back into arr[l..r]*/
            i = 0; // Initial index of first subarray
            j = 0; // Initial index of second subarray
            k = l; // Initial index of merged subarray
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy the remaining elements of L[], if there are any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy the remaining elements of R[], if there
               are any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        /* l is for left index and r is right index of the sub-array of arr to be sorted */
        private void mergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Same as (l+r)/2, but avoids overflow for
                // large l and h
                int m = l + (r - l) / 2;

                // Sort first and second halves
                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);

                merge(arr, l, m, r);
            }
        }

        public int[] sort(int[] arr)
        {
            mergeSort(arr, 0, arr.Length);
            return arr;
        }

    }

    public class MergeSort1
    {
        int[] a = { 10, 14, 19, 26, 27, 31, 33, 35, 42, 44 };
        int[] b = new int[10];
        void merging(int low, int mid, int high)
        {
            int l1, l2, i;
            for (l1 = low, l2 = mid + 1, i = low; l1 <= mid && l2 <= high; i++)
            {
                if (a[l1] <= a[l2])
                    b[i] = a[l1++];
                else
                    b[i] = a[l2++];
            }
            while (l1 <= mid)
                b[i++] = a[l1++];
            while (l2 <= high)
                b[i++] = a[l2++];
            for (i = low; i <= high; i++)
                a[i] = b[i];
        }
        public void sort(int low, int high)
        {
            int mid;

            if (low < high)
            {
                mid = (low + high) / 2;
                sort(low, mid);
                sort(mid + 1, high);
                merging(low, mid, high);
            }
            else
            {
                return;
            }
        }
    }

    public class HeapSort
    {
        // main function to do heap sort
        public int[] sort(int[] arr)
        {
            int n = arr.Length;
            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end
                swap.fnSwap(ref arr[0], ref arr[i]);

                // call max heapify on the reduced heap
                heapify(arr, i, 0);
            }
            return arr;
        }

        void heapify(int[] arr, int n, int i)
        {
            int largest = i;  // Initialize largest as root
            int l = 2 * i + 1;  // left = 2*i + 1
            int r = 2 * i + 2;  // right = 2*i + 2

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                swap.fnSwap(ref arr[i], ref arr[largest]);

                // Recursively heapify the affected sub-tree
                heapify(arr, n, largest);
            }
        }

    }

    public class QuickSort
    {
        public int[] sort(int[] arr)
        {
            qsort(arr, 0, arr.Length - 1);
            return arr;
        }
        public int[] qsort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[p] is now
                   at right place */
                int pi = partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                qsort(arr, low, pi - 1);
                qsort(arr, pi + 1, high);
            }
            return arr;
        }

        int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];    // pivot
            int i = (low - 1);  // Index of smaller element

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than or
                // equal to pivot
                if (arr[j] <= pivot)
                {
                    i++;    // increment index of smaller element
                    swap.fnSwap(ref arr[i], ref arr[j]);
                }
            }
            swap.fnSwap(ref arr[i + 1], ref arr[high]);
            return (i + 1);
        }
    }

}
