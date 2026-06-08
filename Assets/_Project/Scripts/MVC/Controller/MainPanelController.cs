using UnityEngine;

[RequireComponent(typeof(MainPanelView))]
public class MainPanelController : MonoBehaviour
{
    private PlayerDataModel _playerDataModel;
    private MainPanelView _mainPanelView;

    private void Awake()
    {
        _mainPanelView = GetComponent<MainPanelView>();
        _playerDataModel = PlayerDataModel.Instance;
    }

    private void OnEnable()
    {
        _playerDataModel.AddListener(OnPlayerDataChanged);
        _mainPanelView.roleButton.onClick.AddListener(OnRoleButtonClicked);
        _mainPanelView.skillButton.onClick.AddListener(OnSkillButtonClicked);

        _mainPanelView.RefreshUIData(_playerDataModel);
    }

    private void OnDisable()
    {
        _playerDataModel.RemoveListener(OnPlayerDataChanged);

        _mainPanelView.roleButton.onClick.RemoveListener(OnRoleButtonClicked);
        _mainPanelView.skillButton.onClick.RemoveListener(OnSkillButtonClicked);
    }

    private void OnPlayerDataChanged(PlayerDataModel playerDataModel)
    {
        _mainPanelView.RefreshUIData(playerDataModel);
    }

    private void OnRoleButtonClicked()
    {
        UIManager.Instance.OpenPanel(PanelName.RolePanel);
    }

    private void OnSkillButtonClicked()
    {
        Debug.Log("OnSkillButtonClicked");
    }
}