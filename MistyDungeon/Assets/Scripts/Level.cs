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
    public List<Spell> spells = new List<Spell>();

    [Header("Generator")]
    public int depthLevel = 0;
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
        //generateLevel();
    }

    void Update(){
        if(levelLoaded){
            selectTile();
        }
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
        levelLoaded = false;
        cam.transform.parent = transform.parent;

        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
        map = new TileObject[0,0];

        Destroy(player.gameObject);

        foreach (Enemy e in enemies) {
            GameObject.Destroy(e.transform.gameObject);
        }
        enemies = new List<Enemy>();

        Destroy(stairs.gameObject);
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
        if( xSelect >= 0 && ySelect >= 0 && xSelect < size && ySelect < size ){
            return map[xSelect,ySelect].isWalkable();
        }
        return false;
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


    public bool isUnoccupied(int x, int y){
        foreach(Enemy e in enemies){
            if(e.positionX == x && e.positionY == y){
                return false;
            }
        }
        if(player.positionX == x && player.positionY == y){
            return false;
        }
        return true;
    }
}
