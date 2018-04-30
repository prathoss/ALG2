using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrab
{
    public static class ArraySortExtension
    {

        public static void Hrabisort(this int[] array, int kType = 1)
        {
            int[] kArray;
            switch (kType)
            {
                case 1:
                    kArray = K1(array.Length);
                    break;
                case 2:
                    kArray = K2(array.Length);
                    break;
                case 3:
                    kArray = K3(array.Length);
                    break;
                default:
                    throw new Exception("Index out of bounds, only 1, 2, 3 values can be send as parameter.");
            }
            foreach(int k in kArray)
            {
                for (int i = array.Length - k - 1; i >= 0; i--)
                {
                    for (int l = i; l < array.Length - k; l += k)
                    {
                        if (array[l] > array[l + k])
                        {
                            Swap(array, l, l + k);
                        }
                    }
                }
            }

        }

        public static void InsertionSort(this int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int j = i + 1;
                int tmp = array[j];
                while (j > 0 && tmp < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = tmp;
            }
        }

        public static void Quicksort(this int[] array)
        {
            PQuicksort(array, 0, array.Length - 1);
        }

        private static void PQuicksort(int[] array, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = partition(array, left, right);

            if (index != -1)
            {
                PQuicksort(array, left, index - 1);
                PQuicksort(array, index + 1, right);
            }
        }

        private static int partition(int[] array, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = array[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (array[i] < pivot)
                {
                    Swap(array, i, end);
                    end++;
                }
            }

            Swap(array, end, right);

            return end;
        }

        private static void Swap(int[] array, int left, int right)
        {
            int tmp = array[right];
            array[right] = array[left];
            array[left] = tmp;
        }

        private static int[] K1(int Count)
        {
            List<int> arr = new List<int>();
            int max = LogXY(Count, 2);
            for (int i = 1; i <= max; i++)
            {
                arr.Add(Count / (int)Math.Pow(2, i));
            }
            return arr.ToArray();
        }

        private static int[] K2(int Count)
        {
            List<int> arr = new List<int>();
            int j = (int)(Math.Ceiling((decimal)(Count / 3)));
            int imax = LogXY(2 * j + 1, 3);
            for(int i = imax; i > 0; i--)
            {
                arr.Add(((int)(Math.Pow(3,i)) - 1) / 2);
            }
            return arr.ToArray();
        }

        private static int[] K3(int Count)
        {
            List<int> arr = new List<int>();
            int max2 = LogXY(Count, 2);
            int max3 = LogXY(Count, 3);
            for (int i = 0; i <= max2; i++)
            {
                for (int j = 0; j <= max3; j++)
                {
                    int p = Power(i, j);
                    if (p < Count) arr.Add(p);
                    else break;
                }
            }
            return arr.OrderByDescending(x => x).ToArray();
        }

        private static int LogXY(int x, int y)
        {
            return (int)(Math.Log(x) / Math.Log(y));
        }

        private static int Power(int x2, int x3)
        {
            return (int)(Math.Pow(2, x2) * Math.Pow(3, x3));
        }
    }
}
