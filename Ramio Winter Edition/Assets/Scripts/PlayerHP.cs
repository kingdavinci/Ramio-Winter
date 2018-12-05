using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour {
    public float hp = 25;
    public int lives = 3;
    public Text healthText;
    public Slider healthBar;
    public float timer = 300;
    public Text timerText;
	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives");
        healthText.GetComponent<Text>().text = "Health: " + hp;
        healthBar.GetComponent<Slider>().value = hp;
        timerText.GetComponent<Text>().text = "time:" + Mathf.RoundToInt(timer);
	}
    void Update() {
        timer -= Time.deltaTime;
        timerText.GetComponent<Text>().text = "time:" + Mathf.RoundToInt(timer);
        if (timer <= 0.0f)
        {
            PlayerPrefs.SetInt("Lives", lives - 1);
            SceneManager.LoadScene("Lose");
        }
        if (hp <= 0)
        {
            PlayerPrefs.SetInt("Lives", lives - 1);
            SceneManager.LoadScene("Lose");
        }
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float yVelocity = GetComponent<Rigidbody2D>().velocity.y;
            if (collision.gameObject.tag == "Enemy" && yVelocity >= 0)
            {
                hp -= 1;
                healthText.GetComponent<Text>().text = "Health: " + hp;
                healthBar.GetComponent<Slider>().value = hp;
            }
            else if (collision.gameObject.tag == "Enemy" && yVelocity < 0)
            {
                Destroy(collision.gameObject);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
            }
        }
        if (collision.gameObject.tag == "Fire")
        {
            hp -= 1;
            healthText.GetComponent<Text>().text = "Health: " + hp;
            healthBar.GetComponent<Slider>().value = hp;
        }
        if (collision.gameObject.tag == "MedKit")
        {
            hp += 1;
            Destroy(collision.gameObject);
            healthText.GetComponent<Text>().text = "Health: " + hp;
            healthBar.GetComponent<Slider>().value = hp;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            hp -= 1;
            healthText.GetComponent<Text>().text = "Health: " + hp;
            healthBar.GetComponent<Slider>().value = hp;
        }
        if (collision.gameObject.tag == "Icicles")
        {
            hp -= 1;
            healthText.GetComponent<Text>().text = "Health: " + hp;
            healthBar.GetComponent<Slider>().value = hp;
        }
    }
}
