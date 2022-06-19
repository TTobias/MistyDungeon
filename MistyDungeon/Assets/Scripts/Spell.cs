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

    public void runTimer(Level l){
        timer--;
        if(timer <= 0){
            StartCoroutine(explode(l));
        }
    }

    public IEnumerator explode(Level l){
        switch (type)
        {
            case(0):
                GetComponent<SpriteRenderer>().sprite = spriteEA;
                break;
            case(1):
                GetComponent<SpriteRenderer>().sprite = spriteP1A;
                break;
            case(2):
            default:
                GetComponent<SpriteRenderer>().sprite = spriteP2A;
                break;
        }


        if(l.player.positionX == xPos && l.player.positionY == yPos){
            l.player.takeDamage("Killed by Magic");
        }

        yield return new WaitForSeconds(0.24f);

        l.spells.Remove(this);
        Destroy(this.gameObject);
    }
}
