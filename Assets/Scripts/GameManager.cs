using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public bool SlowTime = false;

	// Use this for initialization
	void Start () {
	
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
