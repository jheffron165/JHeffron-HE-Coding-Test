using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSwitch : MonoBehaviour
{
    public bool IsOn = false;

    //reference to an object in the scene
    public Transform SwitchPivot;

    //rotation values for when the switch is off or on
    public Vector3 OffEulerAngles;
    public Vector3 OnEulerAngles;

    //how long to wait before the switch turns off again
    public float TurnOffAfterSeconds = 3.0f;

    //events to call on changing light status
    public UnityEvent onLightOn;
    public UnityEvent onLightOff;
    
    //sets default rotation
    private void Start()
    {
        UpdateSwitchRotation();
    }

    //updates rotation of pivot based on switch status
    private void UpdateSwitchRotation()
    {
        SwitchPivot.localEulerAngles = IsOn ? OnEulerAngles : OffEulerAngles;
    }

    //sets light on and sets turn off to invoke
    //calls delegate 
    public void SetLightOn()
    {
        IsOn = true;
        UpdateSwitchRotation();
        Invoke("SetLightOff", TurnOffAfterSeconds);
        onLightOn?.Invoke();
    }
    
    //turns light off and calls delegate
    private void SetLightOff()
    {
        IsOn = false;
        UpdateSwitchRotation();
        onLightOff?.Invoke();
    }
}
