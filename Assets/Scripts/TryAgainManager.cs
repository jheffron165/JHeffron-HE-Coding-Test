using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainManager : MonoBehaviour
{
    //delegate that's called when the try again panel shows
    public delegate void OnTryAgainPanelShown();
    public static OnTryAgainPanelShown onTryAgainPanelShown;

    //gameobject references
    public GameObject tryAgainPanel;
    public GameObject grayOutPanel;

    //binds delegate and sets panel to hidden by default
    void Start()
    {
        WidgetInteractionCounter.onAnyWidgetInteractedWith += OnWidgetInteractedWith;
        if (tryAgainPanel != null) tryAgainPanel.SetActive(false);
    }

    //checks if we've interested with this widget 10 times or more
    private void OnWidgetInteractedWith(WidgetInteractionCounter relevantWidget, int currentIndex)
    {
        if(currentIndex >= 10)
        {
            ShowTryAgainPanel();
        }
    }

    //show the try again panel and invoke the delegate
    private void ShowTryAgainPanel()
    {
        if (tryAgainPanel != null) tryAgainPanel.SetActive(true);
        onTryAgainPanelShown?.Invoke();
    }

    //when restarting, reload the current scene
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //when level is finished, grey out the screen
    public void FinishLevel()
    {
        grayOutPanel.SetActive(true);
    }
}
