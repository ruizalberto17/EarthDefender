using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProjectileMovement : MonoBehaviour {

    public float speed;
    private HeroController player;
    private Rigidbody2D HeroProjectile;
    public GameObject Hero;
    public GameObject SplashAnimation;
    public GameObject DeathAnimation;
    public float RotationSpeed;
    public float HeroSpeed;
    public int ProjectileDamage;

	// Use this for initialization
	void Start () {
        HeroProjectile = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<HeroController>();

        if (player.Speed < 0) {
            speed = -speed;
            RotationSpeed = -RotationSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {
        HeroProjectile.velocity = new Vector2(speed, HeroProjectile.velocity.y);
        HeroProjectile.angularVelocity = RotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy"){
            //Instantiate(DeathAnimation, collision.transform.position, Quaternion.identity);
            //Destroy(collision.gameObject);
            collision.GetComponent<EnemyHealth>().GiveDamage(ProjectileDamage);
        }
        if(collision.tag == "Projectile"){
            Destroy(collision.gameObject);
        }
        Instantiate(SplashAnimation, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
