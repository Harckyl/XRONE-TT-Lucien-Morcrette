using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour
{
    public GameObject Timer;
    public void Play()
    {
        //on veut réinitialisé le time in game et on veut relancer le timer du temps restant
        Timer.GetComponent<TextBehaviour>().reload();
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
