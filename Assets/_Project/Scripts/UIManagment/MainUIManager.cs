using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MainUIManager : MonoBehaviour
{

    #region FIELDS

    [SerializeField]
    private GameObject playMenuWindow, mainMenuWindow, exitMenuWindow, creditsMenuWindow, settingsMenuWindow;
    [SerializeField]
    private GameObject defaultButton;
    [SerializeField]
    private GameObject[] allMainMenuButtons;

    private Dictionary<string, GameObject> allMenus;
    private string previousWindow;


    #endregion

    #region UNITY_METHODS

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(defaultButton);
        allMenus = new Dictionary<string, GameObject>
        {
            { "PlayMenuWindow", playMenuWindow },
            { "ExitMenuWindow", exitMenuWindow },
            { "CreditsMenuWindow", creditsMenuWindow },
            { "SettingsMenuWindow", settingsMenuWindow }
        };
    }

    #endregion

    #region MAIN_METHODS

    public void OpenWindow(string windowName)
    {
        foreach (var menu in allMenus.Values)
            menu.SetActive(false);
        if (previousWindow != windowName)
        {
            allMenus[windowName].SetActive(true);
            previousWindow = windowName;
        }
        else
        {
            allMenus[windowName].SetActive(false);
            previousWindow = "";
        }
    }

    public void SetDefaultButton() => EventSystem.current.SetSelectedGameObject(defaultButton);

    #endregion

}
