using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private Dictionary<string, GameObject> _panels = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

   
    public Canvas mainCanvas;

    public void OpenPanel(string panelName)
    {
        var panel = GetOrCreatePanel(panelName);
        if (panel == null)
        {
            Debug.LogError($"Can't find ");
            return;
        }

        panel.SetActive(true);
    }

    public void ClosePanel(string panelName)
    {
        if (_panels.ContainsKey(panelName))
        {
            _panels[panelName].SetActive(false);
        }
        else
        {
            Debug.LogError($"Can't find");
        }
    }


    private GameObject GetOrCreatePanel(string name)
    {
        if (_panels.ContainsKey(name))
        {
            return _panels[name];
        }

        var prefab = Resources.Load<GameObject>("MyUI/" + name);
        if (prefab == null)
        {
            Debug.LogError($"Can't find");
            return null;
        }

        if (mainCanvas == null)
        {
            Debug.LogError($"Can't find {nameof(mainCanvas)}");
            return null;
        }

        var panel = Instantiate(prefab, mainCanvas.transform);
        _panels.Add(name, panel);
        return panel;
    }

    private void OnDestroy()
    {
        if (Instance != this)
        {
            return;
        }

        Instance = null;
    }
}