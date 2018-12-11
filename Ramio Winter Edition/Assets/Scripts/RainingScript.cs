using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainingScript : MonoBehaviour {

    public GameObject RainDrop;
    float Delay = 2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Delay -= Time.deltaTime;
        if(Delay <= 0)
        {
            Instantiate(RainDrop, transform.position, Quaternion.identity);
            Delay = 2;
        }
	}
}
