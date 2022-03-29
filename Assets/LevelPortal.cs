using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    private int SceneLoad;
    void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(SceneLoad);
        }
    }
}
