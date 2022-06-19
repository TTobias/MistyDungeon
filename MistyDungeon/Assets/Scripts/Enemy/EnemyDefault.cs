using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Data")]
    public int positionX;
    public int positionY;

    [Header("Technical")]
    public Vector3 offset = new Vector3(0f,0f,0f);


    public Enemy(int x, int y){
        positionX = x;
        positionY = y;
    }

    public virtual void doTurn(Level l){
        Debug.Log("ENEMY BEHAVIOR IS MISSING");
    }
}
