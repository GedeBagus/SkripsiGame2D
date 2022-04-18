using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int health = 100;
	private Animator anim;
		
	float dirX, moveSpeed = 6f;
	bool moveRight = true;
	public bool playerNear = false;

	// public GameObject deathEffect;
	void Start(){
		anim = GetComponent<Animator>();
	}

	// void update(){
	// 	if (Mathf.Abs(dirX) > 0)
    //     {
    //         anim.SetBool("isRunning", true);
    //     } 
	// }

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		// Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D Area) {
        if (moveRight == true) {
            moveRight = false;
			transform.Rotate(0f, 180f, 0f);
        }
        else {
            moveRight = true;
			transform.Rotate(0f, 180f, 0f);
        }
    }

    void Update () {
		if (moveRight && playerNear == true){
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
			anim.SetBool("isRunning", true);
		}
			
		else if (moveRight == false && playerNear == true){
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
			anim.SetBool("isRunning", true);
		}
			
	}  
}