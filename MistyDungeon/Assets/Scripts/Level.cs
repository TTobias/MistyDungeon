using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Data")]
    public TileObject[,] map;
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();
    public Stairs stairs;

    [Header("Generator")]
    public int depthLevel = 1;
    public int difficulty = 1;
    public int enemyAmount = 5;
    public int size = 20;

    [Header("Technical")]
    public float tileHeight = 1.2f;
    public float tileWidth = 10;
    public GameObject tilePrefab;
    public GameObject fogPrefab;
    public GameObject playerPrefab;
    public GameObject skeletonPrefab;
    public GameObject stairPrefab;
    public bool levelLoaded = false;

    [Header("Camera")]
    public Vector3 CameraOffset = new Vector3(0,0);
    public int cameraPosX = 0;
    public int cameraPosY = 0;
    public Camera cam;

    [Header("MapInteraction")]
    //Last selected tile
    public int xSelect = 0;
    public int ySelect = 0;


    void Start(){
        generateLevel();
    }

    void Update(){
        selectTile();
    }

    void FixedUpdate()
    {
        
    }



    public void generateLevel(){
        levelLoaded = true;
        generateMap();
        spawnPlayer();
        setCamera();
        setStairs();
        generateEnemies();
        updateTiles();
    }

    public void clearLevel(){
        cam.transform.parent = transform;   
        levelLoaded = false;
        while(transform.childCount > 0){
            Destroy(transform.GetChild(0));
        }
        map = new TileObject[0,0];
        Destroy(player.gameObject);
        while(enemies.Count > 0){
            Enemy e = enemies[0];
            enemies.RemoveAt(0);
            Destroy(e);
        }
    }


    public void spawnPlayer(){
        GameObject tmp = Instantiate<GameObject>(playerPrefab); 
        player = tmp.GetComponent<Player>();
        player.positionX = (int)Random.Range(size*0.1f,size*0.9f);
        player.positionY = (int)Random.Range(size*0.1f,size*0.9f);
        fixPlayerPosition();
    }

    public void updateTiles(){
        for(int x = 0; x<size; x++){
            for(int y = 0; y<size; y++){
                map[x,y].updateColor();
                //map[x,y].updateFog(player.positionX, player.positionY, 100, player.extViewRange); //everything is visible
                map[x,y].updateFog(player.positionX, player.positionY, player.viewRange, player.extViewRange);
            }
        }
    }

    public void setCamera(){
        cameraPosX = player.positionX;
        cameraPosY = player.positionY;
        cam.transform.position = map[cameraPosX,cameraPosY].tile.transform.position + CameraOffset;
        cam.transform.parent = player.transform;
    }

    public void resetCameraPosition(int n){
        cameraPosX = player.positionX;
        cameraPosY = player.positionY;
        cam.transform.position = map[cameraPosX,cameraPosY].tile.transform.position + CameraOffset;
    }


    public void generateEnemies(){
        for(int i = 0; i < enemyAmount; i++){
            Enemy e = Instantiate<GameObject>(skeletonPrefab).GetComponent<Enemy>();
            e.positionX = (int)Random.Range(size*0.1f,size*0.9f);
            e.positionY = (int)Random.Range(size*0.1f,size*0.9f);

            e.transform.position = map[e.positionX,e.positionY].tile.transform.position + e.offset;

            enemies.Add(e);
        }
    }


    public void selectTile(){
        if(Input.GetMouseButtonDown(0)){
            Vector3 mPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mPos);
            //Vector2(x*tileWidth, y*tileHeight + x*0.5f*tileHeight);

            int tileX = (int)Mathf.Round(mPos.x / (float)tileWidth);
            int tileY = (int)Mathf.Round((mPos.y - tileX*0.5f*tileHeight) / (float)tileHeight) ;

            if(tileX >= 0 && tileY >= 0 && tileX < size && tileY < size){
                //map[tileX,tileY].selected = !map[tileX,tileY].selected;
                xSelect = tileX;
                ySelect = tileY;
            }else{
                Debug.Log("TILE OUT OF BOUNDS : "+tileX+" , "+tileY);
            }

            updateTiles();
        }
    }


    public bool selectionIsValid(){
        return xSelect >= 0 && ySelect >= 0 && xSelect < size && ySelect < size && map[xSelect,ySelect].isWalkable();
    }


    public void fixPlayerPosition(){
        player.transform.position = map[player.positionX,player.positionY].tile.transform.position + player.playerOffset;
    }


    public void generateMap(){
        //create Map
        map = new TileObject[size,size];
        for(int x = 0; x<size; x++){
            for(int y = 0; y<size; y++){
                map[x,y] = new TileObject(x,y);    
                
                if(y<size/4 +1 && x+y<=size/4){ //bottom left corner
                    map[x,y].isVoid = true;
                }/*
                if(x>(size/4)*3 && x+y>=(size/4)*3*2){ //top right corner
                    map[x,y].isVoid = true;
                }*/

                map[x,y].tile = Instantiate<GameObject>(tilePrefab);
                map[x,y].tile.transform.position = new Vector2(x*tileWidth, y*tileHeight + x*0.5f*tileHeight);
                map[x,y].tile.transform.parent = this.transform;
                map[x,y].tile.name = "Tile: "+x+" , "+y;

                map[x,y].updateColor();

                map[x,y].fog = Instantiate<GameObject>(fogPrefab);
                map[x,y].fog.transform.position = map[x,y].tile.transform.position;
                map[x,y].fog.transform.parent = map[x,y].tile.transform;
            }
        }
    }


    public void setStairs(){
        stairs = Instantiate<GameObject>(stairPrefab).GetComponent<Stairs>();
        do{
            stairs.posX = (int)Random.Range(size*0.1f,size*0.9f);
            stairs.posY = (int)Random.Range(size*0.1f,size*0.9f);
        }while(stairs.posX < 0 || stairs.posY < 0 || stairs.posX >= size || stairs.posY >= size || !map[stairs.posX,stairs.posY].isWalkable() || map[stairs.posX,stairs.posY].distanceTo(player.positionX,player.positionY) < 5);
        stairs.transform.position = map[stairs.posX,stairs.posY].tile.transform.position;
    }
}
