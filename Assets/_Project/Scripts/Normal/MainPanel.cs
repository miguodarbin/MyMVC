using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    //1.关联组件
    //2.为组件添加事件回调
    //3.更新数据
    //4.显隐

    //————————————————————————————————————————
    //1.关联组件
    public TMP_Text playerName;
    public TMP_Text playerLevel;
    public TMP_Text currencyCount;
    public TMP_Text diamondCount;
    public TMP_Text powerCount;

    public Button roleButton;

    private static MainPanel instance;

    public static MainPanel Instance
    {
        get { return instance; }
    }

    //————————————————————————————————————————
    //2.为组件添加事件回调

    private void OnEnable()
    {
        roleButton.onClick.AddListener(OnRoleButtonClick);
    }

    private void OnDisable()
    {
        roleButton.onClick.RemoveListener(OnRoleButtonClick);
    }


    private void OnRoleButtonClick()
    {
        RolePanel.ShowMe();
    }

    //————————————————————————————————————————
    //3.更新信息
    public void UpdateInfo()
    {
        playerName.text = PlayerPrefs.GetString("PlayerName", "唐老狮");
        playerLevel.text = "LV." + PlayerPrefs.GetInt("PlayerLevel", 1).ToString();
        currencyCount.text = PlayerPrefs.GetInt("CurrencyCount", 999).ToString();
        diamondCount.text = PlayerPrefs.GetInt("DiamondCount", 888).ToString();
        powerCount.text = PlayerPrefs.GetInt("PowerCount", 10).ToString();
    }

    //————————————————————————————————————————
    //4.显隐
    public static void ShowMe()
    {
        if (instance == null)
        {
            var mainPanelBluePrint = Resources.Load<GameObject>("MyUI/MyMainPanel");
            var canvas = GameObject.Find("Canvas");
            if (mainPanelBluePrint == null && canvas == null)
            {
                Debug.Log("缺少 canvas 或者 UI");
                return;
            }

            var mainPanel = Instantiate(mainPanelBluePrint, canvas.transform);
            instance = mainPanel.GetComponent<MainPanel>();
        }

        instance.gameObject.SetActive(true);
        //每次触发 ShowMe 都会更新数据
        MainPanel.instance.UpdateInfo();
    }

    public static void HideMe()
    {
        //删除
        // if (instance != null)
        // {
        //     Debug.Log("n");
        //     Destroy(instance.gameObject);
        //     instance = null;
        //     
        // }

        //隐藏

        if (instance != null && instance.gameObject.activeInHierarchy == true)
        {
            instance.gameObject.SetActive(false);
        }
    }
}