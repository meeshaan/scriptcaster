using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

    bool BossFight2 = false;

    bool seen = false;
    Renderer rend;
    public float timer = 10.0f;
    int strength = 1;
    
    // Use this for initialization
   
     private GameManager1 gameManager1;
   
    void Start()
    {
        rend = GetComponent<Renderer>();
        if(GameObject.Find("GameManager1") == true)
        {
            GameObject Manager1 = GameObject.Find("GameManager1");
            gameManager1 = Manager1.GetComponent<GameManager1>();
        } 
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.isVisible)
            seen = true;

        if (seen && !rend.isVisible)
            Destroy(gameObject);

        timer -= Time.deltaTime;

        if (timer <= 0)
            Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Enemy")
            Destroy(gameObject);
        // else if(c.collider.tag == "Boss2"){
        //     Destroy(gameObject);
        //     gameManager1.BossFight2 = true;
        // }
    }

}
