using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        //attaching this script to the portal
        //will load the win screen when player collides
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level4");
        }
    }
}
