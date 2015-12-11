using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {
	public Transform cap;
	public Transform cube;
	public Transform cylinder;
	public Transform sphere; 
	//
	public Transform enemy;
	public GameObject Spawnner;
	//
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


	public int path1Limit = 0;
	public int path2Limit = 0;
	public int path3Limit = 0;
	public int totalSpawnNumber = 0;

	public int randomEnemy = 0;
	public int randomSpawn = 0;

	private List<GameObject> enemies = new List<GameObject>();
	
	
	public bool x = true;
	
	public float timer = 4.9f;



	//reference Game Mananger//

	private GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		GameObject Manager = GameObject.FindGameObjectWithTag ("GameController");
		gameManager = Manager.GetComponent<GameManager>();


	}
	
	// Update is called once per frame
	void Update () {
		
		spawn = gameManager.Path1;
		TopRight = gameManager.Path2;
		BottomLeft = gameManager.Path3;
		BottomRight = gameManager.Path2;
		
		StartCoroutine (Spawn ());
		
		
	}
	IEnumerator Spawn()
	{	   

		
		while (x == true) {
			
			x = false; 
			yield return new WaitForSeconds (1f);
			randomEnemy = Random.Range (1, 5);
			randomSpawn = Random.Range (1,5);
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

		if (totalSpawnNumber < 12) 
		{
			if (randomEnemy == 1)
				{
					enemy = cube;
					totalSpawnNumber ++;
				}	
			else if(randomEnemy == 2)
				{
					totalSpawnNumber++;
					enemy = cap;
				}
			else if (randomEnemy == 3)
				{
					//enemy = cylinder;
					//totalSpawnNumber ++;
				}
			else if (randomEnemy == 4)
				{
					//enemy = sphere;
					//totalSpawnNumber ++;
				}
			else
					continue;
			if (randomSpawn == 1 && path1Limit < 3)
				{
					if(enemy == cap || enemy == cube)
					{
						Spawnner = spawn;
						path1Limit ++;
					}
					else
						Spawnner =spawn;
				}
			else if (randomSpawn == 2 && path2Limit < 3)
				{
					if(enemy == cap || enemy == cube)
 					{
						Spawnner = TopRight;
						path2Limit ++;
					}
					else {
						Spawnner = TopRight;
					}
				}
			else if (randomSpawn == 3 && path3Limit < 3)
				{
					if(enemy == cap || enemy == cube)
					{
						Spawnner = BottomLeft;
						path3Limit ++;
					}
					else {
						Spawnner = BottomLeft;
					}
				}
				
				

			//cubeOffset = cubeOffset + 0.7f; 
			GameObject newEnemy = Instantiate (enemy, Spawnner.transform.position, Quaternion.identity) as GameObject;
			//newEnemy = Resources.Load("cube" + cubeCount) as GameObject;
			//cubeCount = cubeCount + 1;
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




