using UnityEngine;
using System.Collections;

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


	// Use this for initialization
	void Start () {
        fireCool = false;
        waterCool = false;
        airCool = false;
        earthCool = false;	
	}
	
	// Update is called once per frame
	void Update () {
        if (fireCool == true)
        {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0)
            {
                fireCool = false;
                fireTime = coolTime;
            }
        }
        if (waterCool == true)
        {
            waterTime -= Time.deltaTime;
            if (waterTime <= 0)
            {
                waterCool = false;
                waterTime = coolTime;
            }
        }
        if (airCool == true)
        {
            airTime -= Time.deltaTime;
            if (airTime <= 0)
            {
                airCool = false;
                airTime = coolTime;
            }
        }
        if (earthCool == true)
        {
            earthTime -= Time.deltaTime;
            if (earthTime <= 0)
            {
                earthCool = false;
                earthTime = coolTime;
            }
        }

		if (hasReturned == true){
			if((currentActive + stringToEdit).ToLower() == "fireball"){
				//Transform newball = (Transform)Instantiate (fireball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fBall = (Transform)Instantiate(fireball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0,0,0)));
                fBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
			}
            else if ((currentActive + stringToEdit).ToLower() == "firecube")
            {
				//Transform newcube = (Transform)Instantiate (firecube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fcube = (Transform)Instantiate(firecube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fcube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
			}
            else if ((currentActive + stringToEdit).ToLower() == "firecap")
            {
				//Transform newcap = (Transform)Instantiate (firecap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform fCap = (Transform)Instantiate(firecap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                fCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                fireCool = true;
			}
            if ((currentActive + stringToEdit).ToLower() == "waterball")
            {
                //Transform newball = (Transform)Instantiate(waterball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wBall = (Transform)Instantiate(waterball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;
            }
            else if ((currentActive + stringToEdit).ToLower() == "watercube")
            {
                //Transform newcube = (Transform)Instantiate(watercube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wCube = (Transform)Instantiate(watercube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;

            }
            else if ((currentActive + stringToEdit).ToLower() == "watercap")
            {
                //Transform newcap = (Transform)Instantiate(watercap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform wCap = (Transform)Instantiate(watercap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                wCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                waterCool = true;
            }
            if ((currentActive + stringToEdit).ToLower() == "airball")
            {
                //Transform newball = (Transform)Instantiate(airball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform aBall = (Transform)Instantiate(airball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                airCool = true;
            }
            else if ((currentActive + stringToEdit).ToLower() == "aircube")
            {
                //Transform newcube = (Transform)Instantiate(aircube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform aCube = (Transform)Instantiate(aircube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                airCool = true;
            }
            else if ((currentActive + stringToEdit).ToLower() == "aircap")
            {
                //Transform newcap = (Transform)Instantiate(aircap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform aCap = (Transform)Instantiate(aircap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                aCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                airCool = true;
            }
            if ((currentActive + stringToEdit).ToLower() == "earthball")
            {
                //Transform newball = (Transform)Instantiate(earthball, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eBall = (Transform)Instantiate(earthball, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthcube")
            {
                //Transform newcube = (Transform)Instantiate(earthcube, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eCube = (Transform)Instantiate(earthcube, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eCube.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthcap")
            {
                //Transform newcap = (Transform)Instantiate(earthcap, new Vector3(0, 0, 0), Quaternion.identity);
                Transform eCap = (Transform)Instantiate(earthcap, this.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                eCap.GetComponent<Rigidbody2D>().AddForce(new Vector2(projSpeed * this.transform.parent.gameObject.transform.localScale.x, 0));
                earthCool = true;
            }
			stringToEdit = "";
		}
	}
	
	void OnGUI() {
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
		else if (hasReturned == false && controlUp == true && currentActive == "fire")
			stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        else if (hasReturned == false && controlUp == true && currentActive == "water")
            stringToEdit = GUI.TextField(new Rect(240, 10, 200, 20), stringToEdit, 25);
        else if (hasReturned == false && controlUp == true && currentActive == "air")
            stringToEdit = GUI.TextField(new Rect(470, 10, 200, 20), stringToEdit, 25);
        else if (hasReturned == false && controlUp == true && currentActive == "earth")
            stringToEdit = GUI.TextField(new Rect(700, 10, 200, 20), stringToEdit, 25);

        if (fireCool == true)
            GUI.Box(new Rect(10, 10, 200, 20), fireTime.ToString("0"));
        if (waterCool == true)
            GUI.Box(new Rect(240, 10, 200, 20), waterTime.ToString("0"));
        if (airCool == true)
            GUI.Box(new Rect(470, 10, 200, 20), airTime.ToString("0"));
        if (earthCool == true)
            GUI.Box(new Rect(700, 10, 200, 20), earthTime.ToString("0"));

	}
}
