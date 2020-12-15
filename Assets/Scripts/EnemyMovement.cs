using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int Speed;
    public bool MoveForward = true;
    private Rigidbody2D EnemyBody;
    public Transform WallDetector;
    public Transform WallDetector2;
    private Animator MyAnimator;
    public float StoppingDistance;
    public Transform ProjectileStartForward;
    public Transform ProjectileStartBackwards;
    public GameObject ProjectileForwards;
    public GameObject ProjectileBackwards;
    public float TimeBetweenShots;
    public float StartTimeBetweenShots;
    public Transform Player;
    // Use this for initialization
    void Start()
    {
        EnemyBody = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        EnemyBody.velocity = new Vector2(Speed, 0);
        Player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D front = Physics2D.Raycast(WallDetector.position, Vector2.down, .4f);
        RaycastHit2D back = Physics2D.Raycast(WallDetector2.position, Vector2.down, .4f);
        Debug.DrawRay(WallDetector.position, Vector2.down * .4f);
        Debug.DrawRay(WallDetector2.position, Vector2.down * .4f);

        if (front.collider == false || back.collider == false)
        {
            MoveForward = !MoveForward;
        }
        if (MoveForward == true)
        {
            EnemyBody.velocity = new Vector2(Speed, 0);
            MyAnimator.SetFloat("Speed", EnemyBody.velocity.x);

        }
        else
        {
            EnemyBody.velocity = new Vector2(-Speed, 0);
            MyAnimator.SetFloat("Speed", EnemyBody.velocity.x);

        }
        if (Vector2.Distance(EnemyBody.position, Player.position) < StoppingDistance)
        {
            EnemyBody.velocity = new Vector2(0, 0);
            if (TimeBetweenShots <= 0)
            {
                if (MoveForward == true)
                {
                    Instantiate(ProjectileForwards, ProjectileStartForward.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(ProjectileBackwards, ProjectileStartBackwards.position, Quaternion.identity);

                }
                TimeBetweenShots = StartTimeBetweenShots;
            }
            else
            {
                TimeBetweenShots -= Time.deltaTime;
            }
        }
    }
}
