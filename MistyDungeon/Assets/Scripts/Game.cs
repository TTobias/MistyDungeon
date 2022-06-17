using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Data")]
    public int playerAmount = 1;

    [Header("Reference")]
    public Level level;
    public Phase phase;


    void Start()
    {
        phase = new PlayerPhase(1);
    }


    void FixedUpdate()
    {
        
    }
}
