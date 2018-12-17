﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    public GameObject Snowball;
    float ThrowDelay = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ThrowDelay -= Time.deltaTime;
        if(ThrowDelay <= 0)
        {
            Instantiate(Snowball, transform.position, Quaternion.identity);
            ThrowDelay = 1;
        }
	}
}
