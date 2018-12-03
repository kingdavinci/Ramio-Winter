using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public GameObject prefab;
    public GameObject player;
    public float bulletSpeed = 10f;
    public float shootDistance = 5;
    public float bulletLifetime = 1.0f;
    public float shootDelay = 1.0f;
    private float timer = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 shootDir = player.transform.position - transform.position;
        if(shootDir.magnitude < shootDistance && timer >= shootDelay)
        {
            Vector2 shootDirection = shootDir;
            //create the bullet object

            //reduce the length of the direction to 1, so it is always the same regardless of how far away
            //the mouse is from the player. 
            shootDirection.Normalize();

            Vector3 spawnPosition = transform.position;
            spawnPosition.x += shootDirection.x * 0.2f;
            spawnPosition.y += shootDirection.y * 0.2f;

            //create the object in front of the player
            GameObject bullet = (GameObject)Instantiate(prefab, spawnPosition, Quaternion.identity);
            //apply the velocity in the shoot direction
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, bulletLifetime);
            timer = 0;
        }
    }
}
