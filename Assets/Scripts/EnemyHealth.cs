using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float Health;
    public GameObject DeathEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Health <= 0){
            Instantiate(DeathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

	}

    public void GiveDamage(int DamageToGive){
        Health -= DamageToGive;
    }
}
