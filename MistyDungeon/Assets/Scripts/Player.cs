using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Data")]
    public int positionX;
    public int positionY;
    public int playerNumber = 1;

    [Header("Ability")]
    public int viewRange = 1;
    public int extViewRange = 2;

    [Header("Items")]
    public string slot1 = "Dagger"; //Placeholder
    
    [Header("Reference")]
    public Level level;

    [Header("Technical")]
    public Vector3 playerOffset = new Vector3(0.1f,0.1f,0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}