using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveAndAnimate : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float JumpSpeed = 1f;
    bool Grounded = false;
    float Jumping = 0;
    bool Launched = false;
    float LaunchTimer;
    public bool Running = false;
    public bool Idle = true;
    public bool Submerged = false;

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float xRaw = Input.GetAxisRaw("Horizontal");
        if (xRaw != 0)
        {
            GetComponent<Animator>().SetFloat("X", xRaw);
        }
        Vector3 Velocity = GetComponent<Rigidbody2D>().velocity;
        Jumping -= Time.deltaTime;
        LaunchTimer -= Time.deltaTime;
        if (LaunchTimer <= 0)
        {
            Launched = false;
        }
        if (Time.timeScale == 1 && !Launched && !Submerged)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2((MoveX * MoveSpeed * 4) - (Velocity.x * 2), 0));
        }
        if (Input.GetButtonDown("Jump") && Grounded && Time.timeScale == 1 && !Launched)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 50 * JumpSpeed));
            Jumping = .05f;
        }
        if (Input.GetButton("Jump") && Jumping > 0 && Time.timeScale == 1 && !Launched && !Submerged)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15 * JumpSpeed));
        }
        if(Submerged)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2((Input.GetAxis("Horizontal") * MoveSpeed * 4) - (Velocity.x * 2), (Input.GetAxis("Vertical") * MoveSpeed * 4) - (Velocity.y * 2)));
        }

        if (MoveX < 1 && MoveX > -1 && Grounded)
        {
            GetComponent<Animator>().SetBool("Jumping", false);
            GetComponent<Animator>().SetBool("Running", false);
            GetComponent<Animator>().SetBool("Idle", true);
        }
        else
        if (!Grounded)
        {
            GetComponent<Animator>().SetBool("Jumping", true);
            GetComponent<Animator>().SetBool("Running", false);
            GetComponent<Animator>().SetBool("Idle", false);
        }
        else
        if (MoveX == 1)
        {
            //GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Jumping", false);
            GetComponent<Animator>().SetBool("Running", true);
            GetComponent<Animator>().SetBool("Idle", false);
        }
        else
        if (MoveX == -1)
        {
            //GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Jumping", false);
            GetComponent<Animator>().SetBool("Running", true);
            GetComponent<Animator>().SetBool("Idle", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Grounded = true;
        }
        if (collision.gameObject.name == "LevelTransition")
        {
            SceneManager.LoadScene("Scene2");
        }
        if (collision.gameObject.name == "LevelTransition2")
        {
            SceneManager.LoadScene("WinScene");
        }
        if (collision.gameObject.tag == "Launcher")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(collision.gameObject.GetComponent<Launcher>().Force.x, collision.gameObject.GetComponent<Launcher>().Force.y));
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<PlayerHP>().hp -= collision.gameObject.GetComponent<Launcher>().Damage;
            Launched = true;
            LaunchTimer = collision.gameObject.GetComponent<Launcher>().Stun;
        }
        if(collision.gameObject.layer == 4)
        {
            Submerged = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Grounded = true;
        }
        if (collision.gameObject.layer == 4)
        {
            Submerged = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Grounded = false;
        }
        if (collision.gameObject.layer == 4)
        {
            Debug.Log("leaving water");
            Submerged = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Time.timeScale == 1)
        {
            Vector2 KnockBack = transform.position - collision.gameObject.transform.position;
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity / 2;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.RoundToInt(KnockBack.x) * (16 * collision.gameObject.GetComponent<EnemyScript>().Knockback), Mathf.RoundToInt(KnockBack.y) * (13 * collision.gameObject.GetComponent<EnemyScript>().Knockback)));
        }
    }
}

