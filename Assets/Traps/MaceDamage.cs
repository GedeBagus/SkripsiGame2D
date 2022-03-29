using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceDamage : MonoBehaviour
{
    private int maceDamage = 20;
    [SerializeField] private Character character;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")){
            Damage();
            Debug.Log("kena player");
        }
    }

    void Damage()
    {
        // maceDamage = 20;
        character.playerHealth = character.playerHealth - maceDamage;
        character.UpdateHealth();
    }
}
