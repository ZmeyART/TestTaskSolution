using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


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

    private void OnEnable() => SetDefaultButton();

    private void Awake()
    {
        allMenus = new Dictionary<string, GameObject>
        {
            { "PlayMenuWindow", playMenuWindow },
            { "ExitMenuWindow", exitMenuWindow },
            { "CreditsMenuWindow", creditsMenuWindow },
            { "SettingsMenuWindow", settingsMenuWindow }
        };
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null &&
            (Keyboard.current.anyKey.wasPressedThisFrame ||
             (Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame)))
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(defaultButton);
        }
    }

    #endregion

    #region MAIN_METHODS

    public void OpenWindow(string windowName)
    {
        foreach (var menu in allMenus.Values)
            if(menu.activeInHierarchy)
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

    public void CloseGame() => Application.Quit();

    #endregion

}
