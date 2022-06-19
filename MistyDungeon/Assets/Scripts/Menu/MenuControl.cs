using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    
    
    public void btnStartGame(){
        SceneManager.LoadScene(2);
    }

    public void btnStartCoopGame(){

    }

    public void btnAchievements(){

    }

    public void btnSettings(){

    }

    public void btnExit(){
        Application.Quit();
    }
}
