using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public int Speed;
    public bool MoveForward = true;
    private Rigidbody2D EnemyBody;
    public Transform Player;
    public Transform WallDetector;
    public Transform WallDetector2;
    public float StoppingDistance;
    public Transform ProjectileStartForward;
    public GameObject ProjectileForwards;
    public float TimeBetweenShots;
    public float StartTimeBetweenShots;

    // Use this for initialization
    void Start()
    {
        EnemyBody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyBody.velocity = new Vector2(0,Speed);
        TimeBetweenShots = StartTimeBetweenShots;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D front = Physics2D.Raycast(WallDetector.position, Vector2.up, 1f);
        RaycastHit2D back = Physics2D.Raycast(WallDetector2.position, Vector2.down, 1f);
        Debug.DrawRay(WallDetector.position, Vector2.up * 1f);
        Debug.DrawRay(WallDetector2.position, Vector2.down * 1f);
        if (front.collider == true || back.collider == true)
        {
            MoveForward = !MoveForward;
        }
        if (MoveForward == true)
        {
            EnemyBody.velocity = new Vector2(0,Speed);
        }
        else
        {
            EnemyBody.velocity = new Vector2(0,-Speed);
        }
        if (Vector2.Distance(EnemyBody.position, Player.position) < StoppingDistance)
        {
            EnemyBody.velocity = new Vector2(0, 0);
        }
        if (TimeBetweenShots <= 0)
        {
            Instantiate(ProjectileForwards, ProjectileStartForward.position, Quaternion.identity);
            TimeBetweenShots = StartTimeBetweenShots;
        }
        else
        {
            TimeBetweenShots -= Time.deltaTime;
        }
    }
}
