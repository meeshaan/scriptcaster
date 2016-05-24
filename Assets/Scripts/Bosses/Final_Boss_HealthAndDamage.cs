using UnityEngine;
using System.Collections;

public class Final_Boss_HealthAndDamage : MonoBehaviour {
    public GameObject final_boss_manager;
    public int typeID; //1==fire, 2==water, 3==wind, 4==earth
    private int health;
    private int stageInt; //used to determine when to switch stage
    private bool invincible;

    // Use this for initialization
    void Start()
    {
        health = final_boss_manager.GetComponent<Final_Boss_manager>().health;
        invincible = false;
        stageInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( final_boss_manager.GetComponent<Final_Boss_manager>().health <= 0)
        {
            Destroy(this.gameObject);
        }
        
        if(stageInt >= 2){
            this.GetComponent<Final_Boss_Movement>().ChooseRandomStage();
            stageInt = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D c){
        if(!final_boss_manager.GetComponent<Final_Boss_manager>().isInvicible){
            if (c.gameObject.tag == "fireball"){
                this.GetComponent<Final_Boss_Movement>().StartInvincibility(3f);
                final_boss_manager.GetComponent<Final_Boss_manager>().health -= 1;
                stageInt += 1;
            }            
        }
    }
    
    void OnTriggerEnter2D(Collider2D c) {
        if(!final_boss_manager.GetComponent<Final_Boss_manager>().isInvicible){
            if (c.gameObject.tag == "fireball"){
                this.GetComponent<Final_Boss_Movement>().StartInvincibility(3f);
                final_boss_manager.GetComponent<Final_Boss_manager>().health -= 1;
                stageInt += 1;
            }            
        }
    }

    void OnGUI()
    {
    }
}
