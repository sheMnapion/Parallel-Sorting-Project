using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace parallelComputingProject
{
    class SerialQuicksort : SerialSortBase
    {
        public enum SortMethod
        {
            quickSort = 0,
            randomizedQuicksort,
            improvedQuicksort,
            randomizedImprovedQuicksort
        };
        public SerialQuicksort(int[] data)
            : base(data)
        {

        }

        private double quickSort(int left, int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _quickSort(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }
        /// <summary>
        /// Quicksort interface
        /// could select whether randomly choose pivot or not
        /// </summary>
        /// <param name="testRound"></param>
        /// <param name="randomized"></param>
        private double rQuickSort(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _randomizedQuicksort(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        private double improvedQuicksort(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _improvedQuicksort(left, right, false);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        private double rImprovedQuicksort(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _improvedQuicksort(left, right, true);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }
        private double ImprovedQuicksort(bool randomized = true)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _improvedQuicksort(0, _data.Length - 1, randomized);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void QuickSort(bool randomized = true, bool record = false, 
            String fileName = "..\\..\\DataFiles\\order1.txt")
        {
            if (randomized)
                _sorter = new Sorter(rQuickSort);
            else
                _sorter = new Sorter(quickSort);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }

        public void ImprovedQuickSort(bool randomized=true,bool record=false,
            String fileName="..\\..\\DataFiles\\order1.txt")
        {
            if (randomized)
                _sorter = new Sorter(rImprovedQuicksort);
            else
                _sorter = new Sorter(improvedQuicksort);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }
        public void PerformanceAnalyzer(SortMethod method, int testRound = 100)
        {
            if (method == SortMethod.quickSort)
                _sorter = new Sorter(quickSort);
            else if (method == SortMethod.randomizedQuicksort)
                _sorter = new Sorter(rQuickSort);
            else if (method == SortMethod.improvedQuicksort)
                _sorter = new Sorter(improvedQuicksort);
            else
                _sorter = new Sorter(rImprovedQuicksort);
            Console.WriteLine("Testing {0} method for {1} rounds", method.ToString(), testRound);
            _performanceAnalyzer(testRound);
        }

        public void SizePerformanceAnalyzer(int testScale = 30000, int testRound = 100)
        {
            _sorter = rImprovedQuicksort;
            Console.WriteLine("Testing randomized improved quicksort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
    }
}
