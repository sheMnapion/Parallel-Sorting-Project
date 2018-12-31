using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace parallelComputingProject
{
    class Utilities
    {
        public static void Swap<T>(ref T my, ref T other)
        {
            T temp = my;
            my = other;
            other = temp;
        }

        public static void checkSum(int[] array,int start,int end,int assumptionSum)
        {
            int count = 0;
            for (int i = start; i <= end; i++)
            {
                count += array[i];
            }
            if (count != assumptionSum)
                throw new ArgumentOutOfRangeException();
        }

        public static void assert(bool assertion)
        {
            if (!assertion)
            {
                Console.WriteLine(assertion.ToString());
                throw new IndexOutOfRangeException();
            }
        }
    }
}
