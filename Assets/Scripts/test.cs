using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {
	public Transform cap;
	public Transform cube;
	public Transform cylinder;
	public Transform sphere; 


	public GameObject spawn;
	public GameObject BottomRight; 
	public GameObject BottomLeft;
	public GameObject TopRight;
	public float capOffset = 0.3f;
	public float cubeOffset = 0.3f;
	public float cylinderOffset = 0.3f;
	public float sphereOffset = 0.3f;
	public int capCount = 0;
	public int  cubeCount = 0;
	public int cylinderCount = 0;
	public int sphereCount = 0;

	public int random = 0;

	private List<GameObject> enemies = new List<GameObject>();
	
	
	public bool x = true;
	
	public float timer = 4.9f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		StartCoroutine (Spawn ());
		
		
	}
	IEnumerator Spawn()
	{	

		
		while (x == true) {
			
			x = false; 
			yield return new WaitForSeconds (1f);
			random = Random.Range (1, 5);
			//if (capCount <= 3 && random == 1) 
			/*if(capCount <= 0)
			{
				capOffset = capOffset + 0.7f;
				GameObject newCap = Instantiate (cap, spawn.transform.position *capOffset, Quaternion.identity) as GameObject;
				newCap = Resources.Load("cap" + capCount) as GameObject;
				capCount = capCount + 1;
				Debug.Log ("test1");
				yield return new WaitForSeconds (3f);
				//capOffset = capOffset + 0.7f; 
			}
			x = true;
			*/

		if (cubeCount <= 0) 
		{
			//cubeOffset = cubeOffset + 0.7f; 
			GameObject newCube = Instantiate (cube, TopRight.transform.position, Quaternion.identity) as GameObject;
			newCube = Resources.Load("cube" + cubeCount) as GameObject;
			cubeCount = cubeCount + 1;
			Debug.Log ("test1");
			yield return new WaitForSeconds (3f);
			//cubeOffset = cubeOffset + 0.7f; 
		}
		x = true;

			/*
			if (cylinderCount <= 3 && random == 3) 
		{
			cylinderOffset = cylinderOffset + 0.7f; 
			GameObject newCylinder = Instantiate (cylinder, BottomLeft.transform.position *cylinderOffset, Quaternion.identity) as GameObject;
			newCylinder = Resources.Load("cylinder" + cylinderCount) as GameObject;
			cylinderCount = cylinderCount + 1;
			Debug.Log ("test1");
			yield return new WaitForSeconds (3f);
			//cubeOffset = cubeOffset + 0.7f; 
		}
		x = true;
		if (sphereCount <= 3 && random == 4) 
		{
			sphereOffset = sphereOffset + 0.7f; 
			GameObject newSphere = Instantiate (sphere, BottomRight.transform.position *sphereOffset, Quaternion.identity) as GameObject;
			newSphere = Resources.Load("sphere" + sphereCount) as GameObject;
			sphereCount = sphereCount + 1;
			Debug.Log ("test1");
			yield return new WaitForSeconds (3f);
			//cubeOffset = cubeOffset + 0.7f; 
		}
		x = true;*/
	}

		
}


	
	
	
}


/*if(enemies.Count > 3)
{
	for(int i = 0; i < enemies.Count; i++)
	{
		Destroy(enemies[i]);
	}
}*/

//while(enemyCount > 5)
//{
//	if(Input.GetKey(KeyCode.Space))
//		Destroy(enemy);
//}




