using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float clock;
    public float maxTime = 20;
    // Start is called before the first frame update
    void Start()
    {
        clock = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        clock -= Time.deltaTime;
        if(clock <= 0f)
        {
            //gameOver
        }
        
    }
}
