using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private new GameObject gameObject;  // Idk what 'new' does here, but it removed a warning

    // Movement Animations
    public void MovementAnimations(Vector2 movement) 
    {
        // Left and Right
        if (movement.x < 0) {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        } else if (movement.x > 0) {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        // Idling for up/down motion
        if (movement.magnitude == 0) {
            animator.SetBool("is_idle", true);
        } else {
            animator.SetBool("is_idle", false);
        }

        // Running?
        animator.SetFloat("speed_x", Mathf.Abs(movement.x));
        animator.SetFloat("speed_y", movement.y);
    }
}
