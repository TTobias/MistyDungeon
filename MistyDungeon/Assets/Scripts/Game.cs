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
                if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){ // Ersetzen durch auswahl
                    //Load cutscene
                    phase = Phase.GAME;
                }

            }else if(phase == Phase.CUTSCENE){
                if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){ //BUTTONDOWN überprüfen
                    //Depth += 1
                    //Load next Level
                    phase = Phase.GAME;
                }
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

                }

            }else if(phase == Phase.LEVELUP){

            }else if(phase == Phase.CUTSCENE){

            }
        }
    }


    public IEnumerator PlayerMoveCooldown(){
        onCooldown = true;
        yield return new WaitForSeconds(0.8f);
        onCooldown = false;
    }


    public void handlePlayer(int n){

    }








}
