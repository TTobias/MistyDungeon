using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Data")]
    public TileObject[,] map;
    public GameObject[,] mapObject;
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
            }
        }
        //set map Tiles
        mapObject = new GameObject[size,size];
        for(int x = 0; x<size; x++){
            for(int y = 0; y<size; y++){
                mapObject[x,y] = Instantiate<GameObject>(tilePrefab);
                mapObject[x,y].transform.position = new Vector2(x*tileWidth + tileWidth/2, y*tileHeight + x*0.5f*tileHeight + tileHeight/2);

            }
        }

        //set enemies
    }

}
