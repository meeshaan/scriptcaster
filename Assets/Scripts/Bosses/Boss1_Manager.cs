using UnityEngine;
using System.Collections;

public class Boss1_Manager : MonoBehaviour {

    public GameObject healthbar;
    public float health; //base value 150
    public float maxhealth;
    public bool stunned;
    public bool isattacking;
    public bool canbreakwall;
    

    void Start(){
        maxhealth = 150f;
        health = 150f;
        stunned = false;
        canbreakwall = false;
    }
    
    void Update(){
        if (health <= 0){
            Destroy(GameObject.Find("Boss1"));
        }
        
        SetHealth(health/maxhealth);
    }
    
    void SetHealth(float newhealth){
        healthbar.transform.localScale = new Vector3(newhealth, healthbar.transform.localScale.y, healthbar.transform.localScale.x);
    }
}
