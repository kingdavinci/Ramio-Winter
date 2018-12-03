using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0)
        {
            float x = Input.GetAxis("Horizontal");
            GetComponent<Animator>().SetFloat("X", x);
            GetComponent<Animator>().SetFloat("Y", 0);
            GetComponent<Animator>().SetBool("Idle", false);
        }else if (Input.GetAxis("Vertical") != 0)
        {
            float y = Input.GetAxis("Vertical");
            GetComponent<Animator>().SetFloat("Y", y);
            GetComponent<Animator>().SetFloat("X", 0);
            GetComponent<Animator>().SetBool("Idle", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Idle", true);
            GetComponent<Animator>().SetFloat("X", 0);
            GetComponent<Animator>().SetFloat("Y", 0);
        }
	}
}
