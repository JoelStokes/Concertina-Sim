using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellowToggle : MonoBehaviour
{
    public bool toggle = false;

    private SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown(){
        toggle = !toggle;
        ChangeColor();
    }
    private void ChangeColor(){
        if (toggle){
            spriteRenderer.color = new Vector4(.2f,.2f,.2f,1);
        } else {
            spriteRenderer.color = new Vector4(1,1,1,1);
        }
    }
}
