using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTransform : MonoBehaviour
{
    
    private Vector3 defaultRotation;

    [SerializeField]
    private Vector3 rotationSpeed;

    private bool transformActive = false;

    public void SetTransformActive(bool newTransformActive)
    {
        transformActive = newTransformActive;
    }

    public void ToggleTransformActive(){
        transformActive = !transformActive;
    }

    private void Start()
    {
        defaultRotation = transform.localEulerAngles;
    }

    public void FixedUpdate(){
        if(transformActive)
        {
            transform.localEulerAngles += rotationSpeed;
        }
    }

}
