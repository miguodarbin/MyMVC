using UnityEngine;
using UnityEngine.Events;

//1.这是一个玩家数据 model 类
public class PlayerDataModel
{
    //1.他要定义负责哪些数据
    //2.数据从哪来，初始化
    //3.这些数据有哪些规则
    //4.数据改了通知外部
    //5.不需要继承 mono，因为不需要 Unity API,保证数据的唯一性，用单例

    private event UnityAction<PlayerDataModel> onDataChanged;

    //5.不需要继承 mono，因为不需要 Unity API,保证数据的唯一性，用单例
    private static PlayerDataModel _instance = new PlayerDataModel();

    public static PlayerDataModel Instance
    {
        get { return _instance; }
    }

    private PlayerDataModel()
    {
        Init();
    }


    //1.定义负责哪些数据
    private string playerName;

    public string PlayerName
    {
        get { return playerName; }
    }

    private int _playerLevel;

    public int PlayerLevel
    {
        get { return _playerLevel; }
    }

    private int _currencyCount;

    public int CurrencyCount
    {
        get { return _currencyCount; }
    }

    private int _diamondCount;

    public int DiamondCount
    {
        get { return _diamondCount; }
    }

    private int _powerCount;

    public int PowerCount
    {
        get { return _powerCount; }
    }

    private int _hp;

    public int HP
    {
        get { return _hp; }
    }

    private int _atk;

    public int Atk
    {
        get { return _atk; }
    }

    private int _def;

    public int Def
    {
        get { return _def; }
    }

    private int _baoJi;

    public int BaoJi
    {
        get { return _baoJi; }
    }

    private int _shanBi;

    public int ShanBi
    {
        get { return _shanBi; }
    }

    private int _xinYun;

    public int XinYun
    {
        get { return _xinYun; }
    }


    //2.数据从哪来，初始化
    private void Init()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "唐老狮");
        _playerLevel = PlayerPrefs.GetInt("Level", 1);
        _currencyCount = PlayerPrefs.GetInt("Currency", 999);
        _diamondCount = PlayerPrefs.GetInt("Diamond", 888);
        _powerCount = PlayerPrefs.GetInt("Power", 10);
        _hp = PlayerPrefs.GetInt("HP", 100);
        _atk = PlayerPrefs.GetInt("Atk", 100);
        _def = PlayerPrefs.GetInt("Def", 100);
        _baoJi = PlayerPrefs.GetInt("BaoJi", 100);
        _shanBi = PlayerPrefs.GetInt("ShanBi", 100);
        _xinYun = PlayerPrefs.GetInt("XinYun", 100);
        SaveData();
    }

    //3.这些数据有哪些规则（所以叫做 Model，不叫做 Data）
    //3.1数据的升级规则
    public void LevelUp()
    {
        _playerLevel++;
        _hp += _playerLevel;
        _atk += _playerLevel;
        _def += _playerLevel;
        _baoJi += _playerLevel;
        _shanBi += _playerLevel;
        _xinYun += _playerLevel;
        SaveData();
        BroadcastDataChanged();
    }

    //3.2数据的保存规则
    private void SaveData()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("Level", _playerLevel);
        PlayerPrefs.SetInt("Currency", _currencyCount);
        PlayerPrefs.SetInt("Diamond", _diamondCount);
        PlayerPrefs.SetInt("Power", _powerCount);
        PlayerPrefs.SetInt("HP", _hp);
        PlayerPrefs.SetInt("Atk", _atk);
        PlayerPrefs.SetInt("Def", _def);
        PlayerPrefs.SetInt("BaoJi", _baoJi);
        PlayerPrefs.SetInt("ShanBi", _shanBi);
        PlayerPrefs.SetInt("XinYun", _xinYun);
    }

    //3.3数据的清空规则
    private void ClearData()
    {
        _playerLevel = 1;
        _currencyCount = 999;
        _diamondCount = 888;
        _powerCount = 10;
        _hp = 100;
        _atk = 100;
        _def = 100;
        _baoJi = 100;
        _shanBi = 100;
        _xinYun = 100;
        SaveData();
        BroadcastDataChanged();
    }

    //4.外部可以在这个订阅入口订阅，一旦自己数据有改变，就会通知外部，把自己做为消息传出去 TODO：这里还不确定在哪里发布通知？不过先定义一个通知吧
    public void AddListener(UnityAction<PlayerDataModel> function)
    {
        onDataChanged += function;
    }

    public void RemoveListener(UnityAction<PlayerDataModel> function)
    {
        onDataChanged -= function;
    }

    private void BroadcastDataChanged()
    {
        if (this.onDataChanged != null)
        {
            onDataChanged.Invoke(this);
        }
    }
}