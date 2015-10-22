using UnityEngine;
using System.Collections;

public class EarthControl : MonoBehaviour {

    public string stringToEdit = "";
    public Transform ball;
    public Transform cube;
    public Transform cap;
    bool hasReturned = false;
    bool earthUp = false;
    public float cooldown;
    public bool isCooling;


    // Use this for initialization
    void Start()
    {
        isCooling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooling == true) 
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown <= 0)
        {
            isCooling = false;
        }

        if (hasReturned == true && isCooling == false)
        {
            if (stringToEdit.ToLower() == "ball")
            {
                Transform newball = (Transform)Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (stringToEdit.ToLower() == "cube")
            {
                Transform newcube = (Transform)Instantiate(cube, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (stringToEdit.ToLower() == "cap")
            {
                Transform newcap = (Transform)Instantiate(cap, new Vector3(0, 0, 0), Quaternion.identity);
            }
            stringToEdit = "";
        }
        else {
            //display cooldown
        }
    }

    void OnGUI()
    {
        GUI.SetNextControlName("Spellbook");
        Event e = Event.current;
        if (e.keyCode == KeyCode.Return)
        {
            hasReturned = true;
            earthUp = false;
        }
        else if (e.keyCode == KeyCode.Alpha4 && isCooling == false)
        {
            earthUp = true;
            hasReturned = false;
            stringToEdit = "";
            GUI.FocusControl("Spellbook");
        }
        else if (hasReturned == false && earthUp == true)
        {
            stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
        }

        if (isCooling) 
        {
            GUI.Box(new Rect(10, 10, 200, 20), cooldown.ToString("0"));
        }
    }
}
