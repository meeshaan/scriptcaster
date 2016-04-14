using UnityEngine;
using System.Collections;

public class AI_PlayerDetection : MonoBehaviour {

    public Transform sightStart;
    public Transform sightEnd;
    public float startingAngle;
    public float arcDegrees;
    public float timePeriod;
    public bool isDetected = false;
    public bool debugCircle;
    public float radius;
    
    private float _Time;

    
    private bool sweepingUp = true;
    public bool inRange = false;
   
    
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Gizmos.DrawSphere(sightStart.position, radius);
        //DebugExtension.DrawCircle(sightStart.position, Color.gray, radius);
        DebugExtension.DebugCircle(sightStart.position, sightStart.up, Color.gray, radius);
        Raycasting();
        Behaviors();
	}
    
    void OnDrawGizmos(){
        if(debugCircle) DebugExtension.DrawCircle(sightStart.position, sightStart.up, Color.gray, radius);
    }
    
    void Raycasting(){
        if(!isDetected) {
            visionSweep();
        }
        else{
            detectionBubble();
        }
    }
    
    void Behaviors(){
        
    }
    
    //Function that creates a linecast and rotates the sight line empty game object.
    //By doing this we rotate the vision linecast in arc to detect the player.
    void visionSweep(){
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        
        //Creates an array that holds everything that is detected by the linecast;
        RaycastHit2D[] rayHitArray = Physics2D.LinecastAll(sightStart.position, sightEnd.position);
        
        isDetected = clearSight(rayHitArray);
        
        if(isDetected){
            inRange = true;
            //Debug.Log("In Range");
        }
        
        _Time = _Time + Time.deltaTime;
        float phase = Mathf.Sin(_Time / timePeriod);
        transform.localRotation = Quaternion.Euler( new Vector3(0, 0, (phase * arcDegrees) + -startingAngle));
    }
    
    void detectionBubble(){
        
        inRange = Physics2D.OverlapCircle(sightStart.position, radius, 1 << LayerMask.NameToLayer("Player"));
        if(!inRange){
            //Debug.Log("Not Detected");
            isDetected = false;
        }
        else{
            //Debug.Log("Still Detected");
        }
    }
    
    
    //Function that takes in all of the RaycastHit2D's in the LinecastAll and checks to make sure the player is not obstructed
    //Only checks the tags of Gameobjects with 2D colliders.
    //Enemy and camerabounds colliders should not be taken into account when dealing with line of sight
    bool clearSight(RaycastHit2D[] hits){
        
        foreach (RaycastHit2D hit in hits)
        {           
            // ignore the enemy's own colliders (and other enemies) and the camera bounds
            if (hit.transform.tag == "Enemy")
                continue;
                
            if (hit.transform.tag == "camerabounds")
                continue;
            if (hit.transform.tag == "Untagged")
                continue;
            
            Debug.Log(hit.transform.tag);
            // if anything other than the player is hit then it must be between the player and the enemy's eyes (since the player can only see as far as the player)
            if (hit.transform.tag != "Player")
            {
                Debug.Log(hit.transform.tag);
                return false;
            }
            
            //if we get here then the player is not obstructed
            if(hit.transform.tag == "Player"){
                return true;
            }
        }
        
        return false;
    }
}
