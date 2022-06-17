using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Data")]
    public TileObject[,] map;
    public Player player;
    //public int enemies;

    [Header("Generator")]
    public int depthLevel = 1;
    public int difficulty = 1;
    public int size = 20;

    [Header("Technical")]
    public float tileHeight = 1.2f;
    public float tileWidth = 10;
    public GameObject tilePrefab;
    public GameObject playerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        generateMap();
        spawnPlayer();
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

                map[x,y].tile = Instantiate<GameObject>(tilePrefab);
                map[x,y].tile.transform.position = new Vector2(x*tileWidth + tileWidth/2, y*tileHeight + x*0.5f*tileHeight + tileHeight/2);
                map[x,y].tile.transform.parent = this.transform;
                map[x,y].tile.name = "Tile: "+x+" , "+y;

                map[x,y].updateColor();
            }
        }

        //set enemies
    }


    public void spawnPlayer(){
        GameObject tmp = Instantiate<GameObject>(playerPrefab); 
        player = tmp.GetComponent<Player>();
        player.positionX = (int)Random.Range(size*0.1f,size*0.9f);
        player.positionY = (int)Random.Range(size*0.1f,size*0.9f);
        tmp.transform.position = map[player.positionX,player.positionY].tile.transform.position + player.playerOffset;
    }

    public void updateTiles(){
        for(int x = 0; x<size; x++){
            for(int y = 0; y<size; y++){
                map[x,y].updateColor();
            }
        }
    }
}
