using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {
    public bool PlayerFinished;
    public string LevelToLoad;

	// Use this for initialization
	void Start () {
        PlayerFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.V) && PlayerFinished){
            Application.LoadLevel(LevelToLoad);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            PlayerFinished = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            PlayerFinished = false;
        }
    }

}
