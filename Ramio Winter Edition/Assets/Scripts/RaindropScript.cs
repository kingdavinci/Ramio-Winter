using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaindropScript : MonoBehaviour {

    public GameObject Splash;
    public float Lifetime = 4f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
        {
            Instantiate(Splash, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Splash, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(gameObject);
    }
}