using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextControlScript : MonoBehaviour {

	//player animator
	public Animator player;

    //input string
    string stringToEdit = "";

    //spell types
    //fire
	public Transform fireball;
	public Transform firecube;
	public Transform firecap;
    //water
    public Transform waterball;
    public Transform watercube;
    public Transform watercap;
    //air
    public Transform airball;
    public Transform aircube;
    public Transform aircap;
    //earth
    public Transform earthball;
    public Transform earthcube;
    public Transform earthcap;
    
    //for text prompt for checking if return key has been entered
	bool hasReturned = false;
	bool controlUp = false;

    //active string for distinguishing spells
    string currentActive;

    //projectile speed
    public float projSpeed;
    public float fireSpeed;
    public float bubbleSpeed;
    public float tornadoSpeed;
    public float rockSpeed;
    public float waveSpeed;
    public float liftSpeed;
    public float dropletSpeed;
    public float flareSpeed;
    public float spoutSpeed;
    public float slashSpeed;

    //booleans to manage cooldowns
    bool fireCool;
    bool waterCool;
    bool airCool;
    bool earthCool;

    //length of cooldowns for each spell
    float fireTime;
    float waterTime;
    float airTime;
    float earthTime;
    public float coolTime;

    //sprites for books
    public SpriteRenderer fireBook;
    public SpriteRenderer waterBook;
    public SpriteRenderer airBook;
    public SpriteRenderer earthBook;
    public SpriteRenderer openBook;
	public SpriteRenderer pauseBook;

    //skin for textbox
    public GUISkin invisibleBox;
    GUIStyle style;

    //cooldown timers display
    public Text fireCoolTimer;
    public Text waterCoolTimer;
    public Text airCoolTimer;
    public Text earthCoolTimer;

    //slo-mo Value
    public float slomoValue = 0.1f;

	//for pause menu
	bool isPaused;
	//public Text pauseMenu1;
	//public Text pauseMenu2;
	float resumeSpeed;

	// Use this for initialization
	void Start () {
        //cooldowns
        fireCool = false;
        waterCool = false;
        airCool = false;
        earthCool = false;
        openBook.enabled = false;
        fireTime = coolTime;
        waterTime = coolTime;
        airTime = coolTime;
        earthTime = coolTime;

        //GUI style
        invisibleBox.textField.fontSize = Screen.width / 15;

		//pause menu
		isPaused = false;
		pauseBook.enabled = false;

		//slomo
		Time.timeScale = 1.0f;
	}

//----------------------------------------------------------------
//UPDATE FUNCTION
//----------------------------------------------------------------
	void Update () {
		
        //COOLDOWN TIMERS

        //for when cooldown is active and checking for when cooldown hits 0
        //When 0 reactivate sprite and re-enable text prompt
        //fire
        if (fireCool == true)
        {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0)
            {
                fireCool = false;
                fireCoolTimer.text = "";
                fireTime = coolTime;
                fireBook.sprite = Resources.Load("red book", typeof(Sprite)) as Sprite;
            }
        }
        //water
        if (waterCool == true)
        {
            waterTime -= Time.deltaTime;
            if (waterTime <= 0)
            {
                waterCool = false;
                waterCoolTimer.text = "";
                waterTime = coolTime;
                waterBook.sprite = Resources.Load("blue book", typeof(Sprite)) as Sprite;
            }
        }
        //air
        if (airCool == true)
        {
            airTime -= Time.deltaTime;
            if (airTime <= 0)
            {
                airCool = false;
                airCoolTimer.text = "";
                airTime = coolTime;
                airBook.sprite = Resources.Load("green book", typeof(Sprite)) as Sprite;
            }
        }
        //earth
        if (earthCool == true)
        {
            earthTime -= Time.deltaTime;
            if (earthTime <= 0)
            {
                earthCool = false;
                earthCoolTimer.text = "";
                earthTime = coolTime;
                earthBook.sprite = Resources.Load("yellow book", typeof(Sprite)) as Sprite;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //SPELL CASTING

        //casting spells, checking for return key
		if (hasReturned == true){
			player.SetBool("writing", false);
            //----------------------fire-------------------------------
			if((currentActive + stringToEdit).ToLower() == "fireball"){
				if (GameObject.Find("Player").GetComponent<NewMovementScript>().facingRight)
				{
					//Transform newball = (Transform)Instantiate (fireball, new Vector3(0, 0, 0), Quaternion.identity);
                	Transform fBall = (Transform)Instantiate(fireball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0,180,0)));
                	fBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(fireSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
				else
				{
					Transform fBall = (Transform)Instantiate(fireball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
					fBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(fireSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
                fireCool = true;
                fireBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                fireBook.enabled = true;
                openBook.enabled = false;
			}
            else if ((currentActive + stringToEdit).ToLower() == "fireflare")
            {
				//Transform newcube = (Transform)Instantiate (firecube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fcube = (Transform)Instantiate(firecube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fcube.GetComponent<Rigidbody2D>().AddForce(new Vector2(flareSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
                fireBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                fireBook.enabled = true;
                openBook.enabled = false;
			}
            else if ((currentActive + stringToEdit).ToLower() == "fireblast")
            {
				if (!GameObject.Find("Player").GetComponent<NewMovementScript>().facingRight)
				{
				//Transform newcap = (Transform)Instantiate (firecap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fCap = (Transform)Instantiate(firecap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                //fCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
				else
				{
					Transform fCap = (Transform)Instantiate(firecap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
				}
                fireCool = true;
                fireBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                fireBook.enabled = true;
                openBook.enabled = false;
			}

            //----------------------water-------------------------------
            if ((currentActive + stringToEdit).ToLower() == "waterbubble")
            {
                //Transform newball = (Transform)Instantiate(waterball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wBall = (Transform)Instantiate(waterball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(bubbleSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;
                waterBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                waterBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "waterdroplet")
            {
				if (!GameObject.Find("Player").GetComponent<NewMovementScript>().facingRight)
				{
                	//Transform newcube = (Transform)Instantiate(watercube, new Vector3(0, 0, 0), Quaternion.identity);
                	Transform wCube = (Transform)Instantiate(watercube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                	wCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(dropletSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
				else
				{
					Transform wCube = (Transform)Instantiate(watercube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
					wCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(dropletSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
                waterCool = true;
                waterBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                waterBook.enabled = true;
                openBook.enabled = false;

            }
            else if ((currentActive + stringToEdit).ToLower() == "waterspout")
            {
                StartCoroutine("goSpout");
                //Transform newcap = (Transform)Instantiate(watercap, new Vector3(0, 0, 0), Quaternion.identity);
                waterCool = true;
                waterBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                waterBook.enabled = true;
                openBook.enabled = false;
            }

            //----------------------air-------------------------------
            if ((currentActive + stringToEdit).ToLower() == "airgust")
            {
				if (!GameObject.Find("Player").GetComponent<NewMovementScript>().facingRight)
				{
                	//Transform newball = (Transform)Instantiate(airball, new Vector3(0, 0, 0), Quaternion.identity);
                	Transform aBall = (Transform)Instantiate(airball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                	aBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(tornadoSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
				else
				{
					Transform aBall = (Transform)Instantiate(airball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
					aBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(tornadoSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
                airCool = true;
                airBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                airBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "airlift")
            {
                //Transform newcube = (Transform)Instantiate(aircube, new Vector3(0, 0, 0), Quaternion.identity);
                GameObject pos = GameObject.Find("GroundCheck");
                Transform aCube = (Transform)Instantiate(aircube, pos.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, liftSpeed * this.transform.parent.gameObject.transform.localScale.y));
                airCool = true;
                airBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                airBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "airslash")
            {
				if (!GameObject.Find("Player").GetComponent<NewMovementScript>().facingRight)
				{
                	//Transform newcap = (Transform)Instantiate(aircap, new Vector3(0, 0, 0), Quaternion.identity);
                	Transform aCap = (Transform)Instantiate(aircap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
               		aCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(slashSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
				else
				{
					Transform aCap = (Transform)Instantiate(aircap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
					aCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(slashSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
                airCool = true;
                airBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                airBook.enabled = true;
                openBook.enabled = false;
            }

            //----------------------earth-------------------------------
            if ((currentActive + stringToEdit).ToLower() == "earthrock")
            {
                //Transform newball = (Transform)Instantiate(earthball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eBall = (Transform)Instantiate(earthball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(rockSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
                earthBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                earthBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthboulder")
            {
                //Transform newcube = (Transform)Instantiate(earthcube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eCube = (Transform)Instantiate(earthcube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                //eCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
                earthBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                earthBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthwall")
            {
				if (!GameObject.Find("Player").GetComponent<NewMovementScript>().facingRight)
				{
                	//Transform newcap = (Transform)Instantiate(earthcap, new Vector3(0, 0, 0), Quaternion.identity);
                	Transform eCap = (Transform)Instantiate(earthcap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                	//eCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				}
				else
				{
					Transform eCap = (Transform)Instantiate(earthcap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
				}
                earthCool = true;
                earthBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                earthBook.enabled = true;
                openBook.enabled = false;
            }
            else
            {
                openBook.enabled = false;
                earthBook.enabled = true;
                airBook.enabled = true;
                waterBook.enabled = true;
                fireBook.enabled = true;
            }
			stringToEdit = "";
            currentActive = "";
		}

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //SPRITE LOADING FOR TEXT PROMPTS

        //opening books
        if (currentActive == "fire")
        {
            fireBook.enabled = false;
            openBook.sprite = Resources.Load("red book open", typeof(Sprite)) as Sprite;
            openBook.enabled = true;
            waterBook.enabled = true;
            airBook.enabled = true;
            earthBook.enabled = true;
        }
        else if (currentActive == "water")
        {
            waterBook.enabled = false;
            openBook.sprite = Resources.Load("blue book open", typeof(Sprite)) as Sprite;
            openBook.enabled = true;
            fireBook.enabled = true;
            airBook.enabled = true;
            earthBook.enabled = true;
        }
        else if (currentActive == "air")
        {
            airBook.enabled = false;
            openBook.sprite = Resources.Load("green book open", typeof(Sprite)) as Sprite;
            openBook.enabled = true;
            fireBook.enabled = true;
            waterBook.enabled = true;
            earthBook.enabled = true;
        }
        else if (currentActive == "earth")
        {
            earthBook.enabled = false;
            openBook.sprite = Resources.Load("yellow book open", typeof(Sprite)) as Sprite;
            openBook.enabled = true;
            fireBook.enabled = true;
            waterBook.enabled = true;
            airBook.enabled = true;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //COOLDOWNS

        //for cooldown timers
        if (fireCool == true)
            fireCoolTimer.text = fireTime.ToString("0");
        if (waterCool == true)
            waterCoolTimer.text = waterTime.ToString("0");
        if (airCool == true)
            airCoolTimer.text = airTime.ToString("0");
        if (earthCool == true)
            earthCoolTimer.text = earthTime.ToString("0");
	}


//----------------------------------------------------------------
//ONGUI FUNCTION
//----------------------------------------------------------------
	void OnGUI() {
        
        //fix for input string buffer bug
        foreach (char c in stringToEdit)
        {
            if (c == '1' || c == '2' || c == '3' || c == '4')
            {
                stringToEdit = stringToEdit.Replace(c, ' ');
                //Debug.Log("Detected Number");
            }
        }

        //setting up text boxes
        GUI.skin = invisibleBox;
		GUI.SetNextControlName ("Spellbook");
		Event e = Event.current;

        //if return key has been entered
		if (e.keyCode == KeyCode.Return && !isPaused) {
			hasReturned = true;
			controlUp = false;

			//deactivate slo-mo
			Time.timeScale = 1.0f;
		}
		//for pausing
		else if (e.keyCode == KeyCode.Escape && !isPaused) 
		{
			resumeSpeed = Time.timeScale;
			Time.timeScale = 0.0f;
			pauseBook.enabled = true;
			//pauseMenu1.enabled = true;
			//pauseMenu2.enabled = true;
			isPaused = true;
		}
		//returning 
		else if (e.keyCode == KeyCode.M && isPaused)
		{
			Application.LoadLevel(0);
		}
		//for resuming
		else if (e.keyCode == KeyCode.R && isPaused)
		{
			Time.timeScale = resumeSpeed;
			pauseBook.enabled = false;
			//pauseMenu1.enabled = false;
			//pauseMenu2.enabled = false;
			isPaused = false;
		}
        //if 1 key has been entered - fire
		else if (e.keyCode == KeyCode.Alpha1 && fireCool == false && !isPaused)
        {
			player.SetBool("writing", true);
			controlUp = true;
			hasReturned = false;
			stringToEdit = "";
            currentActive = "fire";
			GUI.FocusControl("Spellbook");

            //activate slo-mo
            Time.timeScale = slomoValue;

		}
        //if 2 key has been entered - water
		else if (e.keyCode == KeyCode.Alpha2 && waterCool == false && !isPaused)
        {
			player.SetBool("writing", true);
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "water";
            GUI.FocusControl("Spellbook");

            //activate slo-mo
            Time.timeScale = slomoValue;
        }
        //if 2 key has been entered - air
		else if (e.keyCode == KeyCode.Alpha3 && airCool == false && !isPaused)
        {
			player.SetBool("writing", true);
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "air";
            GUI.FocusControl("Spellbook");

            //activate slo-mo
            Time.timeScale = slomoValue;
        }
        //if 2 key has been entered - earth
		else if (e.keyCode == KeyCode.Alpha4 && earthCool == false && !isPaused)
        {
			player.SetBool("writing", true);
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "earth";
            GUI.FocusControl("Spellbook");

            //activate slo-mo
            Time.timeScale = slomoValue;
        }
        
        //displaying text field, custom position place on screen. adjusted for screen width and height
        else if (hasReturned == false && controlUp == true && currentActive == "fire")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 150), (Screen.height - (Screen.height / 4.50f)), 300, 100), stringToEdit, 100);
        else if (hasReturned == false && controlUp == true && currentActive == "water")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 150), (Screen.height - (Screen.height / 4.50f)), 300, 100), stringToEdit, 100);
        else if (hasReturned == false && controlUp == true && currentActive == "air")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 150), (Screen.height - (Screen.height / 4.50f)), 300, 100), stringToEdit, 100);
        else if (hasReturned == false && controlUp == true && currentActive == "earth")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 150), (Screen.height - (Screen.height / 4.50f)), 300, 100), stringToEdit, 100);

	}

    IEnumerator goSpout()
    {
		if (!GameObject.Find ("Player").GetComponent<NewMovementScript> ().facingRight) {
			for (int i = 0; i < 4; ++i) {
				Transform wCap = (Transform)Instantiate (watercap, this.gameObject.transform.position, Quaternion.Euler (new Vector3 (0, 180, 0)));
				wCap.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (spoutSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				yield return new WaitForSeconds (0.2f);
			}
		} else {
			for (int i = 0; i < 4; ++i) {
				Transform wCap = (Transform)Instantiate (watercap, this.gameObject.transform.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
				wCap.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (spoutSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
				yield return new WaitForSeconds (0.2f);
			}
		}
    }
}
