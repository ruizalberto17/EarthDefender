using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject SplashAnimation;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
            Instantiate(SplashAnimation, transform.position, transform.rotation);

        }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
           
        if (collision.CompareTag("Projectile")){
            Instantiate(SplashAnimation, transform.position, transform.rotation);
            DestroyProjectile();
        }

        if (collision.CompareTag("Player")){
            Instantiate(SplashAnimation, transform.position, transform.rotation);
            DestroyProjectile();

        }
        Instantiate(SplashAnimation, transform.position, transform.rotation);
        DestroyProjectile();

    }
}
