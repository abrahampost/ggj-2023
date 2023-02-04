using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    // Movement
    public float speed;
    private Vector2 movement;
    private Vector2 target;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;

    // audio
    private PlayerSoundController soundController;

    // Animations
    private AnimationController animationController;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        soundController = GetComponent<PlayerSoundController>();
        animationController = GetComponent<AnimationController>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() 
    {
        SetTargetPosition();
        SetAgentPosition();
    }

    // private void FixedUpdate()
    // {
    //     float horizontal = Input.GetAxisRaw("Horizontal");
    //     float vertical = Input.GetAxisRaw("Vertical");
    //     movement = new Vector2(horizontal, vertical).normalized * speed * Time.deltaTime;
    //     rb.MovePosition(rb.position + movement);

    //     // Animation
    //     animationController.MovementAnimation(movement);

 	// 	// Audio
    //     soundController.PlayFootStepsIfMoving(movement);
    // }

    // AI
    //https://www.youtube.com/watch?v=DGBaEuZz-RA&t=102s
    private void SetTargetPosition()
    {
        // if (Input.GetKey(KeyCode.Mouse0)) {
            // target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(target);
        // }
        
        // target = new Vector2(player.transform.x, player.transform.y);
        target = player.transform.position;

    }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector2(target.x, target.y));
    }
}
