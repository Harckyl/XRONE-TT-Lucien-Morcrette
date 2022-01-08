using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextBehaviour : MonoBehaviour
{
    //pour écrire dans la zone de texte
    public Text textZone;
    public void setText(string textToDisplay)
    {
        textZone.text = textToDisplay;
    }
}
