using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    private static RolePanel instance;
    //1. 获取控件
    //2. 添加逻辑回调
    //3. 更新信息
    //4. 设置显隐


    //————————————————————————————————————————
    //1.关联组件
    public Button closeButton;
    public Button levelUpButton;
    public TMP_Text levelText;
    public TMP_Text hpText;
    public TMP_Text atkText;
    public TMP_Text defText;
    public TMP_Text baoJiText;
    public TMP_Text shanBiText;
    public TMP_Text xinYunText;

    //————————————————————————————————————————
    //2.添加逻辑回调
    private void OnEnable()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
        levelUpButton.onClick.AddListener(OnClickLevelUpButton);
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveAllListeners();
        levelUpButton.onClick.RemoveAllListeners();
    }

    public void OnClickCloseButton()
    {
        HideMe();
    }

    public void OnClickLevelUpButton()
    {
        //1.要更新哪些数据？=》PlayerPrefs 的数据
        //2.怎么更新？=》Set 方法，设置新的值，新的值等于旧的值加 level
        //3.数据更新完，UI 也要同步=》UpdateInfo

        //1.更新哪些数据？要先得到老的数据，才能更新新的数据
        int currentLevel = PlayerPrefs.GetInt("PlayerLevel", 1);
        int currentHP = PlayerPrefs.GetInt("HP", 100);
        int currentATK = PlayerPrefs.GetInt("ATK", 100);
        int currentDEF = PlayerPrefs.GetInt("DEF", 100);
        int currentBaoJi = PlayerPrefs.GetInt("BaoJi", 100);
        int currentShanBi = PlayerPrefs.GetInt("ShanBi", 100);
        int currentXinYun = PlayerPrefs.GetInt("XinYun", 100);

        //2.怎么更新？
        int newlevel = currentLevel + 1;
        PlayerPrefs.SetInt("PlayerLevel", newlevel);
        PlayerPrefs.SetInt("HP", currentHP + newlevel);
        PlayerPrefs.SetInt("ATK", currentATK + newlevel);
        PlayerPrefs.SetInt("DEF", currentDEF + newlevel);
        PlayerPrefs.SetInt("BaoJi", currentBaoJi + newlevel);
        PlayerPrefs.SetInt("ShanBi", currentShanBi + newlevel);
        PlayerPrefs.SetInt("XinYun", currentXinYun + newlevel);
        //PlayerPrefs.Save();
        
        //3.数据更新完，UI 也要同步
        UpdateInfo();
        MainPanel.Instance.UpdateInfo();
    }

    //————————————————————————————————————————
    //3. 更新信息
    private void UpdateInfo()
    {
        levelText.text = "LV." + PlayerPrefs.GetInt("PlayerLevel", 1).ToString();
        hpText.text = "血    量：" + PlayerPrefs.GetInt("HP", 100).ToString();
        atkText.text = "攻击力：" + PlayerPrefs.GetInt("ATK", 100).ToString();
        defText.text = "防御力：" + PlayerPrefs.GetInt("DEF", 100).ToString();
        baoJiText.text = "暴击率：" + PlayerPrefs.GetInt("BaoJi", 100).ToString();
        shanBiText.text = "闪避率：" + PlayerPrefs.GetInt("ShanBi", 100).ToString();
        xinYunText.text = "幸运值：" + PlayerPrefs.GetInt("XinYun", 100).ToString();
    }

    //————————————————————————————————————————
    //3. 设置显隐

    public static void ShowMe()
    {
        if (instance == null)
        {
            var rolePanelBluePrint = Resources.Load<GameObject>("MyUI/MyRolePanel");
            var canvas = GameObject.Find("Canvas");
            if (rolePanelBluePrint == null && canvas == null)
            {
                Debug.Log("缺少 canvas 或者 UI");
                return;
            }

            var rolePanel = Instantiate(rolePanelBluePrint, canvas.transform);
            instance = rolePanel.GetComponent<RolePanel>();
        }

        instance.gameObject.SetActive(true);
        //每次触发 ShowMe 都会更新数据
        RolePanel.instance.UpdateInfo();
    }

    public static void HideMe()
    {
        //隐藏

        if (instance != null && instance.gameObject.activeInHierarchy == true)
        {
            instance.gameObject.SetActive(false);
        }
    }
}