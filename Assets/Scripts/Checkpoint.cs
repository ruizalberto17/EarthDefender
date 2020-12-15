using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public LevelManager LevelManage;

	// Use this for initialization
	void Start () {
        LevelManage = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            LevelManage.RespawnPlayer();
        }
    }
}
