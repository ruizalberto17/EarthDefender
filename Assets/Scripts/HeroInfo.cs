using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfo : MonoBehaviour {

    public bool IsDead;
    public static float TotalHealth;
    public float MaxHealth;
    private LevelManager LevelManage;
    public Text text;
    public GameObject DeathEffect;


    // Use this for initialization
    void Start () {
        IsDead = false;
        text = GetComponent<Text>();
        LevelManage = FindObjectOfType<LevelManager>();
        TotalHealth = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (TotalHealth <= 0){
            Instantiate(DeathEffect, transform.position, transform.rotation);
            LevelManage.RespawnPlayer();
            IsDead = true;
        }
        text.text = "" + TotalHealth;
	}

    public static void TakenDamage(float DamageToTake){
        TotalHealth = TotalHealth - DamageToTake;
    }
    public void FullHealth(){
        TotalHealth = 3;
        IsDead = false;
    }
}
