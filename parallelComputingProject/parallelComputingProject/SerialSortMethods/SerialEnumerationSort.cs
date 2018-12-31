using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace parallelComputingProject
{
    class SerialEnumerationSort : SerialSortBase
    {
        public SerialEnumerationSort(int[] data)
            : base(data)
        {

        }

        private void enumerationSort(int left, int right)
        {
            int[] temp = new int[_length];
            for (int i = left; i <= right; i++)
            {
                int index = 0;
                for (int j = left; j <= right; j++)
                {
                    if (i == j)
                        continue;
                    if (_data[i] > _data[j])
                        index++;
                    else if ((_data[i] == _data[j]) && i <= j)
                        index++;
                }
                temp[index] = _data[i];
            }
            temp.CopyTo(_data, left);
        }

        private double EnumerationSort(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            enumerationSort(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void EnumerationSort(bool record=false,
            String fileName="..\\..\\DataFiles\\order3.txt")
        {
            _sorter = new Sorter(EnumerationSort);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }
        public void PerformanceAnalyzer(int testRound=100)
        {
            _sorter = new Sorter(EnumerationSort);
            Console.WriteLine("Testing serial enumeration sort for [{0}] ROUNDS", testRound);
            _performanceAnalyzer(testRound);
        }

        public void SizePerformanceAnalyzer(int testScale = 30000, int testRound = 100)
        {
            _sorter = new Sorter(EnumerationSort);
            Console.WriteLine("Testing serial enumeration sort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
    }
}
