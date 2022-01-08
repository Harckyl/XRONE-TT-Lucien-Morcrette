using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //public for debug
    public bool finish = false;
    public GameObject EndScreen;
    public GameObject TimerText;
    //quand la fin collide avec quelque chose (ce sera le joueur)
    private void OnTriggerEnter(Collider other)
    {
        //on récupère le temps restant
        int clock = (int)TimerText.GetComponent<TextBehaviour>().clock;
        string timeRemaining = clock.ToString();
        TimerText.SetActive(false);
        //pour pouvoir cliquer a nouveau sur les boutons
        Cursor.lockState = CursorLockMode.None;
        //we have a winner
        finish = true;
        //pour faire un petit écran de fin avec l'environnement gelé
        Time.timeScale = 0;
        //pour montrer l'UI afin de restart ou quitter
        EndScreen.SetActive(true);
        EndScreen.transform.Find("Text").gameObject.GetComponent<EndTextBehaviour>().setText("VICTOIRE\n" + "Temps restants : " + timeRemaining + " secondes");
    }
    
}
