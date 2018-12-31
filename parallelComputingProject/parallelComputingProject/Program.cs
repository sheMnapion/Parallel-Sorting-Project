using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace parallelComputingProject
{
    class Program
    {
        private static int[] _data;

        public static int[] data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        static void GetData()
        {
            char[] separate = new char[] { ' ' };
            FileStream randomData = new FileStream("..\\..\\DataFiles\\random.txt", FileMode.Open);
            StreamReader dataReader = new StreamReader(randomData);
            data = new int[30000];
            string line = dataReader.ReadLine();
            string[] values = line.Split(separate);
            for (int i = 0; i < 30000; i++)
            {
                data[i] = Convert.ToInt32(values[i]);
            }
            Console.WriteLine("GET DATA DONE");
        }

        static void GenerateData(int size)
        {
            data = new int[size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
                data[i] = r.Next(-50000, 50000);
        }
        static void WriteData()
        {
            GetData();
            SerialEnumerationSort ses = new SerialEnumerationSort(data);
            SerialMergesort sms = new SerialMergesort(data);
            SerialQuicksort nsq = new SerialQuicksort(data);
            ParallelQuicksort pqs = new ParallelQuicksort(data);
            ParallelMergesort pms = new ParallelMergesort(data);
            ParallelEnumerationSort pes = new ParallelEnumerationSort(data);

            ses.EnumerationSort(true);
            pqs.Quicksort(true);
            pms.ParallelMergeSort(true);
            sms.MergeSort(true);
            nsq.QuickSort(false, true);
            pes.EnumerationSort(true);
        }

        static void SizeAnalyzePerformance(int testScale=30000,int testRound=10)
        {
            int[] _empData = new int[testScale];
            SerialQuicksort sqs = new SerialQuicksort(_empData);
            SerialMergesort sms = new SerialMergesort(_empData);
            ParallelQuicksort pqs = new ParallelQuicksort(_empData);
            ParallelMergesort pms = new ParallelMergesort(_empData);
            LibrarySort ls = new LibrarySort(_empData);

            pqs.SizePerformanceAnalyzer(testScale, testRound);
            pms.SizePerformanceAnalyzer(testScale, testRound);
            sqs.SizePerformanceAnalyzer(testScale, testRound);
            sms.SizePerformanceAnalyzer(testScale, testRound);
            ls.SizePerformanceAnalyzer(testScale, testRound);
        }
        static void AnalyzePerformance()
        {
            GetData();
            ParallelQuicksort pqs = new ParallelQuicksort(data);
            SerialQuicksort rsqi = new SerialQuicksort(data);
            ParallelMergesort pms = new ParallelMergesort(data);
            SerialMergesort sms = new SerialMergesort(data);
            ParallelEnumerationSort pes = new ParallelEnumerationSort(data);
            SerialEnumerationSort ses = new SerialEnumerationSort(data);
            LibrarySort ls = new LibrarySort(data);

            rsqi.PerformanceAnalyzer(SerialQuicksort.SortMethod.randomizedImprovedQuicksort, 10);
            pqs.PerformanceAnalyzer(10);
            pms.PerformanceAnalyzer(10); // show the performance on given data
            ls.PerformanceAnalyzer(10);
            sms.PerformanceAnalyzer(10);
            ses.PerformanceAnalyzer(10);
            pes.PerformanceAnalyzer(10);
            
        }
        static void Main(string[] args)
        {
            WriteData();
            AnalyzePerformance();
            //SizeAnalyzePerformance(10000, 10);
            SizeAnalyzePerformance(100000, 10);
            //SizeAnalyzePerformance(1000000, 10);
            //SizeAnalyzePerformance(10000000, 10);
        }
    }
}
