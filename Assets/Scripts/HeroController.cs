using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    public float Speed, Height;
    private Rigidbody2D HeroBody;
    public bool grounded;
    public bool crouch;
    public LayerMask whatIsGround;
    private Collider2D HeroCollider;
    private Animator MyAnimator;
    public GameObject HeroProjectile;
    public Transform ProjectileStartForward;
    public Transform ProjectileStartBackward;

    public float ShotDelay;
    private float ShotDelayCounter;

    // Use this for initialization
    void Start()
    {
        HeroBody = GetComponent<Rigidbody2D>();
        HeroCollider = GetComponent<BoxCollider2D>();
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(HeroCollider, whatIsGround);
        if (grounded == true){
            MyAnimator.SetBool("Ground", true);
        }
            if (Input.GetKey(KeyCode.RightArrow))
        {
            HeroBody.velocity = new Vector2(4, HeroBody.velocity.y);
            MyAnimator.SetFloat("Speed", HeroBody.velocity.x);
            Speed = HeroBody.velocity.x;
            crouch = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            HeroBody.velocity = new Vector2(-4, HeroBody.velocity.y);
            MyAnimator.SetFloat("Speed", HeroBody.velocity.x);
            Speed = HeroBody.velocity.x;
            crouch = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded == true){
                HeroBody.velocity = new Vector2(HeroBody.velocity.x, 15);
                GetComponent<AudioSource>().Play();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            if (Speed > 0)
            {
                Instantiate(HeroProjectile, ProjectileStartForward.position, Quaternion.identity);
                ShotDelayCounter = ShotDelay;
            }
            if (Speed < 0)
            {
                Instantiate(HeroProjectile, ProjectileStartBackward.position, Quaternion.identity);
                ShotDelayCounter = ShotDelay;
            }
        }
        if(Input.GetKey(KeyCode.Space)){
            ShotDelayCounter -= Time.deltaTime;
            if(ShotDelayCounter <= 0){
                ShotDelayCounter = ShotDelay;
                if (Speed > 0)
                {
                    Instantiate(HeroProjectile, ProjectileStartForward.position, Quaternion.identity);
                }
                if(Speed < 0){
                    Instantiate(HeroProjectile, ProjectileStartBackward.position, Quaternion.identity);

                }
            }
        }
        MyAnimator.SetBool("Ground", grounded);
        if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
        {
            if (!crouch)
            {
                crouch = true;
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    MyAnimator.SetBool("Crouch", true);
                }
                else
                {
                    MyAnimator.SetBool("Crouch", false);
                }
                HeroBody.velocity = new Vector2(0, HeroBody.velocity.y);
                MyAnimator.SetFloat("Speed", HeroBody.velocity.x);
                Speed = HeroBody.velocity.x;
            }
        }
        PlayerRaycast();
    }
    void PlayerRaycast(){
    }
}
