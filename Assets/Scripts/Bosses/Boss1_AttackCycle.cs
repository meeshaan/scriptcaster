using UnityEngine;
using System.Collections;

public class Boss1_AttackCycle : MonoBehaviour {
    
    public GameObject horn1;
    public GameObject horn2;
    public GameObject headCollider;
    public Transform groundChecker;
    public GameObject shockwave;
    public GameObject xbufferfront;
    public GameObject xbufferback;
    public GameObject bossDontFlip;
    public Sprite greenHead;
    public Sprite redHead;
    public bool facingLeft;
    public float backupSpeed;
    public float attackSpeed;
    public float waitseconds;
    public float radius; //determines the radius of the detection bubble will be halved after detection to be used for EarlyAttackCheck
    public bool isGrounded = true;
    public bool attackStarted;
    
    
    private GameObject player;
    private GameObject boss1_manager;
    private GameObject head;
    private GameObject gameManager;
    private Vector3 wallPosition;
    private bool attacking;
    private bool isFalling;
    private bool stunned;
    private bool isDetected;
    private bool moving;        //used for determining if the boss should be moving at all
    private bool movingLeft;    //used for determining direction
    private bool rotating;
    private bool quickAttacking;
    private bool inCoroutine;
    private bool wallEarlyDetection;
    public bool dontattack;
    private bool cooldownrunning;
    private bool AfterFlingCanFlip; //used to make sure the boss doesn't immediately flip when a player is flung off its back
    private bool canShockwave;
    private bool isAngry;
    private bool canflip;
    private bool canmove;
    

//=====MonoBehaviour Functions================================================================================================
	// Use this for initialization
	void Start () {
	   boss1_manager = GameObject.Find("Boss1Manager");
       player = GameObject.Find("Player");
       head = GameObject.Find("Boss1 Head");
       gameManager = GameObject.Find("GameManager");
       stunned = boss1_manager.GetComponent<Boss1_Manager>().stunned;
       attacking = boss1_manager.GetComponent<Boss1_Manager>().isattacking;
       facingLeft = true;
       moving = true;
       AfterFlingCanFlip = true;
       canShockwave = true;
       isFalling = false;
       isDetected = false;
       attackStarted = false;
       dontattack = false;
       inCoroutine = false;
       rotating = false;
       wallEarlyDetection = false;
       horn1.tag = "Untagged";
       horn2.tag = "Untagged";
	}
    
    void OnCollisionEnter2D (Collision2D col) {
        
        if(col.gameObject.tag == "spell" && attacking == true && boss1_manager.GetComponent<Boss1_Manager>().health > 75 && col.gameObject.transform.position.x != wallPosition.x){
            boss1_manager.GetComponent<Boss1_Manager>().stunned = true;
            attacking = false;
            stunned = true;
            //rotating = true;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "spell" && attacking == true && boss1_manager.GetComponent<Boss1_Manager>().health < 75 && isAngry){
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "bubble" && attacking == true && boss1_manager.GetComponent<Boss1_Manager>().health < 75 && isAngry){
            SetAnger(false);
        }
        else if (col.gameObject.tag == "spell" && attacking == true && boss1_manager.GetComponent<Boss1_Manager>().health < 75 && !isAngry){
            boss1_manager.GetComponent<Boss1_Manager>().stunned = true;
            attacking = false;
            stunned = true;
            //rotating = true;
            Destroy(col.gameObject);
        }        
    }
    
    void OnTriggerEnter2D(Collider2D col){
        
        if (col.gameObject.tag == "Player" && quickAttacking == true){
            bool addforcetoboss = attacking;
            attacking = false;
            int playerfacing;
            if(facingLeft){
                playerfacing = -1;
            }
            else{
                playerfacing = 1;
            }
            if(!gameManager.GetComponent<GameManager>().playerFlung){
                FlingPlayer(playerfacing * 500, 300 );
            }
            if(addforcetoboss){
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-playerfacing * 500, 300),ForceMode2D.Impulse);
                StartCoroutine(afterHitWait());
            }
        }
    }
	
//=====Update Function=================================================================================================
    
	// Update is called once per frame
	void FixedUpdate () {
       canflip = bossDontFlip.GetComponent<BossFlipScript>().shouldFlip;
       canmove = bossDontFlip.GetComponent<BossFlipScript>().shouldMove;
        
	   if(attackStarted){
           wallEarlyDetection = Physics2D.Linecast(transform.position, GameObject.Find("detectorEnd").transform.position, 1 << LayerMask.NameToLayer("PlayerWall"));
           if(wallEarlyDetection){
               wallPosition = GameObject.FindWithTag("spell").transform.position;
           }
           BackingUp();
       }
       else if(attacking){
           ChargeAttack();
       }
       else if(boss1_manager.GetComponent<Boss1_Manager>().stunned){
           Stunned();
       }
       else if (!isDetected){
           //idle;
           Detect();
       }
       
       else{
           //do nothing
       }
	}

    void Update (){
        
        //code that determines the color of the head sprite
        if(isAngry){
            head.GetComponent<SpriteRenderer>().sprite = redHead;
        }
        else if(!isAngry){
            head.GetComponent<SpriteRenderer>().sprite = greenHead;
        }
        
        if(!boss1_manager.GetComponent<Boss1_Manager>().stunned && stunned){
            StopCoroutine("waitToFlip");
            StartCoroutine("waitToFlip");
            stunned = false;
            StopCoroutine("stunTime");
            attackStarted = true;
            inCoroutine = false;
            head.transform.eulerAngles = new Vector3(0,0,0);
        }
        
        isGrounded = Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Platform"));
        if(!isGrounded){
            isFalling = true;
        }
        else if(isGrounded && isFalling){
            isFalling = false;
            //Shockwave();
        }
        
        
        if(!stunned){
            if(GameObject.Find("BossBackTrigger").GetComponent<boss_back_detection>().playerOnBack == true && !gameManager.GetComponent<GameManager>().playerFlung){
                if(facingLeft){
//                    Debug.Log("On Back Fling");
                    if(AfterFlingCanFlip){
                        StartCoroutine("waitToFlip");
                    }
                    else{
                        StopCoroutine("waitToFlip");
                        StartCoroutine("waitToFlip");
                    }
                    FlingPlayer(300, 400);
                }
                else{
                    Debug.Log("On Back Fling");
                    
                    if(AfterFlingCanFlip){
                        StartCoroutine("waitToFlip");
                    }
                    else{
                        StopCoroutine("waitToFlip");
                        StartCoroutine("waitToFlip");
                    }
                    
                    FlingPlayer(-300, 400);
                }
            }
        }
    }

//=====Attack Cycle Functions=================================================================================================

    
    //The Boss' windup before his charge attack
    //He will attack early if the player gets too close
    void BackingUp () {
        
        if(!inCoroutine){
            inCoroutine = true;
            StartCoroutine(backupTime());
        }
        
        //Check to make sure the player isn't too close
        TooCloseAttack();
        
        //the true and false are swapped here because the boss is backing away from the player
        if((GameObject.Find("Player").transform.position.x > xbufferfront.transform.position.x  && GameObject.Find("Player").transform.position.x < xbufferback.transform.position.x)
        || (GameObject.Find("Player").transform.position.x < xbufferfront.transform.position.x && GameObject.Find("Player").transform.position.x > xbufferback.transform.position.x)){
            moving = false; //player is in the bufferzone 
        }
        else if(GameObject.Find("Player").transform.position.x > xbufferfront.transform.position.x && GameObject.Find("Player").transform.position.x > transform.position.x){

            moving = true;
            movingLeft = true;
        }
        else if(GameObject.Find("Player").transform.position.x < xbufferfront.transform.position.x && GameObject.Find("Player").transform.position.x < transform.position.x){
            movingLeft = false;
            moving = true;
        }
        else{
            moving = false;
        }
        
        
        
        //makes sure the boss is moving in the opposite direction from where its facing
        if (movingLeft && facingLeft && moving && dontattack && canflip)
        {
            Flip();
        }
        else if (!movingLeft && !facingLeft && moving && dontattack && canflip)
        {
            Flip();
        }
        
        //backs the boss up at a reduced speed.
        if(movingLeft && moving && canmove){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 10 * backupSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!movingLeft && moving && canmove){
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 10 * backupSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);           
        }
        else if(!moving){
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        }     
    }
    
    //The code that controls the Boss' attack on the player
    void ChargeAttack () {
        
        if(canShockwave){
            canShockwave = false;
            Shockwave();
            StartCoroutine(shockwaveCooldown());
        }
        
        //Check to make sure the player isn't too close
        TooCloseAttack();
        
        //the true and false are swapped here because the boss is backing away from the player
        if((GameObject.Find("Player").transform.position.x > xbufferfront.transform.position.x  && GameObject.Find("Player").transform.position.x < xbufferback.transform.position.x)
        || (GameObject.Find("Player").transform.position.x < xbufferfront.transform.position.x && GameObject.Find("Player").transform.position.x > xbufferback.transform.position.x)){
            
            moving = false; //player is in the bufferzone 
        }
        if(GameObject.Find("Player").transform.position.x > xbufferfront.transform.position.x && GameObject.Find("Player").transform.position.x > transform.position.x){
            movingLeft = false;
            moving = true;
        }
        else if(GameObject.Find("Player").transform.position.x < xbufferfront.transform.position.x && GameObject.Find("Player").transform.position.x < transform.position.x){
            movingLeft = true;
            moving = true;
        }
        else{
            moving = false;
        }
        
        //makes sure the boss is moving in the opposite direction from where its facing
        if (movingLeft && !facingLeft && moving && dontattack && canflip)
        {
            Flip();
        }
        else if (!movingLeft && facingLeft && moving && dontattack && canflip)
        {
            Flip();
        }
        
        if(wallEarlyDetection){
            if(wallPosition.x < transform.position.x && (transform.position.x - wallPosition.x) < 4){
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 550),ForceMode2D.Impulse);
                wallEarlyDetection = false;
            }
            else if(wallPosition.x > transform.position.x && (wallPosition.x - transform.position.x) < 4){
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 550),ForceMode2D.Impulse);
                wallEarlyDetection = false;
            }
        }
        
        //Moves the boss forward fast.
        if(movingLeft && moving && canmove){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * 10 * attackSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (!movingLeft && moving && canmove){
            GetComponent<Rigidbody2D>().velocity = new Vector2(1 * 10 * attackSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);           
        }     
    }
    
    //works with charge attack to jump over a prematurely placed wall
    void JumpWall(){
        
    }
    
    //Controls the actions the boss takes when stunned and when coming out of stun
    void Stunned () {
        if(!inCoroutine){
            inCoroutine = true;
            StartCoroutine("stunTime");    
        }
    }


//=====Supporting Functions=================================================================================================

    //Detection code that detects the player at the start of the battle
    void Detect () {
        isDetected = Physics2D.OverlapCircle(transform.position, radius, 1 << LayerMask.NameToLayer("Player"));
        if (isDetected){
            radius /= 2;
            attackStarted = true;
            boss1_manager.GetComponent<Boss1_Manager>().attackStarted = true;
        }
    }
    
    //Is run after if the player is on the boss's back when the boss is not stunned
    void FlingPlayer (float xForce, float yForce) {
        player.GetComponent<NewMovementScript>().inControl = false;
        player.GetComponent<NewMovementScript>().flungInAir = true;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce));
        gameManager.GetComponent<GameManager>().playerFlung = true;
        if(!inCoroutine){
            inCoroutine = true;
            StartCoroutine(afterHitWait());    
        }
    }
    
    //Function that checks to make sure the player didn't prematurely place a wall
    void CheckForEarlyWall(){
        
    }
    
    //Sends out a shockwave that damages the player if it is not jumped over
    void Shockwave(){
//        Debug.Log("Shockwave");
        Instantiate(shockwave, GameObject.Find("shockpoint").transform.position, Quaternion.identity);
    }
    
    //If the Player gets too close, the boss will perform a quick attack
    void TooCloseAttack (){
        //bool earlyDetected = Physics2D.OverlapCircle(gameObject.transform.position, radius, 1 << LayerMask.NameToLayer("Player"));
        bool earlyDetected;
        
        if((xbufferfront.transform.position.x - player.transform.position.x) < 1.6f && facingLeft
            && !(player.transform.position.x > xbufferfront.transform.position.x && player.transform.position.x < xbufferback.transform.position.x)
            && player.transform.position.y < 4.5 
            || (player.transform.position.x - xbufferfront.transform.position.x) < 1.6f && !facingLeft 
            && !(player.transform.position.x < xbufferfront.transform.position.x && player.transform.position.x > xbufferback.transform.position.x)
            && player.transform.position.y < 4.5 ){
            earlyDetected = true;       
        }
        else{
            earlyDetected = false;
        }
        //Debug.Log(dontattack + " " + earlyDetected);
        if(earlyDetected && !quickAttacking && !dontattack){
            //Debug.Log("Quickattacking");
            quickAttacking = true;
            StartCoroutine(quickAttack());
            StartCoroutine(quickattackCoolDown());
        }
        
    }
    
    //Flips the Boss to face the opposite direction
    void Flip(){
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    public void cooldownHelper(){
        StopCoroutine("quickattackCoolDown");
        StartCoroutine("quickattackCoolDown");
    }
    
    public void SetAnger(bool isPissed){
        if(isPissed){
            isAngry = true;
            Vector3 to = new Vector3(0,0, 14.0f);
            head.transform.eulerAngles = to;
        }
        else{
            isAngry = false;
            Vector3 to = new Vector3(0,0,0);
            head.transform.eulerAngles = to;
        }        
    }
    
//=====Coroutines==============================================================================================================    
    
    IEnumerator backupTime(){
        yield return new WaitForSeconds(waitseconds);
        attackStarted = false;
        attacking = true;
        inCoroutine = false;
    }
    IEnumerator afterHitWait(){
        yield return new WaitForSeconds(2.5f);
        attackStarted = true;
        inCoroutine = false;
    }
    IEnumerator stunTime(){
        boss1_manager.GetComponent<Boss1_Manager>().stunned = true;
        horn1.transform.localScale = new Vector3 (1f,1f,1f);
        horn2.transform.localScale = new Vector3 (1f,1f,1f);
        horn1.layer = 9;
        horn2.layer = 9;
        headCollider.layer = 9;
        Vector3 to = new Vector3(0,0, 62.0f);
        head.transform.eulerAngles = to;
        yield return new WaitForSeconds(8.0f);
        head.transform.eulerAngles = new Vector3(0,0,0);
        horn1.layer = 0;
        horn2.layer = 0;
        headCollider.layer = 0;
        //StartCoroutine(quickattackCoolDown());
        inCoroutine = false;
        horn1.transform.localScale = new Vector3 (1f,-1f,1f);
        horn2.transform.localScale = new Vector3 (1f,-1f,1f);
        boss1_manager.GetComponent<Boss1_Manager>().stunned = false;
        stunned = false;
        attackStarted = true;
    }
    
    IEnumerator quickAttack(){
        horn1.GetComponent<BoxCollider2D>().isTrigger = true;
        horn2.GetComponent<BoxCollider2D>().isTrigger = true;
        horn1.tag = "boss_damage";
        horn2.tag = "boss_damage"; 
        Vector3 to = new Vector3(0,0, 62.0f);
        head.transform.eulerAngles = to;
        yield return new WaitForSeconds(0.3f);
        head.transform.eulerAngles = new Vector3(0,0,0);
        horn1.tag = "Untagged";
        horn2.tag = "Untagged";
        quickAttacking = false;
        StopCoroutine("quickattackCoolDown");
        StartCoroutine("quickattackCoolDown");
        yield return null;
    }
    
    IEnumerator quickattackCoolDown(){
        cooldownrunning = true;
        dontattack = true;
        yield return new WaitForSeconds(3.0f);
        horn1.GetComponent<BoxCollider2D>().isTrigger = false;
        horn2.GetComponent<BoxCollider2D>().isTrigger = false;
        dontattack = false;
        cooldownrunning = false;
        yield return null;   
    }
    
    IEnumerator waitToFlip(){
        AfterFlingCanFlip = false;
        yield return new WaitForSeconds(1.5f);
        AfterFlingCanFlip = true;
        yield return null;
    }
    
    IEnumerator shockwaveCooldown(){
        yield return new WaitForSeconds(6.0f);
        canShockwave = true;
        yield return null;
    }
}
