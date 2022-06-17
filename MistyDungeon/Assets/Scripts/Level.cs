using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Data")]
    public TileObject[,] map;
    public GameObject[,] mapObject;
    public GameObject player;
    //public int enemies;

    [Header("Generator")]
    public int depthLevel = 1;
    public int difficulty = 1;
    public int size = 20;

    [Header("Technical")]
    public float tileHeight = 1.2f;
    public float tileWidth = 10;
    public GameObject tilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        generateMap();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    public void generateMap(){
        //create Map
        map = new TileObject[size,size];
        for(int x = 0; x<size; x++){
            for(int y = 0; y<size; y++){
                map[x,y] = new TileObject();
                /*
                if(y<size/4 +1 && x+y<=size/4){ //bottom left corner
                    map[x,y].isVoid = true;
                }
                if(x>(size/4)*3 && x+y>=(size/4)*3*2){ //top right corner
                    map[x,y].isVoid = true;
                }*/
            }
        }
        //set map Tiles
        mapObject = new GameObject[size,size];
        for(int x = 0; x<size; x++){
            for(int y = 0; y<size; y++){
                mapObject[x,y] = Instantiate<GameObject>(tilePrefab);
                mapObject[x,y].transform.position = new Vector2(x*tileWidth + tileWidth/2, y*tileHeight + x*0.5f*tileHeight + tileHeight/2);
                //mapObject[x,y].GetComponent<SpriteRenderer>().enabled = !map[x,y].isVoid;
                mapObject[x,y].GetComponent<SpriteRenderer>().color = map[x,y].isVoid?Color.black:Color.white;
            }
        }

        //set enemies
    }

}
