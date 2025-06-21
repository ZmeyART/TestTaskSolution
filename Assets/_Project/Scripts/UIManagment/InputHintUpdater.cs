using UnityEngine;
using UnityEngine.UI;

public class InputHintUpdater : MonoBehaviour
{

    #region FIELDS

    [SerializeField]
    private Image hintImage;
    [SerializeField]
    private UIAssetScriptableObject assetScriptableObject;

    private static readonly System.Collections.Generic.List<InputHintUpdater> allHints = new();


    #endregion

    #region UNITY_METHODS

    private void OnEnable()
    {
        allHints.Add(this);
        UpdateIcon();
    }

    private void OnDisable() => allHints.Remove(this);

    #endregion

    #region MAIN_METHODS

    public static void UpdateAll()
    {
        foreach (var hint in allHints)
            hint.UpdateIcon();
    }

    public void UpdateIcon()
    {
        switch (InputDetector.CurrentInput)
        {
            case InputType.KeyboardMouse:
                hintImage.sprite = assetScriptableObject.iconPC;
                break;
            case InputType.Xbox:
                hintImage.sprite = assetScriptableObject.iconXbox;
                break;
            case InputType.PlayStation:
                hintImage.sprite = assetScriptableObject.iconSony;
                break;
        }
    }

    #endregion

}