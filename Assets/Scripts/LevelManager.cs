using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject Checkpoint;
    public GameObject Player;
    public HeroInfo HeroInfo;


	// Use this for initialization
	void Start () {
        HeroInfo = FindObjectOfType<HeroInfo>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void RespawnPlayer(){
        Debug.Log("Player Respawn");
        Player.transform.position = Checkpoint.transform.position;
        HeroInfo.FullHealth();
        //HeroInfo.IsDead = false;
    }
}
