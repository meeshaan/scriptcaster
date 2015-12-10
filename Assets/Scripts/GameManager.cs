using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool SlowTime = false;
	public GameObject Path1;
	public GameObject Path2;

	// Use this for initialization
	void Start () {
		Path1 = GameObject.FindGameObjectWithTag ("Path1");
		Path2 = GameObject.FindGameObjectWithTag ("Path2");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Q))
		{ 
			if (SlowTime == false)
				SlowTime = true;
			else if (SlowTime == true)
				SlowTime = false;
		}


	}

}
