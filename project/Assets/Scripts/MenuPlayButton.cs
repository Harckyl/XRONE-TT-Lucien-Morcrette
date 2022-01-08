using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPlayButton : MonoBehaviour
{
    
    public void Play()
    {
        //on veut réinitialisé le time in game et on veut relancer le timer du temps restant
        SceneManager.LoadScene("GameScene");
    }
}
