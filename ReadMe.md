Author����S�� Time��2018-12-30 Email��161220062@smail.nju.edu.cn


���ǹ����ҵĲ��м�����Ŀ������ļ���˵���ĵ�����ʵ���˹鲢���򡢿��������ö������Ĵ��кͲ��а汾�Լ���Ӧ�����ܷ�����


# 1. �ļ��нṹ����
    �ļ����°���ԭʼ����random.txt��˵���ĵ�ReadMe.txt��ʵ�鱨��report.pdf����ص�����ļ�order*.txt���������н����ͼ�ļ���images/��ʵ�鱨��LatexԴ���ļ���ReportTex/��Դ�����ļ���parallelComputingProject/��


# 2. ��������&��������
    ����Ŀ��c#���Ա�д�����л���Ϊwin10��Visual Studio 2013�����֧����������������VS�д���Ŀ�ļ�parallelComputingProject.sln����IDE��ѡ�����->��ʼִ�м������С�������صĴ���λ��parallelComputingProject/parallelComputingProject�ļ����¡�

2.1 ������
    ���ļ����µ�Program.csΪ������ڣ��������иĶ�main���������ݽ��в�ͬ�����㣬����������������
    (1) WriteData() : ����random.txt�е����ݣ���6�ֲ�ͬ�����򷽷��ֱ����򣬲�����������DataFiles�µ�order*.txt�ļ��С�
    (2) AnalyzePerformance() : ����random.txt�е����ݣ���6�в�ͬ�����򷽷��ֱ����򣬲�ͳ�����ڸ����ݼ������ɴκ��ƽ��ʱ����������ͨ���޸���Ӧ�����������Ϊ����
    (3) SizeAnalyzePerformance(int testScale=100000,int testRound=10) : ���Դ��кͲ��еĿ��ź͹鲢�����ڸ������ݼ���С����������ɴε�ƽ��ʱ����

2.2 ���༰�丨������
   Utilities�ļ����°���SerialSortBase.cs��Utilities.cs�������ļ���ʵ����Ӧ���õĿ⺯�������������򷽷��Լ����ܷ������ܡ�
   Utilities.cs����Swap�ӿڣ����ڽ����������ݣ����ڿ��ţ���checkSum�ӿڣ����ڼ��������е�һ�������ݺ��Ƿ���ȷ����assert�ӿڣ�Debug.Assert���䣬�������Ӧ������ȷ����
   SerialSortBase.csΪ����������Ļ��࣬������ϸ�����书�ܡ�
2.2.1 ������Ա
    protected int[] _data ���Ҫ��������ݡ�
    protected int[] _shared ��Ϊ�������ݵı����ڴ档���ڹ鲢�����ڹ鲢��������Ҫ����Ŀռ���Ԫ�أ�����ʹ��һ����ԭ���ݵǳ������������м�ռ䣬�����ظ������ͷſռ���ɵ�������ʧ��
    protected Random _r �����õ���������������������Կ��Ž����������
    protected int _length ��¼�������ݵĳ��ȡ�
    protected const int _insertionSortThreshold = 12  �����Ż���ʹ�õĳ�����
    protected delegate double Sorter(int left,int right) ���ڼ�ʱ�������ܵ�ί�к���������ָ�룩
    protected Sorter _sorter ��ί�е�ʵ����
2.2.2 ���ܺ���
    ���캯������Ҫ��ȷ����data���ø�������Ϊ��Ҫ��������ݡ�
    int _partition(int left,int right) : �������õ��ķָ������һ�����ݷ�Ϊ���Σ�һ�α�pivotС��һ�α�pivot�󣬷���pivot����λ�á�
    void _quickSort(int left,int right) : ���š�
    int _randomizedPartition(int left,int right) : ������֣�_partition��������汾��
    void _randomizedQuicksort(int left,int right) : ������š�
    void _improvedQuicksort(int left,int right,bool randomized=true) : ����ʵ�ֵĶԿ��ŵĸĽ���
    bool _inOrder(int left,int right, bool _increase=true) : ���_data�Ƿ������򣨻������źá�
    void _insertionSort(int left,int right) : �������򣬸Ľ������õ����Ӻ�����
    void _mergeSort(int left,int right) : �鲢����
    void _sizePerformanceAnalyzer(int testScale=30000,int testRound=100,bool checkOrder=true): ���ܷ�������֮һ�������򷽷��ڸ������ݹ�ģ��testScale���½���testRound�غϺ��ƽ����ʱ���з������������������С���checkOrderΪtrue��������󻹽�����������ȷ�Եļ�顣
    void _performanceAnalyzer(int testRound=100,bool checkOrder=true) �����ܷ�������֮һ�������򷽷��ڸ������ݼ�(_data)�½���testRound�غϺ��ƽ����ʱ���з������������������С���checkOrderΪtrue������ÿ�غ�����󻹽�����������ȷ�Եļ�顣
    void _sortAndRecord(string fileName) : �������򲢽���������ָ���ļ��С�

2.3 ��������
    ��������ʵ�ִ����ļ�λ���ļ���SerialSortMethods�£����а����ĸ����ļ�LibrarySort.cs��SerialEnumerationSort.cs��SerialMergesort.cs��SerialQuicksort.cs�����̳��Ի���SerialSortBase��LibrarySortΪ��׼��ʵ�֣�Array.Sort���������ֱ�Ϊ����ö�����򡢴��й鲢����ʹ��п��š��䶼֧��ͳһ�ӿ�sortMethodName(bool record=false, string fileName='...')�����ڼ�¼����������PerformanceAnalyzer���������ݼ��ϵ����ܣ���SizePerformanceAnalyzer���������ݹ�ģʱ�����ܣ���

2.4 ��������
    ��������ʵ�ִ����ļ�λ���ļ���ParallelSortMethods�£����а����ĸ����ļ�ParallelEnumerationSort.cs��ParallelMergesort.cs��ParalellQuicksort.cs�����̳��Ի���SerialSortBase����֧�ֺ����������������ƵĽӿڡ�����ʹ��ʵ���ɲ���Program.cs�е�����������

2.5 �����ļ�
    λ��DataFiles�ļ����¡�����Ŀ���������ļ�����DataFiles��ֱ�ӿ�����ȥ�ġ�


# 3. ����
    parallelComputingProject/parallelComputingProject/bin/Debug/paralelComputingProject.exeΪĿǰ�Ŀ�ִ���ļ�����ͨ������֮�������ݼ�¼���ڸ����ݼ��ϵ����ܷ����Լ��ڸ������ݼ���ģ�µ����ܷ�����
    ������������з�������⣬��ͨ������������ϵ��
