using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace parallelComputingProject
{
    class ParallelMergesort : SerialSortBase
    {
        private int _paraThreshold = 12000;
        private int _nprocs;
        public ParallelMergesort(int[] data)
            : base(data)
        {
            _shared = new int[data.Length];// a shared memory for merge use
            _nprocs = Environment.ProcessorCount;
        }

        private void displayCommonArea(int[,] commonArea)
        {
            for (int i = 0; i <= _nprocs; i++)
            {
                for (int j = 0; j < _nprocs; j++)
                {
                    Console.Write("{0}\t", commonArea[i, j]);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Mergesort as the minimal unit, doing serially
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void serialMergeSort(int left, int right)
        {
            if (left >= right)
                return;
            int mid = (left + right) / 2;
            serialMergeSort(left, mid);
            serialMergeSort(mid + 1, right);
            int leftPointer = left;
            int rightPointer = mid + 1;
            int index = left;
            while ((leftPointer <= mid) && (rightPointer <= right))
            {
                if (_data[leftPointer] <= _data[rightPointer])
                {
                    _shared[index++] = _data[leftPointer];
                    leftPointer++;
                }
                else
                {
                    _shared[index++] = _data[rightPointer];
                    rightPointer++;
                }
            }
            while (leftPointer <= mid)
            {
                _shared[index++] = _data[leftPointer++];
            }
            while (rightPointer <= right)
                _shared[index++] = _data[rightPointer++];
            Array.Copy(_shared, left, _data, left, right - left + 1); 
        }

        /// <summary>
        /// parallel mergesort thread calling interface
        /// </summary>
        /// <param name="para"></param>
        private void tParallelMergeSort(object para)
        {
            object[] paras = para as object[];
            int left = (int)paras[0];
            int right = (int)paras[1];
            Semaphore s = (Semaphore)paras[2];
            parallelMergeSort(left, right);
            s.Release();
        }

        private void parallelMergeSort(int left,int right)
        {
            if (right - left < _paraThreshold)
            {
                serialMergeSort(left, right);
                return;
            }
            //Console.WriteLine("Parallel Mergesort {0} to {1}", left, right);
            int mid = (left + right) / 2;
            Semaphore sChild = new Semaphore(0, 2);
            object para1 = (object)new object[] { left, mid, sChild };
            object para2 = (object)new object[] { mid + 1, right, sChild };
            Thread t1 = new Thread(new ParameterizedThreadStart(tParallelMergeSort));
            t1.Start(para1);
            Thread t2 = new Thread(new ParameterizedThreadStart(tParallelMergeSort));
            t2.Start(para2);
            sChild.WaitOne();
            sChild.WaitOne();
            int leftPointer = left;
            int rightPointer = mid + 1;
            int index = left;
            while ((leftPointer <= mid) && (rightPointer <= right))
            {
                if (_data[leftPointer] <= _data[rightPointer])
                {
                    _shared[index++] = _data[leftPointer];
                    leftPointer++;
                }
                else
                {
                    _shared[index++] = _data[rightPointer];
                    rightPointer++;
                }
            }
            while (leftPointer <= mid)
            {
                _shared[index++] = _data[leftPointer++];
            }
            while (rightPointer <= right)
                _shared[index++] = _data[rightPointer++];
            Array.Copy(_shared, left, _data, left, right - left + 1);
        }

        private double parallelMergeSortTimer(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            parallelMergeSort(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }
        public void ParallelMergeSort(bool record=false,
            String fileName="..\\..\\DataFiles\\order5.txt")
        {
            _sorter = new Sorter(psrsMergesortTimer);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }

        private void _tPsrsMergesortSlave(object para)
        {
            object[] paras = para as object[];
            int left = (int)paras[0];
            int right = (int)paras[1];
            int id = (int)paras[2];
            Semaphore c = (Semaphore)paras[3];
            Semaphore s = (Semaphore)paras[4];
            int[,] commonArea = (int[,])paras[5];

            _mergeSort(left, right);
            //Array.Sort(_data, left, right - left + 1);
            int step = (right - left + 1) / _nprocs;
            int startIndex = id * _nprocs;
            for (int i = 0; i < _nprocs; i++)
                commonArea[id, i] = _data[i * step + 1];
            c.Release();
            s.WaitOne();
            // above for sorting and send sample to correspondent lines
            // wait for s's signal to continue
            int pivotCount = 0, pivotIndex = 0;
            int[] localPivotCount = new int[_nprocs];
            localPivotCount[0] = 0;
            for (int i = left; i <= right; i++)
            {
                if (_data[i] > commonArea[_nprocs, pivotIndex])
                {
                    if (pivotIndex < _nprocs - 2)
                    {
                        commonArea[id, pivotIndex] = pivotCount;
                        pivotIndex++;
                        pivotCount = 1;
                    }
                    else
                    {
                        commonArea[id, pivotIndex] = pivotCount;
                        commonArea[id, pivotIndex + 1] = right - i + 1;
                        break;
                    }
                }
                else
                {
                    pivotCount++;
                }
            }
            for (int i = 0; i < _nprocs; i++)
                Debug.Assert(commonArea[id, i] >= 0);
            for (int i = 0; i < _nprocs - 1; i++)
                localPivotCount[i + 1] = commonArea[id, i];
            for (int i = 1; i < _nprocs; i++)
                localPivotCount[i] += localPivotCount[i - 1];
            //Console.WriteLine('(');
            c.Release();
            s.WaitOne();
            // above for counting # of elements below each main pivot
            // and store them in correspondent lines in commonArea
            int newLeft = commonArea[0, id];
            int newRigt = commonArea[_nprocs, id] - 1;
            Debug.Assert(newLeft >= 0 && newRigt >= 0);
            // above done for counting, now need to send them to proper place
            for (int i = 0; i < _nprocs; i++)
            {
                int sendPozLeft = commonArea[id, i];
                int sendPozRigt = commonArea[id + 1, i] - 1;
                int sharePositionBegin = left + localPivotCount[i];
                for (int j = sendPozLeft; j <= sendPozRigt; j++)
                {
                    _shared[j] = _data[sharePositionBegin++];
                }
            }
            
            c.Release();
            s.WaitOne();
            for (int i = newLeft; i <= newRigt; i++)
                _data[i] = _shared[i];
            // data copy done
            c.Release();
            s.WaitOne();
            //Array.Sort(_data, newLeft, newRigt - newLeft + 1);
            _mergeSort(newLeft, newRigt);
            // sorting done
            c.Release();
        }
        private void _psrsMergeSortMaster()
        {
            //Console.WriteLine("Total mergesort threads: {0}", _nprocs);
            Semaphore[] c = new Semaphore[_nprocs];
            Semaphore[] s = new Semaphore[_nprocs];
            for (int i = 0; i < _nprocs; i++)
            {
                c[i] = new Semaphore(0, 1);
                s[i] = new Semaphore(0, 1);
            }
            int step = _length / _nprocs;
            int[,] commonArea = new int[_nprocs + 1, _nprocs];
            int[] pivots = new int[_nprocs * _nprocs];
            for (int i = 0; i < _nprocs; i++)
            {
                int left = i * step;
                int right = (i + 1) * step - 1;
                if (i == _nprocs - 1)
                    right = _length - 1;
                object[] paras = new object[6] { left, right, i, c[i], s[i], commonArea };
                Thread t=new Thread(new ParameterizedThreadStart(_tPsrsMergesortSlave));
                t.Start(paras);
            }
            // above for starting threads
            for (int i = 0; i < _nprocs; i++)
                c[i].WaitOne();
            // displayCommonArea(commonArea);
            // wait for threads to finish, now get their samples in commonArea
            for (int i = 0; i < _nprocs; i++)
                for (int j = 0; j < _nprocs; j++)
                    pivots[i * _nprocs + j] = commonArea[i, j];
            Array.Sort(pivots); // just call lib function to sort p^2 elements; just algo-sugar
            int[] sample = new int[_nprocs - 1];
            for (int i = 0; i < _nprocs - 1; i++)
            {
                sample[i] = pivots[(i + 1) * _nprocs];
            }
            /*
            Console.WriteLine("Main samples:");
            for (int i = 0; i < _nprocs - 1; i++)
                Console.Write("{0} ", sample[i]);
            Console.WriteLine();
            */
            for (int i = 0; i < _nprocs - 1; i++)
            {
                commonArea[_nprocs, i] = sample[i];
            }
            // store elements in the lastline of commonArea

            for (int i = 0; i < _nprocs; i++)
                s[i].Release();
            // above done for choosing main pivots
            for (int i = 0; i < _nprocs; i++)
                c[i].WaitOne();
            //Console.WriteLine("Back in master, ought to be no client working");
            //displayCommonArea(commonArea);
            // wait for partitioning counting done in each processor
            // some checking
            for (int i = 0; i < _nprocs;i++ )
            {
                for (int j = 0; j < _nprocs; j++)
                    Debug.Assert(commonArea[i, j] >= 0);
            }
            for (int i = 0; i < _nprocs; i++)
                for (int j = _nprocs; j >= 1; j--)
                    commonArea[j, i] = commonArea[j - 1, i];
            for (int i = 0; i < _nprocs; i++)
                commonArea[0, i] = 0;
            for (int j = 0; j < _nprocs; j++)
            {
                for (int i = 0; i <= _nprocs; i++)
                {
                    if (i == 0)
                    {
                        if (j > 0)
                            commonArea[i, j] = commonArea[_nprocs, j - 1];
                    }
                    else
                        commonArea[i, j] += commonArea[i - 1, j];
                }
            }
            //displayCommonArea(commonArea);
            for (int i = 0; i <= _nprocs; i++)
            {
                for (int j = 0; j < _nprocs; j++)
                    Debug.Assert(commonArea[i, j] >= 0);
            }
            Debug.Assert(commonArea[_nprocs, _nprocs - 1] == _length);
            for (int i = 0; i < _nprocs; i++)
                s[i].Release();
                // above done for partitioning
            for (int i = 0; i < _nprocs; i++)
                c[i].WaitOne();
            //Console.WriteLine("Copy done");
            for (int i = 0; i < _nprocs; i++)
                s[i].Release();
            for (int i = 0; i < _nprocs; i++)
                c[i].WaitOne();
            //Console.WriteLine("Get data done");
            // Get data done
            for (int i = 0; i < _nprocs; i++)
                s[i].Release();
            for (int i = 0; i < _nprocs; i++)
                c[i].WaitOne();
            //Console.WriteLine("Done in master");
            /*
            if (!_inOrder(0, _length - 1))
            {
                Console.WriteLine("ERROR!!!");
                throw new ArgumentOutOfRangeException();
            }
             */
        }

        private double psrsMergesortTimer(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _psrsMergeSortMaster();
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }
        public void PerformanceAnalyzer(int testRound=100)
        {
            _sorter = new Sorter(psrsMergesortTimer);
            Console.WriteLine("Testing parallel mergesort for {0} rounds", testRound);
            _performanceAnalyzer(testRound);
        }

        public void SizePerformanceAnalyzer(int testScale=30000,int testRound=100)
        {
            _sorter = new Sorter(psrsMergesortTimer);
            Console.WriteLine("Testing parallel mergesort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
    }
}
