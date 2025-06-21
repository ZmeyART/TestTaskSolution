using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class MouseSelectionFix : MonoBehaviour
{

    #region UNITY_METHODS

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        var pointer = new PointerEventData(EventSystem.current)
        {
            position = mousePos
        };
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, results);
        if (results.Count > 0)
        {
            EventSystem.current.SetSelectedGameObject(results[0].gameObject);
            if (Mouse.current.leftButton.wasPressedThisFrame)
                ExecuteEvents.Execute(results[0].gameObject, pointer, ExecuteEvents.pointerDownHandler);
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                ExecuteEvents.Execute(results[0].gameObject, pointer, ExecuteEvents.pointerClickHandler);
                ExecuteEvents.Execute(results[0].gameObject, pointer, ExecuteEvents.pointerUpHandler);
            }
        }
    }

    #endregion

}