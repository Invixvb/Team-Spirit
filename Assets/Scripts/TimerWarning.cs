using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerWarning : MonoBehaviour
{
    private float TimeLeft;
    private bool gameStarted, GameIsOver;
    private float TimeAmount;
    // Start is called before the first frame update
    void Start()
    {
        TimeLeft = TimeAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && !GameIsOver)
        {
            TimeLeft -= 1 * Time.deltaTime;

        }

        if (TimeLeft <= 0 )
        {
            
            
        }
    }
}
