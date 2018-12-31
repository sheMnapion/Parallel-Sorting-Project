using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace parallelComputingProject
{
    class SerialMergesort : SerialSortBase
    {
        public SerialMergesort(int[] data) : base(data)
        {
            _shared = new int[data.Length];
        }

        private double MergeSort(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _mergeSort(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void MergeSort(bool record=false, 
            String fileName="..\\..\\DataFiles\\order2.txt")
        {
            _sorter = new Sorter(MergeSort);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }

        public void PerformanceAnalyzer(int testRound=100)
        {
            _sorter = new Sorter(MergeSort);
            Console.WriteLine("Testing serial mergesort for {0} rounds", testRound);
            _performanceAnalyzer(testRound);
        }

        public void SizePerformanceAnalyzer(int testScale = 30000, int testRound = 100)
        {
            _sorter = new Sorter(MergeSort);
            Console.WriteLine("Testing serial mergesort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
    }
}
