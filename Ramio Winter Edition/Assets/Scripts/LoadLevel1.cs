using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour {
    public void Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
}
