using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RolePanelView : MonoBehaviour
{
    public Button closeButton;
    public Button levelUpButton;
    public TMP_Text levelText;
    public TMP_Text hpText;
    public TMP_Text atkText;
    public TMP_Text defText;
    public TMP_Text baoJiText;
    public TMP_Text shanBiText;
    public TMP_Text xinYunText;

    public void RefreshUIData(PlayerDataModel playerDataModel)
    {
        levelText.text = "LV." + playerDataModel.PlayerLevel.ToString();
        hpText.text = "血    量：" + playerDataModel.HP.ToString();
        atkText.text = "攻击力：" + playerDataModel.Atk.ToString();
        defText.text = "防御力：" + playerDataModel.Def.ToString();
        baoJiText.text = "暴击率：" + playerDataModel.BaoJi.ToString();
        shanBiText.text = "闪避率：" + playerDataModel.ShanBi.ToString();
        xinYunText.text = "幸运值：" + playerDataModel.XinYun.ToString();
    }
}