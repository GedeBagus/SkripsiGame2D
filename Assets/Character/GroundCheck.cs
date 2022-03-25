using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    
    [SerializeField] private LayerMask ground;
    public bool IsGrounded;
    
    private void OnTriggerStay2D(Collider2D collider) {
        IsGrounded = collider != null && (((1 << collider.gameObject.layer) & ground) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        IsGrounded = false;
    }
}
