using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceMove : MonoBehaviour
{
    [SerializeField] private LayerMask TrapArea;
       
    // Start is called before the first frame update
    // void Start()
    // {
    //     // rb.velocity = transform.right * speed;
    // }

    float dirX, moveSpeed = 6f;
	bool moveRight = true;

	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D Area) {
        // if (Area == TrapArea){

        // }        
        if (moveRight == true) {
            moveRight = false;
        }
        else {
            moveRight = true;
        }
    }

    void Update () {
	// 	if (transform.position.x > 4f)
	// 		moveRight = false;
	// 	if (transform.position.x < -4f)
	// 		moveRight = true;

		if (moveRight)
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		else
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
	}  
}
