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
    public string deathMessage = "";

    [Header("Ability")]
    public int viewRange = 1;
    public int extViewRange = 2;
    public int tmpRange = 5;
    public bool tmpRangeActive = false;
    public int abilitySelected = 0;
    public int[] abilityCooldown = {0,0,0};
    public int[] abilityCooldownMax = {4,8,5};
    public int arcaneArmor = 0; //if >0, hits the armor can take - no, time it exists
    public int arcaneArmorMax = 2;
    public int teleportRange = 3;

    [Header("Items")]
    public string[] items = {"vision","teleport","shield"};
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


    public void takeDamage(string s){
        if(arcaneArmor> 0){

        }else if(armor > 0){
            armor--;
        }else{
            alive = false;
            deathMessage = s;
        }
    }


    public void teleportUsed(){
        abilityCooldown[1] = abilityCooldownMax[1];
    }


    public void handleAbility(Game g){
        if(abilitySelected == 1){
            if(abilityCooldown[0] > 0){
                abilitySelected = 0;
            }else{
                tmpRangeActive = true;
                g.level.updateTiles();
                abilityCooldown[0] = abilityCooldownMax[0];
                abilitySelected = 0;
            }
        }else if(abilitySelected == 3){
            if(abilityCooldown[2] > 0){
                abilitySelected = 0;
            }else{
                arcaneArmor = arcaneArmorMax;
                abilityCooldown[2] = abilityCooldownMax[2];
                abilitySelected = 0;
            }
        }

        g.showCooldowns();
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

    public void lowerCooldown(){
        abilityCooldown[0] -= 1;
        abilityCooldown[1] -= 1;
        abilityCooldown[2] -= 1;

        if(abilityCooldown[0] < 0){
            abilityCooldown[0] = 0;
        }
        if(abilityCooldown[1] < 0){
            abilityCooldown[1] = 0;
        }
        if(abilityCooldown[2] < 0){
            abilityCooldown[2] = 0;
        }

        tmpRangeActive = false;
        arcaneArmor--;
        if(arcaneArmor < 0){ arcaneArmor = 0; }

        Debug.Log("TEST");
    }
}
