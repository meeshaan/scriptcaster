using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyingSpawn : MonoBehaviour {
	public Transform airEnemy;
	public Transform fireEnemy;
	public GameObject flySpawn1;
	public GameObject flySpawn2;
	//
	public Transform enemy;
	public GameObject Spawnner;
	//

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
		

		
		StartCoroutine (Spawn ());
		
		
	}
	IEnumerator Spawn()
	{	   
		
		
		while (x == true) {
			
			x = false; 
			yield return new WaitForSeconds (3f);
			randomEnemy = Random.Range (1, 3);
			randomSpawn = Random.Range (1, 3);
			if(gameManager.SpawnnedEnemies < gameManager.totalEnemiesInGame)
			{
				if (randomEnemy == 1)
				{
					enemy = airEnemy;
					gameManager.SpawnnedEnemies ++;
				}
				else if (randomEnemy == 2)
				{
					enemy = fireEnemy;
					gameManager.SpawnnedEnemies ++;
				}
				if (randomSpawn == 1)
					Spawnner = flySpawn1;
				else if (randomSpawn == 2)
					Spawnner = flySpawn2;
			
			GameObject newEnemy = Instantiate (enemy, Spawnner.transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (2f);		
			x = true;
			}
		}
			//x = true;
		
		
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




