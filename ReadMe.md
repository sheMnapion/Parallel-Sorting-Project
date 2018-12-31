<<<<<<< HEAD:ReadMe.md
Author£ºÀîŠS³Ì Time£º2018-12-30 Email£º161220062@smail.nju.edu.cn


ÕâÊÇ¹ØÓÚÎÒµÄ²¢ÐÐ¼ÆËãÏîÄ¿µÄÏà¹ØÎÄ¼þµÄËµÃ÷ÎÄµµ¡£ÆäÊµÏÖÁË¹é²¢ÅÅÐò¡¢¿ìËÙÅÅÐòºÍÃ¶¾ÙÅÅÐòµÄ´®ÐÐºÍ²¢ÐÐ°æ±¾ÒÔ¼°ÏàÓ¦µÄÐÔÄÜ·ÖÎö¡£


# 1. ÎÄ¼þ¼Ð½á¹¹×ÛÊö
    ÎÄ¼þ¼ÐÏÂ°üÀ¨Ô­Ê¼Êý¾Ýrandom.txt£¬ËµÃ÷ÎÄµµReadMe.txt£¬ÊµÑé±¨¸æreport.pdf£¬Ïà¹ØµÄÊä³öÎÄ¼þorder*.txt£¬´úÂëÔËÐÐ½á¹û½ØÍ¼ÎÄ¼þ¼Ðimages/£¬ÊµÑé±¨¸æLatexÔ´ÂëÎÄ¼þ¼ÐReportTex/ºÍÔ´´úÂëÎÄ¼þ¼ÐparallelComputingProject/¡£


# 2. ´úÂëÔËÐÐ&»ù±¾ÃèÊö
    ±¾ÏîÄ¿ÓÃc#ÓïÑÔ±àÐ´£¬ÔËÐÐ»·¾³Îªwin10ºÍVisual Studio 2013¡£Èç¹ûÖ§³ÖÉÏÊö»·¾³£¬ÔòÓÃVSÖÐ´ò¿ªÏîÄ¿ÎÄ¼þparallelComputingProject.sln£¬ÔÚIDEÖÐÑ¡Ôñµ÷ÊÔ->¿ªÊ¼Ö´ÐÐ¼´¿ÉÔËÐÐ¡£ÆäÖÐÏà¹ØµÄ´úÂëÎ»ÓÚparallelComputingProject/parallelComputingProjectÎÄ¼þ¼ÐÏÂ¡£

2.1 Ö÷º¯Êý
    ¸ÃÎÄ¼þ¼ÐÏÂµÄProgram.csÎª³ÌÐòÈë¿Ú£¬¿ÉÔÚÆäÖÐ¸Ä¶¯mainº¯ÊýµÄÄÚÈÝ½øÐÐ²»Í¬µÄÔËËã£¬ÆäÖÐÓÐÈý¸öº¯Êý£º
    (1) WriteData() : ¶ÁÈërandom.txtÖÐµÄÊý¾Ý£¬ÓÃ6ÖÖ²»Í¬µÄÅÅÐò·½·¨·Ö±ðÅÅÐò£¬²¢½«½á¹ûÊä³öÖÁDataFilesÏÂµÄorder*.txtÎÄ¼þÖÐ¡£
    (2) AnalyzePerformance() : ¶ÁÈërandom.txtÖÐµÄÊý¾Ý£¬ÓÃ6ÖÐ²»Í¬µÄÅÅÐò·½·¨·Ö±ðÅÅÐò£¬²¢Í³¼ÆÆäÔÚ¸ÃÊý¾Ý¼¯ÉÏÈô¸É´ÎºóµÄÆ½¾ùÊ±³¤£¨´ÎÊý¿ÉÍ¨¹ýÐÞ¸ÄÏàÓ¦´úÂëµ÷Õû£»ÒòÎª£©¡£
    (3) SizeAnalyzePerformance(int testScale=100000,int testRound=10) : ²âÊÔ´®ÐÐºÍ²¢ÐÐµÄ¿ìÅÅºÍ¹é²¢ÅÅÐòÔÚ¸ø¶¨Êý¾Ý¼¯´óÐ¡µÄÇé¿öÏÂÈô¸É´ÎµÄÆ½¾ùÊ±³¤¡£

2.2 »ùÀà¼°Æä¸¨Öú¹¦ÄÜ
   UtilitiesÎÄ¼þ¼ÐÏÂ°üÀ¨SerialSortBase.csºÍUtilities.csÁ½¸öÀàÎÄ¼þ£¬ÊµÏÖÏàÓ¦³£ÓÃµÄ¿âº¯Êý¡¢»ù±¾µÄÅÅÐò·½·¨ÒÔ¼°ÐÔÄÜ·ÖÎö¹¦ÄÜ¡£
   Utilities.cs°üÀ¨Swap½Ó¿Ú£¨ÓÃÓÚ½»»»Á½¸öÊý¾Ý£¬ÓÃÓÚ¿ìÅÅ£©£¬checkSum½Ó¿Ú£¨ÓÃÓÚ¼ìÑéÊý×éÖÐµÄÒ»²¿·ÖÊý¾ÝºÍÊÇ·ñÕýÈ·£©ºÍassert½Ó¿Ú£¨Debug.AssertµÍÅä£¬½ö¼ì²éÏàÓ¦Ìõ¼þÕýÈ·£©¡£
   SerialSortBase.csÎªËùÓÐÅÅÐòÀàµÄ»ùÀà£¬ÒÔÏÂÏêÏ¸ÃèÊöÆä¹¦ÄÜ¡£
2.2.1 »ù±¾³ÉÔ±
    protected int[] _data ´æ·ÅÒªÅÅÐòµÄÊý¾Ý¡£
    protected int[] _shared ×÷ÎªÅÅÐòÊý¾ÝµÄ±¸ÓÃÄÚ´æ¡£ÓÉÓÚ¹é²¢ÅÅÐòÔÚ¹é²¢²½ÖèÖÐÐèÒª¶îÍâµÄ¿Õ¼ä´æ·ÅÔªËØ£¬ËùÒÔÊ¹ÓÃÒ»¸öÓëÔ­Êý¾ÝµÇ³¡µÄÊý×éÀ´µ±ÖÐ¼ä¿Õ¼ä£¬±ÜÃâÖØ¸´ÉêÇëÊÍ·Å¿Õ¼äÔì³ÉµÄÐÔÄÜËðÊ§¡£
    protected Random _r ÅÅÐòÓÃµ½µÄËæ»úÊý·¢ÉúÆ÷£¬ÓÃÀ´¶Ô¿ìÅÅ½øÐÐËæ»ú»¯¡£
    protected int _length ¼ÇÂ¼ÅÅÐòÊý¾ÝµÄ³¤¶È¡£
    protected const int _insertionSortThreshold = 12  ¿ìÅÅÓÅ»¯ÖÐÊ¹ÓÃµÄ³£Êý¡£
    protected delegate double Sorter(int left,int right) ÓÃÓÚ¼ÆÊ±·ÖÎöÐÔÄÜµÄÎ¯ÍÐº¯Êý£¨º¯ÊýÖ¸Õë£©
    protected Sorter _sorter ¸ÃÎ¯ÍÐµÄÊµÀý»¯
2.2.2 ¹¦ÄÜº¯Êý
    ¹¹Ôìº¯Êý£ºÐèÒªÃ÷È·¸ø³ödata£¬ÓÃ¸ÃÊý¾Ý×÷Îª½«ÒªÅÅÐòµÄÊý¾Ý¡£
    int _partition(int left,int right) : ¿ìÅÅÖÐÓÃµ½µÄ·Ö¸îº¯Êý£¬½«Ò»¶ÎÊý¾Ý·ÖÎªÁ½¶Î£¬Ò»¶Î±ÈpivotÐ¡£¬Ò»¶Î±Èpivot´ó£¬·µ»ØpivotËùÔÚÎ»ÖÃ¡£
    void _quickSort(int left,int right) : ¿ìÅÅ¡£
    int _randomizedPartition(int left,int right) : Ëæ»ú»®·Ö£¬_partitionµÄËæ»ú»¯°æ±¾¡£
    void _randomizedQuicksort(int left,int right) : Ëæ»ú¿ìÅÅ¡£
    void _improvedQuicksort(int left,int right,bool randomized=true) : ¸öÈËÊµÏÖµÄ¶Ô¿ìÅÅµÄ¸Ä½ø¡£
    bool _inOrder(int left,int right, bool _increase=true) : ¼ì²é_dataÊÇ·ñÒÑÕýÐò£¨»òÄæÐò£©ÅÅºÃ¡£
    void _insertionSort(int left,int right) : ²åÈëÅÅÐò£¬¸Ä½ø¿ìÅÅÓÃµ½µÄ×Óº¯Êý¡£
    void _mergeSort(int left,int right) : ¹é²¢ÅÅÐò¡£
    void _sizePerformanceAnalyzer(int testScale=30000,int testRound=100,bool checkOrder=true): ÐÔÄÜ·ÖÎö¹¤¾ßÖ®Ò»£¬¶ÔÅÅÐò·½·¨ÔÚ¸ø¶¨Êý¾Ý¹æÄ££¨testScale£©ÏÂ½øÐÐtestRound»ØºÏºóµÄÆ½¾ùºÄÊ±½øÐÐ·ÖÎö²¢Êä³ö½á¹ûµ½ÃüÁîÐÐ¡£ÈôcheckOrderÎªtrue£¬ÔòÅÅÐòºó»¹½øÐÐÅÅÐò½á¹ûÕýÈ·ÐÔµÄ¼ì²é¡£
    void _performanceAnalyzer(int testRound=100,bool checkOrder=true) £ºÐÔÄÜ·ÖÎö¹¤¾ßÖ®Ò»£¬¶ÔÅÅÐò·½·¨ÔÚ¸ø¶¨Êý¾Ý¼¯(_data)ÏÂ½øÐÐtestRound»ØºÏºóµÄÆ½¾ùºÄÊ±½øÐÐ·ÖÎö²¢Êä³ö½á¹ûµ½ÃüÁîÐÐ¡£ÈôcheckOrderÎªtrue£¬ÔòÔÚÃ¿»ØºÏÅÅÐòºó»¹½øÐÐÅÅÐò½á¹ûÕýÈ·ÐÔµÄ¼ì²é¡£
    void _sortAndRecord(string fileName) : ½øÐÐÅÅÐò²¢½«½á¹ûÊä³öµ½Ö¸¶¨ÎÄ¼þÖÐ¡£

2.3 ´®ÐÐÅÅÐò
    ´®ÐÐÅÅÐòÊµÏÖ´úÂëÎÄ¼þÎ»ÓÚÎÄ¼þ¼ÐSerialSortMethodsÏÂ£¬ÆäÖÐ°üÀ¨ËÄ¸öÀàÎÄ¼þLibrarySort.cs£¬SerialEnumerationSort.cs£¬SerialMergesort.cs£¬SerialQuicksort.cs£¬¶¼¼Ì³Ð×Ô»ùÀàSerialSortBase¡£LibrarySortÎª±ê×¼¿âÊµÏÖ£¨Array.Sort£©£¬ÆäËû·Ö±ðÎª´®ÐÐÃ¶¾ÙÅÅÐò¡¢´®ÐÐ¹é²¢ÅÅÐòºÍ´®ÐÐ¿ìÅÅ¡£Æä¶¼Ö§³ÖÍ³Ò»½Ó¿ÚsortMethodName(bool record=false, string fileName='...')£¨ÓÃÓÚ¼ÇÂ¼ÅÅÐò½á¹û£©£¬PerformanceAnalyzer£¨¸ø¶¨Êý¾Ý¼¯ÉÏµÄÐÔÄÜ£©ºÍSizePerformanceAnalyzer£¨¸ø¶¨Êý¾Ý¹æÄ£Ê±µÄÐÔÄÜ£©¡£

2.4 ²¢ÐÐÅÅÐò
    ²¢ÐÐÅÅÐòÊµÏÖ´úÂëÎÄ¼þÎ»ÓÚÎÄ¼þ¼ÐParallelSortMethodsÏÂ£¬ÆäÖÐ°üÀ¨ËÄ¸öÀàÎÄ¼þParallelEnumerationSort.cs£¬ParallelMergesort.csºÍParalellQuicksort.cs£¬¶¼¼Ì³Ð×Ô»ùÀàSerialSortBase¡£ÆäÖ§³ÖºÍÉÏÊö´®ÐÐÅÅÐòÀàËÆµÄ½Ó¿Ú¡£¾ßÌåÊ¹ÓÃÊµÀý¿É²ÎÕÕProgram.csÖÐµÄÈý¸öº¯Êý¡£

2.5 Êý¾ÝÎÄ¼þ
    Î»ÓÚDataFilesÎÄ¼þ¼ÐÏÂ¡£´ËÏîÄ¿µÄÊä³ö½á¹ûÎÄ¼þ¼´´ÓDataFilesÏÂÖ±½Ó¿½±´¹ýÈ¥µÄ¡£


# 3. ÆäËû
    parallelComputingProject/parallelComputingProject/bin/Debug/paralelComputingProject.exeÎªÄ¿Ç°µÄ¿ÉÖ´ÐÐÎÄ¼þ£¬¿ÉÍ¨¹ýÔËÐÐÖ®½øÐÐÊý¾Ý¼ÇÂ¼¡¢ÔÚ¸ÃÊý¾Ý¼¯ÉÏµÄÐÔÄÜ·ÖÎöÒÔ¼°ÔÚ¸ø¶¨Êý¾Ý¼¯¹æÄ£ÏÂµÄÐÔÄÜ·ÖÎö¡£
    Èç¹ûÓÐÆäËûÔËÐÐ·½ÃæµÄÎÊÌâ£¬ÇëÍ¨¹ýµç×ÓÓÊÏäÁªÏµ¡£
=======
Authorï¼šæŽå¥¡ç¨‹ Timeï¼š2018-12-30 Emailï¼š161220062@smail.nju.edu.cn


è¿™æ˜¯å…³äºŽæˆ‘çš„å¹¶è¡Œè®¡ç®—é¡¹ç›®çš„ç›¸å…³æ–‡ä»¶çš„è¯´æ˜Žæ–‡æ¡£ã€‚å…¶å®žçŽ°äº†å½’å¹¶æŽ’åºã€å¿«é€ŸæŽ’åºå’Œæžšä¸¾æŽ’åºçš„ä¸²è¡Œå’Œå¹¶è¡Œç‰ˆæœ¬ä»¥åŠç›¸åº”çš„æ€§èƒ½åˆ†æžã€‚


# 1. æ–‡ä»¶å¤¹ç»“æž„ç»¼è¿°
    æ–‡ä»¶å¤¹ä¸‹åŒ…æ‹¬åŽŸå§‹æ•°æ®random.txtï¼Œè¯´æ˜Žæ–‡æ¡£ReadMe.txtï¼Œå®žéªŒæŠ¥å‘Šreport.pdfï¼Œç›¸å…³çš„è¾“å‡ºæ–‡ä»¶order*.txtï¼Œä»£ç è¿è¡Œç»“æžœæˆªå›¾æ–‡ä»¶å¤¹images/ï¼Œå®žéªŒæŠ¥å‘ŠLatexæºç æ–‡ä»¶å¤¹ReportTex/å’Œæºä»£ç æ–‡ä»¶å¤¹parallelComputingProject/ã€‚


# 2. ä»£ç è¿è¡Œ&åŸºæœ¬æè¿°
    æœ¬é¡¹ç›®ç”¨c#è¯­è¨€ç¼–å†™ï¼Œè¿è¡ŒçŽ¯å¢ƒä¸ºwin10å’ŒVisual Studio 2013ã€‚å¦‚æžœæ”¯æŒä¸Šè¿°çŽ¯å¢ƒï¼Œåˆ™ç”¨VSä¸­æ‰“å¼€é¡¹ç›®æ–‡ä»¶parallelComputingProject.slnï¼Œåœ¨IDEä¸­é€‰æ‹©è°ƒè¯•->å¼€å§‹æ‰§è¡Œå³å¯è¿è¡Œã€‚å…¶ä¸­ç›¸å…³çš„ä»£ç ä½äºŽparallelComputingProject/parallelComputingProjectæ–‡ä»¶å¤¹ä¸‹ã€‚

2.1 ä¸»å‡½æ•°
    è¯¥æ–‡ä»¶å¤¹ä¸‹çš„Program.csä¸ºç¨‹åºå…¥å£ï¼Œå¯åœ¨å…¶ä¸­æ”¹åŠ¨mainå‡½æ•°çš„å†…å®¹è¿›è¡Œä¸åŒçš„è¿ç®—ï¼Œå…¶ä¸­æœ‰ä¸‰ä¸ªå‡½æ•°ï¼š
    (1) WriteData() : è¯»å…¥random.txtä¸­çš„æ•°æ®ï¼Œç”¨6ç§ä¸åŒçš„æŽ’åºæ–¹æ³•åˆ†åˆ«æŽ’åºï¼Œå¹¶å°†ç»“æžœè¾“å‡ºè‡³DataFilesä¸‹çš„order*.txtæ–‡ä»¶ä¸­ã€‚
    (2) AnalyzePerformance() : è¯»å…¥random.txtä¸­çš„æ•°æ®ï¼Œç”¨6ä¸­ä¸åŒçš„æŽ’åºæ–¹æ³•åˆ†åˆ«æŽ’åºï¼Œå¹¶ç»Ÿè®¡å…¶åœ¨è¯¥æ•°æ®é›†ä¸Šè‹¥å¹²æ¬¡åŽçš„å¹³å‡æ—¶é•¿ï¼ˆæ¬¡æ•°å¯é€šè¿‡ä¿®æ”¹ç›¸åº”ä»£ç è°ƒæ•´ï¼›å› ä¸ºï¼‰ã€‚
    (3) SizeAnalyzePerformance(int testScale=100000,int testRound=10) : æµ‹è¯•ä¸²è¡Œå’Œå¹¶è¡Œçš„å¿«æŽ’å’Œå½’å¹¶æŽ’åºåœ¨ç»™å®šæ•°æ®é›†å¤§å°çš„æƒ…å†µä¸‹è‹¥å¹²æ¬¡çš„å¹³å‡æ—¶é•¿ã€‚

2.2 åŸºç±»åŠå…¶è¾…åŠ©åŠŸèƒ½
   Utilitiesæ–‡ä»¶å¤¹ä¸‹åŒ…æ‹¬SerialSortBase.cså’ŒUtilities.csä¸¤ä¸ªç±»æ–‡ä»¶ï¼Œå®žçŽ°ç›¸åº”å¸¸ç”¨çš„åº“å‡½æ•°ã€åŸºæœ¬çš„æŽ’åºæ–¹æ³•ä»¥åŠæ€§èƒ½åˆ†æžåŠŸèƒ½ã€‚
   Utilities.csåŒ…æ‹¬SwapæŽ¥å£ï¼ˆç”¨äºŽäº¤æ¢ä¸¤ä¸ªæ•°æ®ï¼Œç”¨äºŽå¿«æŽ’ï¼‰ï¼ŒcheckSumæŽ¥å£ï¼ˆç”¨äºŽæ£€éªŒæ•°ç»„ä¸­çš„ä¸€éƒ¨åˆ†æ•°æ®å’Œæ˜¯å¦æ­£ç¡®ï¼‰å’ŒassertæŽ¥å£ï¼ˆDebug.Assertä½Žé…ï¼Œä»…æ£€æŸ¥ç›¸åº”æ¡ä»¶æ­£ç¡®ï¼‰ã€‚
   SerialSortBase.csä¸ºæ‰€æœ‰æŽ’åºç±»çš„åŸºç±»ï¼Œä»¥ä¸‹è¯¦ç»†æè¿°å…¶åŠŸèƒ½ã€‚
2.2.1 åŸºæœ¬æˆå‘˜
    protected int[] _data å­˜æ”¾è¦æŽ’åºçš„æ•°æ®ã€‚
    protected int[] _shared ä½œä¸ºæŽ’åºæ•°æ®çš„å¤‡ç”¨å†…å­˜ã€‚ç”±äºŽå½’å¹¶æŽ’åºåœ¨å½’å¹¶æ­¥éª¤ä¸­éœ€è¦é¢å¤–çš„ç©ºé—´å­˜æ”¾å…ƒç´ ï¼Œæ‰€ä»¥ä½¿ç”¨ä¸€ä¸ªä¸ŽåŽŸæ•°æ®ç™»åœºçš„æ•°ç»„æ¥å½“ä¸­é—´ç©ºé—´ï¼Œé¿å…é‡å¤ç”³è¯·é‡Šæ”¾ç©ºé—´é€ æˆçš„æ€§èƒ½æŸå¤±ã€‚
    protected Random _r æŽ’åºç”¨åˆ°çš„éšæœºæ•°å‘ç”Ÿå™¨ï¼Œç”¨æ¥å¯¹å¿«æŽ’è¿›è¡ŒéšæœºåŒ–ã€‚
    protected int _length è®°å½•æŽ’åºæ•°æ®çš„é•¿åº¦ã€‚
    protected const int _insertionSortThreshold = 12  å¿«æŽ’ä¼˜åŒ–ä¸­ä½¿ç”¨çš„å¸¸æ•°ã€‚
    protected delegate double Sorter(int left,int right) ç”¨äºŽè®¡æ—¶åˆ†æžæ€§èƒ½çš„å§”æ‰˜å‡½æ•°ï¼ˆå‡½æ•°æŒ‡é’ˆï¼‰
    protected Sorter _sorter è¯¥å§”æ‰˜çš„å®žä¾‹åŒ–
2.2.2 åŠŸèƒ½å‡½æ•°
    æž„é€ å‡½æ•°ï¼šéœ€è¦æ˜Žç¡®ç»™å‡ºdataï¼Œç”¨è¯¥æ•°æ®ä½œä¸ºå°†è¦æŽ’åºçš„æ•°æ®ã€‚
    int _partition(int left,int right) : å¿«æŽ’ä¸­ç”¨åˆ°çš„åˆ†å‰²å‡½æ•°ï¼Œå°†ä¸€æ®µæ•°æ®åˆ†ä¸ºä¸¤æ®µï¼Œä¸€æ®µæ¯”pivotå°ï¼Œä¸€æ®µæ¯”pivotå¤§ï¼Œè¿”å›žpivotæ‰€åœ¨ä½ç½®ã€‚
    void _quickSort(int left,int right) : å¿«æŽ’ã€‚
    int _randomizedPartition(int left,int right) : éšæœºåˆ’åˆ†ï¼Œ_partitionçš„éšæœºåŒ–ç‰ˆæœ¬ã€‚
    void _randomizedQuicksort(int left,int right) : éšæœºå¿«æŽ’ã€‚
    void _improvedQuicksort(int left,int right,bool randomized=true) : ä¸ªäººå®žçŽ°çš„å¯¹å¿«æŽ’çš„æ”¹è¿›ã€‚
    bool _inOrder(int left,int right, bool _increase=true) : æ£€æŸ¥_dataæ˜¯å¦å·²æ­£åºï¼ˆæˆ–é€†åºï¼‰æŽ’å¥½ã€‚
    void _insertionSort(int left,int right) : æ’å…¥æŽ’åºï¼Œæ”¹è¿›å¿«æŽ’ç”¨åˆ°çš„å­å‡½æ•°ã€‚
    void _mergeSort(int left,int right) : å½’å¹¶æŽ’åºã€‚
    void _sizePerformanceAnalyzer(int testScale=30000,int testRound=100,bool checkOrder=true): æ€§èƒ½åˆ†æžå·¥å…·ä¹‹ä¸€ï¼Œå¯¹æŽ’åºæ–¹æ³•åœ¨ç»™å®šæ•°æ®è§„æ¨¡ï¼ˆtestScaleï¼‰ä¸‹è¿›è¡ŒtestRoundå›žåˆåŽçš„å¹³å‡è€—æ—¶è¿›è¡Œåˆ†æžå¹¶è¾“å‡ºç»“æžœåˆ°å‘½ä»¤è¡Œã€‚è‹¥checkOrderä¸ºtrueï¼Œåˆ™æŽ’åºåŽè¿˜è¿›è¡ŒæŽ’åºç»“æžœæ­£ç¡®æ€§çš„æ£€æŸ¥ã€‚
    void _performanceAnalyzer(int testRound=100,bool checkOrder=true) ï¼šæ€§èƒ½åˆ†æžå·¥å…·ä¹‹ä¸€ï¼Œå¯¹æŽ’åºæ–¹æ³•åœ¨ç»™å®šæ•°æ®é›†(_data)ä¸‹è¿›è¡ŒtestRoundå›žåˆåŽçš„å¹³å‡è€—æ—¶è¿›è¡Œåˆ†æžå¹¶è¾“å‡ºç»“æžœåˆ°å‘½ä»¤è¡Œã€‚è‹¥checkOrderä¸ºtrueï¼Œåˆ™åœ¨æ¯å›žåˆæŽ’åºåŽè¿˜è¿›è¡ŒæŽ’åºç»“æžœæ­£ç¡®æ€§çš„æ£€æŸ¥ã€‚
    void _sortAndRecord(string fileName) : è¿›è¡ŒæŽ’åºå¹¶å°†ç»“æžœè¾“å‡ºåˆ°æŒ‡å®šæ–‡ä»¶ä¸­ã€‚

2.3 ä¸²è¡ŒæŽ’åº
    ä¸²è¡ŒæŽ’åºå®žçŽ°ä»£ç æ–‡ä»¶ä½äºŽæ–‡ä»¶å¤¹SerialSortMethodsä¸‹ï¼Œå…¶ä¸­åŒ…æ‹¬å››ä¸ªç±»æ–‡ä»¶LibrarySort.csï¼ŒSerialEnumerationSort.csï¼ŒSerialMergesort.csï¼ŒSerialQuicksort.csï¼Œéƒ½ç»§æ‰¿è‡ªåŸºç±»SerialSortBaseã€‚LibrarySortä¸ºæ ‡å‡†åº“å®žçŽ°ï¼ˆArray.Sortï¼‰ï¼Œå…¶ä»–åˆ†åˆ«ä¸ºä¸²è¡Œæžšä¸¾æŽ’åºã€ä¸²è¡Œå½’å¹¶æŽ’åºå’Œä¸²è¡Œå¿«æŽ’ã€‚å…¶éƒ½æ”¯æŒç»Ÿä¸€æŽ¥å£sortMethodName(bool record=false, string fileName='...')ï¼ˆç”¨äºŽè®°å½•æŽ’åºç»“æžœï¼‰ï¼ŒPerformanceAnalyzerï¼ˆç»™å®šæ•°æ®é›†ä¸Šçš„æ€§èƒ½ï¼‰å’ŒSizePerformanceAnalyzerï¼ˆç»™å®šæ•°æ®è§„æ¨¡æ—¶çš„æ€§èƒ½ï¼‰ã€‚

2.4 å¹¶è¡ŒæŽ’åº
    å¹¶è¡ŒæŽ’åºå®žçŽ°ä»£ç æ–‡ä»¶ä½äºŽæ–‡ä»¶å¤¹ParallelSortMethodsä¸‹ï¼Œå…¶ä¸­åŒ…æ‹¬å››ä¸ªç±»æ–‡ä»¶ParallelEnumerationSort.csï¼ŒParallelMergesort.cså’ŒParalellQuicksort.csï¼Œéƒ½ç»§æ‰¿è‡ªåŸºç±»SerialSortBaseã€‚å…¶æ”¯æŒå’Œä¸Šè¿°ä¸²è¡ŒæŽ’åºç±»ä¼¼çš„æŽ¥å£ã€‚å…·ä½“ä½¿ç”¨å®žä¾‹å¯å‚ç…§Program.csä¸­çš„ä¸‰ä¸ªå‡½æ•°ã€‚

2.5 æ•°æ®æ–‡ä»¶
    ä½äºŽDataFilesæ–‡ä»¶å¤¹ä¸‹ã€‚æ­¤é¡¹ç›®çš„è¾“å‡ºç»“æžœæ–‡ä»¶å³ä»ŽDataFilesä¸‹ç›´æŽ¥æ‹·è´è¿‡åŽ»çš„ã€‚


# 3. å…¶ä»–
    parallelComputingProject/parallelComputingProject/bin/Debug/paralelComputingProject.exeä¸ºç›®å‰çš„å¯æ‰§è¡Œæ–‡ä»¶ï¼Œå¯é€šè¿‡è¿è¡Œä¹‹è¿›è¡Œæ•°æ®è®°å½•ã€åœ¨è¯¥æ•°æ®é›†ä¸Šçš„æ€§èƒ½åˆ†æžä»¥åŠåœ¨ç»™å®šæ•°æ®é›†è§„æ¨¡ä¸‹çš„æ€§èƒ½åˆ†æžã€‚
    å¦‚æžœæœ‰å…¶ä»–è¿è¡Œæ–¹é¢çš„é—®é¢˜ï¼Œè¯·é€šè¿‡ç”µå­é‚®ç®±è”ç³»ã€‚
>>>>>>> 0e1f8cc967e8add66bf4cb7524e02fa535acc0a0:ReadMe.txt
