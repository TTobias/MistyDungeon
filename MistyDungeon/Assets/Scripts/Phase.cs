using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase{
    
}



public class PlayerPhase : Phase{
    public int playerNumber = 1;

    public PlayerPhase(int n){
        playerNumber = n;
    }
}


public class EnemyPhase : Phase{

}
