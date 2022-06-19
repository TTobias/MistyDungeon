using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public Skeleton(int x, int y) : base(x, y){
        
    }


    public override void doTurn(Level l){
        //Skeleton move towards the player if their hex distance is <= 8, attack if hexdistance = 1 and move randomly otherwise
        //If there are multiple players it chooses the closest one or a  random one if the distance is the same

        //determine closest player
        //for now always player1

        int[] rx = {-1, -1, 0, 1, 1, 0};
        int[] ry = {0, 1, 1, 0, -1, -1};
        List<int> ropt = new List<int>();

        if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) == 1){
            //attack
            StartCoroutine(attack(l.player.positionX, l.player.positionY,l));
            //Debug.Log("Skeleton attacks");

        }else if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) <= 8){
            //move closer
            int d = 100000;
            int bx = 0, by = 0;
            for(int i = 0; i<6; i++){
                if(positionX + rx[i] >= 0 && positionX + rx[i] < l.size 
                    && positionY + ry[i] >= 0 && positionY + ry[i] < l.size
                    && l.map[positionX+rx[i],positionY+ry[i]].isWalkable()
                    && l.isUnoccupied(positionX+rx[i],positionY+ry[i])){

                    int tmpd = l.distance(positionX + rx[i], positionY + ry[i], l.player.positionX, l.player.positionY);
                    if(tmpd < d){
                        d = tmpd;
                        bx = positionX + rx[i];
                        by = positionY + ry[i];
                    }
                }
            }
            StartCoroutine(moveTo(bx,by,l));
            //Debug.Log("Skeleton moves closer");

        }else{
            //move random
            for(int i = 0; i<6; i++){
                if(positionX + rx[i] >= 0 && positionX + rx[i] < l.size 
                    && positionY + ry[i] >= 0 && positionY + ry[i] < l.size
                    && l.map[positionX+rx[i],positionY+ry[i]].isWalkable()
                    && l.isUnoccupied(positionX+rx[i],positionY+ry[i])){

                    ropt.Add(i);
                }
            }

            int ran = Random.Range(0,ropt.Count);
            StartCoroutine(moveTo(positionX + rx[ran],positionY + ry[ran],l));
            //Debug.Log("Skeleton moves random");
        }
    }

    IEnumerator moveTo(int x, int y, Level level){
        //make move
        //onCooldown = true;
        int prevX = positionX;
        int prevY = positionY;
        positionX = x;
        positionY = y;

        int steps = 10;
        Vector3 step = level.map[x,y].tile.transform.position - level.map[prevX,prevY].tile.transform.position;
        step.z = 0f;
        for(int i = 0; i< steps ; i++){
            transform.position += step * (1f / (float)steps);
            yield return new WaitForSeconds(0.2f/(float)steps);
        }

        //fix position
        transform.position = level.map[x,y].tile.transform.position + offset;

        //onCooldown = false;
    }

    IEnumerator attack(int x, int y, Level level){
        int prevX = positionX;
        int prevY = positionY;
        positionX = x;
        positionY = y;

        int steps = 4;
        Vector3 step = level.map[x,y].tile.transform.position - level.map[prevX,prevY].tile.transform.position;
        step.z = 0f;
        for(int j = 0; j< steps ; j++){
            transform.position += step * (1f / (float)steps);
            yield return new WaitForSeconds(0.1f/(float)steps);
        }
        level.player.takeDamage("Killed by Skeleton Warrior");
                    
        step = -step;
        for(int j = 0; j< steps ; j++){
            transform.position += step * (1f / (float)steps);
            yield return new WaitForSeconds(0.1f/(float)steps);
        }
            
        //fix position
        transform.position = level.map[x,y].tile.transform.position + offset;
    }
}
