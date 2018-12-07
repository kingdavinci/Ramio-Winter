using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitbullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Snow")
        {
            Destroy(collision.gameObject);
        }
	}
}
