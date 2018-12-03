using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {
    public int hp = 10;
    public GameObject prefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hp--;
            if (hp <= 0)
            {
                Destroy(gameObject);
                int r = Random.Range(0, 12);
                if (r == 2)
                {
                    Instantiate(prefab, transform.position,
                         Quaternion.identity);
                }
            }
        }

    }
}
