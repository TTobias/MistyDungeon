using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Data")]
    public int playerAmount = 1;
    public int stage = 0;
    public enum Phase{ GAME, LEVELUP, CUTSCENE, GAMEOVER};
    public Phase phase;
    public bool onCooldown = false;

    [Header("Reference")]
    public Level level;
    public enum GamePhase { PLAYER1, PLAYER2, ENEMY };
    public GamePhase gamePhase;
    public GameObject storyOverlay;
    public GameObject levelupOverlay;
    public GameObject gameOverOverlay;

    [Header("Technical")]
    public float borderWidth = 0.1f;
    public int language = 1; //deutsch

    [Header("Upgrade")]
    public AbilityTree skilltree = new AbilityTree();
    public Skill[] upgradeOptions;


    void Start()
    {
        startStory();
    }


    //Disclaimer: Ich bin mir bewusst das dies absolut kein sauberer code ist, aber naja, was sind schon programmierparadigmen :)
    void FixedUpdate()
    {
        if(!onCooldown && level.levelLoaded){

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
                    StartCoroutine(handleEnemies());
                    gamePhase = GamePhase.PLAYER1;
                }

            }else if(phase == Phase.LEVELUP){
                if(Input.GetButtonDown("Space") || Input.GetMouseButtonDown(0)){ // Ersetzen durch auswahl
                    //Load cutscene
                    startStory();
                }

            }else if(phase == Phase.CUTSCENE){
                if(Input.GetButtonDown("Space") || Input.GetMouseButtonDown(0)){ //BUTTONDOWN überprüfen
                    //Depth += 1
                    //Load next Level
                    startLevel();
                }
            }
        }
    }


    public void handlePlayer(int n){
        //check no move possible
        if(!level.checkMovePossible()){
            level.player.deathMessage = "Player was cornered";
            initiateGameOver();
        }

        if(player.abilitySelected == 0 || player.abilitySelected == 1 || player.abilitySelected == 3){ //move
            level.setPreview("move");
        
            if(Input.GetMouseButtonDown(0)){
                //Mouse in Hexagon Area of Screen 
                if(Input.mousePosition.x > borderWidth*Screen.width && Input.mousePosition.x < (1f-borderWidth)*Screen.width){ 
                    //HEXAGON SELECT
                    if(level.selectionIsValid()){
                        if(level.map[level.xSelect,level.ySelect].distanceTo(level.player.positionX, level.player.positionY) == 1 && level.isUnoccupied(level.xSelect,level.ySelect)){ //valid move
                            
                            doPlayerMove(1, level.xSelect, level.ySelect);
                        }
                    }

                }
                //Mouse in PLayer1 Area of Screen
                else if(Input.mousePosition.x < borderWidth*Screen.width){ 
                    //ABILITIES
                }
            }

        }else if(player.abilitySelected == 2){ //teleport
            level.setPreview("teleport");

        }

    }




    public IEnumerator handleEnemies(){
        onCooldown = true;

        //handle Spells
        handleSpells();


        for(int i = 0; i<level.enemies.Count; i++){
            
            //do enemy behavior
            level.enemies[i].doTurn(level);
        }
            
        yield return new WaitForSeconds(0.25f);

        //check if player died
        if(!level.player.alive){
            initiateGameOver();
            ////ALSO UPDATE ARMOR INDICATOR
        }
        onCooldown = false;
    }


    public void doPlayerMove(int n, int x, int y){
        StartCoroutine(PlayerMove(1));
    }


    public IEnumerator PlayerMove(int n){

        level.setPreview("");

        //make move
        int prevX = level.player.positionX, prevY = level.player.positionY;
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

        //do kill
        if(/*level.player.has("dagger")*/ true){//use dagger
            level.cam.transform.parent = transform.parent;
            for(int i = 0; i<level.enemies.Count; i++){
                if( level.distance(prevX,prevY,level.enemies[i].positionX, level.enemies[i].positionY) == 1 
                    && level.distance(level.player.positionX, level.player.positionY, level.enemies[i].positionX, level.enemies[i].positionY) == 1 ){
                    

                    steps = 4;
                    step = level.enemies[i].transform.position - level.player.transform.position;
                    step.z = 0f;
                    for(int j = 0; j< steps ; j++){
                        level.player.transform.position += step * (1f / (float)steps);
                        yield return new WaitForSeconds(0.2f/(float)steps);
                    }
                    Enemy e = level.enemies[i];
                    level.enemies.Remove(e);
                    Destroy(e.gameObject);
                    
                    step = -step;
                    for(int j = 0; j< steps ; j++){
                        level.player.transform.position += step * (1f / (float)steps);
                        yield return new WaitForSeconds(0.2f/(float)steps);
                    }
                }
            }
            level.cam.transform.parent = level.player.transform;
        }
        if(/*level.player.has("spear")*/ true){//use spear
            int dx = level.player.positionX - prevX;
            int dy = level.player.positionY - prevY;
            for(int i = 0; i<level.enemies.Count; i++){
                if(level.enemies[i].positionX == prevX + 2*dx && level.enemies[i].positionY == prevY + 2*dy){

                    steps = 4;
                    step = level.enemies[i].transform.position - level.player.transform.position;
                    step.z = 0f;
                    for(int j = 0; j< steps ; j++){
                        level.player.transform.position += step * (1f / (float)steps);
                        yield return new WaitForSeconds(0.2f/(float)steps);
                    }
                    Enemy e = level.enemies[i];
                    level.enemies.Remove(e);
                    Destroy(e.gameObject);
                    
                    step = -step;
                    for(int j = 0; j< steps ; j++){
                        level.player.transform.position += step * (1f / (float)steps);
                        yield return new WaitForSeconds(0.2f/(float)steps);
                    }
                }
            }
        }

        //fix playerposition
        level.fixPlayerPosition();
        level.updateTiles();
        level.resetCameraPosition(n);


        onCooldown = false;
        gamePhase = GamePhase.PLAYER2;

        //Check if Level is finished
        if(level.player.positionX == level.stairs.posX && level.player.positionY == level.stairs.posY){
            //startLevelup();
            startStory();
        }
    }


    public void startLevelup(){
        phase = Phase.LEVELUP;

        storyOverlay.SetActive(false);
        levelupOverlay.SetActive(true);
        gameOverOverlay.SetActive(false);

        level.clearLevel();

        if(playerAmount == 1){
            List<Skill> opt = skilltree.findOptions(level.player);

            upgradeOptions = new Skill[Mathf.Min(opt.Count, 3)];
            for(int i = 0; i<upgradeOptions.Length; i++){
                Skill s = opt[Random.Range(0, opt.Count)];
                opt.Remove(s);
                upgradeOptions[i] = s;
            }

        }else{
            //COOP
        }
    }

    
    public void startLevel(){
        phase = Phase.GAME;
        gamePhase = GamePhase.PLAYER1;

        level.depthLevel += 1;
        level.generateLevel();

        storyOverlay.SetActive(false);
        levelupOverlay.SetActive(false);
        gameOverOverlay.SetActive(false);

        if(playerAmount == 1){
            
        }else{
            //COOP
        }
    }



    public void handleSpells(){
        for(int i = 0; i<level.spells.Count; i++){
            level.spells[i].runTimer(level);
        }
    }
    
    public void startStory(){
        phase = Phase.CUTSCENE;

        storyOverlay.SetActive(true);
        levelupOverlay.SetActive(false);
        gameOverOverlay.SetActive(false);

        if(level.depthLevel < Translation.cutsceneText[language].Length){
            storyOverlay.transform.GetChild(0).GetComponent<Text>().text = Translation.cutsceneText[language][level.depthLevel][playerAmount-1];
        }else{
            storyOverlay.transform.GetChild(0).GetComponent<Text>().text = "...";
        }
    }


    public void selectUpgrade(int p, int i){
        startStory();
    }

    public void upgrade1P1(){ selectUpgrade(1,0); }
    public void upgrade2P1(){ selectUpgrade(1,1); }
    public void upgrade3P1(){ selectUpgrade(1,2); }
    public void upgrade1P2(){ selectUpgrade(2,0); }
    public void upgrade2P2(){ selectUpgrade(2,1); }
    public void upgrade3P2(){ selectUpgrade(2,2); }
    


    public void selectAbility(int i){
        if(level.player.abilitySelected == i){
            level.player.abilitySelected = 0;
        }else{
            level.player.abilitySelected = i; 
            level.player.handleAbility(this);
        }
    }

    public void btnAbility1(){ selectAbility(1); }
    public void btnAbility2(){ selectAbility(2); }
    public void btnAbility3(){ selectAbility(3); }


    public void initiateGameOver(){
        string msg = level.player.deathMessage;
        phase = Phase.GAMEOVER;
        Debug.Log("Game Over");
        level.clearLevel();
        gameOverOverlay.SetActive(true);
        storyOverlay.SetActive(false);
        levelupOverlay.SetActive(false);

        gameOverOverlay.transform.GetChild(1).GetComponent<Text>().text = "Depth reached : "+level.depthLevel+"\n"+msg;
    }



    public void backToMenuBtn(){
        SceneManager.LoadScene(0);
    }

    public void restartBtn(){
        SceneManager.LoadScene(2);
    }
}
