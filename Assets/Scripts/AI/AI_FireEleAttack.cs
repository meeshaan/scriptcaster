using UnityEngine;
using System.Collections;

public class AI_FireEleAttack : MonoBehaviour {
    
    public Transform sightStart;
    public Transform sightEnd;
    public bool isDetected = false;

	void Start () {
	
	}
	
	void Update () {
	    if(isDetected = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"))){
            Attack();
        }
	}
    
    void Attack () {
        
    }
}
