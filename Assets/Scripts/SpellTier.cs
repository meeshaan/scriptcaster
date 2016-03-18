using UnityEngine;
using System.Collections;

public class SpellTier : MonoBehaviour {

	private TextControlScript tier1;
	private TextControlScript tier2;
	private TextControlScript tier3;

	// Use this for initialization
	void Start () {
		tier1 = GameObject.Find ("CastPoint").GetComponent<TextControlScript> ();
		tier2 = GameObject.Find ("CastPoint").GetComponent<TextControlScript> ();
		tier3 = GameObject.Find ("CastPoint").GetComponent<TextControlScript> ();

		//tier1.spellTier1 = false;
		//tier2.spellTier1 = false;
		//tier3.spellTier1 = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//spell tier 
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Tier1")
		{
			tier1.spellTier1 = true;
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "Tier2" && tier1.spellTier1 == true)
		{
			tier2.spellTier2 = true;
			Destroy (c.gameObject);
		}
		else if (c.gameObject.tag == "Tier3" && tier1.spellTier1 == true && tier2.spellTier2 == true)
		{
			tier3.spellTier3 = true;
			Destroy (c.gameObject);
		}
	}
}
