using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileObject
{
    [Header("Position")]
    public int posX;
    public int posY;


    [Header("Property")]
    public bool isVoid = false;
    public bool selected = false;
    public bool highlighted = false;

    [Header("Reference")]
    public GameObject tile;
    public GameObject fog;

    public TileObject(int x, int y){
        posX = x;
        posY = y;
    }


    public void updateColor(){
        tile.GetComponent<SpriteRenderer>().color = 
            isVoid? Color.black:
            selected? Color.red:
            highlighted? Color.yellow:
            Color.white;
    }

    public void updateFog(int px, int py, int r, int rx){ //player pos with view range and extended range
        fog.SetActive(!isVoid);
        fog.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);

        int d = distance(px, py, posX, posY);

        /* //For Debug
        switch(d){
            case(0): fog.GetComponent<SpriteRenderer>().color = Color.blue; break;
            case(1): fog.GetComponent<SpriteRenderer>().color = Color.cyan; break;
            case(2): fog.GetComponent<SpriteRenderer>().color = Color.green; break;
            case(3): fog.GetComponent<SpriteRenderer>().color = Color.yellow; break;
            case(4): fog.GetComponent<SpriteRenderer>().color = Color.red; break;
        }*/
        
        if( d <= r){
            fog.SetActive(false);
        }else if( d <= rx){
            fog.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.8f);
        }
    }



    // (-1+1) ( 0+1) 
    // (-1 0) ( 0 0) (+1 0)
    //        ( 0-1) (+1-1)  
    public int distance(int x1, int y1, int x2, int y2){ //distance of hexfields, 1 is source 2 is target
        int dx = Mathf.Abs(x1 - x2);
        int dy = Mathf.Abs(y1 - y2);

        if(dx == 0){ return dy; }
        else if(dy == 0){ return dx; }
        else{
            if(x2 < x1 && y2 < y1){ //Small Corner
                return dx+dy;
            }else if(x2 < x1 && y2 > y1){ //Big Corner
                return Mathf.Max(dx, dy);
            }else if(x2 > x1 && y2 < y1){ //Big Corner
                return Mathf.Max(dx, dy);
            }else if(x2 > x1 && y2 > y1){ //Small Corner
                return dx+dy;
            }else return 0;
        }

    }
}
