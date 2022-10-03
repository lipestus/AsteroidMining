using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestLerp : MonoBehaviour
{
    private bool canLerp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Keyboard.current.vKey.wasPressedThisFrame)
            canLerp = true;

        if (!canLerp) return;
        Vector3 smoothTransition = Vector3.Lerp(transform.position, new Vector3(10f,10f,0f), 5f * Time.deltaTime);
        transform.position = smoothTransition;
    }
}
