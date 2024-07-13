using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectExtended : ScrollRect
{
    /// <summary>
    /// Enum for which mouse button will be used to drag the scroll rect content.
    /// </summary>
    public enum MouseDragButton
    {
        /// <summary>
        /// Left mouse button.
        /// </summary>
        Left,

        /// <summary>
        /// Right mouse button.
        /// </summary>
        Right,

        /// <summary>
        /// Middle mouse button.
        /// </summary>
        Middle,
    }

    /// <summary>
    /// Enum for which modifier key will be used with the mouse button to drag the scroll rect content.
    /// </summary>
    public enum MouseDragModifierKey
    {
        /// <summary>
        /// No modifier key.
        /// </summary>
        None,

        /// <summary>
        /// Use the shift modifier key along with the mouse button to drag the content of the scroll rect.
        /// </summary>
        Shift,

        /// <summary>
        /// Use the ctrl modifier key along with the mouse button to drag the content of the scroll rect.
        /// </summary>
        Ctrl,

        /// <summary>
        /// Use the alt modifier key along with the mouse button to drag the content of the scroll rect.
        /// </summary>
        Alt,

        /// <summary>
        /// Use the command modifier along with the and mouse button to drag the content of the scroll rect.
        /// </summary>
        Command,
    }

    // Should the scroll rect content be draggable by the mouse?
    [SerializeField]
    private bool mouseDrag = true;

    public bool GetMouseDrag()
    {
        return mouseDrag;
    }

    public void SetMouseDrag(bool mouseDrag)
    {
        this.mouseDrag = mouseDrag;
    }

    // The mouse button that will be used to drag the scroll rect.
    [SerializeField]
    private MouseDragButton mouseDragButton = MouseDragButton.Left;

    // The modifier key that must be used with the mouse button to drag the scroll rect.
    [SerializeField]
    private MouseDragModifierKey mouseDragModifierKey = MouseDragModifierKey.Ctrl;

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (mouseDrag)
        {
            if (mouseDragButton == MouseDragButton.Left)
            {
                if (eventData.button != PointerEventData.InputButton.Left)
                {
                    // Set pointerDrag to null to prevent OnDrag() and OnEndDrag from being called.
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragButton == MouseDragButton.Right)
            {
                if (eventData.button != PointerEventData.InputButton.Right)
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragButton == MouseDragButton.Middle)
            {
                if (eventData.button != PointerEventData.InputButton.Middle)
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }

            // Correct mouse button was pressed, now check if the correct modifier key is pressed.
            if (mouseDragModifierKey == MouseDragModifierKey.Ctrl)
            {
                if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.None)
            {
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Command)
            {
                if (!(Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Shift)
            {
                if (!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Alt)
            {
                if (!(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }

            // Remap mouse input as left mouse button since ScrollRect only accepts the left mouse button.
            eventData.button = PointerEventData.InputButton.Left;
            base.OnInitializePotentialDrag(eventData);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (mouseDrag)
        {
            if (mouseDragButton == MouseDragButton.Left)
            {
                if (eventData.button != PointerEventData.InputButton.Left)
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragButton == MouseDragButton.Right)
            {
                if (eventData.button != PointerEventData.InputButton.Right)
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragButton == MouseDragButton.Middle)
            {
                if (eventData.button != PointerEventData.InputButton.Middle)
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }

            // Correct mouse button was pressed, now check if the correct modifier key is pressed.
            if (mouseDragModifierKey == MouseDragModifierKey.Ctrl)
            {
                if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.None)
            {
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Command)
            {
                if (!(Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Shift)
            {
                if (!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Alt)
            {
                if (!(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
                {
                    eventData.pointerDrag = null;
                    return;
                }
            }

            // Remap mouse input as left mouse button since ScrollRect only accepts the left mouse button.
            eventData.button = PointerEventData.InputButton.Left;
            base.OnBeginDrag(eventData);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (mouseDrag)
        {
            if (mouseDragButton == MouseDragButton.Left)
            {
                if (eventData.button != PointerEventData.InputButton.Left)
                    return;
            }
            else if (mouseDragButton == MouseDragButton.Right)
            {
                if (eventData.button != PointerEventData.InputButton.Right)
                    return;
            }
            else if (mouseDragButton == MouseDragButton.Middle)
            {
                if (eventData.button != PointerEventData.InputButton.Middle)
                    return;
            }

            // Remap mouse input as left mouse button since ScrollRect only accepts the left mouse button.
            eventData.button = PointerEventData.InputButton.Left;
            base.OnEndDrag(eventData);
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (mouseDrag)
        {
            if (mouseDragButton == MouseDragButton.Left)
            {
                if (eventData.button != PointerEventData.InputButton.Left)
                    return;
            }
            else if (mouseDragButton == MouseDragButton.Right)
            {
                if (eventData.button != PointerEventData.InputButton.Right)
                    return;
            }
            else if (mouseDragButton == MouseDragButton.Middle)
            {
                if (eventData.button != PointerEventData.InputButton.Middle)
                    return;
            }

            // Correct mouse button was pressed, now check if the correct modifier key is pressed.
            if (mouseDragModifierKey == MouseDragModifierKey.Ctrl)
            {
                if (!(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
                {
                    // Call OnEndDrag so m_Dragging can be set to false and inertia can happen.
                    // Also prevent the content from being redragged without first letting go of the mouse button.
                    OnEndDrag(eventData);
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.None)
            {
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Command)
            {
                if (!(Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand)))
                {
                    OnEndDrag(eventData);
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Shift)
            {
                if (!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
                {
                    OnEndDrag(eventData);
                    eventData.pointerDrag = null;
                    return;
                }
            }
            else if (mouseDragModifierKey == MouseDragModifierKey.Alt)
            {
                if (!(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
                {
                    OnEndDrag(eventData);
                    eventData.pointerDrag = null;
                    return;
                }
            }

            // Remap mouse input as left mouse button since ScrollRect only accepts the left mouse button.
            eventData.button = PointerEventData.InputButton.Left;
            base.OnDrag(eventData);
        }
    }
}
