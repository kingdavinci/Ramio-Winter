using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject prefab;
    public float shootSpeed = 10;
    float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if(Input.GetButton("Fire1") && timer > 0.2f)
        {
            timer = 0;
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
            //when calculating a vector from a to b
            //always do destination - start position
            GameObject bullet = (GameObject)Instantiate(prefab,
                transform.position + offset, Quaternion.identity);
            bullet.GetComponent < Rigidbody2D>().velocity = shootDir;
            Destroy(bullet, 0.5f);
        }
	}
}
