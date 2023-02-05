using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Movement
    private Vector2 target;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;
    private GameObject tree;

    // stats
    private float baseSpeed = 3.5f;
    private float baseAcceleration;
    private float health = 10;

    // testing
    private bool speedModded = false;

    // audio
    private PlayerSoundController soundController;

    // Animations
    private AnimationController animationController;
    private SpriteRenderer spriteRenderer;
    private Color originColor;

    // Attack
    // [SerializeField]
    // private GameObject attack;
    public GameObject attack;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        tree = GameObject.FindWithTag("Tree");

        soundController = GetComponent<PlayerSoundController>();
        animationController = GetComponent<AnimationController>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = baseSpeed;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        baseAcceleration = agent.acceleration;

        spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[0];
        originColor = spriteRenderer.color;
    }

    private void Update()
    {
        SetTargetPosition();
        SetAgentPosition();

        // Attack if close to target
        if (DistanceToTarget() < 2) {
            // Debug.Log("ATTACK");
            gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            StartCoroutine(ResetMotion());
            IEnumerator ResetMotion()
            {
                yield return new WaitForSecondsRealtime(1.0f);
                gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;
            }
            FindFirstObjectByType<AttackSoundController>().SkellyMeleeAttack();
            Attack();
        }

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

        // Audio
        if (!gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped)
        {
            soundController.PlayFootStepsIfMoving(new Vector2(1, 1));
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

        if (target.x - transform.position.x > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
        } else {
            transform.eulerAngles = new Vector3(0, 180, 0); // normal
        }
    }

    private float DistanceToTarget() 
    {
        return Vector2.Distance(transform.position, target);
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

        // Color on hit
        if (value < 0) {
            SetColor(new Color(100, 0, 0));

            StartCoroutine(ResetColor());
            IEnumerator ResetColor()
            {
                yield return new WaitForSecondsRealtime(0.2f);
                SetColor(originColor);
            }
        }

        if (health <= 0)
        {
            agent.speed = 0;
            soundController.playDeathScream();
            animationController.DeathAnimation();
            Destroy(gameObject, 1.0f);

            return;
        }

        soundController.playOnHit();
        animationController.HitAnimation();
    }

    public void ModifySpeedByPercentage(float percentage, float time = .1f)
    {
        if (baseSpeed * percentage < agent.speed)
        {
            agent.acceleration = 60;
            agent.speed = baseSpeed * percentage;
            StartCoroutine(WaitForTime());

            IEnumerator WaitForTime()
            {
                yield return new WaitForSecondsRealtime(time);
                agent.acceleration = baseAcceleration;
                agent.speed = baseSpeed;
            }
        }
    }

    public string Bark()
    {
        return "woof";
    }

    private void SetColor(Color color) {
        spriteRenderer.color = color;
    }

    private void Attack() 
    {
        // instantiate attack obj
        // wait and destroy
        // animation
        // GameObject attack = EnemyAttack.Init(gameObject);
        // EnemyAttack attack = new EnemyAttack(gameObject);

        GameObject newAttack = Instantiate(attack, transform.position, transform.rotation);
        newAttack.GetComponent<EnemyAttack>().parent = gameObject;
        newAttack.GetComponent<EnemyAttack>().damage = 10.0f;

        Destroy(newAttack, 1.0f);

        // StartCoroutine(ClearAttack());
        // IEnumerator ClearAttack()
        // {
        //     yield return new WaitForSecondsRealtime(1.0f);
        //     Destroy(attack, 1.0f);
        // }

        animationController.AttackAnimation(1.0f);
    }
}
