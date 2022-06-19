using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTree
{
    public bool isUnlocked(string id){
        return false;
    }

    public bool tryUnlock(string id){
        return false; //not successfull
    }



    public List<Skill> findOptions(Player p){
        List<Skill> l = new List<Skill>();

        if(armorLevel < 5){
            l.Add(armorSkill);
        }
        for(int i = 0; i<playerSkills.Length; i++){
            if(canUnlock(playerSkills,i)){
                l.Add(playerSkills[i]);
            }
        }

        if(p.hasDagger()){

        }

        return l;
    }

    public int armorLevel = 0;  //max 5
    public Skill armorSkill = new Skill("armor");
    public Skill[] playerSkills = {
        new Skill("ext_view_1"),
        new Skill("ext_view_2","ext_view_1"),
        new Skill("ext_view_3","ext_view_2"),
        new Skill("ext_view_4","ext_view_3"),
        new Skill("view_1","ext_view_1"),
        new Skill("view_2","ext_view_2","view_1"),
        new Skill("view_3","ext_view_3","view_2")
    };
    //0=dagger, 1=bow, 2=grimoire, 3=spear, 4=cloak, 5=timestop, 6=eye, 7=teleport, 8=shield
    public Skill[] daggerSkill = {

    };
    public Skill[] bowSkill = {

    };
    public Skill[] grimoireSkill = {

    };
    public Skill[] spearSkill = {

    };
    public Skill[] cloakSkill = {

    };
    public Skill[] timestopSkill = {

    };
    public Skill[] eyeSkill = {

    };
    public Skill[] teleportSkill = {

    };
    public Skill[] shieldSkill = {

    };


    public bool canUnlock(Skill[] list, int index){

    }

}






//Max 2 dependencies
public class Skill{
    public string identifier = "";
    public bool[] unlocked = {false, false};
    public string requires = "";
    public string requires2 = "";

    public Skill(string id){
        identifier = id;
    }

    public Skill(string id, string req){
        identifier = id;
        requires = req;
    }

    public Skill(string id, string req2){
        identifier = id;
        requires = req;
        requires2 = req2;
    }


    public void unlock(int p){
        unlocked[p-1] = true;
    }

    public bool hasUnlocked(int p){
        return unlocked[p-1];
    }
}