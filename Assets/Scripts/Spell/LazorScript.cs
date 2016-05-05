using UnityEngine;
using System.Collections;

public class LazorScript : MonoBehaviour {

    private Vector2 lazerPosition;
    public GameObject wall;
    public Vector2 lazerStartPos;
    public Vector2 target;
    public float moveSpeed = 20;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        transform.GetComponent<Renderer>().material.color =Color.red;
        //target = Player.transform.position;
        if (GameObject.Find ("earthcap") == true){
            wall = GameObject.Find("earthcap");
            target = wall.transform.position;
       }
       else
       {
          target = Player.transform.position;
       }
	}
	
	// Update is called once per frame
	void Update () {
	           transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed*Time.deltaTime);
	           if(transform.position.x == target.x)
                Destroy(this.gameObject);
    
    }
     void OnCollisionEnter2D(Collision2D c)
        {
        
        if(c.gameObject.name == "earthcap"){
            wall = GameObject.Find("earthcap");
            Destroy(wall);
            Destroy(this.gameObject);
        }
       
       if(c.gameObject.name != "Boss2"){
            Destroy(this.gameObject);
        }         
    }
}
