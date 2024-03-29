using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Handle current bellow direction, toggled via Capslock, Spacebar, or mouse click
public class BellowController : MonoBehaviour
{
    public bool pushing = false;
    public bool toggle = true;
    public TextMeshPro directionText;

    void Update()
    {
        if (toggle){
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.CapsLock)){
                pushing = !pushing;
            }
        } else {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.CapsLock)){
                pushing = true;
            } else {
                pushing = false;
            }
        }

        SetText();
    }

    public void SetToggle(){
        toggle = !toggle;
    }

    private void SetText(){
        if (pushing){
            directionText.SetText("In");
        } else {
            directionText.SetText("Out");
        }
    }

    /*void OnMouseDown(){   //Won't work with current key setup, need alternative
        pushing = !pushing;
    }*/
}
