using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCollision : MonoBehaviour {

    public GameObject explosion;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("Collision");
        Destroy(gameObject);
        GameObject impact = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
    }
}
