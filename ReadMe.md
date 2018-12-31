<<<<<<< HEAD:ReadMe.md
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
=======
Author锛氭潕濂＄▼ Time锛�2018-12-30 Email锛�161220062@smail.nju.edu.cn


杩欐槸鍏充簬鎴戠殑骞惰璁＄畻椤圭洰鐨勭浉鍏虫枃浠剁殑璇存槑鏂囨。銆傚叾瀹炵幇浜嗗綊骞舵帓搴忋�佸揩閫熸帓搴忓拰鏋氫妇鎺掑簭鐨勪覆琛屽拰骞惰鐗堟湰浠ュ強鐩稿簲鐨勬�ц兘鍒嗘瀽銆�


# 1. 鏂囦欢澶圭粨鏋勭患杩�
    鏂囦欢澶逛笅鍖呮嫭鍘熷鏁版嵁random.txt锛岃鏄庢枃妗eadMe.txt锛屽疄楠屾姤鍛妑eport.pdf锛岀浉鍏崇殑杈撳嚭鏂囦欢order*.txt锛屼唬鐮佽繍琛岀粨鏋滄埅鍥炬枃浠跺すimages/锛屽疄楠屾姤鍛奓atex婧愮爜鏂囦欢澶筊eportTex/鍜屾簮浠ｇ爜鏂囦欢澶筽arallelComputingProject/銆�


# 2. 浠ｇ爜杩愯&鍩烘湰鎻忚堪
    鏈」鐩敤c#璇█缂栧啓锛岃繍琛岀幆澧冧负win10鍜孷isual Studio 2013銆傚鏋滄敮鎸佷笂杩扮幆澧冿紝鍒欑敤VS涓墦寮�椤圭洰鏂囦欢parallelComputingProject.sln锛屽湪IDE涓�夋嫨璋冭瘯->寮�濮嬫墽琛屽嵆鍙繍琛屻�傚叾涓浉鍏崇殑浠ｇ爜浣嶄簬parallelComputingProject/parallelComputingProject鏂囦欢澶逛笅銆�

2.1 涓诲嚱鏁�
    璇ユ枃浠跺す涓嬬殑Program.cs涓虹▼搴忓叆鍙ｏ紝鍙湪鍏朵腑鏀瑰姩main鍑芥暟鐨勫唴瀹硅繘琛屼笉鍚岀殑杩愮畻锛屽叾涓湁涓変釜鍑芥暟锛�
    (1) WriteData() : 璇诲叆random.txt涓殑鏁版嵁锛岀敤6绉嶄笉鍚岀殑鎺掑簭鏂规硶鍒嗗埆鎺掑簭锛屽苟灏嗙粨鏋滆緭鍑鸿嚦DataFiles涓嬬殑order*.txt鏂囦欢涓��
    (2) AnalyzePerformance() : 璇诲叆random.txt涓殑鏁版嵁锛岀敤6涓笉鍚岀殑鎺掑簭鏂规硶鍒嗗埆鎺掑簭锛屽苟缁熻鍏跺湪璇ユ暟鎹泦涓婅嫢骞叉鍚庣殑骞冲潎鏃堕暱锛堟鏁板彲閫氳繃淇敼鐩稿簲浠ｇ爜璋冩暣锛涘洜涓猴級銆�
    (3) SizeAnalyzePerformance(int testScale=100000,int testRound=10) : 娴嬭瘯涓茶鍜屽苟琛岀殑蹇帓鍜屽綊骞舵帓搴忓湪缁欏畾鏁版嵁闆嗗ぇ灏忕殑鎯呭喌涓嬭嫢骞叉鐨勫钩鍧囨椂闀裤��

2.2 鍩虹被鍙婂叾杈呭姪鍔熻兘
   Utilities鏂囦欢澶逛笅鍖呮嫭SerialSortBase.cs鍜孶tilities.cs涓や釜绫绘枃浠讹紝瀹炵幇鐩稿簲甯哥敤鐨勫簱鍑芥暟銆佸熀鏈殑鎺掑簭鏂规硶浠ュ強鎬ц兘鍒嗘瀽鍔熻兘銆�
   Utilities.cs鍖呮嫭Swap鎺ュ彛锛堢敤浜庝氦鎹袱涓暟鎹紝鐢ㄤ簬蹇帓锛夛紝checkSum鎺ュ彛锛堢敤浜庢楠屾暟缁勪腑鐨勪竴閮ㄥ垎鏁版嵁鍜屾槸鍚︽纭級鍜宎ssert鎺ュ彛锛圖ebug.Assert浣庨厤锛屼粎妫�鏌ョ浉搴旀潯浠舵纭級銆�
   SerialSortBase.cs涓烘墍鏈夋帓搴忕被鐨勫熀绫伙紝浠ヤ笅璇︾粏鎻忚堪鍏跺姛鑳姐��
2.2.1 鍩烘湰鎴愬憳
    protected int[] _data 瀛樻斁瑕佹帓搴忕殑鏁版嵁銆�
    protected int[] _shared 浣滀负鎺掑簭鏁版嵁鐨勫鐢ㄥ唴瀛樸�傜敱浜庡綊骞舵帓搴忓湪褰掑苟姝ラ涓渶瑕侀澶栫殑绌洪棿瀛樻斁鍏冪礌锛屾墍浠ヤ娇鐢ㄤ竴涓笌鍘熸暟鎹櫥鍦虹殑鏁扮粍鏉ュ綋涓棿绌洪棿锛岄伩鍏嶉噸澶嶇敵璇烽噴鏀剧┖闂撮�犳垚鐨勬�ц兘鎹熷け銆�
    protected Random _r 鎺掑簭鐢ㄥ埌鐨勯殢鏈烘暟鍙戠敓鍣紝鐢ㄦ潵瀵瑰揩鎺掕繘琛岄殢鏈哄寲銆�
    protected int _length 璁板綍鎺掑簭鏁版嵁鐨勯暱搴︺��
    protected const int _insertionSortThreshold = 12  蹇帓浼樺寲涓娇鐢ㄧ殑甯告暟銆�
    protected delegate double Sorter(int left,int right) 鐢ㄤ簬璁℃椂鍒嗘瀽鎬ц兘鐨勫鎵樺嚱鏁帮紙鍑芥暟鎸囬拡锛�
    protected Sorter _sorter 璇ュ鎵樼殑瀹炰緥鍖�
2.2.2 鍔熻兘鍑芥暟
    鏋勯�犲嚱鏁帮細闇�瑕佹槑纭粰鍑篸ata锛岀敤璇ユ暟鎹綔涓哄皢瑕佹帓搴忕殑鏁版嵁銆�
    int _partition(int left,int right) : 蹇帓涓敤鍒扮殑鍒嗗壊鍑芥暟锛屽皢涓�娈垫暟鎹垎涓轰袱娈碉紝涓�娈垫瘮pivot灏忥紝涓�娈垫瘮pivot澶э紝杩斿洖pivot鎵�鍦ㄤ綅缃��
    void _quickSort(int left,int right) : 蹇帓銆�
    int _randomizedPartition(int left,int right) : 闅忔満鍒掑垎锛宊partition鐨勯殢鏈哄寲鐗堟湰銆�
    void _randomizedQuicksort(int left,int right) : 闅忔満蹇帓銆�
    void _improvedQuicksort(int left,int right,bool randomized=true) : 涓汉瀹炵幇鐨勫蹇帓鐨勬敼杩涖��
    bool _inOrder(int left,int right, bool _increase=true) : 妫�鏌data鏄惁宸叉搴忥紙鎴栭�嗗簭锛夋帓濂姐��
    void _insertionSort(int left,int right) : 鎻掑叆鎺掑簭锛屾敼杩涘揩鎺掔敤鍒扮殑瀛愬嚱鏁般��
    void _mergeSort(int left,int right) : 褰掑苟鎺掑簭銆�
    void _sizePerformanceAnalyzer(int testScale=30000,int testRound=100,bool checkOrder=true): 鎬ц兘鍒嗘瀽宸ュ叿涔嬩竴锛屽鎺掑簭鏂规硶鍦ㄧ粰瀹氭暟鎹妯★紙testScale锛変笅杩涜testRound鍥炲悎鍚庣殑骞冲潎鑰楁椂杩涜鍒嗘瀽骞惰緭鍑虹粨鏋滃埌鍛戒护琛屻�傝嫢checkOrder涓簍rue锛屽垯鎺掑簭鍚庤繕杩涜鎺掑簭缁撴灉姝ｇ‘鎬х殑妫�鏌ャ��
    void _performanceAnalyzer(int testRound=100,bool checkOrder=true) 锛氭�ц兘鍒嗘瀽宸ュ叿涔嬩竴锛屽鎺掑簭鏂规硶鍦ㄧ粰瀹氭暟鎹泦(_data)涓嬭繘琛宼estRound鍥炲悎鍚庣殑骞冲潎鑰楁椂杩涜鍒嗘瀽骞惰緭鍑虹粨鏋滃埌鍛戒护琛屻�傝嫢checkOrder涓簍rue锛屽垯鍦ㄦ瘡鍥炲悎鎺掑簭鍚庤繕杩涜鎺掑簭缁撴灉姝ｇ‘鎬х殑妫�鏌ャ��
    void _sortAndRecord(string fileName) : 杩涜鎺掑簭骞跺皢缁撴灉杈撳嚭鍒版寚瀹氭枃浠朵腑銆�

2.3 涓茶鎺掑簭
    涓茶鎺掑簭瀹炵幇浠ｇ爜鏂囦欢浣嶄簬鏂囦欢澶筍erialSortMethods涓嬶紝鍏朵腑鍖呮嫭鍥涗釜绫绘枃浠禠ibrarySort.cs锛孲erialEnumerationSort.cs锛孲erialMergesort.cs锛孲erialQuicksort.cs锛岄兘缁ф壙鑷熀绫籗erialSortBase銆侺ibrarySort涓烘爣鍑嗗簱瀹炵幇锛圓rray.Sort锛夛紝鍏朵粬鍒嗗埆涓轰覆琛屾灇涓炬帓搴忋�佷覆琛屽綊骞舵帓搴忓拰涓茶蹇帓銆傚叾閮芥敮鎸佺粺涓�鎺ュ彛sortMethodName(bool record=false, string fileName='...')锛堢敤浜庤褰曟帓搴忕粨鏋滐級锛孭erformanceAnalyzer锛堢粰瀹氭暟鎹泦涓婄殑鎬ц兘锛夊拰SizePerformanceAnalyzer锛堢粰瀹氭暟鎹妯℃椂鐨勬�ц兘锛夈��

2.4 骞惰鎺掑簭
    骞惰鎺掑簭瀹炵幇浠ｇ爜鏂囦欢浣嶄簬鏂囦欢澶筆arallelSortMethods涓嬶紝鍏朵腑鍖呮嫭鍥涗釜绫绘枃浠禤arallelEnumerationSort.cs锛孭arallelMergesort.cs鍜孭aralellQuicksort.cs锛岄兘缁ф壙鑷熀绫籗erialSortBase銆傚叾鏀寔鍜屼笂杩颁覆琛屾帓搴忕被浼肩殑鎺ュ彛銆傚叿浣撲娇鐢ㄥ疄渚嬪彲鍙傜収Program.cs涓殑涓変釜鍑芥暟銆�

2.5 鏁版嵁鏂囦欢
    浣嶄簬DataFiles鏂囦欢澶逛笅銆傛椤圭洰鐨勮緭鍑虹粨鏋滄枃浠跺嵆浠嶥ataFiles涓嬬洿鎺ユ嫹璐濊繃鍘荤殑銆�


# 3. 鍏朵粬
    parallelComputingProject/parallelComputingProject/bin/Debug/paralelComputingProject.exe涓虹洰鍓嶇殑鍙墽琛屾枃浠讹紝鍙�氳繃杩愯涔嬭繘琛屾暟鎹褰曘�佸湪璇ユ暟鎹泦涓婄殑鎬ц兘鍒嗘瀽浠ュ強鍦ㄧ粰瀹氭暟鎹泦瑙勬ā涓嬬殑鎬ц兘鍒嗘瀽銆�
    濡傛灉鏈夊叾浠栬繍琛屾柟闈㈢殑闂锛岃閫氳繃鐢靛瓙閭鑱旂郴銆�
>>>>>>> 0e1f8cc967e8add66bf4cb7524e02fa535acc0a0:ReadMe.txt
