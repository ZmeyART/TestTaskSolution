using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SettingsWindowController : MonoBehaviour
{

    #region FIELDS

    [SerializeField]
    private GameObject mainCanvas;
    [SerializeField]
    private Animator camAnimator;
    [SerializeField]
    private GameObject gamePanel, controlsPanel, videoPanel, keyBindingsPanel;
    [SerializeField]
    private GameObject defaultButton;

    private Dictionary<string, GameObject> allSettingsPanel;
    private string previousPanel;


    #endregion

    #region UNITY_METHODS

    private void Start()
    {
        allSettingsPanel = new()
        {
            { nameof(gamePanel), gamePanel },
            { nameof(controlsPanel), controlsPanel },
            { nameof(videoPanel), videoPanel },
            { nameof(keyBindingsPanel), keyBindingsPanel }
        };
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(defaultButton);
        camAnimator.SetFloat("Animate", 1);
        mainCanvas.SetActive(false);
    }

    private void OnDisable()
    {
        camAnimator.SetFloat("Animate", 0);
        mainCanvas.SetActive(true);
    }

    #endregion

    #region MAIN_METHODS

    public void OpenPanel(string panelName)
    {
        if (panelName != previousPanel)
        {
            foreach (var panel in allSettingsPanel.Values)
                panel.SetActive(false);
            allSettingsPanel[panelName].SetActive(true);
            previousPanel = panelName;
        }
    }

    #endregion

}
