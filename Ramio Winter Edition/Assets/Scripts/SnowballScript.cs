using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour {

    public Vector2 ThrowDirection = new Vector2();
    public GameObject Poof;
    public float Lifetime = 4f;
    public bool Aimed = false;

	// Use this for initialization
	void Start () {
        if(Aimed)
        {
            Lifetime = 100;
            GetComponent<Rigidbody2D>().AddForce(new Vector2((GameObject.FindGameObjectWithTag("Player").transform.position.normalized.x - transform.position.x) * -(GameObject.FindGameObjectWithTag("Player").transform.position.normalized.x - transform.position.x) * 3.2f, (GameObject.FindGameObjectWithTag("Player").transform.position.y - transform.position.y) - ((GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x) * .3f) * 50));
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = ThrowDirection;
        }
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
