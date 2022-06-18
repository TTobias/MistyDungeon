using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTree : MonoBehaviour
{
    public bool isUnlocked(string id){
        return false;
    }

    public bool tryUnlock(string id){
        return false; //not successfull
    }



    public List<Skill> findOptions(int p){
        return new List<Skill>();
        //TO ADD
    }


    public SkillTreeObject playerSkills;
    //0=dagger, 1=bow, 2=grimoire, 3=spear, 4=cloak, 5=timestop, 6=eye, 7=teleport, 8=shield
    public SkillTreeObject[] itemSkills;


    void Start(){
        //playerSkills = new SkillTreeObject( {new SkillTreeObject(new Skill("Test"), new SkillTreeObject[0])} );
    }

}







public class Skill{
    public string identifier = "";
    public bool[] unlocked = {false, false};


    public Skill(string id){
        identifier = id;
    }


    public void unlock(int p){
        unlocked[p-1] = true;
    }

    public bool hasUnlocked(int p){
        return unlocked[p-1];
    }
}



public class SkillTreeObject{
    public Skill skill;
    public SkillTreeObject[] next;
    public bool isDummy = false;


    public SkillTreeObject(Skill s, SkillTreeObject[] n){
        skill = s;
        next = n;
    }
    public SkillTreeObject(SkillTreeObject[] n){
        skill = null;
        next = n;
        isDummy = true;
    }

    public bool contains(string id){
        if(!isDummy && skill.identifier == id){
            return true;
        }else{
            for(int i = 0; i < next.Length; i++){
                if(next[i].contains(id)){
                    return true;
                }
            }
            return false;
        }
    }
}
