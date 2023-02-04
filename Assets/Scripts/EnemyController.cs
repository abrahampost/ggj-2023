using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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

    // stats
    private float health = 10f;
    private float damage = 2f;
    
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

        if (Input.GetKeyDown("space"))
        {
            decreaseHealth(2);
        }
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
        
        target = player.transform.position;
    }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector2(target.x, target.y));
    }

    public void decreaseHealth(float damageDelt)
    {
        health -= damageDelt;

        if (health <= 0)
        {
            soundController.playDeathScream();
            animationController.DeathAnimation();
            Destroy(gameObject, 1);

            return;
        }

        soundController.playOnHit();
        animationController.HitAnimation();
    }
    
}
