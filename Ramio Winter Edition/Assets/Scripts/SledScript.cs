using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledScript : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Rigidbody2D>().rotation != 0)
        {
            GetComponent<Rigidbody2D>().rotation = Mathf.Round(GetComponent<Rigidbody2D>().rotation * .1f);
        }
	}
}
