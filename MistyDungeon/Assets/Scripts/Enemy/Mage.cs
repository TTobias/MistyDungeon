using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Enemy
{
    public Sprite mainSprite;
    public Sprite reloadSprite;

    public GameObject spellPrefab;
    public int cooldown = 0;


    public Mage(int x, int y) : base(x, y){
    }


    public override void initialize(){
        Debug.Log("Mage Spawned");
        cooldown = Random.Range(0,2);

        if(cooldown == 0){
            GetComponent<SpriteRenderer>().sprite = mainSprite;
        }else{
            GetComponent<SpriteRenderer>().sprite = reloadSprite;
        }
    }


    public override void doTurn(Level l){
        //Mage attacks soecific if r<=5, attacks every second and doesn't move then, moves random if r>10
        //If there are multiple players it chooses the closest one or a  random one if the distance is the same

        //determine closest player
        //for now always player1


        int[] rx = {-1, -1, 0, 1, 1, 0};
        int[] ry = {0, 1, 1, 0, -1, -1};
        List<int> ropt = new List<int>();

        if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) <= 10){
            //check attack
            if(cooldown <= 0){

                int attempt = 0;
                //attack
                if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) <= 5){
                    //player attack
                    int xx = 0;
                    int yy = 0;
                    do{
                        int r1 = Random.Range(0,6), r2 = Random.Range(0,6);
                        xx = positionX + rx[r1]+rx[r2];
                        yy = positionY + ry[r1]+ry[r2];
                        attempt++;
                        if(attempt >= 15){
                            break;
                        }
                    }while(xx < 0 || yy < 0 || xx >= l.size ||yy >= l.size || !l.map[xx,yy].isWalkable() || !l.isUnoccupied(xx,yy) || (l.player.positionX == xx && l.player.positionY == yy) || l.distance(xx,yy,l.player.positionX,l.player.positionY) > l.distance(positionX,positionY,l.player.positionX,l.player.positionY));

                    if(attempt < 15){
                        StartCoroutine(attack(xx,yy,l));
                    }

                }else{
                    int xx = 0;
                    int yy = 0;
                    do{
                        int r1 = Random.Range(0,6), r2 = Random.Range(0,6);
                        xx = positionX + rx[r1]+rx[r2];
                        yy = positionY + ry[r1]+ry[r2];
                        attempt++;
                        if(attempt >= 15){
                            break;
                        }
                    }while(xx < 0 || yy < 0 || xx >= l.size ||yy >= l.size || !l.isUnoccupied(xx,yy) || !l.map[xx,yy].isWalkable());

                    if(attempt < 15){
                        StartCoroutine(attack(xx,yy,l));
                    }
                }

            }else{
                if(l.distance(positionX,positionY,l.player.positionX,l.player.positionY) > 1){
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
                }else{
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
                }
            }

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


        cooldown--;
        if(cooldown == 0){
            GetComponent<SpriteRenderer>().sprite = mainSprite;
        }else{
            GetComponent<SpriteRenderer>().sprite = reloadSprite;
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
        cooldown = 2;

        Spell s = Instantiate<GameObject>(spellPrefab).GetComponent<Spell>();
        s.xPos = x;
        s.yPos = y;
        s.timer = 1;
        s.resetColor();
        s.transform.position = level.map[x,y].tile.transform.position;
        level.addSpell(s);
        yield return new WaitForSeconds(0f);
    }
}
