using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class WidgetInteractionCounter : MonoBehaviour
{
    //the component to show the interaction count
    public TMP_Text textComponent;

    //the current number of interactions we've counted
    private int currentIndex = 0;

    //a delegate that calls whenever a ui element is interacted with
    public delegate void OnAnyWidgetInteractedWith(WidgetInteractionCounter relevantWidget, int currentIndex);
    public static event OnAnyWidgetInteractedWith onAnyWidgetInteractedWith;

    //has this counter been disabling?
    private bool isDisabled = false;

    //action to run on disabling
    public UnityEvent actionOnDisabling;

    void Start()
    {
        //trys to find component if not set manually
        if(textComponent == null) textComponent = GetComponentInChildren<TMP_Text>();
        if(textComponent == null)
        {
            Debug.LogWarning("Failed to find text component for widget: " + this.gameObject.name);
        }

        //makes the interactable disable when the try again panel is show
        TryAgainManager.onTryAgainPanelShown += DisableInteractable;
    }

    //stops the counter and invokes any methods bound to disabling
    private void DisableInteractable()
    {
        isDisabled = true;
        actionOnDisabling?.Invoke();
    }

    //if not disabling, increase the counter, update the widget, and invoke the delegate event
    public void InteractWithWidget()
    {
        if (isDisabled) return;
        currentIndex++;

        if(textComponent != null)
        {
            textComponent.text = currentIndex.ToString();
        }

        onAnyWidgetInteractedWith?.Invoke(this, currentIndex);
    }
}
