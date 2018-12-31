using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace parallelComputingProject
{
    class ParallelQuicksort : SerialSortBase
    {
        private int _divideSize; // recommended size for minimum parallel division size
        private int _partitionAreaNumber; // number of final division
        private int[] _areaLeft; // record the left bound of serial quicksort
        private int[] _areaRigt; // record the rigt bound of serial quicksort
        private int _layer;  // layer number of division tree
        private int _nprocs; // processor number of the current computer
        private int[] _partitionSpace; // share space for parallel partitioning

        public ParallelQuicksort(int[] data) : base(data)
        {
            _nprocs = Environment.ProcessorCount;
            _layer = (int)Math.Ceiling(Math.Log(_nprocs, 2.0));
            _partitionAreaNumber = (int)Math.Pow(2, _layer);
            _areaLeft = new int[_partitionAreaNumber];
            _areaRigt = new int[_partitionAreaNumber];
            //Console.WriteLine("{0}:{1}\n", _layer, _partitionAreaNumber);
            _divideSize = _length / _nprocs;
            _partitionSpace = new int[_length];
            //Console.WriteLine("Recommended division size: {0}", _divideSize);
        }

        private void tParaPartitionClient(object para)
        {
            object[] paras = para as object[];
            int id = (int)paras[0];
            int left = (int) paras[1];
            int right = (int) paras[2];
            int pivotValue = (int)paras[3];
            Semaphore server = (Semaphore)paras[4];
            Semaphore client = (Semaphore)paras[5];
            int[] smaller=(int[])paras[6];
            int[] bigger = (int[])paras[7];
            int[] ret=paraPartitionCountSlave(left, right, pivotValue);
           // Console.WriteLine("Ret for client [{0}]:[{1}]-[{2}]", id, ret[0], ret[1]);
            smaller[id] = ret[0];
            bigger[id] = ret[1];
            server.Release();
            client.WaitOne();
            // wait for synchronization to copy the data to the correct region
            int regionalStart = left;
            for (int i = id - 1; i >= 0; i--)
            {
                regionalStart -= bigger[i];
                regionalStart -= smaller[i];
            }
            int smallerBegin = regionalStart;
            int biggerBegin = regionalStart;
            for(int i=0;i<_nprocs;i++)
                biggerBegin+=smaller[i];
            for (int i = 0; i < id; i++)
            {
                smallerBegin += smaller[i];
                biggerBegin += bigger[i];
            }
            paraPartitionSendSlave(left, right, smallerBegin, biggerBegin, pivotValue);
            server.Release();
            client.WaitOne();
            // wait for synchronization for overwriting data in _data
            paraPartitionCopySlave(left, right - left + 1);
            server.Release();
        }
        private int[] paraPartitionCountSlave(int left,int right,int pivotValue)
        {
            int smaller = 0, bigger = 0;
            for (int i = left; i <= right; i++)
            {
                if (_data[i] > pivotValue)
                    bigger++;
                else
                    smaller++;
            }
            return new int[2] { smaller, bigger };
        }

        /// <summary>
        /// Slave for partitioning, send partitioned data to _partitionSpace
        /// original place [left,right]
        /// sendto [smallerBegin, ] [biggerBegin, ]
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="smallerBegin"></param>
        /// <param name="biggerBegin"></param>
        /// <param name="pivotValue"></param>
        private void paraPartitionSendSlave(int left,int right,
            int smallerBegin,int biggerBegin,int pivotValue)
        {
            //Console.WriteLine("Copy {0}-{1} begin at {2} and {3}", left, right, smallerBegin, biggerBegin);
            int smallerPointer = 0, biggerPointer = 0;
            for (int i = left; i <= right; i++)
            {
                if (_data[i] > pivotValue)
                {
                    _partitionSpace[biggerBegin + biggerPointer] = _data[i];
                    biggerPointer++;
                }
                else
                {
                    _partitionSpace[smallerBegin + smallerPointer] = _data[i];
                    smallerPointer++;
                }
            }
        }

        /// <summary>
        /// Slave for partitioning, copy from _partitionSpace to _data
        /// start from [partitionSpacePointer, ] in _partitionSpace
        /// to [originPointer] in _data
        /// with length length
        /// </summary>
        /// <param name="partitionSpacePointer"></param>
        /// <param name="originPointer"></param>
        /// <param name="length"></param>
        private void paraPartitionCopySlave(int startPoz, int length)
        {
            for (int i = 0; i < length; i++)
                _data[startPoz + i] = _partitionSpace[startPoz + i];
        }
        /// <summary>
        /// partition master, partition data[left,right] and return the position of the pivot
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int paraPartitionMaster(int left,int right)
        {
            if (right <= left)
                return left;
            else if (right - left < _divideSize)
            {
                return _randomizedPartition(left, right);
            }
            int changeIndex = _r.Next(left, right);
            Utilities.Swap(ref _data[changeIndex], ref _data[right]); // for randomization
            int pivotValue = _data[right];
            int partitionSize = (right - left + 1) / _nprocs;
            // Step one, threads count the # of elements bigger or smaller
            // than pivot value, divided uniformally
            Semaphore server = new Semaphore(0, _nprocs);
            int[] smaller = new int[_nprocs];
            int[] bigger = new int[_nprocs];
            Semaphore[] client=new Semaphore[_nprocs];
            for (int i = 0; i < _nprocs; i++)
                client[i] = new Semaphore(0, 1);
            Thread[] partitionThreads = new Thread[_nprocs];
            for (int i = 0; i < _nprocs; i++)
            {
                int leftPointer = left + i * partitionSize;
                int rightPointer = left + (i + 1) * partitionSize - 1;
                if (i == _nprocs - 1)
                    rightPointer = right;
                object[] paras = new object[8] { i, 
                    leftPointer, rightPointer, pivotValue, server, client[i], smaller, bigger };
                partitionThreads[i] = new Thread(
                    new ParameterizedThreadStart(tParaPartitionClient));
                partitionThreads[i].Start(paras);
            }
            for (int i = 0; i < _nprocs; i++)
                server.WaitOne();
            for (int i = 0; i < _nprocs; i++)
                client[i].Release();
            // above for barrier for counting
            for (int i = 0; i < _nprocs; i++)
                server.WaitOne();
            for (int i = 0; i < _nprocs; i++)
                client[i].Release();
            // above for barrier for sending data to share space
            for (int i = 0; i < _nprocs; i++)
                server.WaitOne();
            // above for waiting for overwriting 
            int ret = left - 1;
            for (int i = 0; i < _nprocs; i++)
                ret += smaller[i];
            return ret;
        }
        public void ParaPartitionInterface(int left,int right)
        {
            _showArray(left, right);
            paraPartitionMaster(left, right);
            Console.WriteLine("Done");
            _showArray(left, right);
        }
        
        private void tNaiveParaQuicksort(object para)
        {
            object[] paras = para as object[];
            int left = (int)paras[0];
            int right = (int)paras[1];
            Semaphore s = (Semaphore)paras[2];
            naiveParaQuicksort(left, right);
            s.Release();
        }
        private void naiveParaQuicksort(int left,int right)
        {
            if (left >= right)
                return;
            else if (right - left < _divideSize / 4)
            {
                _improvedQuicksort(left, right);
                return;
            }
            int pivot = paraPartitionMaster(left, right);
            Semaphore s=new Semaphore(0,2);
            object para1 = (object)new object[3] { left, pivot - 1, s };
            object para2 = (object)new object[3] { pivot + 1, right, s };
            Thread t1 = new Thread(new ParameterizedThreadStart(tNaiveParaQuicksort));
            t1.Start(para1);
            Thread t2 = new Thread(new ParameterizedThreadStart(tNaiveParaQuicksort));
            t2.Start(para2);
            for (int i = 0; i < 2; i++)
                s.WaitOne();
            return;
        }

        /// <summary>
        /// Thread interface for calling _quicksort as a subthread
        /// para = {leftIndex,rightIndex,semaphore s}
        /// </summary>
        /// <param name="para"></param>
        private void tQuicksort(object para)
        {
            object[] paras = para as object[];
            int left = (int)paras[0];
            int right = (int)paras[1];
            Semaphore s = (Semaphore)paras[2];
            _quickSort(left, right);
            s.Release();
        }

        private double nativeParaQuicksortTimer(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            nativeParaQuicksort(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }
        /// <summary>
        /// an implementation on my pc whose physical processor count is 2
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void nativeParaQuicksort(int left,int right)
        {
            int pivot1 = paraPartitionMaster(left, right);
            int pivot2 = paraPartitionMaster(left, pivot1 - 1);
            int pivot3 = paraPartitionMaster(pivot1 + 1, right);
            Semaphore s = new Semaphore(0, 4);
            Thread[] threadPool = new Thread[4];
            object paras0 = (object)new object[3] { left, pivot2 - 1, s };
            object paras1 = (object)new object[3] { pivot2 + 1, pivot1 - 1, s };
            object paras2 = (object)new object[3] { pivot1 + 1, pivot3 - 1, s };
            object paras3 = (object)new object[3] { pivot3 + 1, right, s };
            threadPool[0] = new Thread(new ParameterizedThreadStart(tQuicksort));
            threadPool[0].Start(paras0);
            threadPool[1] = new Thread(new ParameterizedThreadStart(tQuicksort));
            threadPool[1].Start(paras1);
            threadPool[2] = new Thread(new ParameterizedThreadStart(tQuicksort));
            threadPool[2].Start(paras2);
            threadPool[3] = new Thread(new ParameterizedThreadStart(tQuicksort));
            threadPool[3].Start(paras3);
            for (int i = 0; i < 4; i++)
                s.WaitOne();
        }

        /// <summary>
        /// Partition _data into _partitionAreaNumber segments for para-run
        /// </summary>
        private void paraSegmentPartition()
        {
            _areaLeft[0] = 0;
            _areaRigt[_partitionAreaNumber - 1] = _length - 1;
            for (int i = 0; i < _layer; i++)
            {
                int startIndex = 0;
                int stepLength = (int)Math.Pow(2, _layer - i - 1);
                int areaLength=(int)Math.Pow(2,_layer-i);
                for (int j = 0; j < (int)Math.Pow(2, i); j++)
                {
                    startIndex = (startIndex + j * areaLength) % (int)Math.Pow(2, _layer);
                    int leftIndex = _areaLeft[startIndex];
                    int rigtIndex = _areaRigt[startIndex + areaLength - 1];
                    int pivot = paraPartitionMaster(leftIndex, rigtIndex);
                    _areaLeft[startIndex + stepLength] = pivot + 1;
                    _areaRigt[startIndex + stepLength - 1] = pivot - 1;
                }
            }
        }

        /// <summary>
        /// final implementation for parallel quicksort
        /// first parallelly partition the numbers into nprocs
        /// then run serial quicksort on each one of them
        /// </summary>
        private void realParaQuicksort()
        {
            paraSegmentPartition();
            int nthreads = (int)Math.Pow(2, _layer);
            Semaphore s=new Semaphore(0,nthreads);
            for (int i = 0; i < nthreads; i++)
            {
                object para = (object)new object[3] { _areaLeft[i], _areaRigt[i], s };
                Thread t = new Thread(new ParameterizedThreadStart(tQuicksort));
                t.Start(para);
            }
            for (int i = 0; i < nthreads; i++)
                s.WaitOne();
        }
        private double paraQuicksortTimer(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            //naiveParaQuicksort(left, right);
            realParaQuicksort();
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void Quicksort(bool record=false,
            String fileName="..\\..\\DataFiles\\order4.txt")
        {
            _sorter = new Sorter(paraQuicksortTimer);
            if (record)
                _sortAndRecord(fileName);
            else
                _sorter(0, _length - 1);
        }
        public void PerformanceAnalyzer(int testRound=100)
        {
            Console.WriteLine("Testing parallel quicksort for {0} rounds", testRound);
            _sorter = new Sorter(paraQuicksortTimer);
            _performanceAnalyzer(testRound);
        }

        public void SizePerformanceAnalyzer(int testScale=30000,int testRound=100)
        {
            _sorter = new Sorter(paraQuicksortTimer);
            Console.WriteLine("Testing parallel quicksort on scale {0} for {1} rounds", testScale, testRound);
            _sizePerformanceAnalyzer(testScale, testRound);
        }
        private double ParaPartitionTimer(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            paraPartitionMaster(left,right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        private double SerialPartitionTimer(int left,int right)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _partition(left, right);
            timer.Stop();
            TimeSpan span = timer.Elapsed;
            return span.TotalSeconds;
        }

        public void PartitionAnalyzer(int testRound=100)
        {
            _sorter = new Sorter(SerialPartitionTimer);
            Console.WriteLine("Serial partition test for {0} rounds", testRound);
            _performanceAnalyzer(testRound, false);
            _sorter = new Sorter(ParaPartitionTimer);
            Console.WriteLine("Parallel Partition test for {0} rounds", testRound);
            _performanceAnalyzer(testRound, false);
        }

        public void NativeParallelQuicksortAnalyzer(int testRound=100)
        {
            _sorter = new Sorter(nativeParaQuicksortTimer);
            Console.WriteLine("Testing native parallel quicksort for {0} rounds", testRound);
            _performanceAnalyzer(testRound);
        }
    }
}
