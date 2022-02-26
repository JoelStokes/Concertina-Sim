using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No longer used, moved into Bellow Controller
public class BellowToggle : MonoBehaviour
{
    public bool toggle = true;

    private SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetToggle(){
        toggle = !toggle;
        ChangeColor();
    }

    void OnMouseDown(){ //Probably will be removed/unused?
        SetToggle();
    }
    private void ChangeColor(){
        if (toggle){
            spriteRenderer.color = new Vector4(.2f,.2f,.2f,1);
        } else {
            spriteRenderer.color = new Vector4(1,1,1,1);
        }
    }
}
