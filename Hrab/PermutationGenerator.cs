using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrab
{
    public class PermutationGenerator
    {
        int _k = 0;
        int _factorial;
        public int[] Array { get; private set; }
        public PermutationGenerator(int[] array)
        {
            Array = array;
            _factorial = 1;
            for (int i = 2; i <= Array.Length; i++) _factorial *= i;
        }

        public int[] Next()
        {
            if (_k == _factorial) return null;
            if(Array.Length == 0)
            {
                _k++;
                return new int[0];
            }
            int factorial = _factorial / Array.Length;
            int[] arr = Array;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                int tempi = (_k / factorial) % (arr.Length - i);
                int tempa = arr[i + tempi];
                for(int j = i + tempi; j >= i + 1; j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[i] = tempa;
                factorial /= Array.Length - i - 1;
            }
            _k += 1;
            return arr;
        }
    }
}
