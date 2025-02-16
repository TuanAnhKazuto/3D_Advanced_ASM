using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainBtnPanel;
    public GameObject settingPanel;
    public GameObject ctrlPanel;
    public GameObject campaignPanel;


    private void Start()
    {
        ShowMainBtn();
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    #region PanelType
    public enum PanelType
    {
        MainBtnPanel,
        SettingPanel,
        CampaignPanel,
        CtrlPanel
    }

    public void ShowPanel(PanelType panelType)
    {
        mainBtnPanel.SetActive(false);
        settingPanel.SetActive(false);
        campaignPanel.SetActive(false);
        ctrlPanel.SetActive(false);
        switch (panelType)
        {
            case PanelType.MainBtnPanel:
                mainBtnPanel.SetActive(true);
                settingPanel.SetActive(false);
                campaignPanel.SetActive(false);
                break;
            case PanelType.SettingPanel:
                settingPanel.SetActive(true);
                ctrlPanel.SetActive(false);
                break;
            case PanelType.CampaignPanel:
                campaignPanel.SetActive(true);
                break;
            case PanelType.CtrlPanel:
                settingPanel.SetActive(true);
                ctrlPanel.SetActive(true);
                break;
        }
    }
    private void ShowMainBtn()
    {
        ShowPanel(PanelType.MainBtnPanel);
    }

    private void ShowSetting()
    {
        ShowPanel(PanelType.SettingPanel);
    }

    private void ShowCampaign()
    {
        ShowPanel(PanelType.CampaignPanel);
    }

    private void ShowCtrl()
    {
        ShowPanel(PanelType.CtrlPanel);
    }
    #endregion

    public void BtnSetting()
    {
        ShowSetting();
    }

    public void BtnCtrl()
    {
        ShowCtrl();
    }

    public void BtnCampaign()
    {
        ShowCampaign();
    }

    public void BtnExitSetting()
    {
        ShowMainBtn();
    }
    public void BtnExitCtrl()
    {
        ShowSetting();
    }

    public void BtnQuit()
    {
        Application.Quit();
    }
}
