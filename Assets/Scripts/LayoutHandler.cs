using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//On Layout Change, contacts all child Buttons to update currently used layout
public class LayoutHandler : MonoBehaviour
{
    public GameObject[] ButtonRows;
    private TextMeshPro text;
    private List<ButtonController> ButtonList = new List<ButtonController>();
    void Start(){
        text = GetComponent<TextMeshPro>();

        for (int i=0; i<ButtonRows.Length; i++){
            for (int j=0; j<ButtonRows[i].transform.childCount; j++){
                ButtonList.Add(ButtonRows[i].transform.GetChild(j).GetComponent<ButtonController>());
            }
        }
    }

    public void ChangeLayout(TMP_Dropdown dropdown){    //Send layout update to all buttons
        string newLayout = dropdown.captionText.text;

        for (int i=0; i<ButtonList.Count; i++){
            ButtonList[i].SwitchLayout(newLayout);
        }
        text.SetText(newLayout);
    }
}
