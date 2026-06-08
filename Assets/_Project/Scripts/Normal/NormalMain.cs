using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMain : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainPanel.ShowMe();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            MainPanel.HideMe();
        }
    }
}
