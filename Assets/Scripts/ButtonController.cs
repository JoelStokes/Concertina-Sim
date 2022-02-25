using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Handle button input based on keyboard or mouse, plays one of two notes based on bellow direction
public class ButtonController : MonoBehaviour
{
    public float pushPitch; //note pitch, 1 = Middle C
    public string pushNote;
    public float pullPitch;
    public string pullNote;

    public string keystroke;    //Key pressed to play

    private BellowController bellowController;
    private TextMeshPro text;
    private SpriteRenderer spriteRenderer;
    private AudioSource audio;

    private bool held = false;
    private bool keyboardPress = false;

    private float waitColor = .25f;
    private float pressColor = .75f;

    void Start()
    {
        bellowController = GameObject.Find("BellowController").GetComponent<BellowController>();
        audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    //Update checks for the matching keystroke press as an alternative for mouse click, along with button releases
    void Update()
    {
        if (Input.GetKeyDown(keystroke)){
            keyboardPress = true;
            NotePressed();
        }

        if (held){
            if (keyboardPress){
                if (Input.GetKeyUp(keystroke)){
                    NoteReleased();
                }
            } else {
                if (Input.GetMouseButtonUp(0)){
                    NoteReleased();
                }
            }
        }

        if (bellowController.pushing){
            spriteRenderer.color = new Vector4(1, pressColor, pressColor, 1);
            text.SetText(pushNote);
        } else {
            spriteRenderer.color = new Vector4(pressColor, pressColor, 1, 1);
            text.SetText(pullNote);
        }
    }

    void OnMouseDown(){
        keyboardPress = false;
        NotePressed();
    }

    private void NotePressed(){
        held = true;

        if (bellowController.pushing){  //Set pitch based on bellow direction & note properties
            audio.pitch = pushPitch;
            spriteRenderer.color = new Vector4(pressColor, waitColor, waitColor, 1);
        } else {
            audio.pitch = pullPitch;
            spriteRenderer.color = new Vector4(waitColor, waitColor, pressColor, 1);
        }

        audio.Play();
    }

    private void NoteReleased(){
        held = false;
        audio.Stop();
        //Color change on hold & release? Slightly darker?
    }

    private void ChangeNote(){  //Change Button Text & Color based on direction change

    }
}
