using UnityEngine;

[RequireComponent(typeof(RolePanelView))]
public class RolePaneController : MonoBehaviour
{
    private PlayerDataModel _playerDataModel;
    private RolePanelView _rolePanelView;

    private void Awake()
    {
        _rolePanelView = GetComponent<RolePanelView>();
        _playerDataModel = PlayerDataModel.Instance;
    }

    private void OnEnable()
    {
        _playerDataModel.AddListener(OnPlayerDataChanged);
        _rolePanelView.closeButton.onClick.AddListener(OnCloseButtonClicked);
        _rolePanelView.levelUpButton.onClick.AddListener(OnLevelUpButtonClicked);

        _rolePanelView.RefreshUIData(_playerDataModel);
    }

    private void OnDisable()
    {
        _playerDataModel.RemoveListener(OnPlayerDataChanged);
        _rolePanelView.closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        _rolePanelView.levelUpButton.onClick.RemoveListener(OnLevelUpButtonClicked);
    }

    private void OnPlayerDataChanged(PlayerDataModel playerDataModel)
    {
        _rolePanelView.RefreshUIData(playerDataModel);
    }

    private void OnCloseButtonClicked()
    {
        UIManager.Instance.ClosePanel(PanelName.RolePanel);
    }

    private void OnLevelUpButtonClicked()
    {
        _playerDataModel.LevelUp();
    }
}