using UnityEngine;
using System.Collections;

public class AI_PlayerDetection : MonoBehaviour {

    public Transform sightStart;
    public Transform sightEnd;
    public float startingAngle;
    public float arcDegrees;
    public float timePeriod;
    public bool isDetected = false;
    public float radius;
    
    private float _Time;

    
    private bool sweepingUp = true;
   
    
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Gizmos.DrawSphere(sightStart.position, radius);
        Physics2D.CircleCast(sightStart.position, 10,);
        Raycasting();
        Behaviors();
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
        
        _Time = _Time + Time.deltaTime;
        float phase = Mathf.Sin(_Time / timePeriod);
        transform.localRotation = Quaternion.Euler( new Vector3(0, 0, (phase * arcDegrees) + -startingAngle));
    }
    
    void detectionBubble(){
        
    }
}
