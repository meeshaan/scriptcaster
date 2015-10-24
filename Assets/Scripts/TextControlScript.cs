using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextControlScript : MonoBehaviour {
	
	public string stringToEdit = "";
	public Transform fireball;
	public Transform firecube;
	public Transform firecap;
    public Transform waterball;
    public Transform watercube;
    public Transform watercap;
    public Transform airball;
    public Transform aircube;
    public Transform aircap;
    public Transform earthball;
    public Transform earthcube;
    public Transform earthcap;
	bool hasReturned = false;
	bool controlUp = false;
    string currentActive;
    public float projSpeed;
    public bool fireCool;
    public bool waterCool;
    public bool airCool;
    public bool earthCool;
    public float fireTime;
    public float waterTime;
    public float airTime;
    public float earthTime;
    float coolTime = 10.0f;
    public SpriteRenderer fireBook;
    public SpriteRenderer waterBook;
    public SpriteRenderer airBook;
    public SpriteRenderer earthBook;
    public SpriteRenderer openBook;
    public GUISkin invisibleBox;
    public Text fireCoolTimer;
    public Text waterCoolTimer;
    public Text airCoolTimer;
    public Text earthCoolTimer;

	// Use this for initialization
	void Start () {
        fireCool = false;
        waterCool = false;
        airCool = false;
        earthCool = false;
        openBook.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
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

		if (hasReturned == true){
			if((currentActive + stringToEdit).ToLower() == "fireball"){
				//Transform newball = (Transform)Instantiate (fireball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fBall = (Transform)Instantiate(fireball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
                fBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
                fireBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                fireBook.enabled = true;
                openBook.enabled = false;
			}
            else if ((currentActive + stringToEdit).ToLower() == "firecube")
            {
				//Transform newcube = (Transform)Instantiate (firecube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fcube = (Transform)Instantiate(firecube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fcube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
                fireBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                fireBook.enabled = true;
                openBook.enabled = false;
			}
            else if ((currentActive + stringToEdit).ToLower() == "firecap")
            {
				//Transform newcap = (Transform)Instantiate (firecap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fCap = (Transform)Instantiate(firecap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
                fireBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                fireBook.enabled = true;
                openBook.enabled = false;
			}
            if ((currentActive + stringToEdit).ToLower() == "waterball")
            {
                //Transform newball = (Transform)Instantiate(waterball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wBall = (Transform)Instantiate(waterball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;
                waterBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                waterBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "watercube")
            {
                //Transform newcube = (Transform)Instantiate(watercube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wCube = (Transform)Instantiate(watercube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;
                waterBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                waterBook.enabled = true;
                openBook.enabled = false;

            }
            else if ((currentActive + stringToEdit).ToLower() == "watercap")
            {
                //Transform newcap = (Transform)Instantiate(watercap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wCap = (Transform)Instantiate(watercap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;
                waterBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                waterBook.enabled = true;
                openBook.enabled = false;
            }
            if ((currentActive + stringToEdit).ToLower() == "airball")
            {
                //Transform newball = (Transform)Instantiate(airball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform aBall = (Transform)Instantiate(airball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                airCool = true;
                airBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                airBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "aircube")
            {
                //Transform newcube = (Transform)Instantiate(aircube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform aCube = (Transform)Instantiate(aircube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                airCool = true;
                airBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                airBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "aircap")
            {
                //Transform newcap = (Transform)Instantiate(aircap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform aCap = (Transform)Instantiate(aircap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                airCool = true;
                airBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                airBook.enabled = true;
                openBook.enabled = false;
            }
            if ((currentActive + stringToEdit).ToLower() == "earthball")
            {
                //Transform newball = (Transform)Instantiate(earthball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eBall = (Transform)Instantiate(earthball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
                earthBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                earthBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthcube")
            {
                //Transform newcube = (Transform)Instantiate(earthcube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eCube = (Transform)Instantiate(earthcube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
                earthBook.sprite = Resources.Load("grey book", typeof(Sprite)) as Sprite;
                earthBook.enabled = true;
                openBook.enabled = false;
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthcap")
            {
                //Transform newcap = (Transform)Instantiate(earthcap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eCap = (Transform)Instantiate(earthcap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
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

        if (fireCool == true)
            fireCoolTimer.text = fireTime.ToString("0");
        if (waterCool == true)
            waterCoolTimer.text = waterTime.ToString("0");
        if (airCool == true)
            airCoolTimer.text = airTime.ToString("0");
        if (earthCool == true)
            earthCoolTimer.text = earthTime.ToString("0");
	}
	
	void OnGUI() {
        GUI.skin = invisibleBox;
		GUI.SetNextControlName ("Spellbook");
		Event e = Event.current;
		if (e.keyCode == KeyCode.Return){
			hasReturned = true;
			controlUp = false;
		}
		else if (e.keyCode == KeyCode.Alpha1 && fireCool == false)
        {
			controlUp = true;
			hasReturned = false;
			stringToEdit = "";
            currentActive = "fire";
			GUI.FocusControl("Spellbook");
		}
        else if (e.keyCode == KeyCode.Alpha2 && waterCool == false)
        {
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "water";
            GUI.FocusControl("Spellbook");
        }
        else if (e.keyCode == KeyCode.Alpha3 && airCool == false)
        {
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "air";
            GUI.FocusControl("Spellbook");
        }
        else if (e.keyCode == KeyCode.Alpha4 && earthCool == false)
        {
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "earth";
            GUI.FocusControl("Spellbook");
        }
        //else if (hasReturned == false && controlUp == true && currentActive == "fire")
        //    stringToEdit = GUI.TextField(new Rect((Screen.width/2 - 100), (Screen.height - (Screen.height * 0.9f)), 200, 60), stringToEdit, 100);
        //else if (hasReturned == false && controlUp == true && currentActive == "water")
        //    stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 50), (Screen.height - (Screen.height * 0.9f)), 100, 60), stringToEdit, 100);
        //else if (hasReturned == false && controlUp == true && currentActive == "air")
        //    stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 50), (Screen.height - (Screen.height * 0.9f)), 100, 60), stringToEdit, 100);
        //else if (hasReturned == false && controlUp == true && currentActive == "earth")
        //    stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 50), (Screen.height - (Screen.height * 0.9f)), 100, 60), stringToEdit, 100);

        else if (hasReturned == false && controlUp == true && currentActive == "fire")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 100), (Screen.height - (Screen.height/4.55f)), 200, 60), stringToEdit, 100);
        else if (hasReturned == false && controlUp == true && currentActive == "water")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 50), (Screen.height - (Screen.height/4.55f)), 100, 60), stringToEdit, 100);
        else if (hasReturned == false && controlUp == true && currentActive == "air")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 50), (Screen.height - (Screen.height/4.55f)), 100, 60), stringToEdit, 100);
        else if (hasReturned == false && controlUp == true && currentActive == "earth")
            stringToEdit = GUI.TextField(new Rect((Screen.width / 2 - 50), (Screen.height - (Screen.height/4.55f)), 100, 60), stringToEdit, 100);

	}
}
