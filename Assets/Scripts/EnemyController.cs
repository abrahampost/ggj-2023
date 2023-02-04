using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Movement
    private Vector2 target;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;

    // stats
    private float baseSpeed = 3.5f;
    private float health = 10;

    // testing
    private bool speedModded = false;

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
        agent.speed = baseSpeed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        SetTargetPosition();
        SetAgentPosition();

        // player method tests
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(2);
        }

        if (Input.GetKeyDown("p"))
        {
            if (speedModded)
            {
                Debug.Log("P PRESSED");
                ModifySpeedByPercentage(1f);
            }
            else
            {
                Debug.Log("P PRESSED");
                ModifySpeedByPercentage(.5f);
            }

            speedModded = !speedModded;
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

    // Modify Stats
    public void TakeDamage(float value)
    {
        ModifyHealthByValue(-value);
    }

    public void Heal(float value)
    {
        ModifyHealthByValue(value);
    }

    public void ModifyHealthByValue(float value)
    {
        health += value;

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

    public void ModifySpeedByPercentage(float percentage)
    {
        agent.speed = baseSpeed * percentage;
    }
}
