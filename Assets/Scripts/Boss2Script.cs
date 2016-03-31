using UnityEngine;
using System.Collections;

public class Boss2Script : MonoBehaviour {
    public GameObject Player;
    public float moveSpeed;
   
    private Vector2 target;
    

	// Use this for initialization
	void Start () {
	   Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        target = Player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed*Time.deltaTime);
	
	}
}
