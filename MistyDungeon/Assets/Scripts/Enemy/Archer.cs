using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    public Sprite mainSprite;
    public Sprite reloadSprite;

    public GameObject arrowPrefab;
    public Sprite arrowSide;

    public Archer(int x, int y) : base(x, y){
        
    }


    public override void doTurn(Level l){
        //Archer Attacks if Player is in line and 2<=r<=5, moves away if closer, moves random if r>10, moves closer if further away, moves in line when in between
        //If there are multiple players it chooses the closest one or a  random one if the distance is the same

        //determine closest player
        //for now always player1

        int[] rx = {-1, -1, 0, 1, 1, 0};
        int[] ry = {0, 1, 1, 0, -1, -1};
        List<int> ropt = new List<int>();

        if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) < 2){
            //move away
            int d = -100000;
            int bx = 0, by = 0;
            for(int i = 0; i<6; i++){
                if(positionX + rx[i] >= 0 && positionX + rx[i] < l.size 
                    && positionY + ry[i] >= 0 && positionY + ry[i] < l.size
                    && l.map[positionX+rx[i],positionY+ry[i]].isWalkable()
                    && l.isUnoccupied(positionX+rx[i],positionY+ry[i])){

                    int tmpd = l.distance(positionX + rx[i], positionY + ry[i], l.player.positionX, l.player.positionY);
                    if(tmpd > d){
                        d = tmpd;
                        bx = positionX + rx[i];
                        by = positionY + ry[i];
                    }
                }
            }
            StartCoroutine(moveTo(bx,by,l));

        }else if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) <= 3){
            //move in line or attack
            if(l.inLine(positionX,positionY,l.player.positionX,l.player.positionY)){
                //attack
                StartCoroutine(attack(l.player.positionX,l.player.positionY,l));

            }else{
                //try move in line if close
                //move random
                for(int i = 0; i<6; i++){
                    if(positionX + rx[i] >= 0 && positionX + rx[i] < l.size 
                        && positionY + ry[i] >= 0 && positionY + ry[i] < l.size
                        && l.map[positionX+rx[i],positionY+ry[i]].isWalkable()
                        && l.inLine(positionX+rx[i],positionY+ry[i],l.player.positionX,l.player.positionY)
                        && l.isUnoccupied(positionX+rx[i],positionY+ry[i])){

                        ropt.Add(i);
                    }
                }

                //no in line option
                if(ropt.Count == 0){
                    for(int i = 0; i<6; i++){
                        if(positionX + rx[i] >= 0 && positionX + rx[i] < l.size 
                            && positionY + ry[i] >= 0 && positionY + ry[i] < l.size
                            && l.map[positionX+rx[i],positionY+ry[i]].isWalkable()
                            && l.isUnoccupied(positionX+rx[i],positionY+ry[i])){

                            ropt.Add(i);
                        }
                    }
                }

                int ran = Random.Range(0,ropt.Count);
                StartCoroutine(moveTo(positionX + rx[ran],positionY + ry[ran],l));
            }
            
            

        }else if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) <= 10){
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
        GameObject arrow = Instantiate<GameObject>(arrowPrefab);
        arrow.transform.position = transform.position;

        //Arrow standart; V: up, side: top left
        if(x != positionX){
            arrow.GetComponent<SpriteRenderer>().sprite = arrowSide;
        }

        int steps = 8;
        level.player.takeDamage("Killed by Archer");
        Vector3 step = level.map[x,y].tile.transform.position - level.map[positionX,positionY].tile.transform.position;
        step.z = 0f;
        for(int j = 0; j< steps ; j++){
            arrow.transform.position += step * (1f / (float)steps);
            yield return new WaitForSeconds(0.1f/(float)steps);
        }
        
        Destroy(arrow);
    }
}
