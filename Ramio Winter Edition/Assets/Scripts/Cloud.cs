using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "CloudDestroy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
	}
}
