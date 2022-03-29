using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth = 100;
    [SerializeField] private Text healthText;

    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("0");

        if (playerHealth <= 0){
            Debug.Log("Game Over");
        }
    }
}
