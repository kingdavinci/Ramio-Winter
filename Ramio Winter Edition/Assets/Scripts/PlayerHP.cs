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
    public float timer2 = 0;
    public Text timerText;
    public GameObject prefab;
    public float shootSpeed = 10;
    public bool fruitcake = false;
    public GameObject DeathScreen;

    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetInt("Lives", lives);
        lives = PlayerPrefs.GetInt("Lives");
        healthText.GetComponent<Text>().text = "Health: " + hp;
        healthBar.GetComponent<Slider>().value = hp;
        timerText.GetComponent<Text>().text = "time:" + Mathf.RoundToInt(timer);
        hp = 25;
	}
    void Update() {
        timer -= Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer2 >= 15)
        {
            fruitcake = false;
        }
        timerText.GetComponent<Text>().text = "time:" + Mathf.RoundToInt(timer);
        if (timer <= 0.0f)
        {
            PlayerPrefs.SetInt("Lives", lives - 1);
            DeathScreen.GetComponent<Canvas>().enabled = true;
        }
        if (hp <= 0)
        {
            PlayerPrefs.SetInt("Lives", lives - 1);
            DeathScreen.GetComponent<Canvas>().enabled = true;
        }
        if (fruitcake == true && Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            Debug.Log("X is " + mousePosition.x + " and y is " + mousePosition.y + " and z is " + mousePosition.z);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log("X is " + mousePosition.x + " and y is " + mousePosition.y + " and z is " + mousePosition.z);
            mousePosition.z = 0;
            Vector3 shootDir = mousePosition - transform.position;
            shootDir.Normalize();
            Vector3 offset = shootDir;
            offset = offset * 0.3f;
            shootDir = shootDir * shootSpeed;
            GameObject bullet = (GameObject)Instantiate(prefab,
               transform.position + offset, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir;
            Destroy(bullet, 0.5f);
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
        if (collision.gameObject.tag == "FruitCake")
        {
            fruitcake = true;
            Destroy(collision.gameObject);
            timer2 = 0;
        }
    }
}
