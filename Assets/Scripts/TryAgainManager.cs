using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgainManager : MonoBehaviour
{

    public delegate void OnTryAgainPanelShown();
    public static OnTryAgainPanelShown onTryAgainPanelShown;

    public GameObject tryAgainPanel;

    void Start()
    {
        WidgetInteractionCounter.onAnyWidgetInteractedWith += OnWidgetInteractedWith;
        if (tryAgainPanel != null) tryAgainPanel.SetActive(false);
    }

    private void OnWidgetInteractedWith(WidgetInteractionCounter relevantWidget, int currentIndex)
    {
        if(currentIndex >= 10)
        {
            ShowTryAgainPanel();
        }
    }

    private void ShowTryAgainPanel()
    {
        if (tryAgainPanel != null) tryAgainPanel.SetActive(true);
        onTryAgainPanelShown?.Invoke();
    }
}
