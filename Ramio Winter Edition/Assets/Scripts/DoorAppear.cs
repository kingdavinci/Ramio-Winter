using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAppear : MonoBehaviour {

    public GameObject door;

    void OnTriggerEnter2D(Collider2D collision)
    {
        door.SetActive(true);
    }
}
