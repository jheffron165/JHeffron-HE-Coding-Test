using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class WidgetInteractionCounter : MonoBehaviour
{

    public TMP_Text textComponent;

    private int currentIndex = 0;

    public delegate void OnAnyWidgetInteractedWith(WidgetInteractionCounter relevantWidget, int currentIndex);

    public static event OnAnyWidgetInteractedWith onAnyWidgetInteractedWith;

    private bool isDisabled = false;

    public UnityEvent actionOnDisabling;

    void Start()
    {
        if(textComponent == null) textComponent = GetComponentInChildren<TMP_Text>();
        if(textComponent == null)
        {
            Debug.LogWarning("Failed to find text component for widget: " + this.gameObject.name);
        }

        TryAgainManager.onTryAgainPanelShown += DisableInteractable;
    }

    private void DisableInteractable()
    {
        isDisabled = true;
        actionOnDisabling?.Invoke();
    }

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
