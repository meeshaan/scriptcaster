using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour {
	public bool SlowTime = false;
	public GameObject Path1;
	public GameObject Path2;
	public GameObject Path3;
	public int totalEnemiesInGame;
	public int SpawnnedEnemies;
	public int enemiesKilled;
    public bool playerFlung; //If the player has no movement control as is being flung this will be true
  
	// Use this for initialization
	void Start () {
		Path1 = GameObject.FindGameObjectWithTag ("Path1");
		Path2 = GameObject.FindGameObjectWithTag ("Path2");
		Path3 = GameObject.FindGameObjectWithTag ("Path3");
		totalEnemiesInGame = 10;
		SpawnnedEnemies = 0;
		enemiesKilled = 0;
		
	}

	void Update(){
		if (enemiesKilled == totalEnemiesInGame) {
			Application.LoadLevel ("win");
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
}