using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Phase{
    public string name = "Phase";
}



[System.Serializable]
public class PlayerPhase : Phase{
    public int playerNumber = 1;

    public PlayerPhase(int n){
        playerNumber = n;
        name = "Player "+n+" Phase";
    }
}


[System.Serializable]
public class EnemyPhase : Phase{

    public EnemyPhase(){
        name = "EnemyPhase";
    }
}
