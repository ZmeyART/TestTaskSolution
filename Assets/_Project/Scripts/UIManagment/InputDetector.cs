using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public enum InputType
{
    KeyboardMouse,
    PlayStation,
    Xbox
}


public class InputDetector : MonoBehaviour
{

    #region INITIALIZATION

    public static InputType CurrentInput { get; private set; }

    #endregion

    #region UNITY_METHODS

    private void OnEnable()
    {
        InputSystem.onAnyButtonPress.Call(OnAnyInput);
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDisable() => InputSystem.onDeviceChange -= OnDeviceChange;

    #endregion

    #region MAIN_METHODS

    private void OnAnyInput(InputControl control)
    {
        UpdateInputType(control.device);
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (change == InputDeviceChange.Added || change == InputDeviceChange.Reconnected)
            UpdateInputType(device);
    }

    private void UpdateInputType(InputDevice device)
    {
        if (device is Gamepad gamepad)
        {
            string product = device.description.product?.ToLower() ?? "";

            if (product.Contains("dualshock") || product.Contains("dualsense") || product.Contains("wireless controller"))
                CurrentInput = InputType.PlayStation;
            else if (product.Contains("xbox"))
                CurrentInput = InputType.Xbox;
            else
                CurrentInput = InputType.Xbox;
        }
        else if (device is Keyboard || device is Mouse)
            CurrentInput = InputType.KeyboardMouse;
        InputHintUpdater.UpdateAll();
    }

    #endregion

}
