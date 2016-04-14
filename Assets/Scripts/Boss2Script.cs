using UnityEngine;
using System.Collections;

public class Boss2Script : MonoBehaviour {
    public GameObject Player;
    public float moveSpeed;
   
    private Vector2 target;
    public bool BossFight2 = false;
    public GameObject startPos;
    public bool FacingLeft; 
    
    
    
    
	// Use this for initialization
	void Start () {
	   Player = GameObject.FindGameObjectWithTag("Player");
       startPos = GameObject.Find("BossStartPos");
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position == startPos.transform.position){
            BossFight2 = false;
            Flip();    
        }
        if (BossFight2 == false){
            //Flip();
            target = Player.transform.position;
            }
        transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed*Time.deltaTime);
	   
	}
   void OnCollisionEnter2D(Collision2D c)
        {
        
        if(c.gameObject.name == "earthcap"){
            BossFight2 = true;
            target = startPos.transform.position;
            Flip();
            transform.GetComponent<Renderer>().material.color = Color.yellow;
        }
         
}
    void Flip()
    {
        FacingLeft = !FacingLeft;
        gameObject.transform.Rotate(0,180,0);
    }
}