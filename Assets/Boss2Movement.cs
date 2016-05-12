using UnityEngine;
using System.Collections;

public class Boss2Movement : MonoBehaviour {

    public Transform groundchecker;
    //public Transform blockChecker;
    public bool isGrounded = false;
    //public bool isBlocked = false;
    public bool movingTowardsPlayer = true;
    public bool facingLeft = true;
    public bool facingPlayer = true;
    public GameObject Player;
    public GameObject Boss;
    public float moveSpeed;
    private GameObject wall;
    public GameObject lazerStartPos;
    public GameObject Lazer;
    public bool Fighting = true;
    //public bool detectPlayer = true;
    
    
    //public bool test = false;
    
    public bool firing = false;
    public Vector2 Target;
    public GameObject leftTarget;
    public GameObject rightTarget;
    
    private bool movingLeft = true;
    

    //private bool hitGround = false;
	// Use this for initialization
	void Start () {
	       Player = GameObject.Find("Player");
           Boss = this.gameObject;
           Target = leftTarget.transform.position;
           firing = false;
           facingPlayer = true;
           InvokeRepeating("shoot",2f,5f);

           
           
           
          
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.Linecast(transform.position, groundchecker.position, 1 << LayerMask.NameToLayer("Platform"));
        transform.position = Vector2.MoveTowards(transform.position, Target, moveSpeed*Time.deltaTime);
        checkForPlayer();
	}
    
    void FixedUpdate(){
       
        if (isGrounded)
        {
            Pursuit();
            //checkForPlayer();
        }
            
    }
    
    void Pursuit(){
        if(Player.transform.position.x < Boss.transform.position.x ){
            if (facingLeft == true){
                facingPlayer = true;
            }
            else if (facingLeft == false)
            {
                facingPlayer = false;
            }
        }
        else if(Player.transform.position.x > Boss.transform.position.x ){
            if (facingLeft == true)
            {
                facingPlayer = false;
            }
            else if (facingLeft == false)
            {
                facingPlayer = true;
            }  
         }
    }
    
    
     void OnCollisionEnter2D(Collision2D c)
        {
            if(c.gameObject.name == "leftTarget"){
                Flip();
                Target = rightTarget.transform.position;
                //Pursuit();
               
                
            }
            else if(c.gameObject.name == "rightTarget")
            {
                Flip();
                Target = leftTarget.transform.position;
                //Pursuit();
            }
            else if(c.gameObject.name == "earthcap")
            {
               StartCoroutine(WaitOnWall());
            }
            else if(c.gameObject.name == "Player"){
                Flip();
                Pursuit();
                findTarget();
            }
        }
    IEnumerator Waiting(){
        
        yield return new WaitForSeconds(1); 
        findTarget();
        //Pursuit(); 
        //movingTowardsPlayer = true; 
    }
    
	  void Flip(){
        gameObject.transform.Rotate(0,180,0); 
        facingLeft = !facingLeft;
        StartCoroutine(Waiting());
      }
      IEnumerator WaitOnWall(){
       yield return new WaitForSeconds(2);
       wall = GameObject.Find("earthcap");
       Destroy(wall);
       
    }
    void shoot(){
        if(facingPlayer && movingTowardsPlayer){
            Transform lazer = (Transform)Instantiate(Lazer, lazerStartPos.gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
        }
    }
    
    void checkForPlayer()
    {
            if(!facingPlayer){
                movingTowardsPlayer = false;
             if(facingLeft && Player.transform.position.x > Boss.transform.position.x){
                 
                  //StartCoroutine(Waiting());
                  Flip();
                  
             }
             else if( !facingLeft && Player.transform.position.x < Boss.transform.position.x){
                 
                 //StartCoroutine(Waiting());
                 Flip(); 
             } 
            
        else
        {
            movingTowardsPlayer = true;
            //Pursuit();
        }
       }
    }
    void findTarget(){
       
       
        if(facingLeft == true)
            Target = leftTarget.transform.position;
        else
            Target = rightTarget.transform.position;
        
    }
    

}
