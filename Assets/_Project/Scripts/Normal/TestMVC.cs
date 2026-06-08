using UnityEngine;

public class TestMVC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.OpenPanel(PanelName.MainPanel);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ClosePanel(PanelName.MainPanel);
        }
    }
}
