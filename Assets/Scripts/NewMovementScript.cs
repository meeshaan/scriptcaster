using UnityEngine;
using System.Collections;

public class NewMovementScript : MonoBehaviour {
  //Movement related variables
  public float moveSpeed;  //Our general move speed. This is effected by our
  //InputManager > Horizontal button's Gravity and Sensitivity
  //Changing the Gravity/Sensitivty will in turn result in more loose or tighter control
  public bool inControl;

  public float sprintMultiplier;   //How fast to multiply our speed by when sprinting
  public float sprintDelay;        //How long until our sprint kicks in
  private float sprintTimer;       //Used in calculating the sprint delay
  private bool jumpedDuringSprint; //Used to see if we jumped during our sprint

  //Jump related variables
  public float initialJumpForce;       //How much force to give to our initial jump
  public float extraJumpForce;         //How much extra force to give to our jump when the button is held down
  public float maxExtraJumpTime;       //Maximum amount of time the jump button can be held down for
  public float delayToExtraJumpForce;  //Delay in how long before the extra force is added
  private float jumpTimer;             //Used in calculating the extra jump delay
  private bool playerJumped;           //Tell us if the player has jumped
  private bool playerJumping;          //Tell us if the player is holding down the jump button
  public Transform groundChecker;      //Gameobject required, placed where you wish "ground" to be detected from

  public bool facingRight = true;
  public bool isGrounded = false;             //Check to see if we are grounded
  private GameObject gameManager;
  public bool flungInAir;
  
  void Start(){
      inControl = true;
      gameManager = GameObject.Find("GameManager");
  }
  
  void Update()
  {
    //Casts a line between our ground checker gameobject and our player
    //If the floor is between us and the groundchecker, this makes "isGrounded" true
    if(Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("Platform")) || Physics2D.Linecast(transform.position, groundChecker.position, 1 << LayerMask.NameToLayer("PlayerWall"))){
        isGrounded = true;
    }
    else{
        isGrounded = false;
    }

    if(flungInAir && gameManager.GetComponent<GameManager>().playerFlung ){
        StartCoroutine(waitForFling());
    }
    if(isGrounded && !flungInAir && gameManager.GetComponent<GameManager>().playerFlung){
        inControl = true;
        gameManager.GetComponent<GameManager>().playerFlung = false;
    }
    //If our player hit the jump key, then it's true that we jumped!
    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      playerJumped = true;   //Our player jumped!
      playerJumping = true;  //Our player is jumping!
      jumpTimer = Time.time; //Set the time at which we jumped
    }

    //If our player lets go of the Jump button OR if our jump was held down to the maximum amount...
    if (Input.GetButtonUp("Jump") || Time.time - jumpTimer > maxExtraJumpTime)
    {
      playerJumping = false; //... then set PlayerJumping to false
    }

    //If our player hit a horizontal key...
    if (Input.GetButtonDown("Horizontal"))
    {
      sprintTimer = Time.time;  //.. reset the sprintTimer variable
      jumpedDuringSprint = false;  //... change Jumped During Sprint to false, as we lost momentum
    }
  }

    void FixedUpdate()
    {
        //Physics2D.IgnoreLayerCollision (8, 9, groundChecker.transform.position < );
        if(inControl){
            PlayerMovement();
        }
    }
  
  void PlayerMovement(){
    float move = Input.GetAxis("Horizontal"); //exists to check if an object should be flipped

    //If our player is holding the sprint button, we've held down the button for a while, and we're grounded...
    //OR our player jumped while we were already sprinting...
    if (Input.GetButton("Sprint") && Time.time - sprintTimer > sprintDelay && isGrounded || jumpedDuringSprint)
    {
      //... then sprint
      GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime * sprintMultiplier, GetComponent<Rigidbody2D>().velocity.y);

      //If our player jumped during our sprint...
      if (playerJumped)
      {
        jumpedDuringSprint = true; //... tell the game that we jumped during our sprint!
        //This is a tricky one. Basically, if we are already sprinting and our player jumps, we want them to hold their
        //momentum. Since they are no longer grounded, we would not longer return true on a regular sprint because
        //the build-up of sprint requires the player to be grounded. Likewise, if our player presses another horizontal
        //key, the jumpedDuringSprint would be set to false in our Update() function, thus causing a "loss" in momentum.
      }
    }
    else
    {
      //If we're not sprinting, then give us our general momentum
      GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
    }

    //If our player pressed the jump key...
    if (playerJumped)
    {
      GetComponent<Rigidbody2D>().AddForce(new Vector2(0, initialJumpForce)); //"Jump" our player up in the air!
      playerJumped = false; //Our player already jumped, so no need to jump again just yet
    }

    //If our player is holding the jump button and a little bit of time has passed...
    if (playerJumping && Time.time - jumpTimer > delayToExtraJumpForce)
    {
      GetComponent<Rigidbody2D>().AddForce(new Vector2(0, extraJumpForce)); //... then add some additional force to the jump
    }

    //checks which direction the character is moving and flips it to the correct side
    if (move > 0 && !facingRight)
    {
      Flip();
    }
    else if (move < 0 && facingRight)
    {
      Flip();
    }
  }
  

  void Flip()
  {
    facingRight = !facingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }
  
  IEnumerator waitForFling(){
      yield return new WaitForSeconds(0.1f);
      flungInAir = false;
      yield return null;
  }
}
