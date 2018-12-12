using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour {

    public float Life = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Life -= Time.deltaTime;

        if(Life <= 0)
        {
            Destroy(gameObject);
        }
	}
}
