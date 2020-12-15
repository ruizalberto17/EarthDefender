using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public HeroController Hero;
    private Vector3 LastHeroPosition;
    private float MoveDistancex;
    private float MoveDistancey;

	// Use this for initialization
	void Start () {
        Hero = FindObjectOfType<HeroController>();
        LastHeroPosition = Hero.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + MoveDistancey + 1, transform.position.z);
    }

    // Update is called once per frame
    void Update () {

        MoveDistancey = Hero.transform.position.y - LastHeroPosition.y;
        MoveDistancex = Hero.transform.position.x - LastHeroPosition.x;
        transform.position = new Vector3(transform.position.x + MoveDistancex, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + (MoveDistancey * .5f), transform.position.z);
        LastHeroPosition = Hero.transform.position;
	}
}
