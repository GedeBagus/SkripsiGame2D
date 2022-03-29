using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Damage : MonoBehaviour
{
    private int enemy1Damage = 40;
    bool crRunning = false;
    [SerializeField] private Character character;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (crRunning == false)
        {
            if (collision.CompareTag("Player"))
            {
            StartCoroutine ("Damage");
            Debug.Log("kena player");
            }
        }
    }

    IEnumerator Damage()
    {
        crRunning = true;
        character.currentHealth = character.currentHealth - enemy1Damage;
        character.UpdateHealth();
        yield return new WaitForSeconds(1f);
        crRunning = false;
    }
}
