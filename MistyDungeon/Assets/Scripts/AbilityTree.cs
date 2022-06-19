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
            if(canUnlock(playerSkills,i,p.playerNumber)){
                l.Add(playerSkills[i]);
            }
        }

        if(p.has("dagger")){

        }

        return l;
    }

    public int armorLevel = 0;  //max 5
    public Skill armorSkill = new Skill(0, "armor");
    public Skill[] playerSkills = {
        new Skill(1, "ext_view_1"),
        new Skill(2, "ext_view_2","ext_view_1"),
        new Skill(3, "ext_view_3","ext_view_2"),
        new Skill(4, "ext_view_4","ext_view_3"),
        new Skill(5, "view_1","ext_view_1"),
        new Skill(6, "view_2","ext_view_2","view_1"),
        new Skill(7, "view_3","ext_view_3","view_2")
    };
    //0=dagger, 1=bow, 2=grimoire, 3=spear, 4=cloak, 5=timestop, 6=eye, 7=teleport, 8=shield
    public Skill[] daggerSkill = {
        //new Skill(8, "ext_view_1"),
        //new Skill(9, "ext_view_2","ext_view_1")
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


    public bool canUnlock(Skill[] list, int index, int p){
        string r1 = list[index].requires;
        string r2 = list[index].requires2;

        if(list[index].unlocked[p-1]){
            return false;
        }

        if(r1 == ""){
            return true;
        }else{
            
            for(int i = 0; i< list.Length; i++){
                if(list[i].identifier == r1){
                    if(!list[i].unlocked[p-1]){
                        return false;
                    }
                    break;
                }
            }

            if(r2 == ""){
                return true;
            }else{
                
                for(int i = 0; i< list.Length; i++){
                    if(list[i].identifier == r2){
                        if(!list[i].unlocked[p-1]){
                            return false;
                        }
                        break;
                    }
                }

            }

        }
        return true;
    }

}






//Max 2 dependencies
public class Skill{
    public string identifier = "";
    public bool[] unlocked = {false, false};
    public string requires = "";
    public string requires2 = "";
    int num = -1; //for the translation

    public Skill(int n, string id){
        identifier = id;
        num = n;
    }

    public Skill(int n, string id, string req){
        identifier = id;
        requires = req;
        num = n;
    }

    public Skill(int n, string id, string req, string req2){
        identifier = id;
        requires = req;
        requires2 = req2;
        num = n;
    }


    public void unlock(int p){
        unlocked[p-1] = true;
    }

    public bool hasUnlocked(int p){
        return unlocked[p-1];
    }
}