using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Data")]
    public int positionX;
    public int positionY;
    public int playerNumber = 1;
    public bool alive = true;
    public int armor = 0;
    public int arcaneArmor = 0; //if >0, hits the armor can take

    [Header("Ability")]
    public int viewRange = 1;
    public int extViewRange = 2;

    [Header("Items")]
    public string[] items = {"dagger","vision",""};
    public int itemAmount = 2;
    
    [Header("Reference")]
    public Level level;
    public Sprite p1Sprite;
    public Sprite p2Sprite;

    [Header("Technical")]
    public Vector3 playerOffset = new Vector3(0.1f,0.1f,0f);

    
    public bool has(string s){
        return items[0] == s || items[1] == s || items[2] == s;
    }


    public void takeDamage(){
        if(armor > 0){
            armor--;
        }else{
            alive = false;
        }
    }


    public int armorPoints(){
        return armor;
    }

    void Start(){
        if(playerNumber == 2){
            this.GetComponent<SpriteRenderer>().sprite = p2Sprite;
            playerOffset = new Vector3(0f, 0f, 0f);
        }
    }
}
