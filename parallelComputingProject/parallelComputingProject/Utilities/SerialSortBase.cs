using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace parallelComputingProject
{
    /// <summary>
    /// Serial Sort Base Class: base class for all sorting methods
    /// include the data area _data, random generator _r, data length _length
    /// and several useful methods
    /// </summary>
    class SerialSortBase
    {
        protected int[] _data;
        protected int[] _shared;
        protected Random _r;
        protected int _length;
        protected const int _insertionSortThreshold = 12;
        protected delegate double Sorter(int left,int right);
        protected Sorter _sorter;

        public SerialSortBase() { }
        public SerialSortBase(int[] data)
        {
            _data=new int[data.Length];
            data.CopyTo(_data, 0);
            _r = new Random();
            _length = data.Length;
            Console.WriteLine("READ DATA, SIZE [{0}]", _data.Length);
        }

        /// <summary>
        /// partition for quicksort based on pivot between left and right
        /// return the index of partitioned pivot
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        protected int _partition(int left, int right)
        {
            int x = _data[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (_data[j] <= x)
                {
                    i++;
                    Utilities.Swap(ref _data[i], ref _data[j]);
                }
            }
            Utilities.Swap(ref _data[i + 1], ref _data[right]);
            return i + 1;
        }

        /// <summary>
        /// Tail recursive quicksort; avoid segmentation fault
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        protected void _quickSort(int left, int right)
        {
            while (left < right)
            {
                int q = _partition(left, right);
                _quickSort(left, q - 1);
                left = q + 1;
            }
        }

        /// <summary>
        /// choose the pivot randomly and partition
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        protected int _randomizedPartition(int left, int right)
        {
            int pivotIndex = _r.Next(right - left);
            Utilities.Swap(ref _data[right], ref _data[left + pivotIndex]);
            return _partition(left, right);
        }

        /// <summary>
        /// Randomized quicksort from left to right
        /// Tail recursive to avoid segmentation fault
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        protected void _randomizedQuicksort(int left, int right)
        {
            while (left < right)
            {
                int q = _randomizedPartition(left, right);
                _randomizedQuicksort(left, q - 1);
                left = q + 1;
            }
        }

        protected void _improvedQuicksort(int left, int right, bool randomzied = true)
        {
            while (left < right)
            {
                int q = _partition(left, right);
                if (right - left <= _insertionSortThreshold)
                    _insertionSort(left, right);
                else if (randomzied)
                    _quickSort(left, q - 1);
                else
                    _randomizedQuicksort(left, q - 1);
                left = q + 1;
            }
        }

        protected void _showArray()
        {
            for (int i = 0; i < _length; i++)
                Console.Write("{0} ", _data[i]);
            Console.Write("\n");
        }

        protected void _showArray(int left,int right)
        {
            Console.WriteLine("From {0} to {1}", left, right);
            for (int i = left; i <= right; i++)
                Console.Write("{0} ", _data[i]);
            Console.WriteLine();
        }
        protected bool _inOrder(int left, int right, bool _increase = true)
        {
            for (int i = left; i <= right - 1; i++)
            {
                if ((_data[i] > _data[i + 1]) && _increase)
                {
                    Console.WriteLine("position [{0}]: [{1}] [{2}]", i, _data[i], _data[i + 1]);
                    return false;
                }
                if ((_data[i] < _data[i + 1]) && (!_increase))
                    return false;
            }
            return true;
        }
        protected void _insertionSort(int left, int right)
        {
            if (left >= right)
                return;
            for (int j = left + 1; j <= right; j++)
            {
                int key = _data[j];
                int i = j - 1;
                while (i >= left && _data[i]>key)
                {
                    _data[i + 1] = _data[i];
                    i--;
                }
                _data[i + 1] = key;
            }
        }

        protected void _mergeSort(int left, int right)
        {
            if (left >= right)
                return;
            int mid = (left + right) / 2;
            _mergeSort(left, mid);
            _mergeSort(mid + 1, right);
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
        /// interface for analyzing performance focused on the size of input
        /// run testRounds on randomly generated data of scale testScale
        /// </summary>
        /// <param name="testScale"></param>
        /// <param name="testRound"></param>
        /// <param name="checkOrder"></param>
        protected void _sizePerformanceAnalyzer(int testScale=30000,int testRound=100,bool checkOrder=true)
        {
            double totalTime = 0;
            int[] dataCopy = new int[testScale];
            _data = new int[testScale];
            _shared = new int[testScale];
            _length = testScale;
            for (int i = 0; i < testRound; i++)
            {
                for (int j = 0; j < testScale; j++)
                {
                    dataCopy[j] = _r.Next(-50000, 50000);
                }
                dataCopy.CopyTo(_data, 0);
                totalTime += _sorter(0, _length - 1);
                if (checkOrder)
                {
                    if (!_inOrder(0, _length - 1))
                    {
                        _showArray();
                        throw new SystemException();
                    }
                }
            }
            Console.WriteLine("Average Time for {0} rounds on size [{1}]: [{2}]", testRound,
                testScale, totalTime / testRound);
        }
        protected void _performanceAnalyzer(int testRound=100,bool checkOrder=true)
        {
            double totalTime = 0;
            int[] dataCopy = new int[_data.Length];
            for (int i = 0; i < testRound; i++)
            {
                _data.CopyTo(dataCopy, 0);
                totalTime += _sorter(0, _length - 1);
                if (checkOrder)
                {
                    if (!_inOrder(0, _length - 1))
                    {
                        _showArray();
                        throw new SystemException();
                    }
                }
                dataCopy.CopyTo(_data, 0);
            }
            Console.WriteLine("Average Time for {0} rounds: [{1}]", testRound,
                totalTime / testRound);
        }

        protected void _sortAndRecord(String fileName)
        {
            _sorter(0, _length - 1);
            FileStream outFile=new FileStream(fileName,FileMode.Create,FileAccess.Write);
            StreamWriter oFile = new StreamWriter(outFile);
            for (int i = 0; i < _length; i++)
            {
                oFile.Write("{0} ", _data[i]);
            }
            oFile.Write("\n");
            oFile.Close();
        }
    }
}
