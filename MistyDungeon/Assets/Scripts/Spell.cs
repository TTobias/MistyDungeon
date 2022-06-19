using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Data")]
    public int xPos;
    public int yPos;
    public int type = 0; //0:enemy, 1:p1, 2:p2
    public int timer = 3;

    [Header("Reference")]
    public Sprite spriteE;
    public Sprite spriteEA;
    public Sprite spriteP1;
    public Sprite spriteP1A;
    public Sprite spriteP2;
    public Sprite spriteP2A;


    public void resetColor(){
        switch (type)
        {
            case(0):
                GetComponent<SpriteRenderer>().sprite = spriteE;
                break;
            case(1):
                GetComponent<SpriteRenderer>().sprite = spriteP1;
                break;
            case(2):
            default:
                GetComponent<SpriteRenderer>().sprite = spriteP2;
                break;
        }
    }

    public void runTimer(){
        timer--;
        if(timer <= 0){
            explode();
        }
    }

    public void explode(){

    }
}
