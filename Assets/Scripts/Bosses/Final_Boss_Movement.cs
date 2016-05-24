using UnityEngine;
using System.Collections;

public class Final_Boss_Movement : MonoBehaviour {
    
    public GameObject Player;
    public GameObject bossManager;
    public float speed;
    public float distanceToChange;
    
    private Vector2 position1;
    private Vector2 position2;
    private Vector2 position3;
    private Vector2 position4;
    private Vector2 position5;
    private int stage;
    private int toPosition;
    private float timeToDelay;
    private bool waterStageRight;
    private bool airsStageRight;
    private bool earthStageUp;
    private bool inCoroutine;
    private bool readyToSwitch;


	// Use this for initialization
	void Start () {
        stage = 1;
        toPosition = 0;
        timeToDelay = 0;
        inCoroutine = false;
        readyToSwitch = true;
        waterStageRight = true;
        airsStageRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	   
	}
    void FixedUpdate(){
        CalculatePositions(stage);
        StageSelector(stage);
    }
    
    //calulates the new positions the boss must travel to based on player movement
    private void CalculatePositions(int stageNum){
        if(stageNum == 1){
            position1 = new Vector2(Player.transform.position.x + 6, Player.transform.position.y + 5);
            position2 = new Vector2(Player.transform.position.x + 9, Player.transform.position.y + 1);
            position3 = new Vector2(Player.transform.position.x + 12, Player.transform.position.y + 5);
        }else if (stageNum == 2){
            position1 = new Vector2(Player.transform.position.x, Player.transform.position.y + 6);
            position2 = new Vector2(Player.transform.position.x + 6, Player.transform.position.y + 5);
            position3 = new Vector2(Player.transform.position.x + 9, Player.transform.position.y + 1);
            position4 = new Vector2(Player.transform.position.x - 6, Player.transform.position.y + 5);
            position5 = new Vector2(Player.transform.position.x - 9, Player.transform.position.y + 1);
        }else if(stageNum == 3){
            position1 = new Vector2(Player.transform.position.x + 9, Player.transform.position.y + 7);
            position2 = new Vector2(Player.transform.position.x + 9, Player.transform.position.y + 1);
        }else if(stageNum == 4){
            position1 = new Vector2(Player.transform.position.x, Player.transform.position.y + 6);
            position2 = new Vector2(Player.transform.position.x + 10, Player.transform.position.y + 3);
            position3 = new Vector2(Player.transform.position.x + 2, Player.transform.position.y + 1);
        }
        
    }
    
//===[Stage Movement]===================================================================================================================================
    
    private void StageSelector(int stageNum){
        if(stageNum == 1){
            Stage1Movement();
        }else if(stageNum == 2){
            Stage2Movement();
        }else if(stageNum == 3){
            Stage3Movement();
        }else if(stageNum == 4){
            Stage4Movement();
        }
        else{
            //do nothing
        }
    }
    
    //The fire stage
    private int Stage1Movement(){
        if(toPosition <= 0){
            transform.position = Vector2.MoveTowards(transform.position, position1, speed);
            toPosition = 1;
        }else if(toPosition == 1){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position1MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 2;
            }
        }else if(toPosition == 2){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 2.5f;
                StartCoroutine("position2MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 3;
            }
        }else{
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position3MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 1;
            }
        }
        return toPosition;
    }
    
    //The water stage
    private int Stage2Movement(){
        if(toPosition <= 0){
            transform.position = Vector2.MoveTowards(transform.position, position1, speed);
            toPosition = 1;
        }else if(toPosition == 1){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position1MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                
                //Decides which direction to travel
                if(waterStageRight){    
                    toPosition = 2;
                }else{
                    toPosition = 4;
                }
            }
        }else if(toPosition == 2){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position2MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                
                if(waterStageRight){    
                    toPosition = 3;
                }else{
                    toPosition = 1;
                }
            }
        }else if(toPosition == 3){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 2.5f;
                StartCoroutine("position3MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 1;
                if(waterStageRight){
                    waterStageRight = false;    
                    toPosition = 2;
                }else{
                    toPosition = 2;
                }
            }
        }else if(toPosition == 4){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position4MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 1;
                if(waterStageRight){    
                    toPosition = 1;
                }else{
                    toPosition = 5;
                }
            }
        }else if(toPosition == 5){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 2.5f;
                StartCoroutine("position5MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 1;
                if(waterStageRight){
                    toPosition = 4;
                }else{
                    waterStageRight = true; 
                    toPosition = 4;
                }
            }
        }
        return toPosition;
    }
    
    //The earth stage
    private int Stage3Movement(){
        if(toPosition <= 0){
            transform.position = Vector2.MoveTowards(transform.position, position1, speed);
            toPosition = 1;
        }else if(toPosition == 1){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position1MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 2;
            }
        }else if(toPosition == 2){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 2.5f;
                StartCoroutine("position2MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 1;
            }
        }
        return toPosition;
    }
    
    //The air stage
    private int Stage4Movement(){
        
        if(toPosition <= 0){
            transform.position = Vector2.MoveTowards(transform.position, position1, speed);
            toPosition = 1;
        }else if(toPosition == 1){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position1MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                
                //Decides which direction to travel
                if(airsStageRight){    
                    toPosition = 2;
                }else{
                    airsStageRight = true;
                    toPosition = 2;
                }
            }
        }else if(toPosition == 2){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 1;
                StartCoroutine("position2MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                
                if(airsStageRight){    
                    toPosition = 3;
                }else{
                    toPosition = 1;
                }
            }
        }else if(toPosition == 3){
            if(!inCoroutine && readyToSwitch){
                inCoroutine = true;
                readyToSwitch = false;
                timeToDelay = 2.5f;
                StartCoroutine("position3MoveCo", timeToDelay);
            }else if(!inCoroutine && !readyToSwitch){
                readyToSwitch = true;
                toPosition = 1;
                if(airsStageRight){
                    airsStageRight = false;    
                    toPosition = 2;
                }else{
                    toPosition = 2;
                }
            }
        }
        return toPosition;
    }
//===[Supporting Functions]======================================================================================================================================    

    public void ChooseRandomStage(){
        float randomStageNum = Random.Range(1,5);
        stage = (int) randomStageNum;
        Debug.Log(stage);
    }
    
    public void StartInvincibility(float duration){
        StartCoroutine("isInvicible", duration);
    }
    
    
//===[Collisions and Colliders]======================================================================================================================================    
    
    void OnTriggerEnter2D(Collider2D col){
        /*if(col.gameObject.tag == "Player" && stage < 1){
            ChooseRandomStage();
            //stage = 1;
        }*/
    }
    
    
//===[Coroutines]================================================================================================================================================================

//--Position Movement Coroutines
    IEnumerator position1MoveCo(int delayTime){
        //yield return new WaitForSeconds(delayTime); // start at time X
        float startTime=Time.time; // Time.time contains current frame time, so remember starting point
        while(Time.time-startTime <= delayTime){ // until 1.5 second(s) passed
            transform.position=Vector3.Lerp(transform.position,position1,Time.time-startTime); // lerp from A to B in one second
            yield return null;
        }
        inCoroutine = false;
    }
    IEnumerator position2MoveCo(int delayTime){
        //yield return new WaitForSeconds(delayTime); // start at time X
        float startTime=Time.time; // Time.time contains current frame time, so remember starting point
        while(Time.time-startTime <= delayTime){ // until 1.5 second(s) passed
            transform.position=Vector3.Lerp(transform.position,position2,Time.time-startTime); // lerp from A to B in one second
            yield return null;
        }
        inCoroutine = false;
    }
    IEnumerator position3MoveCo(float delayTime){
        //yield return new WaitForSeconds(delayTime); // start at time X
        float startTime=Time.time; // Time.time contains current frame time, so remember starting point
        while(Time.time-startTime <= delayTime){ // until 1.5 second(s) passed
            transform.position=Vector3.Lerp(transform.position,position3,Time.time-startTime); // lerp from A to B in one second
            yield return null;
        }
        inCoroutine = false;
    }
    IEnumerator position4MoveCo(float delayTime){
        //yield return new WaitForSeconds(delayTime); // start at time X
        float startTime=Time.time; // Time.time contains current frame time, so remember starting point
        while(Time.time-startTime <= delayTime){ // until 1.5 second(s) passed
            transform.position=Vector3.Lerp(transform.position,position4,Time.time-startTime); // lerp from A to B in one second
            yield return null;
        }
        inCoroutine = false;
    }
    IEnumerator position5MoveCo(float delayTime){
        //yield return new WaitForSeconds(delayTime); // start at time X
        float startTime=Time.time; // Time.time contains current frame time, so remember starting point
        while(Time.time-startTime <= delayTime){ // until 1.5 second(s) passed
            transform.position=Vector3.Lerp(transform.position,position5,Time.time-startTime); // lerp from A to B in one second
            yield return null;
        }
        inCoroutine = false;
    }
    
//--Invincibility Coroutine
    IEnumerator isInvicible(float duration){
        bossManager.GetComponent<Final_Boss_manager>().isInvicible = true;
        this.GetComponent<Animator>().SetBool("invincible", true);
        yield return new WaitForSeconds(duration);
        this.GetComponent<Animator>().SetBool("invincible", false);
        bossManager.GetComponent<Final_Boss_manager>().isInvicible = false;
    }           
}
