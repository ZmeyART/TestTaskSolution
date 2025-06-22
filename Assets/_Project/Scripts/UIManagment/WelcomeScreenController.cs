using UnityEngine;
using UnityEngine.InputSystem;


public class WelcomeScreenController : MonoBehaviour
{
    
    #region FIELDS

    [SerializeField]
    private Animator camAnimator;
    [SerializeField]
    private GameObject mainWindowObject;
    [SerializeField] 
    private InputActionAsset inputActions;


    private InputAction _submit;


    #endregion

    #region UNITY_METHODS

    private void OnEnable()
    {
        var actionMap = inputActions.FindActionMap("MainScreen", true);
        _submit = actionMap.FindAction("Submit", true);
        _submit.performed += OnSubmit;
        _submit.Enable();
    }

    private void OnDisable() => _submit.performed -= OnSubmit;

    #endregion

    #region MAIN_METHODS

    private void OnSubmit(InputAction.CallbackContext context)
    {
        camAnimator.SetFloat("Animate", 0.1f);
        mainWindowObject.SetActive(true);
        gameObject.SetActive(false);
    }

    #endregion

}
