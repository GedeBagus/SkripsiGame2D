using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceDamage : MonoBehaviour
{
    private int maceDamage = 20;
    bool crRunning = false;
    [SerializeField] private Character character;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (crRunning == false)
        {
            if (collision.CompareTag("Player"))
            {
            // Damage();
            StartCoroutine ("Damage");
            Debug.Log("kena player");
            }
        }
        // if (collision.CompareTag("Player")){
        //     // Damage();
        //     StartCoroutine ("Damage");
        //     Debug.Log("kena player");
        // }
    }

    // void Damage()
    // {
    //     // maceDamage = 20;
    //     character.currentHealth = character.currentHealth - maceDamage;
    //     character.UpdateHealth();
    // }

    IEnumerator Damage()
    {
        crRunning = true;
        character.currentHealth = character.currentHealth - maceDamage;
        character.UpdateHealth();
        yield return new WaitForSeconds(1f);
        crRunning = false;
    }
}
