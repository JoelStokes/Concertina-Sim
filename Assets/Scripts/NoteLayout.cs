using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows passing in buttons as array for multiple layout types
[CreateAssetMenu(fileName = "NoteLayout", menuName = "Note Layout", order = 0)]
public class NoteLayout : ScriptableObject {
    public string layoutName;
    public int pushPitch;
    public string pushNote;
    public int pullPitch;
    public string pullNote; 
}
