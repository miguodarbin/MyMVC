using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanelView : MonoBehaviour
{
    //1.持有 UI 控件实例，方便实现任何 UI 表现
    //2.更新 UI 表现（需要传入数据）
    
    public TMP_Text playerName;
    public TMP_Text playerLevel;
    public TMP_Text currencyCount;
    public TMP_Text diamondCount;
    public TMP_Text powerCount;

    public Button roleButton;
    public Button skillButton; 

    public void RefreshUIData(PlayerDataModel playerDataModel)
    {
        playerName.text = playerDataModel.PlayerName;
        playerLevel.text = playerDataModel.PlayerLevel.ToString();
        currencyCount.text = playerDataModel.CurrencyCount.ToString();
        diamondCount.text = playerDataModel.DiamondCount.ToString();
        powerCount.text = playerDataModel.PowerCount.ToString();
    }
}
