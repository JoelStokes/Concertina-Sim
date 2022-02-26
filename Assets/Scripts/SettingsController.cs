using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public Animator anim;

    void OnMouseDown(){
        anim.SetBool("Open", true);
    }

    public void Close(){
        anim.SetBool("Open", false);
    }
}
