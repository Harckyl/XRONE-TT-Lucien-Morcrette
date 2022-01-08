using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    public float clock;
    private int clockToShow;
    public float maxTime = 20;
    private bool running = true;
    public Text TextZone;
    private string Text;
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Awake()
    {
        clock = maxTime;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            clock -= Time.deltaTime;
        }
        
        clockToShow = (int)clock;
        if(clock >= 0f)
        {

            Text = "Temps restant : " + clockToShow.ToString() + " secondes";
            TextZone.text = Text;
            
        }
        else
        {
            //pour pouvoir cliquer a nouveau
            Cursor.lockState = CursorLockMode.None;
            //pour faire un petit écran de fin avec l'environnement gelé
            Time.timeScale = 0;
            //pour montrer l'UI afin de restart ou quitter
            EndScreen.SetActive(true);
            //pour afficher le bon text;
            EndScreen.transform.Find("Text").gameObject.GetComponent<EndTextBehaviour>().setText("DEFAITE");

            //booléen de debug pour bien savoir que la clock s'arrette
            running = false;
            clock = 0f;
            //gameover
        }
        
    }
    //pour relancer le timer autre part que dans la classe
    public void reload()
    {
        clock = maxTime;
        running = true;
    }
}
