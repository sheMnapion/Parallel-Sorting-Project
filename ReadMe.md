Author：李奡程 Time：2018-12-30 Email：161220062@smail.nju.edu.cn


这是关于我的并行计算项目的相关文件的说明文档。其实现了归并排序、快速排序和枚举排序的串行和并行版本以及相应的性能分析。


# 1. 文件夹结构综述
    文件夹下包括原始数据random.txt，说明文档ReadMe.txt，实验报告report.pdf，相关的输出文件order*.txt，代码运行结果截图文件夹images/，实验报告Latex源码文件夹ReportTex/和源代码文件夹parallelComputingProject/。


# 2. 代码运行&基本描述
    本项目用c#语言编写，运行环境为win10和Visual Studio 2013。如果支持上述环境，则用VS中打开项目文件parallelComputingProject.sln，在IDE中选择调试->开始执行即可运行。其中相关的代码位于parallelComputingProject/parallelComputingProject文件夹下。

2.1 主函数
    该文件夹下的Program.cs为程序入口，可在其中改动main函数的内容进行不同的运算，其中有三个函数：
    (1) WriteData() : 读入random.txt中的数据，用6种不同的排序方法分别排序，并将结果输出至DataFiles下的order*.txt文件中。
    (2) AnalyzePerformance() : 读入random.txt中的数据，用6中不同的排序方法分别排序，并统计其在该数据集上若干次后的平均时长（次数可通过修改相应代码调整；因为）。
    (3) SizeAnalyzePerformance(int testScale=100000,int testRound=10) : 测试串行和并行的快排和归并排序在给定数据集大小的情况下若干次的平均时长。

2.2 基类及其辅助功能
   Utilities文件夹下包括SerialSortBase.cs和Utilities.cs两个类文件，实现相应常用的库函数、基本的排序方法以及性能分析功能。
   Utilities.cs包括Swap接口（用于交换两个数据，用于快排），checkSum接口（用于检验数组中的一部分数据和是否正确）和assert接口（Debug.Assert低配，仅检查相应条件正确）。
   SerialSortBase.cs为所有排序类的基类，以下详细描述其功能。
2.2.1 基本成员
    protected int[] _data 存放要排序的数据。
    protected int[] _shared 作为排序数据的备用内存。由于归并排序在归并步骤中需要额外的空间存放元素，所以使用一个与原数据登场的数组来当中间空间，避免重复申请释放空间造成的性能损失。
    protected Random _r 排序用到的随机数发生器，用来对快排进行随机化。
    protected int _length 记录排序数据的长度。
    protected const int _insertionSortThreshold = 12  快排优化中使用的常数。
    protected delegate double Sorter(int left,int right) 用于计时分析性能的委托函数（函数指针）
    protected Sorter _sorter 该委托的实例化
2.2.2 功能函数
    构造函数：需要明确给出data，用该数据作为将要排序的数据。
    int _partition(int left,int right) : 快排中用到的分割函数，将一段数据分为两段，一段比pivot小，一段比pivot大，返回pivot所在位置。
    void _quickSort(int left,int right) : 快排。
    int _randomizedPartition(int left,int right) : 随机划分，_partition的随机化版本。
    void _randomizedQuicksort(int left,int right) : 随机快排。
    void _improvedQuicksort(int left,int right,bool randomized=true) : 个人实现的对快排的改进。
    bool _inOrder(int left,int right, bool _increase=true) : 检查_data是否已正序（或逆序）排好。
    void _insertionSort(int left,int right) : 插入排序，改进快排用到的子函数。
    void _mergeSort(int left,int right) : 归并排序。
    void _sizePerformanceAnalyzer(int testScale=30000,int testRound=100,bool checkOrder=true): 性能分析工具之一，对排序方法在给定数据规模（testScale）下进行testRound回合后的平均耗时进行分析并输出结果到命令行。若checkOrder为true，则排序后还进行排序结果正确性的检查。
    void _performanceAnalyzer(int testRound=100,bool checkOrder=true) ：性能分析工具之一，对排序方法在给定数据集(_data)下进行testRound回合后的平均耗时进行分析并输出结果到命令行。若checkOrder为true，则在每回合排序后还进行排序结果正确性的检查。
    void _sortAndRecord(string fileName) : 进行排序并将结果输出到指定文件中。

2.3 串行排序
    串行排序实现代码文件位于文件夹SerialSortMethods下，其中包括四个类文件LibrarySort.cs，SerialEnumerationSort.cs，SerialMergesort.cs，SerialQuicksort.cs，都继承自基类SerialSortBase。LibrarySort为标准库实现（Array.Sort），其他分别为串行枚举排序、串行归并排序和串行快排。其都支持统一接口sortMethodName(bool record=false, string fileName='...')（用于记录排序结果），PerformanceAnalyzer（给定数据集上的性能）和SizePerformanceAnalyzer（给定数据规模时的性能）。

2.4 并行排序
    并行排序实现代码文件位于文件夹ParallelSortMethods下，其中包括四个类文件ParallelEnumerationSort.cs，ParallelMergesort.cs和ParalellQuicksort.cs，都继承自基类SerialSortBase。其支持和上述串行排序类似的接口。具体使用实例可参照Program.cs中的三个函数。

2.5 数据文件
    位于DataFiles文件夹下。此项目的输出结果文件即从DataFiles下直接拷贝过去的。


# 3. 其他
    parallelComputingProject/parallelComputingProject/bin/Debug/paralelComputingProject.exe为目前的可执行文件，可通过运行之进行数据记录、在该数据集上的性能分析以及在给定数据集规模下的性能分析。
    如果有其他运行方面的问题，请通过电子邮箱联系。
