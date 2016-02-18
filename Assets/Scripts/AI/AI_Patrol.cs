using UnityEngine;
using System.Collections;

public class AI_Patrol : MonoBehaviour {
    
    /*
    Default values:
        -patrolDistance: 2.5
        -patrolSpeed: 10
        -pursuitSpeed: 15
        -inPursuit: false
        -facingLeft: true
    */
    
    public float patrolDistance;                //how large the enemy patrol distance is
    public float patrolSpeed;                   //how fast the enemy moves while patrolling
    public float pursuitSpeed;                  //how fast the enemy move while in pursuitSpeed
    public Transform groundChecker;             //Gameobject required, placed where you wish "ground" to be detected from
    public Transform blockChecker;              //Gameobject required, placed where you wish the side collision detector to be (works similar to groundchecker)
    public bool isGrounded = false;             //Check to see if we are grounded
    public bool isBlocked = false;              //Check to see if we are blocked
    public bool inPursuit = false;              //When in patrol-mode this remains false
    public bool facingLeft = true;              //Keeps track of which direction the enemy is facing
    public bool detectPlayer = false;

	private float patrolStartingX;
    private bool movingLeft = true;             //Keeps track of which drirection the enemy should be moving
    private bool hitground = false;             //Turns true when the enemy hits the ground
    
    
    // Use this for initialization
	void Start () {
	
	}
	
	void Update () {
	    //Casts a line between our ground checker gameobject and our player
        //If the floor is between us and the groundchecker, this makes "isGrounded" true
        isGrounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Platform"));
        isBlocked = Physics2D.Linecast(transform.position, blockChecker.position, 1 << LayerMask.NameToLayer("Platform"));
        //isBlocked = Physics2D.Linecast(transform.position, blockChecker.position, 1 << LayerMask.NameToLayer("Player"));
        
        //If we are grounded and not in pursuit run the patrol script
        if(isGrounded && !inPursuit){
          Patrol();  
        }

	}
    
    //When the enemy lands after being in the air this keeps track of the start of the patrol
    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.layer == 9 && !isGrounded){
            patrolStartingX = transform.position.x;
        }
    }
    
    //Handles the movement of the enemy when patrolling a sector
    void Patrol(){
        //When moveingLeft == true then we run this script to move left otherwise we move right
        if(movingLeft){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 10 * patrolSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }
        else{
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 10 * patrolSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);           
        }
        
        //Checks whether we should be moving left or right based on the patrol distance or by being blocked
        if((patrolStartingX - patrolDistance) > transform.position.x || isBlocked && movingLeft){
            movingLeft = false;
        }
        else if((patrolStartingX + patrolDistance) < transform.position.x || isBlocked && !movingLeft){
            movingLeft = true;
        }

        //checks which direction the enemy is moving and flips it to the correct side
        if (movingLeft && !facingLeft)
        {
            Flip();
        }
        else if (!movingLeft && facingLeft)
        {
            Flip();
        }        
    }
    
    void Flip(){
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
