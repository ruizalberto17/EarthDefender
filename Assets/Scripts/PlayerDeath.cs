using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public LevelManager LevelManage;
	// Use this for initialization
	void Start () {
        LevelManage = FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            LevelManage.RespawnPlayer();
        }
    }
}
