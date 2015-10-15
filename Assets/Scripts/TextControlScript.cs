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


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hasReturned == true){
			if((currentActive + stringToEdit).ToLower() == "fireball"){
				Transform newball = (Transform)Instantiate (fireball, new Vector3(0, 0, 0), Quaternion.identity);
			}
            else if ((currentActive + stringToEdit).ToLower() == "firecube")
            {
				Transform newcube = (Transform)Instantiate (firecube, new Vector3(0, 0, 0), Quaternion.identity);
			}
            else if ((currentActive + stringToEdit).ToLower() == "firecap")
            {
				Transform newcap = (Transform)Instantiate (firecap, new Vector3(0, 0, 0), Quaternion.identity);
			}
            if ((currentActive + stringToEdit).ToLower() == "waterball")
            {
                Transform newball = (Transform)Instantiate(waterball, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if ((currentActive + stringToEdit).ToLower() == "watercube")
            {
                Transform newcube = (Transform)Instantiate(watercube, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if ((currentActive + stringToEdit).ToLower() == "watercap")
            {
                Transform newcap = (Transform)Instantiate(watercap, new Vector3(0, 0, 0), Quaternion.identity);
            }
            if ((currentActive + stringToEdit).ToLower() == "airball")
            {
                Transform newball = (Transform)Instantiate(airball, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if ((currentActive + stringToEdit).ToLower() == "aircube")
            {
                Transform newcube = (Transform)Instantiate(aircube, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if ((currentActive + stringToEdit).ToLower() == "aircap")
            {
                Transform newcap = (Transform)Instantiate(aircap, new Vector3(0, 0, 0), Quaternion.identity);
            }
            if ((currentActive + stringToEdit).ToLower() == "earthball")
            {
                Transform newball = (Transform)Instantiate(earthball, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthcube")
            {
                Transform newcube = (Transform)Instantiate(earthcube, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if ((currentActive + stringToEdit).ToLower() == "earthcap")
            {
                Transform newcap = (Transform)Instantiate(earthcap, new Vector3(0, 0, 0), Quaternion.identity);
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
		else if (e.keyCode == KeyCode.Alpha1)
        {
			controlUp = true;
			hasReturned = false;
			stringToEdit = "";
            currentActive = "fire";
			GUI.FocusControl("Spellbook");
		}
        else if (e.keyCode == KeyCode.Alpha2)
        {
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "water";
            GUI.FocusControl("Spellbook");
        }
        else if (e.keyCode == KeyCode.Alpha3)
        {
            controlUp = true;
            hasReturned = false;
            stringToEdit = "";
            currentActive = "air";
            GUI.FocusControl("Spellbook");
        }
        else if (e.keyCode == KeyCode.Alpha4)
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
	}
}
