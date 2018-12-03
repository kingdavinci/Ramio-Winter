using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int Type = 0;
    public int Damage = 0;
    public int Knockback = 50;
    public float Speed = 5;
    public float JumpSpeed = 5;
    public GameObject Player;
    public bool Grounded = false;
    public Vector2 PatrolCenter;
    public float PatrolRange;
    int PatrolDirection = 1;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PatrolCenter = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Velocity = GetComponent<Rigidbody2D>().velocity;

        if (Type == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2((new Vector2(Player.transform.position.x - transform.position.x, 0).normalized.x * Speed) - (Velocity.x * 2), 0));
            if (Player.transform.position.y > transform.position.y && Grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50 * JumpSpeed));
            }
        }

        if (Type == 1)
        {
            Knockback = Mathf.RoundToInt(GetComponent<Rigidbody2D>().velocity.magnitude) * 8;
            if ((Player.transform.position - transform.position).magnitude > 5)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2((Player.transform.position - transform.position).normalized.x, (Player.transform.position - transform.position).normalized.y) * 5);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 6), Random.Range(-5, 6)));
            }
        }

        if (Type == 2)
        {
            if ((Player.transform.position - transform.position).x > 5 || (Player.transform.position - transform.position).x < -5)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2((Player.transform.position - transform.position).x - (Velocity.x * 2), 0) * Speed);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 6), 0));
            }

            if (((Player.transform.position.y + 5) - transform.position.y) > 1 || ((Player.transform.position.y + 5) - transform.position.y) < -1)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, ((Player.transform.position.y + 5) - transform.position.y) - (Velocity.y * 2)) * Speed);
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(-5, 6)));
            }
        }

        if (Type == 3)
        {
            if (PatrolCenter.x - PatrolRange >= transform.position.x)
            {
                PatrolDirection = 1;
            }
            else if (PatrolCenter.x + PatrolRange <= transform.position.x)
            {
                PatrolDirection = -1;
            }
            GetComponent<Rigidbody2D>().AddForce(new Vector2((new Vector2(PatrolDirection, 0).normalized.x * Speed) - (Velocity.x * 2), 0));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Grounded = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Grounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Grounded = false;
        }
    }
}
