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
    private AudioSource audioPlayer;

    private bool held = false;
    private bool keyboardPress = false;

    private float waitColor = .75f;
    private float pressColor = .35f;
    
    private bool pulling = false;

    private float scaleMult = 1.05946f;  //Pitch change is scaleMult^n, n being semitones to raise

    void Start()
    {
        bellowController = GameObject.Find("BellowController").GetComponent<BellowController>();
        audioPlayer = GetComponent<AudioSource>();
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

        if (pulling && bellowController.pushing){
            text.SetText(pushNote);
            pulling = false;
            if (held){
                NotePressed();
            } else {
                ColorChange();
            }
        } else if (!pulling && !bellowController.pushing) {
            text.SetText(pullNote);
            pulling = true;
            if (held){
                NotePressed();
            } else {
                ColorChange();
            }
        }
    }

    void OnMouseDown(){
        keyboardPress = false;
        NotePressed();
    }

    private void NotePressed(){
        held = true;

        if (bellowController.pushing){  //Set pitch based on bellow direction & note properties
            SetPitch(pushPitch);
            spriteRenderer.color = new Vector4(waitColor, pressColor, pressColor, 1);
        } else {
            SetPitch(pullPitch);
            spriteRenderer.color = new Vector4(pressColor, pressColor, waitColor, 1);
        }

        audioPlayer.Play();
    }

    private void SetPitch(float pitchAdjust){
        audioPlayer.pitch = -(Mathf.Pow(scaleMult, pitchAdjust));
    }

    private void NoteReleased(){
        held = false;
        audioPlayer.Stop();
        
        ColorChange();
    }

    private void ColorChange(){
        if (!pulling && !held){
            spriteRenderer.color = new Vector4(1, waitColor, waitColor, 1);
        } else if (pulling && !held) {
            spriteRenderer.color = new Vector4(waitColor, waitColor, 1, 1);
        }
    }
}
