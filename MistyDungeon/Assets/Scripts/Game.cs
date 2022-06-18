using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [Header("Data")]
    public int playerAmount = 1;
    public int stage = 0;
    public enum Phase{ GAME, LEVELUP, CUTSCENE};
    public Phase phase;
    public bool onCooldown = false;

    [Header("Reference")]
    public Level level;
    public enum GamePhase { PLAYER1, PLAYER2, ENEMY };
    public GamePhase gamePhase;

    [Header("Technical")]
    public float borderWidth = 0.1f;


    void Start()
    {
        phase = Phase.CUTSCENE;
        gamePhase = GamePhase.PLAYER1;
    }


    //Disclaimer: Ich bin mir bewusst das dies absolut kein sauberer code ist, aber naja, was sind schon programmierparadigmen :)
    void FixedUpdate()
    {
        if(!onCooldown){

            if(phase == Phase.GAME){
                if(gamePhase == GamePhase.PLAYER1){
                    //handlePlayer(1);

                }else if(gamePhase == GamePhase.PLAYER2){
                    //NOT ADDED YET
                    gamePhase = GamePhase.ENEMY;

                }else if(gamePhase == GamePhase.ENEMY){

                }

            }else if(phase == Phase.LEVELUP){

            }else if(phase == Phase.CUTSCENE){
            }
        }
    }


    //only for input processing
    void Update(){
        if(!onCooldown){

            if(phase == Phase.GAME){
                if(gamePhase == GamePhase.PLAYER1){
                    handlePlayer(1);

                }else if(gamePhase == GamePhase.PLAYER2){
                    //NOT ADDED YET
                    gamePhase = GamePhase.ENEMY;

                }else if(gamePhase == GamePhase.ENEMY){
                    handleEnemies();
                    gamePhase = GamePhase.PLAYER1;
                }

            }else if(phase == Phase.LEVELUP){
                if(Input.GetButtonDown("Space") || Input.GetMouseButtonDown(0)){ // Ersetzen durch auswahl
                    //Load cutscene
                    phase = Phase.GAME;
                }

            }else if(phase == Phase.CUTSCENE){
                if(Input.GetButtonDown("Space") || Input.GetMouseButtonDown(0)){ //BUTTONDOWN überprüfen
                    //Depth += 1
                    //Load next Level
                    phase = Phase.GAME;
                }
            }
        }
    }


    public void handlePlayer(int n){
        if(Input.GetMouseButtonDown(0)){
            //Mouse in Hexagon Area of Screen 
            if(Input.mousePosition.x > borderWidth*Screen.width && Input.mousePosition.x < (1f-borderWidth)*Screen.width){ 
                //HEXAGON SELECT
                if(level.selectionIsValid()){
                    if(level.map[level.xSelect,level.ySelect].distanceTo(level.player.positionX, level.player.positionY) == 1){ //valid move
                        doPlayerMove(1, level.xSelect, level.ySelect);
                    }
                }

            }
            //Mouse in PLayer1 Area of Screen
            else if(Input.mousePosition.x < borderWidth*Screen.width){ 
                //ABILITIES
            }
        }
    }




    public void handleEnemies(){
        for(int i = 0; i<level.enemies.Count; i++){
            //do enemy behavior
        }
    }


    public void doPlayerMove(int n, int x, int y){
        StartCoroutine(PlayerMove(1));
    }


    public IEnumerator PlayerMove(int n){
        onCooldown = true;
        int steps = 10;
        Vector3 step = level.map[level.xSelect,level.ySelect].tile.transform.position - level.player.transform.position;
        step.z = 0f;
        for(int i = 0; i< steps ; i++){
            level.player.transform.position += step * (1f / (float)steps);

            yield return new WaitForSeconds(0.5f/(float)steps);
        }
        level.player.positionX = level.xSelect;
        level.player.positionY = level.ySelect;
        level.fixPlayerPosition();
        level.updateTiles();
        level.resetCameraPosition(n);


        //DO KILLS

        onCooldown = false;
    }

}
