﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.tag == "Player")
        {
                Destroy(gameObject);
        }
    }
}
