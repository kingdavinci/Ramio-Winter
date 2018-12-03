using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Vector3 startPosition;
    public Vector3 paceDirection = new Vector3(0, 0, 0);
    public float paceDistance = 3.0f;
    public float moveSpeed = 3.0f;
	// Use this for initialization
	void Start () {
        //store each enemies unique starting position
        startPosition = transform.position;
        paceDirection.Normalize();
        paceDirection = paceDirection * moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 displacement = transform.position - startPosition;
        float distanceFromStart = displacement.magnitude;
        if(distanceFromStart >= paceDistance)
        {
            //change directions
            paceDirection = -paceDirection;
        }
        GetComponent<Rigidbody2D>().velocity = paceDirection;
	}
}
