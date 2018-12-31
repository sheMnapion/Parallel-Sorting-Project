using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace parallelComputingProject
{
    class LibrarySort : SerialSortBase
    {
        public LibrarySort(int[] data)
            : base(data)
        {

        }

        private double librarySortTimer(int left, int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Array.Sort(_data, left, right - left + 1);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void PerformanceAnalyzer(int testRound = 100)
        {
            _sorter = new Sorter(librarySortTimer);
            Console.WriteLine("Testing library sort for {0} rounds", testRound);
            _performanceAnalyzer(testRound);
        }

        public void SizePerformanceAnalyzer(int testScale = 30000, int testRound = 100)
        {
            _sorter = new Sorter(librarySortTimer);
            Console.WriteLine("Testing library sort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
    }
}
