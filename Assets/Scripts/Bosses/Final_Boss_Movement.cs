using UnityEngine;
using System.Collections;

public class Final_Boss_Movement : MonoBehaviour {
    
    public GameObject Player;
    public float speed;
    public float distanceToChange;
    
    private Vector2 position1;
    private Vector2 position2;
    private Vector2 position3;
    private Vector2 position4;
    private Vector2 position5;
    private int stage;
    private int toPosition;
    private bool waterStageRight;
    private bool airsStageRight;
    private bool earthStageUp;


	// Use this for initialization
	void Start () {
        stage = 0;
        toPosition = 0;
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
        }
        
    }
    
//===[Stage Movement]===================================================================================================================================
    
    private void StageSelector(int stageNum){
        int positionTest;
        if(stageNum == 1){
            positionTest = Stage1Movement();
        }else{
            //do nothing
        }
    }
    
    //The fire stage
    private int Stage1Movement(){
        if(toPosition <= 0){
            transform.position = Vector2.MoveTowards(transform.position, position1, speed);
            toPosition = 1;
        }else if(toPosition == 1){
            transform.position = Vector2.Lerp(transform.position, position1, speed);
            if(Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(position1.x)) < distanceToChange && 
            Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(position1.y)) < distanceToChange){
                toPosition = 2;
            }else{
                toPosition = 1;
            }
        }else if(toPosition == 2){
            transform.position = Vector2.Lerp(transform.position, position2, speed);
            if(Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(position2.x)) < distanceToChange && 
            Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(position2.y)) < distanceToChange){
                toPosition = 3;
            }else{
                toPosition = 2;
            }
        }else{
            transform.position = Vector2.Lerp(transform.position, position3, speed);
            if(Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(position3.x)) < distanceToChange && 
            Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(position3.y)) < distanceToChange){
                toPosition = 1;
            }else{
                toPosition = 3;
            }
        }
        
        return toPosition;
    }
    
    //The water stage
    private int Stage2Movement(){
        
        return toPosition;
    }
    
    //The earth stage
    private int Stage3Movement(){
        
        return toPosition;
    }
    
    //The air stage
    private int Stage4Movement(){
        
        return toPosition;
    }

//===[Collisions and Colliders]======================================================================================================================================    
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player" && stage < 1){
            stage = 1;
        }
    }
    
    
//===[Coroutines]================================================================================================================================================================

    IEnumerator stage1MoveCo(float delayTime){
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime=Time.time; // Time.time contains current frame time, so remember starting point
        while(Time.time-startTime <= 1.5){ // until 1.5 second(s) passed
            transform.position=Vector3.Lerp(transform.position,position1,Time.time-startTime); // lerp from A to B in one second
            yield return null;
        }
        
    }    
}
