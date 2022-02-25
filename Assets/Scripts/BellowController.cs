using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handle current bellow direction, toggled via Capslock, Spacebar, or mouse click
public class BellowController : MonoBehaviour
{
    public bool pushing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.CapsLock)){
            pushing = !pushing;
        }
    }

    void OnMouseDown(){
        pushing = !pushing;
    }
}
