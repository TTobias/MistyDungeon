using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileObject
{
    [Header("Property")]
    public bool isVoid = false;
    public bool selected = false;
    public bool highlighted = false;

    [Header("Reference")]
    public GameObject tile;

    public TileObject(){

    }

    public void updateColor(){
        tile.GetComponent<SpriteRenderer>().color = 
            isVoid? Color.black:
            selected? Color.red:
            highlighted? Color.yellow:
            Color.white;
    }
}
