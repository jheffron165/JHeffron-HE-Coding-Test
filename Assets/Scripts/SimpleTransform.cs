using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransform : MonoBehaviour
{
    //how many degrees to rotate per fixed update step
    [SerializeField]
    private Vector3 rotationSpeed;

    //should the transformation animation currently play
    private bool transformActive = false;

    //changes current active state
    public void SetTransformActive(bool newTransformActive)
    {
        transformActive = newTransformActive;
    }

    //toggles current active state
    public void ToggleTransformActive(){
        transformActive = !transformActive;
    }

    //if currently active, rotate this object
    public void FixedUpdate(){
        if(transformActive)
        {
            transform.localEulerAngles += rotationSpeed;
        }
    }

}
