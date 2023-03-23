using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragAndDropSwitch : MonoBehaviour, IBeginDragHandler, IDropHandler, IDragHandler
{
    //are we currently dragging?
    private bool isDragging = false;

    //the variable to cache mouse position when starting a drag
    Vector2 dragStartPosition;

    //how many pixels vertically we need to register a proper input
    public float verticalPixelsToRegisterDrag = 25;

    //event called when switch is activated
    public UnityEvent onSwitchActivated;

    //variables for enabling/disabling interactivity
    public bool interactable = true;
    public bool temporarilyDisabled = false;

    //on starting a drag, cache the mouse position
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        dragStartPosition = eventData.position;
    }

    //when we drop, check if there were at least a certain number of pixels moved vertically
    //invoke event if so
    public void OnDrop(PointerEventData eventData)
    {
        if (!isDragging || !interactable || temporarilyDisabled) return;
        isDragging = false;
        Vector2 dragEndPosition = eventData.position;

        if((dragEndPosition.y - dragStartPosition.y) > verticalPixelsToRegisterDrag)
        {
            onSwitchActivated?.Invoke();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    //setter function for interactable variable
    public void SetInteractable(bool newInteractable)
    {
        interactable = newInteractable;
    }

    //setter function for temp disabled variable
    public void SetTemporarilyDisabled(bool newTempDisabled)
    {
        temporarilyDisabled = newTempDisabled;
    }
}
