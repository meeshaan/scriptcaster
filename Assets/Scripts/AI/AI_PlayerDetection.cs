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
        isDetected = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
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
}
