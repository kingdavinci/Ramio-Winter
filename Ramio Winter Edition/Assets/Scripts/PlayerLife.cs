using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    public Slider Healthbar;
    public Text Countdown;
    public Text LifeCount;
    public float Health = 10;
    int Lives = 5;
    float DeathTimer = 180;


    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.SetInt("Lives", Lives);
        //PlayerPrefs.SetFloat("DeathTimer", DeathTimer);
        DeathTimer = PlayerPrefs.GetFloat("DeathTimer");
        Lives = PlayerPrefs.GetInt("Lives");
        Debug.Log(Lives);
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.value = Health;
        LifeCount.text = "Lives Left: " + Lives;
        DeathTimer -= Time.deltaTime;
        PlayerPrefs.SetFloat("DeathTimer", DeathTimer);
        Countdown.text = "" + Mathf.Round(DeathTimer);
        if (DeathTimer <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        if (Health <= 0 && Lives > 0)
        {
            PlayerPrefs.SetInt("Lives", Lives - 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Health <= 0 && Lives == 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float YVelocity = GetComponent<Rigidbody2D>().velocity.y;
        if (collision.gameObject.tag == "Enemy" && YVelocity >= 0)
        {
            Health -= collision.gameObject.GetComponent<EnemyScript>().Damage;
        }
        else if (collision.gameObject.tag == "Enemy" && YVelocity < 0 && collision.gameObject.GetComponent<EnemyScript>().Invincible)
        {

        }
        else if (collision.gameObject.tag == "Enemy" && YVelocity < 0)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Magma")
        {
            Health -= .1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallingMagma")
        {
            Health -= 2;
        }
    }
}

