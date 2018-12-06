using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour {

    public Vector2 ThrowDirection = new Vector2();
    public GameObject Poof;
    public float Lifetime = 3.5f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = ThrowDirection;
	}
	
	// Update is called once per frame
	void Update () {
        Lifetime -= Time.deltaTime;
        if (Lifetime <= 0)
        {
            Instantiate(Poof, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(Poof, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
