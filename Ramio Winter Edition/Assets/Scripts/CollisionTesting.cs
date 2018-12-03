using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTesting : MonoBehaviour
{
    //this function will run once at the start
    //of each new collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I started a new collision!");
    }

    //This function will run every every frame that we
    //continue to be in a collision
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("I am staying in collision");
    }

    //This function will run once when we end
    //our collision
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("I left my collision");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name +
            " triggered me.");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("I left the trigger");
    }

     void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("I'm inside the trigger");
    }
}
