using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace parallelComputingProject
{
    class ParallelEnumerationSort : SerialSortBase
    {
        private int[] _sharedData;
        private object locker;
        public ParallelEnumerationSort(int[] data)
            : base(data)
        {
            _sharedData = new int[_length];
        }

        public void partEnumerationSort(int left,int right,int gid)
        {
            //Console.WriteLine("{0} start doing {1}-{2}", gid, left, right);
            for (int i = left; i <= right; i++)
            {
                int index = 0;
                for (int j = 0; j < _length; j++)
                {
                    if (_data[j] < _data[i])
                        index++;
                    else if ((_data[j] == _data[i]) && j < i)
                        index++;
                }
                _sharedData[index] = _data[i];
            }
            //Console.WriteLine("{0} sort {1}-{2} finished.", gid, left, right);
        }

        public void tPartEnumerationSort(object obj)
        {
            object[] paras = obj as object[];
            int left = Convert.ToInt32(paras[0]);
            int right = Convert.ToInt32(paras[1]);
            int gid = Convert.ToInt32(paras[2]);
            Semaphore s = (Semaphore)paras[3];
            partEnumerationSort(left, right, gid);
            s.Release();
        }
        private void enumerationSort(int nprocs=4)
        {
            locker=new object();
            // initialization above
            int size=_length/nprocs;
            Semaphore s = new Semaphore(0, nprocs);
            for (int i = 0; i < nprocs; i++)
            {
                int left = i * size;
                int right = (i + 1) * size;
                int gid = i;
                if (i == nprocs - 1)
                    right = _length - 1;
                object[] paras = new object[] { left, right, gid, s };
                Thread partSort = new Thread(new ParameterizedThreadStart(tPartEnumerationSort));
                partSort.Start(paras);
            }
            for (int i = 0; i < nprocs; i++)
                s.WaitOne();
            _sharedData.CopyTo(_data, 0);
            //Console.WriteLine("Parallel Enumaration Sort FINISHED");
        }
        private double enumerationSort(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            enumerationSort();
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void EnumerationSort(bool record=false,
            String fileName="..\\..\\DataFiles\\order6.txt")
        {
            _sorter = new Sorter(enumerationSort);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }
        public void PerformanceAnalyzer(int testRounds=100)
        {
            Console.WriteLine("Testing parallel enumeration sort for {0} rounds", testRounds);
            _sorter = new Sorter(enumerationSort);
            _performanceAnalyzer(testRounds);
        }

        public void SizePerformanceAnalyzer(int testScale = 30000, int testRound = 100)
        {
            _sorter = new Sorter(enumerationSort);
            Console.WriteLine("Testing parallel enumeration sort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
    }
}
