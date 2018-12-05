using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour {

    public GameObject Snowball;
    public Vector2 ThrowDirection = new Vector2();
    float ThrowDelay = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ThrowDelay -= Time.deltaTime;
        if(ThrowDelay <= 0)
        {
            Instantiate(Snowball, transform.position, Quaternion.identity);
        }
	}
}
